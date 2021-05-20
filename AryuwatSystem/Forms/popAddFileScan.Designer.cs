namespace AryuwatSystem.Forms
{
    partial class popAddFileScan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popAddFileScan));
            this.dgvFile = new System.Windows.Forms.DataGridView();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrown = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxAddNew = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddFile = new AryuwatSystem.UserControls.ButtonAdd();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFile
            // 
            this.dgvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFile.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvFile.BackgroundColor = System.Drawing.Color.White;
            this.dgvFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFile.Location = new System.Drawing.Point(0, 31);
            this.dgvFile.Name = "dgvFile";
            //this.dgvFile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvFile.RowTemplate.ReadOnly = true;
            this.dgvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFile.Size = new System.Drawing.Size(839, 234);
            this.dgvFile.TabIndex = 295;
            this.dgvFile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFile_CellClick);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(453, 5);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(283, 20);
            this.txtFileName.TabIndex = 294;
            this.txtFileName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFileName_MouseClick);
            // 
            // btnBrown
            // 
            this.btnBrown.Location = new System.Drawing.Point(348, 4);
            this.btnBrown.Name = "btnBrown";
            this.btnBrown.Size = new System.Drawing.Size(34, 23);
            this.btnBrown.TabIndex = 292;
            this.btnBrown.Text = "...";
            this.btnBrown.UseVisualStyleBackColor = true;
            this.btnBrown.Click += new System.EventHandler(this.btnBrown_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(10, 5);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(337, 20);
            this.txtFilePath.TabIndex = 291;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(390, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 16);
            this.label14.TabIndex = 290;
            this.label14.Text = "คำอธิบาย";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CustomIcon.png");
            this.imageList1.Images.SetKeyName(1, "doctor_write_128_EeI_icon.ico");
            this.imageList1.Images.SetKeyName(2, "x_256.png");
            this.imageList1.Images.SetKeyName(3, "TN_psd1084_Red.png");
            this.imageList1.Images.SetKeyName(4, "remove_icon.png");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxAddNew);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 70);
            this.panel1.TabIndex = 296;
            // 
            // pictureBoxAddNew
            // 
            this.pictureBoxAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAddNew.Image = global::AryuwatSystem.Properties.Resources.new_folder_image;
            this.pictureBoxAddNew.Location = new System.Drawing.Point(453, 3);
            this.pictureBoxAddNew.Name = "pictureBoxAddNew";
            this.pictureBoxAddNew.Size = new System.Drawing.Size(115, 67);
            this.pictureBoxAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAddNew.TabIndex = 299;
            this.pictureBoxAddNew.TabStop = false;
            this.pictureBoxAddNew.Visible = false;
            this.pictureBoxAddNew.Click += new System.EventHandler(this.pictureBoxAddNew_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::AryuwatSystem.Properties.Resources._118947_save_512x512;
            this.pictureBox1.Location = new System.Drawing.Point(674, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 298;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(133, 28);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 271;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(23, 28);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 270;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFileName);
            this.panel2.Controls.Add(this.btnAddFile);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.btnBrown);
            this.panel2.Controls.Add(this.txtFilePath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 31);
            this.panel2.TabIndex = 297;
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFile.Location = new System.Drawing.Point(742, 3);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(26, 26);
            this.btnAddFile.TabIndex = 293;
            this.btnAddFile.BtnClick += new AryuwatSystem.UserControls.ButtonAdd.ButtonClick(this.btnAddFile_BtnClick_1);
            // 
            // popAddFileScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 335);
            this.Controls.Add(this.dgvFile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "popAddFileScan";
            this.Text = "popAddFileScan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.popAddFileScan_FormClosing);
            this.Load += new System.EventHandler(this.popAddFileScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrown;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label14;
        private UserControls.ButtonAdd btnAddFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxAddNew;
    }
}