namespace EntropyForms
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comptext = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comp = new System.Windows.Forms.TextBox();
            this.uncomp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.red = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comptext
            // 
            this.comptext.Location = new System.Drawing.Point(12, 12);
            this.comptext.Name = "comptext";
            this.comptext.Size = new System.Drawing.Size(438, 426);
            this.comptext.TabIndex = 8;
            this.comptext.Text = "";
            this.comptext.TextChanged += new System.EventHandler(this.comptext_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(468, 238);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(137, 185);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // comp
            // 
            this.comp.Location = new System.Drawing.Point(468, 46);
            this.comp.Name = "comp";
            this.comp.Size = new System.Drawing.Size(100, 20);
            this.comp.TabIndex = 9;
            this.comp.TextChanged += new System.EventHandler(this.comp_TextChanged);
            // 
            // uncomp
            // 
            this.uncomp.Location = new System.Drawing.Point(468, 124);
            this.uncomp.Name = "uncomp";
            this.uncomp.Size = new System.Drawing.Size(100, 20);
            this.uncomp.TabIndex = 10;
            this.uncomp.TextChanged += new System.EventHandler(this.uncomp_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Compressed length";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Uncompressed Length";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(637, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(412, 426);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(490, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "extract";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // red
            // 
            this.red.AutoSize = true;
            this.red.Location = new System.Drawing.Point(468, 84);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(0, 13);
            this.red.TabIndex = 16;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 450);
            this.Controls.Add(this.red);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uncomp);
            this.Controls.Add(this.comp);
            this.Controls.Add(this.comptext);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox comptext;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox comp;
        private System.Windows.Forms.TextBox uncomp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label red;
    }
}