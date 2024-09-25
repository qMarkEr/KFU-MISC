namespace EntropyForms
{
    partial class Form2
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
            this.comp = new System.Windows.Forms.TextBox();
            this.uncomp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dlenc = new System.Windows.Forms.Label();
            this.dlenunc = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // comptext
            // 
            this.comptext.Location = new System.Drawing.Point(12, 12);
            this.comptext.Name = "comptext";
            this.comptext.Size = new System.Drawing.Size(396, 426);
            this.comptext.TabIndex = 0;
            this.comptext.Text = "";
            this.comptext.TextChanged += new System.EventHandler(this.comptext_TextChanged);
            // 
            // comp
            // 
            this.comp.Location = new System.Drawing.Point(466, 49);
            this.comp.Name = "comp";
            this.comp.Size = new System.Drawing.Size(100, 20);
            this.comp.TabIndex = 1;
            // 
            // uncomp
            // 
            this.uncomp.Location = new System.Drawing.Point(466, 127);
            this.uncomp.Name = "uncomp";
            this.uncomp.Size = new System.Drawing.Size(100, 20);
            this.uncomp.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Compressed length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Uncompressed length";
            // 
            // dlenc
            // 
            this.dlenc.AutoSize = true;
            this.dlenc.Location = new System.Drawing.Point(466, 72);
            this.dlenc.Name = "dlenc";
            this.dlenc.Size = new System.Drawing.Size(0, 13);
            this.dlenc.TabIndex = 5;
            // 
            // dlenunc
            // 
            this.dlenunc.AutoSize = true;
            this.dlenunc.Location = new System.Drawing.Point(466, 166);
            this.dlenunc.Name = "dlenunc";
            this.dlenunc.Size = new System.Drawing.Size(0, 13);
            this.dlenunc.TabIndex = 6;
            // 
            // code
            // 
            this.code.AutoSize = true;
            this.code.Location = new System.Drawing.Point(466, 225);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(0, 13);
            this.code.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(469, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Extract";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(632, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(418, 426);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.code);
            this.Controls.Add(this.dlenunc);
            this.Controls.Add(this.dlenc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uncomp);
            this.Controls.Add(this.comp);
            this.Controls.Add(this.comptext);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox comptext;
        private System.Windows.Forms.TextBox comp;
        private System.Windows.Forms.TextBox uncomp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dlenc;
        private System.Windows.Forms.Label dlenunc;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}