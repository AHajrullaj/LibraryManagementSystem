namespace Bibloteka.forms
{
    partial class Menaxheri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menaxheri));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.teTjeraMenaxherControl11 = new Bibloteka.controllers.teTjeraMenaxherControl1();
            this.shfaqLibraMenaxheri1 = new Bibloteka.controllers.shfaqLibraMenaxheri();
            this.shtoLiberMenaxher1 = new Bibloteka.controllers.ShtoLiberMenaxher();
            this.shfaqPunMenaxheri1 = new Bibloteka.controllers.ShfaqPunMenaxheri();
            this.shtoPunonjesNgaMenaxheri1 = new Bibloteka.controllers.ShtoPunonjesNgaMenaxheri();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(36)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 104);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(763, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Log out";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 598);
            this.panel2.TabIndex = 3;
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
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(-1, 297);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(175, 46);
            this.button7.TabIndex = 0;
            this.button7.Text = "Te tjera";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 245);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(174, 46);
            this.button6.TabIndex = 0;
            this.button6.Text = "Listo Libra";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(-1, 193);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(175, 46);
            this.button5.TabIndex = 0;
            this.button5.Text = "Shto nje liber te ri";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-1, 141);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 46);
            this.button4.TabIndex = 0;
            this.button4.Text = "Listo punonjes te biblotekes";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-1, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 46);
            this.button3.TabIndex = 0;
            this.button3.Text = "Shto punonjes ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // teTjeraMenaxherControl11
            // 
            this.teTjeraMenaxherControl11.Location = new System.Drawing.Point(162, 104);
            this.teTjeraMenaxherControl11.Name = "teTjeraMenaxherControl11";
            this.teTjeraMenaxherControl11.Size = new System.Drawing.Size(759, 586);
            this.teTjeraMenaxherControl11.TabIndex = 4;
            // 
            // shfaqLibraMenaxheri1
            // 
            this.shfaqLibraMenaxheri1.Location = new System.Drawing.Point(162, 104);
            this.shfaqLibraMenaxheri1.Name = "shfaqLibraMenaxheri1";
            this.shfaqLibraMenaxheri1.Size = new System.Drawing.Size(763, 586);
            this.shfaqLibraMenaxheri1.TabIndex = 5;
            // 
            // shtoLiberMenaxher1
            // 
            this.shtoLiberMenaxher1.Location = new System.Drawing.Point(162, 104);
            this.shtoLiberMenaxher1.Name = "shtoLiberMenaxher1";
            this.shtoLiberMenaxher1.Size = new System.Drawing.Size(759, 586);
            this.shtoLiberMenaxher1.TabIndex = 6;
            // 
            // shfaqPunMenaxheri1
            // 
            this.shfaqPunMenaxheri1.Location = new System.Drawing.Point(162, 121);
            this.shfaqPunMenaxheri1.Name = "shfaqPunMenaxheri1";
            this.shfaqPunMenaxheri1.Size = new System.Drawing.Size(759, 455);
            this.shfaqPunMenaxheri1.TabIndex = 7;
            // 
            // shtoPunonjesNgaMenaxheri1
            // 
            this.shtoPunonjesNgaMenaxheri1.Location = new System.Drawing.Point(162, 104);
            this.shtoPunonjesNgaMenaxheri1.Name = "shtoPunonjesNgaMenaxheri1";
            this.shtoPunonjesNgaMenaxheri1.Size = new System.Drawing.Size(759, 543);
            this.shtoPunonjesNgaMenaxheri1.TabIndex = 8;
            // 
            // Menaxheri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 702);
            this.Controls.Add(this.shtoPunonjesNgaMenaxheri1);
            this.Controls.Add(this.shfaqPunMenaxheri1);
            this.Controls.Add(this.shtoLiberMenaxher1);
            this.Controls.Add(this.shfaqLibraMenaxheri1);
            this.Controls.Add(this.teTjeraMenaxherControl11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Menaxheri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menaxheri";
            this.Load += new System.EventHandler(this.Menaxheri_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private controllers.teTjeraMenaxherControl1 teTjeraMenaxherControl11;
        private controllers.shfaqLibraMenaxheri shfaqLibraMenaxheri1;
        private controllers.ShtoLiberMenaxher shtoLiberMenaxher1;
        private controllers.ShfaqPunMenaxheri shfaqPunMenaxheri1;
        private controllers.ShtoPunonjesNgaMenaxheri shtoPunonjesNgaMenaxheri1;
    }
}