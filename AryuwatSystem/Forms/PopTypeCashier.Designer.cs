namespace AryuwatSystem.Forms
{
    partial class PopTypeCashier
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
            this.btnGeneralCust = new System.Windows.Forms.Button();
            this.btnSurgicalFee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGeneralCust
            // 
            this.btnGeneralCust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneralCust.Font = new System.Drawing.Font("Tahoma", 30F);
            this.btnGeneralCust.Image = global::AryuwatSystem.Properties.Resources.customers_next_256;
            this.btnGeneralCust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneralCust.Location = new System.Drawing.Point(15, 17);
            this.btnGeneralCust.Name = "btnGeneralCust";
            this.btnGeneralCust.Size = new System.Drawing.Size(519, 108);
            this.btnGeneralCust.TabIndex = 0;
            this.btnGeneralCust.Text = "Summary of Treatment";
            this.btnGeneralCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneralCust.UseVisualStyleBackColor = true;
            this.btnGeneralCust.Click += new System.EventHandler(this.btnNormalUser_Click);
            // 
            // btnSurgicalFee
            // 
            this.btnSurgicalFee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSurgicalFee.Font = new System.Drawing.Font("Tahoma", 30F);
            this.btnSurgicalFee.Image = global::AryuwatSystem.Properties.Resources.our_customers_star_256;
            this.btnSurgicalFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSurgicalFee.Location = new System.Drawing.Point(15, 133);
            this.btnSurgicalFee.Name = "btnSurgicalFee";
            this.btnSurgicalFee.Size = new System.Drawing.Size(519, 92);
            this.btnSurgicalFee.TabIndex = 1;
            this.btnSurgicalFee.Text = "Surgical Fee";
            this.btnSurgicalFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSurgicalFee.UseVisualStyleBackColor = true;
            this.btnSurgicalFee.Click += new System.EventHandler(this.btnSurgicalFee_Click);
            // 
            // PopTypeCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 236);
            this.Controls.Add(this.btnSurgicalFee);
            this.Controls.Add(this.btnGeneralCust);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopTypeCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier Forms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGeneralCust;
        private System.Windows.Forms.Button btnSurgicalFee;
    }
}