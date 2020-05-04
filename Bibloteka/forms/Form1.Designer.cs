namespace Bibloteka
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mainUserControl11 = new Bibloteka.MainUserControl1();
            this.klasiketControl11 = new Bibloteka.KlasiketControl1();
            this.elektronikControl11 = new Bibloteka.controllers.ElektronikControl1();
            this.fizikControl11 = new Bibloteka.controllers.FizikControl1();
            this.kimiControl11 = new Bibloteka.controllers.KimiControl1();
            this.matematikControl11 = new Bibloteka.controllers.MatematikControl1();
            this.teknologjiControl11 = new Bibloteka.controllers.TeknologjiControl1();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(36)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 100);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(761, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Biblioteka";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 529);
            this.panel2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(-1, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 48);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kategorit";
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(-8, 349);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(175, 46);
            this.button9.TabIndex = 0;
            this.button9.Text = "Teknologji";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(-1, 297);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(175, 46);
            this.button7.TabIndex = 0;
            this.button7.Text = "Matematike";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(-8, 245);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(174, 46);
            this.button6.TabIndex = 0;
            this.button6.Text = "Kimi";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(-1, 193);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(175, 46);
            this.button5.TabIndex = 0;
            this.button5.Text = "Fizik";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(-1, 141);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 46);
            this.button4.TabIndex = 0;
            this.button4.Text = "Elektronik";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(0, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 46);
            this.button3.TabIndex = 0;
            this.button3.Text = "Biologji";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mainUserControl11);
            this.panel3.Controls.Add(this.klasiketControl11);
            this.panel3.Controls.Add(this.elektronikControl11);
            this.panel3.Controls.Add(this.fizikControl11);
            this.panel3.Controls.Add(this.kimiControl11);
            this.panel3.Controls.Add(this.matematikControl11);
            this.panel3.Controls.Add(this.teknologjiControl11);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(161, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(771, 529);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // mainUserControl11
            // 
            this.mainUserControl11.Location = new System.Drawing.Point(0, 0);
            this.mainUserControl11.Name = "mainUserControl11";
            this.mainUserControl11.Size = new System.Drawing.Size(770, 492);
            this.mainUserControl11.TabIndex = 13;
            this.mainUserControl11.Load += new System.EventHandler(this.mainUserControl11_Load_2);
            // 
            // klasiketControl11
            // 
            this.klasiketControl11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.klasiketControl11.Location = new System.Drawing.Point(0, 0);
            this.klasiketControl11.Name = "klasiketControl11";
            this.klasiketControl11.Size = new System.Drawing.Size(760, 492);
            this.klasiketControl11.TabIndex = 12;
            // 
            // elektronikControl11
            // 
            this.elektronikControl11.Location = new System.Drawing.Point(0, 0);
            this.elektronikControl11.Name = "elektronikControl11";
            this.elektronikControl11.Size = new System.Drawing.Size(760, 492);
            this.elektronikControl11.TabIndex = 11;
            // 
            // fizikControl11
            // 
            this.fizikControl11.Location = new System.Drawing.Point(0, 0);
            this.fizikControl11.Name = "fizikControl11";
            this.fizikControl11.Size = new System.Drawing.Size(760, 492);
            this.fizikControl11.TabIndex = 10;
            // 
            // kimiControl11
            // 
            this.kimiControl11.Location = new System.Drawing.Point(0, 0);
            this.kimiControl11.Name = "kimiControl11";
            this.kimiControl11.Size = new System.Drawing.Size(760, 492);
            this.kimiControl11.TabIndex = 9;
            // 
            // matematikControl11
            // 
            this.matematikControl11.Location = new System.Drawing.Point(0, 0);
            this.matematikControl11.Name = "matematikControl11";
            this.matematikControl11.Size = new System.Drawing.Size(760, 484);
            this.matematikControl11.TabIndex = 8;
            // 
            // teknologjiControl11
            // 
            this.teknologjiControl11.Location = new System.Drawing.Point(0, 0);
            this.teknologjiControl11.Name = "teknologjiControl11";
            this.teknologjiControl11.Size = new System.Drawing.Size(760, 484);
            this.teknologjiControl11.TabIndex = 7;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(313, 498);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(98, 28);
            this.button8.TabIndex = 6;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(932, 629);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private MainUserControl1 mainUserControl11;
        private KlasiketControl1 klasiketControl11;
        private controllers.ElektronikControl1 elektronikControl11;
        private controllers.FizikControl1 fizikControl11;
        private controllers.KimiControl1 kimiControl11;
        private controllers.MatematikControl1 matematikControl11;
        private controllers.TeknologjiControl1 teknologjiControl11;
    }
}

