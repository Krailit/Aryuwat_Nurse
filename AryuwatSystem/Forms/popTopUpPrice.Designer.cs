namespace AryuwatSystem.Forms
{
    partial class popTopUpPrice
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
            this.btnOK = new System.Windows.Forms.Button();
            this.radioButtonPrice = new System.Windows.Forms.RadioButton();
            this.radioButtonPriceTopup = new System.Windows.Forms.RadioButton();
            this.label1Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Location = new System.Drawing.Point(384, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 38);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // radioButtonPrice
            // 
            this.radioButtonPrice.AutoSize = true;
            this.radioButtonPrice.Checked = true;
            this.radioButtonPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPrice.Location = new System.Drawing.Point(99, 48);
            this.radioButtonPrice.Name = "radioButtonPrice";
            this.radioButtonPrice.Size = new System.Drawing.Size(107, 29);
            this.radioButtonPrice.TabIndex = 3;
            this.radioButtonPrice.TabStop = true;
            this.radioButtonPrice.Text = "ราคาเต็ม";
            this.radioButtonPrice.UseVisualStyleBackColor = true;
            this.radioButtonPrice.Click += new System.EventHandler(this.radioButtonPrice_Click);
            // 
            // radioButtonPriceTopup
            // 
            this.radioButtonPriceTopup.AutoSize = true;
            this.radioButtonPriceTopup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPriceTopup.Location = new System.Drawing.Point(99, 83);
            this.radioButtonPriceTopup.Name = "radioButtonPriceTopup";
            this.radioButtonPriceTopup.Size = new System.Drawing.Size(138, 29);
            this.radioButtonPriceTopup.TabIndex = 4;
            this.radioButtonPriceTopup.Text = "ราคาลด 5%";
            this.radioButtonPriceTopup.UseVisualStyleBackColor = true;
            this.radioButtonPriceTopup.Click += new System.EventHandler(this.radioButtonPriceTopup_Click);
            // 
            // label1Name
            // 
            this.label1Name.AutoSize = true;
            this.label1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1Name.Location = new System.Drawing.Point(12, 9);
            this.label1Name.Name = "label1Name";
            this.label1Name.Size = new System.Drawing.Size(60, 24);
            this.label1Name.TabIndex = 6;
            this.label1Name.Text = "label1";
            // 
            // popTopUpPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 173);
            this.Controls.Add(this.label1Name);
            this.Controls.Add(this.radioButtonPriceTopup);
            this.Controls.Add(this.radioButtonPrice);
            this.Controls.Add(this.btnOK);
            this.Name = "popTopUpPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "popTopUpPrice";
            this.Load += new System.EventHandler(this.popTopUpPrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton radioButtonPrice;
        private System.Windows.Forms.RadioButton radioButtonPriceTopup;
        private System.Windows.Forms.Label label1Name;
    }
}