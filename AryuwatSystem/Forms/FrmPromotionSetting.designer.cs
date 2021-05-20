using System.Windows.Forms;
using AryuwatSystem.UserControls;
using System.ComponentModel;
using System.Drawing;
using System;
using AryuwatSystem.Properties;
namespace AryuwatSystem.Forms
{
    partial class FrmPromotionSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPromotionSetting));
            this.FrmMedicalOrderSetting_Fill_Panel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelList = new System.Windows.Forms.Panel();
            this.panelProductList = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAesthetic = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtFindAes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvAestheticList = new System.Windows.Forms.DataGridView();
            this.tabSurgery = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvSurgeryList = new System.Windows.Forms.DataGridView();
            this.txtFindSurgery = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabWellness_Antiaging = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvWellness_AntiagingList = new System.Windows.Forms.DataGridView();
            this.txtWellness_Antiaging = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPharmacy = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvPharmacyList = new System.Windows.Forms.DataGridView();
            this.txtFindPharmacy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAttachFile = new System.Windows.Forms.TabPage();
            this.dgvFile = new System.Windows.Forms.DataGridView();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAddFile = new AryuwatSystem.UserControls.ButtonAdd();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAddDown = new AryuwatSystem.UserControls.ButtonRigth();
            this.buttonDeleteUp = new AryuwatSystem.UserControls.ButtonLeft();
            this.panelName = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.cboSurgicalFeeTyp = new System.Windows.Forms.ComboBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPro_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPro_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxRefreshProduct = new System.Windows.Forms.PictureBox();
            this.panelGridSelect = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSelectList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.collapsibleSplitter1 = new AryuwatSystem.UserControls.CollapsibleSplitter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FrmMedicalOrderSetting_Fill_Panel.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelProductList.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAesthetic.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAestheticList)).BeginInit();
            this.tabSurgery.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeryList)).BeginInit();
            this.tabWellness_Antiaging.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellness_AntiagingList)).BeginInit();
            this.tabPharmacy.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPharmacyList)).BeginInit();
            this.tabAttachFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).BeginInit();
            this.panel4.SuspendLayout();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefreshProduct)).BeginInit();
            this.panelGridSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrmMedicalOrderSetting_Fill_Panel
            // 
            this.FrmMedicalOrderSetting_Fill_Panel.Controls.Add(this.splitter1);
            this.FrmMedicalOrderSetting_Fill_Panel.Controls.Add(this.panelList);
            this.FrmMedicalOrderSetting_Fill_Panel.Controls.Add(this.panelGridSelect);
            this.FrmMedicalOrderSetting_Fill_Panel.Controls.Add(this.collapsibleSplitter1);
            this.FrmMedicalOrderSetting_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmMedicalOrderSetting_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FrmMedicalOrderSetting_Fill_Panel.Name = "FrmMedicalOrderSetting_Fill_Panel";
            this.FrmMedicalOrderSetting_Fill_Panel.Size = new System.Drawing.Size(1280, 599);
            this.FrmMedicalOrderSetting_Fill_Panel.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 303);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1280, 3);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.panelProductList);
            this.panelList.Controls.Add(this.panelName);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(1280, 306);
            this.panelList.TabIndex = 4;
            // 
            // panelProductList
            // 
            this.panelProductList.Controls.Add(this.tabControl);
            this.panelProductList.Controls.Add(this.panel4);
            this.panelProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductList.Location = new System.Drawing.Point(0, 67);
            this.panelProductList.Name = "panelProductList";
            this.panelProductList.Size = new System.Drawing.Size(1280, 239);
            this.panelProductList.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAesthetic);
            this.tabControl.Controls.Add(this.tabSurgery);
            this.tabControl.Controls.Add(this.tabWellness_Antiaging);
            this.tabControl.Controls.Add(this.tabPharmacy);
            this.tabControl.Controls.Add(this.tabAttachFile);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1280, 205);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabAesthetic
            // 
            this.tabAesthetic.Controls.Add(this.panel10);
            this.tabAesthetic.Location = new System.Drawing.Point(4, 25);
            this.tabAesthetic.Name = "tabAesthetic";
            this.tabAesthetic.Size = new System.Drawing.Size(1272, 176);
            this.tabAesthetic.TabIndex = 5;
            this.tabAesthetic.Text = "AESTHETIC";
            this.tabAesthetic.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtFindAes);
            this.panel10.Controls.Add(this.label11);
            this.panel10.Controls.Add(this.dgvAestheticList);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1272, 176);
            this.panel10.TabIndex = 151;
            // 
            // txtFindAes
            // 
            this.txtFindAes.Location = new System.Drawing.Point(53, 4);
            this.txtFindAes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindAes.Name = "txtFindAes";
            this.txtFindAes.Size = new System.Drawing.Size(241, 23);
            this.txtFindAes.TabIndex = 143;
            this.txtFindAes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindAes_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 142;
            this.label11.Text = "Find :";
            // 
            // dgvAestheticList
            // 
            this.dgvAestheticList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAestheticList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAestheticList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvAestheticList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAestheticList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAestheticList.Location = new System.Drawing.Point(9, 34);
            this.dgvAestheticList.Name = "dgvAestheticList";
            this.dgvAestheticList.RowTemplate.ReadOnly = true;
            this.dgvAestheticList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAestheticList.Size = new System.Drawing.Size(1261, 142);
            this.dgvAestheticList.TabIndex = 148;
            this.dgvAestheticList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAestheticList_CellContentClick);
            this.dgvAestheticList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvAestheticList_RowPostPaint);
            // 
            // tabSurgery
            // 
            this.tabSurgery.Controls.Add(this.panel9);
            this.tabSurgery.Location = new System.Drawing.Point(4, 25);
            this.tabSurgery.Name = "tabSurgery";
            this.tabSurgery.Size = new System.Drawing.Size(1272, 176);
            this.tabSurgery.TabIndex = 3;
            this.tabSurgery.Text = "SURGERY";
            this.tabSurgery.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dgvSurgeryList);
            this.panel9.Controls.Add(this.txtFindSurgery);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1272, 176);
            this.panel9.TabIndex = 151;
            // 
            // dgvSurgeryList
            // 
            this.dgvSurgeryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSurgeryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSurgeryList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSurgeryList.BackgroundColor = System.Drawing.Color.White;
            this.dgvSurgeryList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSurgeryList.Location = new System.Drawing.Point(9, 34);
            this.dgvSurgeryList.Name = "dgvSurgeryList";
            //this.dgvSurgeryList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvSurgeryList.RowTemplate.ReadOnly = true;
            this.dgvSurgeryList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSurgeryList.Size = new System.Drawing.Size(1255, 155);
            this.dgvSurgeryList.TabIndex = 148;
            this.dgvSurgeryList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurgeryList_CellContentClick);
            this.dgvSurgeryList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSurgeryList_RowPostPaint);
            // 
            // txtFindSurgery
            // 
            this.txtFindSurgery.Location = new System.Drawing.Point(53, 4);
            this.txtFindSurgery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindSurgery.Name = "txtFindSurgery";
            this.txtFindSurgery.Size = new System.Drawing.Size(241, 23);
            this.txtFindSurgery.TabIndex = 143;
            this.txtFindSurgery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindSurgery_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 142;
            this.label7.Text = "Find :";
            // 
            // tabWellness_Antiaging
            // 
            this.tabWellness_Antiaging.Controls.Add(this.panel3);
            this.tabWellness_Antiaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWellness_Antiaging.Location = new System.Drawing.Point(4, 25);
            this.tabWellness_Antiaging.Margin = new System.Windows.Forms.Padding(0);
            this.tabWellness_Antiaging.Name = "tabWellness_Antiaging";
            this.tabWellness_Antiaging.Size = new System.Drawing.Size(1272, 176);
            this.tabWellness_Antiaging.TabIndex = 8;
            this.tabWellness_Antiaging.Text = "Wellness & AntiAging";
            this.tabWellness_Antiaging.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvWellness_AntiagingList);
            this.panel3.Controls.Add(this.txtWellness_Antiaging);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1272, 176);
            this.panel3.TabIndex = 151;
            // 
            // dgvWellness_AntiagingList
            // 
            this.dgvWellness_AntiagingList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWellness_AntiagingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWellness_AntiagingList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvWellness_AntiagingList.BackgroundColor = System.Drawing.Color.White;
            this.dgvWellness_AntiagingList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvWellness_AntiagingList.Location = new System.Drawing.Point(9, 34);
            this.dgvWellness_AntiagingList.Name = "dgvWellness_AntiagingList";
            //this.dgvWellness_AntiagingList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvWellness_AntiagingList.RowTemplate.ReadOnly = true;
            this.dgvWellness_AntiagingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWellness_AntiagingList.Size = new System.Drawing.Size(1263, 155);
            this.dgvWellness_AntiagingList.TabIndex = 148;
            this.dgvWellness_AntiagingList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWellness_AntiagingList_CellContentClick);
            this.dgvWellness_AntiagingList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvWellness_AntiagingList_RowPostPaint);
            // 
            // txtWellness_Antiaging
            // 
            this.txtWellness_Antiaging.Location = new System.Drawing.Point(53, 4);
            this.txtWellness_Antiaging.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWellness_Antiaging.Name = "txtWellness_Antiaging";
            this.txtWellness_Antiaging.Size = new System.Drawing.Size(241, 23);
            this.txtWellness_Antiaging.TabIndex = 143;
            this.txtWellness_Antiaging.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtWellness_Antiaging_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 142;
            this.label12.Text = "Find :";
            // 
            // tabPharmacy
            // 
            this.tabPharmacy.Controls.Add(this.panel6);
            this.tabPharmacy.Location = new System.Drawing.Point(4, 25);
            this.tabPharmacy.Name = "tabPharmacy";
            this.tabPharmacy.Size = new System.Drawing.Size(1272, 176);
            this.tabPharmacy.TabIndex = 2;
            this.tabPharmacy.Text = "Pharmacy & Product";
            this.tabPharmacy.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvPharmacyList);
            this.panel6.Controls.Add(this.txtFindPharmacy);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1272, 176);
            this.panel6.TabIndex = 151;
            // 
            // dgvPharmacyList
            // 
            this.dgvPharmacyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPharmacyList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPharmacyList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPharmacyList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPharmacyList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPharmacyList.Location = new System.Drawing.Point(9, 34);
            this.dgvPharmacyList.Name = "dgvPharmacyList";
            //this.dgvPharmacyList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvPharmacyList.RowTemplate.ReadOnly = true;
            this.dgvPharmacyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPharmacyList.Size = new System.Drawing.Size(1255, 155);
            this.dgvPharmacyList.TabIndex = 148;
            this.dgvPharmacyList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPharmacyList_CellContentClick);
            this.dgvPharmacyList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPharmacyList_RowPostPaint);
            // 
            // txtFindPharmacy
            // 
            this.txtFindPharmacy.Location = new System.Drawing.Point(53, 4);
            this.txtFindPharmacy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindPharmacy.Name = "txtFindPharmacy";
            this.txtFindPharmacy.Size = new System.Drawing.Size(241, 23);
            this.txtFindPharmacy.TabIndex = 143;
            this.txtFindPharmacy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindPharmacy_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 142;
            this.label1.Text = "Find :";
            // 
            // tabAttachFile
            // 
            this.tabAttachFile.Controls.Add(this.dgvFile);
            this.tabAttachFile.Controls.Add(this.txtFileName);
            this.tabAttachFile.Controls.Add(this.button2);
            this.tabAttachFile.Controls.Add(this.txtFilePath);
            this.tabAttachFile.Controls.Add(this.label14);
            this.tabAttachFile.Controls.Add(this.btnAddFile);
            this.tabAttachFile.Location = new System.Drawing.Point(4, 25);
            this.tabAttachFile.Name = "tabAttachFile";
            this.tabAttachFile.Size = new System.Drawing.Size(1272, 176);
            this.tabAttachFile.TabIndex = 7;
            this.tabAttachFile.Text = "ATTACH FILE";
            this.tabAttachFile.UseVisualStyleBackColor = true;
            // 
            // dgvFile
            // 
            this.dgvFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFile.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvFile.BackgroundColor = System.Drawing.Color.White;
            this.dgvFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFile.Location = new System.Drawing.Point(9, 57);
            this.dgvFile.Name = "dgvFile";
            //this.dgvFile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvFile.RowTemplate.ReadOnly = true;
            this.dgvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFile.Size = new System.Drawing.Size(1092, 496);
            this.dgvFile.TabIndex = 289;
            this.dgvFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFile_CellContentClick);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(540, 28);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(283, 23);
            this.txtFileName.TabIndex = 288;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(437, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 23);
            this.button2.TabIndex = 285;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(9, 28);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(423, 23);
            this.txtFilePath.TabIndex = 284;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(477, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 16);
            this.label14.TabIndex = 142;
            this.label14.Text = "ชื่อไฟล์ :";
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFile.Location = new System.Drawing.Point(829, 26);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(26, 26);
            this.btnAddFile.TabIndex = 286;
            this.btnAddFile.BtnClick += new AryuwatSystem.UserControls.ButtonAdd.ButtonClick(this.btnAddFile_BtnClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.buttonAddDown);
            this.panel4.Controls.Add(this.buttonDeleteUp);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 205);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1280, 34);
            this.panel4.TabIndex = 4;
            // 
            // buttonAddDown
            // 
            this.buttonAddDown.Location = new System.Drawing.Point(616, 5);
            this.buttonAddDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonAddDown.Name = "buttonAddDown";
            this.buttonAddDown.Size = new System.Drawing.Size(30, 26);
            this.buttonAddDown.TabIndex = 146;
            this.buttonAddDown.BtnClick += new AryuwatSystem.UserControls.ButtonRigth.ButtonClick(this.buttonAddDown_BtnClick);
            // 
            // buttonDeleteUp
            // 
            this.buttonDeleteUp.Location = new System.Drawing.Point(582, 5);
            this.buttonDeleteUp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonDeleteUp.Name = "buttonDeleteUp";
            this.buttonDeleteUp.Size = new System.Drawing.Size(30, 26);
            this.buttonDeleteUp.TabIndex = 147;
            this.buttonDeleteUp.BtnClick += new AryuwatSystem.UserControls.ButtonLeft.ButtonClick(this.buttonDeleteUp_BtnClick);
            // 
            // panelName
            // 
            this.panelName.Controls.Add(this.label15);
            this.panelName.Controls.Add(this.cboSurgicalFeeTyp);
            this.panelName.Controls.Add(this.checkBoxActive);
            this.panelName.Controls.Add(this.label10);
            this.panelName.Controls.Add(this.dateTimePickerStart);
            this.panelName.Controls.Add(this.label6);
            this.panelName.Controls.Add(this.txtPro_Name);
            this.panelName.Controls.Add(this.label5);
            this.panelName.Controls.Add(this.txtPro_Code);
            this.panelName.Controls.Add(this.label3);
            this.panelName.Controls.Add(this.dateTimePickerEnd);
            this.panelName.Controls.Add(this.pictureBoxRefreshProduct);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(1280, 67);
            this.panelName.TabIndex = 145;
            this.panelName.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(940, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 23);
            this.label15.TabIndex = 321;
            this.label15.Text = "แผนก";
            // 
            // cboSurgicalFeeTyp
            // 
            this.cboSurgicalFeeTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSurgicalFeeTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboSurgicalFeeTyp.FormattingEnabled = true;
            this.cboSurgicalFeeTyp.Location = new System.Drawing.Point(936, 33);
            this.cboSurgicalFeeTyp.Name = "cboSurgicalFeeTyp";
            this.cboSurgicalFeeTyp.Size = new System.Drawing.Size(159, 24);
            this.cboSurgicalFeeTyp.TabIndex = 320;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.checkBoxActive.Location = new System.Drawing.Point(834, 22);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(79, 23);
            this.checkBoxActive.TabIndex = 315;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(609, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 16);
            this.label10.TabIndex = 314;
            this.label10.Text = "Date Start :";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(695, 7);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerStart.TabIndex = 313;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(426, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 23);
            this.label6.TabIndex = 312;
            this.label6.Text = "Code";
            // 
            // txtPro_Name
            // 
            this.txtPro_Name.BackColor = System.Drawing.Color.Black;
            this.txtPro_Name.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPro_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPro_Name.Location = new System.Drawing.Point(12, 27);
            this.txtPro_Name.Name = "txtPro_Name";
            this.txtPro_Name.Size = new System.Drawing.Size(408, 27);
            this.txtPro_Name.TabIndex = 311;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(7, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 23);
            this.label5.TabIndex = 310;
            this.label5.Text = "ชื่อโปรโมชัน/Promotion name";
            // 
            // txtPro_Code
            // 
            this.txtPro_Code.BackColor = System.Drawing.Color.Black;
            this.txtPro_Code.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPro_Code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPro_Code.Location = new System.Drawing.Point(426, 27);
            this.txtPro_Code.Name = "txtPro_Code";
            this.txtPro_Code.Size = new System.Drawing.Size(154, 27);
            this.txtPro_Code.TabIndex = 155;
            this.txtPro_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(604, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 151;
            this.label3.Text = "Date Expire :";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(695, 31);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowUpDown = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerEnd.TabIndex = 150;
            // 
            // pictureBoxRefreshProduct
            // 
            this.pictureBoxRefreshProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRefreshProduct.Image = global::AryuwatSystem.Properties.Resources.pharmacy_2561;
            this.pictureBoxRefreshProduct.Location = new System.Drawing.Point(1233, 6);
            this.pictureBoxRefreshProduct.Name = "pictureBoxRefreshProduct";
            this.pictureBoxRefreshProduct.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxRefreshProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRefreshProduct.TabIndex = 149;
            this.pictureBoxRefreshProduct.TabStop = false;
            this.pictureBoxRefreshProduct.Click += new System.EventHandler(this.pictureBoxRefreshProduct_Click);
            this.pictureBoxRefreshProduct.MouseHover += new System.EventHandler(this.pictureBoxRefreshProduct_MouseHover);
            // 
            // panelGridSelect
            // 
            this.panelGridSelect.Controls.Add(this.groupBox1);
            this.panelGridSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGridSelect.Location = new System.Drawing.Point(0, 306);
            this.panelGridSelect.Name = "panelGridSelect";
            this.panelGridSelect.Size = new System.Drawing.Size(1280, 293);
            this.panelGridSelect.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewSelectList);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1280, 293);
            this.groupBox1.TabIndex = 151;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายการที่เลือก :";
            // 
            // dataGridViewSelectList
            // 
            this.dataGridViewSelectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewSelectList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSelectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSelectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelectList.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewSelectList.Name = "dataGridViewSelectList";
            this.dataGridViewSelectList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewSelectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectList.Size = new System.Drawing.Size(1274, 191);
            this.dataGridViewSelectList.TabIndex = 150;
            this.dataGridViewSelectList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewSelectList_CellBeginEdit);
            this.dataGridViewSelectList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellEndEdit);
            this.dataGridViewSelectList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewSelectList_DataError);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTotalPrice);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtProPrice);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 210);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 80);
            this.panel1.TabIndex = 151;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Location = new System.Drawing.Point(636, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 41);
            this.label9.TabIndex = 276;
            this.label9.Text = "หมายเหตุ Remark";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BackColor = System.Drawing.Color.Black;
            this.txtTotalPrice.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalPrice.Location = new System.Drawing.Point(354, 3);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(150, 36);
            this.txtTotalPrice.TabIndex = 274;
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(715, 17);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(302, 57);
            this.txtRemark.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(503, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 27);
            this.label2.TabIndex = 275;
            this.label2.Text = "บาท/THB.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(122, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 27);
            this.label8.TabIndex = 272;
            this.label8.Text = "ราคาเต็ม/Total Price";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1156, 43);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 31);
            this.btnCancel.TabIndex = 269;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1041, 43);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 31);
            this.btnSave.TabIndex = 267;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtProPrice
            // 
            this.txtProPrice.BackColor = System.Drawing.Color.Black;
            this.txtProPrice.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtProPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtProPrice.Location = new System.Drawing.Point(354, 41);
            this.txtProPrice.Name = "txtProPrice";
            this.txtProPrice.ReadOnly = true;
            this.txtProPrice.Size = new System.Drawing.Size(150, 36);
            this.txtProPrice.TabIndex = 271;
            this.txtProPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(503, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 27);
            this.label13.TabIndex = 270;
            this.label13.Text = "บาท/THB.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 27);
            this.label4.TabIndex = 270;
            this.label4.Text = "ราคาโปรโมชัน/Promotion Price";
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.collapsibleSplitter1.ControlToHide = null;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(153, 0);
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.TabIndex = 3;
            this.collapsibleSplitter1.TabStop = false;
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.Visible = false;
            this.collapsibleSplitter1.VisualStyle = AryuwatSystem.UserControls.VisualStyles.Mozilla;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CustomIcon.png");
            this.imageList1.Images.SetKeyName(1, "TN_psd1084_Red.png");
            this.imageList1.Images.SetKeyName(2, "remove_icon.png");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmPromotionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 599);
            this.Controls.Add(this.FrmMedicalOrderSetting_Fill_Panel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "FrmPromotionSetting";
            this.Text = "Promotion Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPromotionSetting_FormClosing);
            this.Load += new System.EventHandler(this.FrmPromotionSetting_Load);
            this.FrmMedicalOrderSetting_Fill_Panel.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelProductList.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabAesthetic.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAestheticList)).EndInit();
            this.tabSurgery.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeryList)).EndInit();
            this.tabWellness_Antiaging.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellness_AntiagingList)).EndInit();
            this.tabPharmacy.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPharmacyList)).EndInit();
            this.tabAttachFile.ResumeLayout(false);
            this.tabAttachFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefreshProduct)).EndInit();
            this.panelGridSelect.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FrmMedicalOrderSetting_Fill_Panel;
        private System.Windows.Forms.Panel panelList;
        private UserControls.CollapsibleSplitter collapsibleSplitter1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPharmacy;
        private System.Windows.Forms.TabPage tabSurgery;
        private System.Windows.Forms.Panel panelProductList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvPharmacyList;
        private UserControls.ButtonRigth buttonAddDown;
        private System.Windows.Forms.TextBox txtFindPharmacy;
        private UserControls.ButtonLeft buttonDeleteUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabAesthetic;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dgvAestheticList;
        private System.Windows.Forms.TextBox txtFindAes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvSurgeryList;
        private System.Windows.Forms.TextBox txtFindSurgery;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.TabPage tabAttachFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private UserControls.ButtonAdd btnAddFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.DataGridView dgvFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabPage tabWellness_Antiaging;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvWellness_AntiagingList;
        private System.Windows.Forms.TextBox txtWellness_Antiaging;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelGridSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtProPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridViewSelectList;
        private System.Windows.Forms.PictureBox pictureBoxRefreshProduct;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtPro_Code;
        private Label label10;
        private DateTimePicker dateTimePickerStart;
        private Label label6;
        internal TextBox txtPro_Name;
        private Label label5;
        private Label label2;
        private TextBox txtTotalPrice;
        private Label label8;
        private CheckBox checkBoxActive;
        private Label label9;
        private TextBox txtRemark;
        private Splitter splitter1;
        private Label label15;
        private ComboBox cboSurgicalFeeTyp;


    }
}