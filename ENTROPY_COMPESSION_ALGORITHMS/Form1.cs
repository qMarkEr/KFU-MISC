using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Text;

namespace EntropyForms
{


    public partial class Form1 : Form
    {
        private int ImageIndex = 0;
        private SortedDictionary<char, double> CharProb = new SortedDictionary<char, double>();
        private Dictionary<String, int> dictionary = new Dictionary<String, int>();
        public List<Bitmap> ExtractedImages;
        public Form1()
        {
            InitializeComponent();
            ExtractedImages = new List<Bitmap>();
        }

        private double[] GetCharProb(string Text)
        {
            
            foreach (var item in Text)
            {
                if (CharProb.ContainsKey(item))
                    CharProb[item] += 1;
                else
                    CharProb[item] = 1;
            }

            var res = CharProb.Values.ToArray();
            for (int i = 0; i < res.Length; i++)
                res[i] /= Text.Length;

            TextHistogram(CharProb);
            return res;
        }
        
        private void TextHistogram(SortedDictionary<char, double> CharProb)
        {
            chart1.Series[0].Points.Clear();
            foreach (var item in CharProb)
                chart1.Series[0].Points.AddXY(item.Key.ToString(), item.Value);

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }
        private void ImageHistogram(double[][] RGB, double[] Luminance)
        {
            ImageHist.Series[0].Points.DataBindY(RGB[0]);
            ImageHist.Series[0].Color = Color.FromArgb(64, Color.Red);
            ImageHist.Series[1].Points.DataBindY(RGB[1]);
            ImageHist.Series[1].Color = Color.FromArgb(64, Color.Green);
            ImageHist.Series[2].Points.DataBindY(RGB[2]);
            ImageHist.Series[2].Color = Color.FromArgb(64, Color.Blue);
            ImageHist.Series[3].Points.DataBindY(Luminance);
            ImageHist.Series[3].Color = Color.Black;

           //ImageHist.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = false;
            //ImageHist.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = false;
            //ImageHist.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            //ImageHist.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }
        private double[] GetPixelLuminance(Bitmap img)
        {
            double[] probs = new double[256];
            double[][] RGB = new double[3][];
            RGB[0] = new double[256];
            RGB[1] = new double[256];
            RGB[2] = new double[256];
            for (int i = 0; i < img.Width; ++i)
            {
                for (int j = 0; j < img.Height; ++j)
                {
                    Color c = img.GetPixel(i, j);
                    int index = (int)Math.Round(0.2126 * c.R + 0.7152 * c.G + 0.0722 * c.B);
                    probs[index] += 1;
                    RGB[0][c.R] += 1;
                    RGB[1][c.G] += 1;
                    RGB[2][c.B] += 1;
                }
            }

            for (int i = 0; i < probs.Length; i++)
            {
                probs[i] /= (img.Width * img.Height);
                RGB[0][i] /= (img.Width * img.Height);
                RGB[1][i] /= (img.Width * img.Height);
                RGB[2][i] /= (img.Width * img.Height);
            }

            ImageHistogram(RGB, probs);
            return probs;
        }
        private void ExtractText(OpenFileDialog fileDialog)
        {
            XDocument bookText = XDocument.Load(fileDialog.FileName);
            XNamespace ns = "http://www.gribuser.ru/xml/fictionbook/2.0";

            var body = bookText.Root.Element(ns + "body");

            if (body != null)
                ExtractedText.Text = body.Value;
            else
                ExtractedText.Text = "File does not contains <body>.";
        }
        private void ExtractImages(OpenFileDialog fileDialog)
        {
            XmlDocument bookImages = new XmlDocument();
            bookImages.Load(fileDialog.FileName);
            XmlNodeList pictureNodes = bookImages.GetElementsByTagName("binary");

            foreach (XmlNode pictureNode in pictureNodes)
            {
                string base64ImageData = pictureNode.InnerText;
                byte[] imageBytes = Convert.FromBase64String(base64ImageData);

                Bitmap bmp;
                using (var ms = new MemoryStream(imageBytes))
                    bmp = new Bitmap(ms);

                ExtractedImages.Add(bmp);
            }
        }
        private double CalculateEntropy(double[] probs)
        {
            double H = 0;
            foreach (var item in probs)
                if (item != 0)
                    H -= item * Math.Log(item, 2);

            return H;
        }
        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text files | *.fb2";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExtractText(fileDialog);
                    ExtractImages(fileDialog);
                    ImageProcess();
                    Left.Enabled = ExtractedImages.Count != 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File read error");
                }
            }
        }
        private void ImageProcess()
        {
            var bmpx = ExtractedImages[ImageIndex];
            Img.SizeMode = PictureBoxSizeMode.Zoom;
            Img.Image = bmpx;
            double[] PixelProbabilities = GetPixelLuminance(bmpx);
            double H = CalculateEntropy(PixelProbabilities);
            ImageEntropyValue.Text = String.Format("Entropy: {0}", H * bmpx.Width * bmpx.Height);
            ImageNum.Text = String.Format("{0} / {1}", ImageIndex + 1, ExtractedImages.Count);
        }
        private void Left_Click(object sender, EventArgs e)
        {
            if (ImageIndex + 1 < ExtractedImages.Count)
            {
                ++ImageIndex;
                ImageProcess();
                (sender as Button).Enabled = !(ImageIndex + 1 == ExtractedImages.Count);
            }
            Right.Enabled = ImageIndex > 0;
            
        }
        private void Right_Click(object sender, EventArgs e)
        {
            if (ImageIndex - 1 >= 0)
            {
                --ImageIndex;
                ImageProcess();
                (sender as Button).Enabled = !(ImageIndex - 1 == -1);
            }
            Left.Enabled = ImageIndex < ExtractedImages.Count;
        }
        private void ExtractedText_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is System.Windows.Forms.RichTextBox)) return;
            if ((sender as System.Windows.Forms.RichTextBox).Text.Length == 0) return;

            var CharProbabilitis = GetCharProb(ExtractedText.Text);
            double H = CalculateEntropy(CharProbabilitis);

            TextEntropyValue.Text = String.Format("Entropy: {0}", 
                H * (sender as System.Windows.Forms.RichTextBox).Text.Length);
            dictionary.Clear();
        }
        private List<int> Compress(string text)
        {
            int dictSize = CharProb.Count;
            
            int i = 0;
            foreach (char c in CharProb.Keys)
                dictionary[c.ToString()] = i++;

            String foundChars = "";
            List<int> result = new List<int>();
            foreach (char character in text) {
                String charsToAdd = foundChars + character;
                if (dictionary.ContainsKey(charsToAdd.ToString()))
                    foundChars = charsToAdd;
                else
                {
                    result.Add(dictionary[foundChars]);
                    dictionary[charsToAdd] = dictSize++; 
                    foundChars = character.ToString();
                }
            }
            if (String.IsNullOrEmpty(foundChars))
                result.Add(dictionary[foundChars]);
            
            return result;
        }
        private void compr_Click(object sender, EventArgs e)
        {
            string text = ExtractedText.Text;
            var code = Compress(text);
            StringBuilder compressed = new StringBuilder();
            foreach (var character in code)
                compressed.Append(String.Format($"{character} "));
            
            Form2 x = new Form2(compressed.ToString(), dictionary, text.Length, code.Count, dictionary.Count(), CharProb.Count());
            x.Show();
        }

        class Node
        {
            public char symbol;
            public int frequency;
            public Node left;
            public Node right;
            public Node(char symbol, int frequency)
            {
                this.symbol = symbol;
                this.frequency = frequency;
            }
            public Node(Node left, Node right)
            {
                this.left = left;
                this.right = right;
            }
        }

        static Node BuildHuffmanTree(string message)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();

            foreach (char symbol in message)
            {
                if (frequencies.ContainsKey(symbol))
                    frequencies[symbol]++;
                else
                    frequencies[symbol] = 1;
            }

            List<Node> nodes = new List<Node>();

            foreach (KeyValuePair<char, int> pair in frequencies)
            {
                Node node = new Node(pair.Key, pair.Value);
                nodes.Add(node);
            }

            while (nodes.Count > 1)
            {
                nodes.Sort((n1, n2) => n1.frequency - n2.frequency);

                Node left = nodes[0];
                Node right = nodes[1];

                Node parent = new Node(left, right);
                parent.frequency = left.frequency + right.frequency;

                nodes.RemoveRange(0, 2);
                nodes.Add(parent);
            }
            return nodes[0];
        }

        static Dictionary<char, string> GetCodes(Node root)
        {
            Dictionary<char, string> codes = new Dictionary<char, string>();

            TraverseTree(root, string.Empty, codes);

            return codes;
        }

        static void TraverseTree(Node node, string code, Dictionary<char, string> codes)
        {
            if (node.left == null && node.right == null)
            {
                codes[node.symbol] = code;
                return;
            }

            TraverseTree(node.left, code + "0", codes);
            TraverseTree(node.right, code + "1", codes);
        }

        public string Encode(string data, Dictionary<char, string> codes)
        {
            var output = new StringBuilder();

            foreach (var character in data)
                output.Append(codes[character] + " ");

            return output.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = ExtractedText.Text;

            var tree = BuildHuffmanTree(text);
            Dictionary<char, string> ns = GetCodes(tree);
            int len_c = 0;
            int len_unc = text.Length;
            foreach (var character in text)
                len_c += ns[character].Length;
            
            string newtext = Encode(text, ns);
            Form3 x = new Form3(newtext, ns, len_c / 8, len_unc);
            x.Show();
        }
    }
}

