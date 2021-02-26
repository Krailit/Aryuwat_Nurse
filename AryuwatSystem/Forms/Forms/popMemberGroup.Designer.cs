namespace DermasterSystem.Forms
{
    partial class popMemberGroup
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
            this.buttonAddDown = new DermasterSystem.UserControls.ButtonRigth();
            this.buttonDeleteUp = new DermasterSystem.UserControls.ButtonLeft();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new DermasterSystem.UserControls.ButtonRigth();
            this.buttonDelete = new DermasterSystem.UserControls.ButtonLeft();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddDown
            // 
            this.buttonAddDown.Location = new System.Drawing.Point(283, 13);
            this.buttonAddDown.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.buttonAddDown.Name = "buttonAddDown";
            this.buttonAddDown.Size = new System.Drawing.Size(30, 26);
            this.buttonAddDown.TabIndex = 151;
            // 
            // buttonDeleteUp
            // 
            this.buttonDeleteUp.Location = new System.Drawing.Point(243, 13);
            this.buttonDeleteUp.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.buttonDeleteUp.Name = "buttonDeleteUp";
            this.buttonDeleteUp.Size = new System.Drawing.Size(30, 26);
            this.buttonDeleteUp.TabIndex = 152;
            // 
            // dgvMember
            // 
            this.dgvMember.AllowUserToAddRows = false;
            this.dgvMember.AllowUserToDeleteRows = false;
            this.dgvMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMember.BackgroundColor = System.Drawing.Color.White;
            this.dgvMember.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMember.Location = new System.Drawing.Point(0, 0);
            this.dgvMember.MultiSelect = false;
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvMember.RowTemplate.ReadOnly = true;
            this.dgvMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMember.Size = new System.Drawing.Size(550, 423);
            this.dgvMember.TabIndex = 150;
            this.dgvMember.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMember_CellContentClick);
            this.dgvMember.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMember_RowPostPaint);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(202, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 153;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 56);
            this.panel1.TabIndex = 154;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(283, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 154;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(52, 18);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(30, 26);
            this.buttonAdd.TabIndex = 155;
            this.buttonAdd.BtnClick += new DermasterSystem.UserControls.ButtonRigth.ButtonClick(this.buttonAdd_BtnClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 18);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(30, 26);
            this.buttonDelete.TabIndex = 156;
            this.buttonDelete.BtnClick += new DermasterSystem.UserControls.ButtonLeft.ButtonClick(this.buttonDelete_BtnClick);
            // 
            // popMemberGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 479);
            this.ControlBox = false;
            this.Controls.Add(this.dgvMember);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAddDown);
            this.Controls.Add(this.buttonDeleteUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "popMemberGroup";
            this.Text = "Group Members";
            this.Load += new System.EventHandler(this.popMemberGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ButtonRigth buttonAddDown;
        private UserControls.ButtonLeft buttonDeleteUp;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private UserControls.ButtonRigth buttonAdd;
        private UserControls.ButtonLeft buttonDelete;
    }
}