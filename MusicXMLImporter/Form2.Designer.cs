namespace WindowsFormsApplication1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.InstSet = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.M64File = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(60, 100);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Instrument Set";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // InstSet
            // 
            this.InstSet.FormattingEnabled = true;
            this.InstSet.Items.AddRange(new object[] {
            "NInst00 (SFX)",
            "NInst01 (SFX)",
            "NInst02 (SFX)",
            "NInst03 (SFX)",
            "NInst04 (SFX)",
            "NInst05 (SFX)",
            "NInst06 (SFX)",
            "NInst07 (SFX)",
            "NInst08 (SFX)",
            "NInst09 (SFX?)",
            "NInst10",
            "NInst11 (Snow)",
            "NInst12 (Unused)",
            "NInst13 (Koopa-The-Quick)",
            "NInst14 (Inside Castle)",
            "NInst15",
            "NInst16",
            "NInst17 (Title screen)",
            "NInst18",
            "NInst19",
            "NInst20",
            "NInst21",
            "NInst22",
            "NInst23",
            "NInst24",
            "NInst25",
            "NInst26",
            "NInst27",
            "NInst28",
            "NInst29",
            "NInst30",
            "NInst31",
            "NInst32",
            "NInst33",
            "NInst34",
            "NInst35",
            "NInst36",
            "NInst37"});
            this.InstSet.Location = new System.Drawing.Point(188, 98);
            this.InstSet.Name = "InstSet";
            this.InstSet.Size = new System.Drawing.Size(191, 21);
            this.InstSet.TabIndex = 99;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "NInst00 (SFX)",
            "NInst01 (SFX)",
            "NInst02 (SFX)",
            "NInst03 (SFX)",
            "NInst04 (SFX)",
            "NInst05 (SFX)",
            "NInst06 (SFX)",
            "NInst07 (SFX)",
            "NInst08 (SFX)",
            "NInst09 (SFX?)",
            "NInst10",
            "NInst11 (Snow)",
            "NInst12 (Unused)",
            "NInst13 (Koopa-The-Quick)",
            "NInst14 (Inside Castle)",
            "NInst15",
            "NInst16",
            "NInst17 (Title screen)",
            "NInst18",
            "NInst19",
            "NInst20",
            "NInst21",
            "NInst22",
            "NInst23",
            "NInst24",
            "NInst25",
            "NInst26",
            "NInst27",
            "NInst28",
            "NInst29",
            "NInst30",
            "NInst31",
            "NInst32",
            "NInst33",
            "NInst34",
            "NInst35",
            "NInst36",
            "NInst37"});
            this.comboBox1.Location = new System.Drawing.Point(188, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 21);
            this.comboBox1.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Sequence to replace";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Explanation";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(52, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 27);
            this.button3.TabIndex = 103;
            this.button3.Text = "Load .m64 file";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // M64File
            // 
            this.M64File.BackColor = System.Drawing.SystemColors.Control;
            this.M64File.Location = new System.Drawing.Point(177, 24);
            this.M64File.Name = "M64File";
            this.M64File.ReadOnly = true;
            this.M64File.Size = new System.Drawing.Size(330, 20);
            this.M64File.TabIndex = 104;
            this.M64File.TextChanged += new System.EventHandler(this.M64File_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 218);
            this.Controls.Add(this.M64File);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.InstSet);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox InstSet;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox M64File;
    }
}