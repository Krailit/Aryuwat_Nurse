namespace AryuwatSystem.Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdExit = new System.Windows.Forms.PictureBox();
            this.cmdLogin = new System.Windows.Forms.PictureBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cmdExit);
            this.groupBox1.Controls.Add(this.cmdLogin);
            this.groupBox1.Controls.Add(this.txtPassWord);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.PictureBox1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 310);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Angsana New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(206, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 37);
            this.label2.TabIndex = 92;
            this.label2.Text = "รหัสผ่าน :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(184, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 147);
            this.panel1.TabIndex = 85;
            // 
            // cmdExit
            // 
            this.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExit.Image = global::AryuwatSystem.Properties.Resources.x_256;
            this.cmdExit.Location = new System.Drawing.Point(338, 246);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(48, 45);
            this.cmdExit.TabIndex = 79;
            this.cmdExit.TabStop = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            this.cmdExit.MouseLeave += new System.EventHandler(this.cmdExit_MouseLeave);
            this.cmdExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdExit_MouseMove);
            // 
            // cmdLogin
            // 
            this.cmdLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdLogin.Image = global::AryuwatSystem.Properties.Resources.ok_256;
            this.cmdLogin.Location = new System.Drawing.Point(284, 246);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(48, 45);
            this.cmdLogin.TabIndex = 78;
            this.cmdLogin.TabStop = false;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            this.cmdLogin.MouseLeave += new System.EventHandler(this.cmdLogin_MouseLeave);
            this.cmdLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdLogin_MouseMove);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPassWord.Location = new System.Drawing.Point(296, 208);
            this.txtPassWord.MaxLength = 50;
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '~';
            this.txtPassWord.Size = new System.Drawing.Size(215, 29);
            this.txtPassWord.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUsername.Location = new System.Drawing.Point(296, 174);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(215, 29);
            this.txtUsername.TabIndex = 0;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(50, 154);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(119, 115);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 84;
            this.PictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(184, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(108, 36);
            this.panel2.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Angsana New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(-2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 37);
            this.label1.TabIndex = 91;
            this.label1.Text = "รหัสผู้ใช้งาน :";
            // 
            // PictureBox3
            // 
            this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox3.Location = new System.Drawing.Point(10, 310);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(617, 57);
            this.PictureBox3.TabIndex = 85;
            this.PictureBox3.TabStop = false;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label6.ForeColor = System.Drawing.Color.DimGray;
            this.Label6.Location = new System.Drawing.Point(104, 337);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(200, 27);
            this.Label6.TabIndex = 91;
            this.Label6.Text = "เข้าสู่ระบบด้วยรหัสใช้งานและรหัสผ่าน ";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label5.ForeColor = System.Drawing.Color.DimGray;
            this.Label5.Location = new System.Drawing.Point(82, 315);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(74, 21);
            this.Label5.TabIndex = 90;
            this.Label5.Text = "เข้าสู่ระบบ";
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(34, 315);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(45, 43);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 89;
            this.PictureBox2.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(638, 372);
            this.ControlBox = false;
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmLogin";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmLogin_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmLogin_PreviewKeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox cmdExit;
        private System.Windows.Forms.PictureBox cmdLogin;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
    }
}