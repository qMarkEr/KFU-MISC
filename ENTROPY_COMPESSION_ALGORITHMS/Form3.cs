using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntropyForms
{
    public partial class Form3 : Form
    {
        Dictionary<char, string> dict;
        public Form3(string text, Dictionary<char, string> dic, int lenc, int lenunc)
        {
            InitializeComponent();
            comptext.Text = text;
            dict = dic;
            foreach (char c in dic.Keys)
                richTextBox1.Text += String.Format($"{c} - {dic[c]}\n");
            comp.Text = lenc.ToString();
            uncomp.Text = lenunc.ToString();
            red.Text = (lenunc -  lenc).ToString();
        }

        private void comptext_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void uncomp_TextChanged(object sender, EventArgs e)
        {

        }

        private void comp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string raw = comptext.Text.Trim();
            var codes = raw.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (string code in codes)
                sb.Append(GetKey(code, dict));
            richTextBox2.Text = sb.ToString();
        }

        private char GetKey(string code, Dictionary<char, string> d)
        {
            foreach (var item in d)
                if (item.Value == code)
                    return item.Key;
            return Char.MinValue;
        }
    }
}
