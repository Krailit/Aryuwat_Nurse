using Cyotek.Windows.Forms;
namespace AryuwatSystem.Forms
{
    partial class SwitchImageDuringZoomDemoForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitchImageDuringZoomDemoForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cursorToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mapNameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageBox = new Cyotek.Windows.Forms.ImageBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.resetMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshMapTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPreviosB = new System.Windows.Forms.Button();
            this.btnNextB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFolderB = new System.Windows.Forms.Button();
            this.labelBFileName = new System.Windows.Forms.Label();
            this.txtBPath = new System.Windows.Forms.TextBox();
            this.btnPreviosA = new System.Windows.Forms.Button();
            this.btnNextA = new System.Windows.Forms.Button();
            this.imageBox1 = new Cyotek.Windows.Forms.ImageBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFolderA = new System.Windows.Forms.Button();
            this.txtAPath = new System.Windows.Forms.TextBox();
            this.labelAFilename = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1192, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.cursorToolStripStatusLabel,
            this.zoomToolStripStatusLabel,
            this.mapNameToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 576);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1192, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Visible = false;
            // 
            // statusToolStripStatusLabel
            // 
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new System.Drawing.Size(1140, 17);
            this.statusToolStripStatusLabel.Spring = true;
            this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusToolStripStatusLabel.Visible = false;
            // 
            // cursorToolStripStatusLabel
            // 
            this.cursorToolStripStatusLabel.Name = "cursorToolStripStatusLabel";
            this.cursorToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.cursorToolStripStatusLabel.ToolTipText = "Current Cursor Position";
            // 
            // zoomToolStripStatusLabel
            // 
            this.zoomToolStripStatusLabel.Name = "zoomToolStripStatusLabel";
            this.zoomToolStripStatusLabel.Size = new System.Drawing.Size(35, 17);
            this.zoomToolStripStatusLabel.Text = "100%";
            this.zoomToolStripStatusLabel.ToolTipText = "Zoom";
            this.zoomToolStripStatusLabel.Visible = false;
            // 
            // mapNameToolStripStatusLabel
            // 
            this.mapNameToolStripStatusLabel.Name = "mapNameToolStripStatusLabel";
            this.mapNameToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.mapNameToolStripStatusLabel.ToolTipText = "Zoom";
            // 
            // imageBox
            // 
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.Image = ((System.Drawing.Image)(resources.GetObject("imageBox.Image")));
            this.imageBox.Location = new System.Drawing.Point(0, 24);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(593, 550);
            this.imageBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Stretch;
            this.imageBox.TabIndex = 12;
            this.imageBox.Zoom = 30;
            this.imageBox.ZoomChanged += new System.EventHandler(this.imageBox_ZoomChanged);
            this.imageBox.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.imageBox_Zoomed);
            this.imageBox.MouseLeave += new System.EventHandler(this.imageBox_MouseLeave);
            this.imageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox_MouseMove);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoEllipsis = true;
            this.messageLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.messageLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.messageLabel.Location = new System.Drawing.Point(0, 574);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(1192, 24);
            this.messageLabel.TabIndex = 13;
            this.messageLabel.Text = resources.GetString("messageLabel.Text");
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetMessageTimer
            // 
            this.resetMessageTimer.Interval = 5000;
            this.resetMessageTimer.Tick += new System.EventHandler(this.resetMessageTimer_Tick);
            // 
            // refreshMapTimer
            // 
            this.refreshMapTimer.Interval = 5;
            this.refreshMapTimer.Tick += new System.EventHandler(this.refreshMapTimer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnPreviosB);
            this.splitContainer1.Panel1.Controls.Add(this.btnNextB);
            this.splitContainer1.Panel1.Controls.Add(this.imageBox);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPreviosA);
            this.splitContainer1.Panel2.Controls.Add(this.btnNextA);
            this.splitContainer1.Panel2.Controls.Add(this.imageBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1192, 574);
            this.splitContainer1.SplitterDistance = 593;
            this.splitContainer1.TabIndex = 14;
            // 
            // btnPreviosB
            // 
            this.btnPreviosB.Location = new System.Drawing.Point(3, 36);
            this.btnPreviosB.Name = "btnPreviosB";
            this.btnPreviosB.Size = new System.Drawing.Size(60, 23);
            this.btnPreviosB.TabIndex = 17;
            this.btnPreviosB.Text = "Previos";
            this.btnPreviosB.UseVisualStyleBackColor = true;
            this.btnPreviosB.Click += new System.EventHandler(this.btnPreviosB_Click);
            // 
            // btnNextB
            // 
            this.btnNextB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextB.Location = new System.Drawing.Point(514, 36);
            this.btnNextB.Name = "btnNextB";
            this.btnNextB.Size = new System.Drawing.Size(60, 23);
            this.btnNextB.TabIndex = 16;
            this.btnNextB.Text = "Next";
            this.btnNextB.UseVisualStyleBackColor = true;
            this.btnNextB.Click += new System.EventHandler(this.btnNextB_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFolderB);
            this.panel1.Controls.Add(this.labelBFileName);
            this.panel1.Controls.Add(this.txtBPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 24);
            this.panel1.TabIndex = 13;
            // 
            // btnFolderB
            // 
            this.btnFolderB.Location = new System.Drawing.Point(556, 4);
            this.btnFolderB.Name = "btnFolderB";
            this.btnFolderB.Size = new System.Drawing.Size(27, 25);
            this.btnFolderB.TabIndex = 2;
            this.btnFolderB.Text = "...";
            this.btnFolderB.UseVisualStyleBackColor = true;
            this.btnFolderB.Visible = false;
            // 
            // labelBFileName
            // 
            this.labelBFileName.AutoSize = true;
            this.labelBFileName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBFileName.Location = new System.Drawing.Point(0, 0);
            this.labelBFileName.Name = "labelBFileName";
            this.labelBFileName.Size = new System.Drawing.Size(41, 15);
            this.labelBFileName.TabIndex = 1;
            this.labelBFileName.Text = "Before";
            // 
            // txtBPath
            // 
            this.txtBPath.Location = new System.Drawing.Point(491, 5);
            this.txtBPath.Name = "txtBPath";
            this.txtBPath.Size = new System.Drawing.Size(67, 23);
            this.txtBPath.TabIndex = 0;
            this.txtBPath.Visible = false;
            // 
            // btnPreviosA
            // 
            this.btnPreviosA.Location = new System.Drawing.Point(3, 36);
            this.btnPreviosA.Name = "btnPreviosA";
            this.btnPreviosA.Size = new System.Drawing.Size(60, 23);
            this.btnPreviosA.TabIndex = 19;
            this.btnPreviosA.Text = "Previos";
            this.btnPreviosA.UseVisualStyleBackColor = true;
            this.btnPreviosA.Click += new System.EventHandler(this.btnPreviosA_Click);
            // 
            // btnNextA
            // 
            this.btnNextA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextA.Location = new System.Drawing.Point(517, 36);
            this.btnNextA.Name = "btnNextA";
            this.btnNextA.Size = new System.Drawing.Size(60, 23);
            this.btnNextA.TabIndex = 18;
            this.btnNextA.Text = "Next";
            this.btnNextA.UseVisualStyleBackColor = true;
            this.btnNextA.Click += new System.EventHandler(this.btnNextA_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox1.Image = ((System.Drawing.Image)(resources.GetObject("imageBox1.Image")));
            this.imageBox1.Location = new System.Drawing.Point(0, 24);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(595, 550);
            this.imageBox1.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Stretch;
            this.imageBox1.TabIndex = 13;
            this.imageBox1.Zoom = 30;
            this.imageBox1.ZoomChanged += new System.EventHandler(this.imageBox1_ZoomChanged);
            this.imageBox1.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.imageBox1_Zoomed);
            this.imageBox1.MouseLeave += new System.EventHandler(this.imageBox1_MouseLeave);
            this.imageBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFolderA);
            this.panel2.Controls.Add(this.txtAPath);
            this.panel2.Controls.Add(this.labelAFilename);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 24);
            this.panel2.TabIndex = 14;
            // 
            // btnFolderA
            // 
            this.btnFolderA.Location = new System.Drawing.Point(549, 3);
            this.btnFolderA.Name = "btnFolderA";
            this.btnFolderA.Size = new System.Drawing.Size(27, 25);
            this.btnFolderA.TabIndex = 4;
            this.btnFolderA.Text = "...";
            this.btnFolderA.UseVisualStyleBackColor = true;
            // 
            // txtAPath
            // 
            this.txtAPath.Location = new System.Drawing.Point(376, 4);
            this.txtAPath.Name = "txtAPath";
            this.txtAPath.Size = new System.Drawing.Size(177, 23);
            this.txtAPath.TabIndex = 3;
            // 
            // labelAFilename
            // 
            this.labelAFilename.AutoSize = true;
            this.labelAFilename.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAFilename.Location = new System.Drawing.Point(0, 0);
            this.labelAFilename.Name = "labelAFilename";
            this.labelAFilename.Size = new System.Drawing.Size(33, 15);
            this.labelAFilename.TabIndex = 2;
            this.labelAFilename.Text = "After";
            // 
            // SwitchImageDuringZoomDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 598);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SwitchImageDuringZoomDemoForm";
            this.Text = "Image Compare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip;
    private ImageBox imageBox;
    private System.Windows.Forms.ToolStripStatusLabel zoomToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel mapNameToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel cursorToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.Label messageLabel;
    private System.Windows.Forms.Timer resetMessageTimer;
    private System.Windows.Forms.Timer refreshMapTimer;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private ImageBox imageBox1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnFolderB;
    private System.Windows.Forms.TextBox txtBPath;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnFolderA;
    private System.Windows.Forms.TextBox txtAPath;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.Button btnNextB;
    private System.Windows.Forms.Button btnPreviosB;
    private System.Windows.Forms.Button btnPreviosA;
    private System.Windows.Forms.Button btnNextA;
    private System.Windows.Forms.Label labelBFileName;
    private System.Windows.Forms.Label labelAFilename;
  }
}