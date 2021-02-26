namespace AryuwatSystem.Forms
{
    partial class TextPrompt
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.lblPromptText = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.NumericUpDown();
            this.buttoncancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(202, 14);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 30);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // lblPromptText
            // 
            this.lblPromptText.AutoSize = true;
            this.lblPromptText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPromptText.Location = new System.Drawing.Point(12, 21);
            this.lblPromptText.Name = "lblPromptText";
            this.lblPromptText.Size = new System.Drawing.Size(130, 16);
            this.lblPromptText.TabIndex = 2;
            this.lblPromptText.Text = "Number of copies";
            // 
            // tbText
            // 
            this.tbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbText.Location = new System.Drawing.Point(142, 19);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(41, 22);
            this.tbText.TabIndex = 3;
            this.tbText.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttoncancel
            // 
            this.buttoncancel.Location = new System.Drawing.Point(283, 14);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(75, 30);
            this.buttoncancel.TabIndex = 4;
            this.buttoncancel.Text = "Cancel";
            this.buttoncancel.UseVisualStyleBackColor = true;
            this.buttoncancel.Click += new System.EventHandler(this.buttoncancel_Click);
            // 
            // TextPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 61);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblPromptText);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextPrompt";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TextPrompt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label lblPromptText;
        private System.Windows.Forms.NumericUpDown tbText;
        private System.Windows.Forms.Button buttoncancel;
    }
}