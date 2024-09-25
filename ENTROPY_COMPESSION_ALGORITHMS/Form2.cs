using System;
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
    public partial class Form2 : Form
    {
        Dictionary<string, int> dict;
        string encode;
        public Form2(string codes, Dictionary<string, int> d, int lenunc, int lenc, int lendc, int lendunc)
        {
            InitializeComponent();
            comptext.Text = codes;
            comp.Text = lenc.ToString();
            dict = d;
            encode = codes;
            uncomp.Text = lenunc.ToString();
            dlenc.Text = String.Format($"Dictionary Length: {lendc}");
            dlenunc.Text = String.Format($"Dictionary Length: {lendunc}");
            code.Text = String.Format($"Redundancy: {lenunc - lendc - lendc}");
        }

        private void comptext_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            encode = encode.Trim();
            string[] lst = encode.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (string s in lst)
/*                sb.Append(dict.FirstOrDefault(x => x.Value == Convert.ToInt32(s)).Key);*/
                  sb.Append(GetKey(Convert.ToInt32(s), dict));
            richTextBox1.Text = sb.ToString();
        }
        private string GetKey(int num, Dictionary<string, int> d)
        {
            foreach (var item in d)
                if (item.Value == num)
                    return item.Key;
            return string.Empty;
        }
    }
}
