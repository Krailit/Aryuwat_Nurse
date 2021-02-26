namespace AryuwatSystem.Forms
{
    partial class PopTypeCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopTypeCustomer));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGeneralCust = new System.Windows.Forms.Button();
            this.btnForeignCust = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CustomIcon.png");
            this.imageList1.Images.SetKeyName(1, "EmpIcon.png");
            this.imageList1.Images.SetKeyName(2, "our_customers_star_256.png");
            this.imageList1.Images.SetKeyName(3, "customers_relations_fav_256.png");
            this.imageList1.Images.SetKeyName(4, "agencyIcon.png");
            this.imageList1.Images.SetKeyName(5, "arab-icon.gif");
            this.imageList1.Images.SetKeyName(6, "Asian_female_boss.png");
            // 
            // btnGeneralCust
            // 
            this.btnGeneralCust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneralCust.Font = new System.Drawing.Font("Tahoma", 30F);
            this.btnGeneralCust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneralCust.ImageIndex = 0;
            this.btnGeneralCust.ImageList = this.imageList1;
            this.btnGeneralCust.Location = new System.Drawing.Point(21, 21);
            this.btnGeneralCust.Name = "btnGeneralCust";
            this.btnGeneralCust.Size = new System.Drawing.Size(471, 65);
            this.btnGeneralCust.TabIndex = 0;
            this.btnGeneralCust.Text = "Walk in (คนไทย)CNT";
            this.btnGeneralCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneralCust.UseVisualStyleBackColor = true;
            this.btnGeneralCust.Click += new System.EventHandler(this.btnNormalUser_Click);
            // 
            // btnForeignCust
            // 
            this.btnForeignCust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForeignCust.Font = new System.Drawing.Font("Tahoma", 28F);
            this.btnForeignCust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForeignCust.ImageIndex = 4;
            this.btnForeignCust.ImageList = this.imageList1;
            this.btnForeignCust.Location = new System.Drawing.Point(21, 94);
            this.btnForeignCust.Name = "btnForeignCust";
            this.btnForeignCust.Size = new System.Drawing.Size(471, 65);
            this.btnForeignCust.TabIndex = 1;
            this.btnForeignCust.Text = "Foreign (ต่างชาติ)CNF";
            this.btnForeignCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnForeignCust.UseVisualStyleBackColor = true;
            this.btnForeignCust.Click += new System.EventHandler(this.btnForeignCust_Click);
            // 
            // PopTypeCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 184);
            this.Controls.Add(this.btnForeignCust);
            this.Controls.Add(this.btnGeneralCust);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopTypeCustomer";
            this.ShowIcon = false;
            this.Text = "ประเภทลูกค้า";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGeneralCust;
        private System.Windows.Forms.Button btnForeignCust;
        private System.Windows.Forms.ImageList imageList1;
    }
}