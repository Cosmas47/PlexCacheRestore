namespace PlexPhotoCacheExporter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Input = new Button();
            btn_Export = new Button();
            textBox1 = new TextBox();
            btn_Output = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            sectionDropDown = new ComboBox();
            btn_Cache = new Button();
            textBox4 = new TextBox();
            checkBox4 = new CheckBox();
            SuspendLayout();
            // 
            // btn_Input
            // 
            btn_Input.Location = new Point(256, 21);
            btn_Input.Name = "btn_Input";
            btn_Input.Size = new Size(137, 31);
            btn_Input.TabIndex = 0;
            btn_Input.Text = "SQLITE File";
            btn_Input.UseVisualStyleBackColor = true;
            btn_Input.Click += button1_Click;
            // 
            // btn_Export
            // 
            btn_Export.Location = new Point(247, 328);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new Size(137, 31);
            btn_Export.TabIndex = 1;
            btn_Export.Text = "Export";
            btn_Export.UseVisualStyleBackColor = true;
            btn_Export.Click += btn_Export_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 2;
            // 
            // btn_Output
            // 
            btn_Output.Location = new Point(256, 97);
            btn_Output.Name = "btn_Output";
            btn_Output.Size = new Size(137, 33);
            btn_Output.TabIndex = 3;
            btn_Output.Text = "Output Path";
            btn_Output.UseVisualStyleBackColor = true;
            btn_Output.Click += button3_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 266);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(121, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Database Selected";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(3, 315);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(138, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Output Path Selected";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(3, 340);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(109, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Ready to Export";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 103);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(238, 23);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(96, 210);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(297, 23);
            textBox3.TabIndex = 8;
            textBox3.Text = "png,jpg,jpeg";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 213);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 9;
            label1.Text = "Types to Export";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 185);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 11;
            label2.Text = "Section to Export";
            // 
            // sectionDropDown
            // 
            sectionDropDown.FormattingEnabled = true;
            sectionDropDown.Location = new Point(106, 182);
            sectionDropDown.Name = "sectionDropDown";
            sectionDropDown.Size = new Size(285, 23);
            sectionDropDown.TabIndex = 12;
            // 
            // btn_Cache
            // 
            btn_Cache.Location = new Point(256, 58);
            btn_Cache.Name = "btn_Cache";
            btn_Cache.Size = new Size(137, 33);
            btn_Cache.TabIndex = 13;
            btn_Cache.Text = "Cache Path";
            btn_Cache.UseVisualStyleBackColor = true;
            btn_Cache.Click += btn_Cache_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 64);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(238, 23);
            textBox4.TabIndex = 14;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Enabled = false;
            checkBox4.Location = new Point(3, 291);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(133, 19);
            checkBox4.TabIndex = 15;
            checkBox4.Text = "Cache Path Selected";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 389);
            Controls.Add(checkBox4);
            Controls.Add(textBox4);
            Controls.Add(btn_Cache);
            Controls.Add(sectionDropDown);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(btn_Output);
            Controls.Add(textBox1);
            Controls.Add(btn_Export);
            Controls.Add(btn_Input);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Plex Photo Cache Recovery Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Input;
        private Button btn_Export;
        private TextBox textBox1;
        private Button btn_Output;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private ComboBox sectionDropDown;
        private Button btn_Cache;
        private TextBox textBox4;
        private CheckBox checkBox4;
    }
}
