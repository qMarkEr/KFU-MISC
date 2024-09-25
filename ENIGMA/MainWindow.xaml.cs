using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using NuGet.DependencyResolver;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ENIGMA
{
    public partial class MainWindow : Window
    {
        // окно с настройками
        Settings sets = new Settings();
        // шифровальная машина
        public Enigma machine = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sets.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button letter = (Button)sender;
            // крайнего ротора
            rot1pos.Content = Convert.ToChar((rot1pos.Content.ToString()[0] - 'A' + 1 + 26) % 26 + 'A');
            machine.Rotate(1, 0); // вращение крайнего ротора

            // при достижении выемки поворачивать средний ротор
            if (machine.Rots.Rotors[0].Rotation == machine.Rots.Rotors[0].notch)
            {
                machine.Rotate(1, 1);
                rot2pos.Content = Convert.ToChar((rot2pos.Content.ToString()[0] - 'A' + 1 + 26) % 26 + 'A');
            }
            // при достижении выемки на среднем поворачивать другой крайний ротор
            if (machine.Rots.Rotors[1].Rotation == machine.Rots.Rotors[1].notch)
            {
                machine.Rotate(1, 2);
                rot3pos.Content = Convert.ToChar((rot3pos.Content.ToString()[0] - 'A' + 1 + 26) % 26 + 'A');
            }

            // шиифруем поступивший символ
            char ch = machine.Encrypt(letter.Uid[0]);
            object lamp = FindName(ch.ToString());
            msg.Text += ch;
            // зажигаем лампу с результатом шифрования
            if (lamp is Border)
            {
                Border wantedChild = lamp as Border;
                ColorChange(wantedChild);
            }

        }

        // функция зажигния лампы
        private async void ColorChange(Border lamp)
        {
            lamp.Background = Brushes.Beige;
            await Task.Delay(1000);
            lamp.Background = Brushes.Black;
        }

        // поворот 3го ротора
        private void rot3_Click(object sender, RoutedEventArgs e)
        {
            Button action = (Button)sender;
            int rotation = 0;
            if (action.Name.Contains("up"))
                rotation = 1;

            if (action.Name.Contains("down"))
                rotation = -1;

            rot3pos.Content = Convert.ToChar((rot3pos.Content.ToString()[0] - 'A' + rotation + 26) % 26 + 'A');
            machine.Rotate(rotation, 2);
        }

        // поворот 2го ротора
        private void rot2_Click(object sender, RoutedEventArgs e)
        {
            Button action = (Button)sender;
            int rotation = 0;
            if (action.Name.Contains("up"))
                rotation = 1;

            if (action.Name.Contains("down"))
                rotation = -1;

            rot2pos.Content = Convert.ToChar((rot2pos.Content.ToString()[0] - 'A' + rotation + 26) % 26 + 'A');
            machine.Rotate(rotation, 1);
        }

        // поворот 1го ротора
        private void rot1_Click(object sender, RoutedEventArgs e)
        {
            Button action = (Button)sender;
            int rotation = 0;
            if (action.Name.Contains("up"))
                rotation = 1;

            if (action.Name.Contains("down"))
                rotation = -1;

            rot1pos.Content = Convert.ToChar((rot1pos.Content.ToString()[0] - 'A' + rotation + 26) % 26 + 'A');
            machine.Rotate(rotation, 0);
        }
    }
}
