namespace Japolingo_0._0._1.GUI
{
    partial class Kanji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kanji));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ValorK = new System.Windows.Forms.Label();
            this.ValorO = new System.Windows.Forms.Label();
            this.ValorKu = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Kanjis = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 216);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ayuda";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(257, 216);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kanji";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Onyomi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kunyomi";
            // 
            // ValorK
            // 
            this.ValorK.AutoSize = true;
            this.ValorK.Location = new System.Drawing.Point(178, 27);
            this.ValorK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ValorK.Name = "ValorK";
            this.ValorK.Size = new System.Drawing.Size(0, 13);
            this.ValorK.TabIndex = 5;
            // 
            // ValorO
            // 
            this.ValorO.AutoSize = true;
            this.ValorO.Location = new System.Drawing.Point(311, 62);
            this.ValorO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ValorO.Name = "ValorO";
            this.ValorO.Size = new System.Drawing.Size(0, 13);
            this.ValorO.TabIndex = 6;
            // 
            // ValorKu
            // 
            this.ValorKu.AutoSize = true;
            this.ValorKu.Location = new System.Drawing.Point(311, 86);
            this.ValorKu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ValorKu.Name = "ValorKu";
            this.ValorKu.Size = new System.Drawing.Size(0, 13);
            this.ValorKu.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 19);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 21);
            this.button3.TabIndex = 8;
            this.button3.Text = "Atrás";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Kanjis
            // 
            this.Kanjis.FormattingEnabled = true;
            this.Kanjis.Items.AddRange(new object[] {
            "三",
            "火"});
            this.Kanjis.Location = new System.Drawing.Point(29, 62);
            this.Kanjis.Margin = new System.Windows.Forms.Padding(2);
            this.Kanjis.Name = "Kanjis";
            this.Kanjis.Size = new System.Drawing.Size(70, 134);
            this.Kanjis.TabIndex = 9;
            this.Kanjis.Click += new System.EventHandler(this.Kanjis_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(116, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 130);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // Kanji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 255);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Kanjis);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ValorKu);
            this.Controls.Add(this.ValorO);
            this.Controls.Add(this.ValorK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Kanji";
            this.Text = "Kanji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ValorK;
        private System.Windows.Forms.Label ValorO;
        private System.Windows.Forms.Label ValorKu;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox Kanjis;
        private System.Windows.Forms.Panel panel1;
    }
}