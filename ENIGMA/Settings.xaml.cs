using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ENIGMA
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private const int btnsize = 30; // размер кнопки на панели коммутации
        // провод
        private BezierSegment bezier; 
        private PathFigure figure; 
        private System.Windows.Shapes.Path path;

        // список всех проводов
        private List<System.Windows.Shapes.Path> wires = new();
        // текущее название провода
        private string wire;
        // подключен ли конец првода
        private bool _isDrawing;
        public Button LastClicked { get; set; }
        public Settings()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Cvs.Focus();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            // нажатая кнопка и ее координаты
            Button cur = (Button)sender;
            Point btn1Point = cur.TransformToAncestor(this).Transform(new Point(0, 0));
            Point point1 = new(btn1Point.X + btnsize / 2, btn1Point.Y + btnsize / 2);
            if (_isDrawing)
            {
                // закрепление провода
                foreach (UIElement item in wires)
                {
                    if (item.Uid.Contains(cur.Uid)) return;
                }
                if (LastClicked != cur)
                {
                    wire += cur.Uid;
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).machine.PB.AddWire(wire[0], wire[1]);
                        }
                    }
                    path.Uid = wire;
                    wires.Add(path);

                }
                wire = String.Empty;
                _isDrawing = false;
                LastClicked = null;
                bezier = null;
                return;
            }
            if (cur == LastClicked) { return; } // не соединять одну и ту же кнопку

            figure = new PathFigure();
            figure.StartPoint = point1;
            wire = cur.Uid;
            bool removed = false;
            for (int i = 0; i < wires.Count; i++)
            {
                if (wires[i].Uid.Contains(cur.Uid))
                {
                    foreach (UIElement item in Cvs.Children)
                    {
                        if (item is Button && wires[i].Uid.Contains(item.Uid) && item != cur)
                        {
                            figure.StartPoint = item.TransformToAncestor(this).Transform(new Point(btnsize / 2, btnsize / 2));
                            wire = item.Uid;
                            break;
                        }
                    }

                    // удаление провода
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).machine.PB.RemoveWire(wire[0]);
                        }
                    }
                    Cvs.Children.Remove(wires[i]);
                    wires.RemoveAt(i);
                    
                    removed = true;
                    break;
                }
            }

            _isDrawing = true;

            // создание провода
            var p = new Point(point1.X + 1, point1.Y + 1);
            NewCurve(p);
            figure.Segments.Add(bezier);
            path = new System.Windows.Shapes.Path();
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 4;
            path.Data = new PathGeometry(new PathFigure[] { figure });
            if (!removed)
                LastClicked = cur;
            
            Cvs.Children.Add(path); // добавить провод в список
        }

        // постоянное обновление кривой при вождении курсора по канвасу
        private void MainCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (bezier == null)
                return;

            figure.Segments.Remove(bezier);
            foreach (UIElement item in Cvs.Children)
            {
                bool flag = false;
                if ((item is Button) && item.IsMouseOver)
                {
                    foreach (UIElement sht in wires)
                    {
                        if (sht.Uid.Contains(item.Uid))
                        {
                            Point p1 = e.GetPosition(Cvs);
                            NewCurve(p1);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        Point p = item.TransformToAncestor(Cvs).Transform(new Point(0, 0));
                        p.X += btnsize / 2;
                        p.Y += btnsize / 2;
                        NewCurve(p);
                    }
                    break;
                }
                else
                {
                    Point p = e.GetPosition(Cvs);
                    NewCurve(p);
                }
            }
            figure.Segments.Add(bezier);
        }

        // создание кривой для отображения провода
        private void NewCurve(Point p)
        {
            bezier = new BezierSegment()
            {
                Point1 = new Point(figure.StartPoint.X / 2 + p.X / 2, figure.StartPoint.Y),
                Point2 = new Point(figure.StartPoint.X / 2 + p.X / 2, p.Y),
                Point3 = p
            };
        }

        // закрыть настройки
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        // выбор роторов и рефлектора
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string type = (comboBox.SelectedItem as TextBlock).Text;
            if (comboBox.Name == "rot3") {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).machine.ChangeRotor(type, 2);
                        (window as MainWindow).rot3pos.Content = 'A';
                    }
                }
            }

            if (comboBox.Name == "rot2")
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).machine.ChangeRotor(type, 1);
                        (window as MainWindow).rot2pos.Content = 'A';
                    }
                }
            }

            if (comboBox.Name == "rot1")
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).machine.ChangeRotor(type, 0);
                        (window as MainWindow).rot1pos.Content = 'A';
                    }
                }
            }
            if (comboBox.Name == "ref")
                foreach (Window window in Application.Current.Windows)
                    if (window.GetType() == typeof(MainWindow))
                        (window as MainWindow).machine.ChangeReflector(type);
                    
                
        }

        // поворот кольца 1го ротора
        private void ring1_Click(object sender, RoutedEventArgs e)
        {
            Button action = (Button)sender;
            int rotation = 0;
            if (action.Name.Contains("up"))
                rotation = 1;

            if (action.Name.Contains("down"))
                rotation = -1;

            ring1pos.Content = Convert.ToChar((ring1pos.Content.ToString()[0] - 'A' + rotation + 26) % 26 + 'A');
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).machine.SetRing(rotation, 0);
                }
            }
        }

        // поворот кольца 2го ротора
        private void ring2_Click(object sender, RoutedEventArgs e)
        {
            Button action = (Button)sender;
            int rotation = 0;
            if (action.Name.Contains("up"))
                rotation = 1;

            if (action.Name.Contains("down"))
                rotation = -1;

            ring2pos.Content = Convert.ToChar((ring2pos.Content.ToString()[0] - 'A' + rotation + 26) % 26 + 'A');
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).machine.SetRing(rotation, 1);
                }
            }
        }
        // поворот кольца 3го ротора
        private void ring3_Click(object sender, RoutedEventArgs e)
        {
            Button action = (Button)sender;
            int rotation = 0;
            if (action.Name.Contains("up"))
                rotation = 1;

            if (action.Name.Contains("down"))
                rotation = -1;

            ring3pos.Content = Convert.ToChar((ring3pos.Content.ToString()[0] - 'A' + rotation + 26) % 26 + 'A');
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).machine.SetRing(rotation, 2);
                }
            }
        }
    }
}
