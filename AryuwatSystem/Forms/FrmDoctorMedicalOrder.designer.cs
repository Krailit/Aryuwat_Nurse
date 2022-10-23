using System.Windows.Forms;
using AryuwatSystem.UserControls;
using System.ComponentModel;
using System.Drawing;
using System;
using AryuwatSystem.Properties;
namespace AryuwatSystem.Forms
{
    partial class FrmDoctorMedicalOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoctorMedicalOrder));
            this.FrmDoctorMedicalOrder_Fill_Panel = new System.Windows.Forms.Panel();
            this.panelList = new System.Windows.Forms.Panel();
            this.panelProductList = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtSORefAccount = new System.Windows.Forms.TextBox();
            this.labelSOrefAcc = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAesthetic = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtFindAes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvAestheticList = new System.Windows.Forms.DataGridView();
            this.tabTreatment = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvTreatmentList = new System.Windows.Forms.DataGridView();
            this.txtFindTreatment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSurgery = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvSurgeryList = new System.Windows.Forms.DataGridView();
            this.txtFindSurgery = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabHair = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvHairList = new System.Windows.Forms.DataGridView();
            this.txtFindHair = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabWellness_Antiaging = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvWellness_AntiagingList = new System.Windows.Forms.DataGridView();
            this.txtWellness_Antiaging = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPromotion = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFindPro = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvPromotionList = new System.Windows.Forms.DataGridView();
            this.tabPharmacy = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvPharmacyList = new System.Windows.Forms.DataGridView();
            this.txtFindPharmacy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAttachFile = new System.Windows.Forms.TabPage();
            this.dgvFile = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnAddFile = new AryuwatSystem.UserControls.ButtonAdd();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panelGridSelect = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSelectList = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbProCredit = new System.Windows.Forms.Label();
            this.lbPromotion = new System.Windows.Forms.Label();
            this.buttonAddDown = new AryuwatSystem.UserControls.ButtonRigth();
            this.buttonDeleteUp = new AryuwatSystem.UserControls.ButtonLeft();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNormal = new System.Windows.Forms.TextBox();
            this.labelNormal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label101 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPriceTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelName = new System.Windows.Forms.Panel();
            this.comboBoxByDr = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelKey1 = new System.Windows.Forms.Label();
            this.checkBoxOld = new System.Windows.Forms.CheckBox();
            this.labelCN = new System.Windows.Forms.Label();
            this.radioPRO = new System.Windows.Forms.RadioButton();
            this.radioWE = new System.Windows.Forms.RadioButton();
            this.radioSU = new System.Windows.Forms.RadioButton();
            this.radioAE = new System.Windows.Forms.RadioButton();
            this.radioButtonSO = new System.Windows.Forms.RadioButton();
            this.radioButtonMO = new System.Windows.Forms.RadioButton();
            this.txtMO = new System.Windows.Forms.TextBox();
            this.txtSoRef = new System.Windows.Forms.TextBox();
            this.comboBoxCommission1 = new System.Windows.Forms.ComboBox();
            this.comboBoxCommission2 = new System.Windows.Forms.ComboBox();
            this.txtSONo = new System.Windows.Forms.TextBox();
            this.btnRunning = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerCreate = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxRefreshProduct = new System.Windows.Forms.PictureBox();
            this.txtBalanceRef = new System.Windows.Forms.TextBox();
            this.lblBalanceRef = new System.Windows.Forms.Label();
            this.lblRefVN = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.labelref1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.collapsibleSplitter1 = new AryuwatSystem.UserControls.CollapsibleSplitter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FrmDoctorMedicalOrder_Fill_Panel.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelProductList.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAesthetic.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAestheticList)).BeginInit();
            this.tabTreatment.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatmentList)).BeginInit();
            this.tabSurgery.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeryList)).BeginInit();
            this.tabHair.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHairList)).BeginInit();
            this.tabWellness_Antiaging.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellness_AntiagingList)).BeginInit();
            this.tabPromotion.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotionList)).BeginInit();
            this.tabPharmacy.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPharmacyList)).BeginInit();
            this.tabAttachFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).BeginInit();
            this.panel8.SuspendLayout();
            this.panelGridSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRunning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefreshProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // FrmDoctorMedicalOrder_Fill_Panel
            // 
            this.FrmDoctorMedicalOrder_Fill_Panel.Controls.Add(this.panelList);
            this.FrmDoctorMedicalOrder_Fill_Panel.Controls.Add(this.collapsibleSplitter1);
            this.FrmDoctorMedicalOrder_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmDoctorMedicalOrder_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FrmDoctorMedicalOrder_Fill_Panel.Name = "FrmDoctorMedicalOrder_Fill_Panel";
            this.FrmDoctorMedicalOrder_Fill_Panel.Size = new System.Drawing.Size(1276, 599);
            this.FrmDoctorMedicalOrder_Fill_Panel.TabIndex = 0;
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.panelProductList);
            this.panelList.Controls.Add(this.panelName);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(1276, 599);
            this.panelList.TabIndex = 4;
            // 
            // panelProductList
            // 
            this.panelProductList.Controls.Add(this.splitter1);
            this.panelProductList.Controls.Add(this.txtSORefAccount);
            this.panelProductList.Controls.Add(this.labelSOrefAcc);
            this.panelProductList.Controls.Add(this.tabControl);
            this.panelProductList.Controls.Add(this.panelGridSelect);
            this.panelProductList.Controls.Add(this.panel1);
            this.panelProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductList.Location = new System.Drawing.Point(0, 96);
            this.panelProductList.Name = "panelProductList";
            this.panelProductList.Size = new System.Drawing.Size(1276, 503);
            this.panelProductList.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 88);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1276, 3);
            this.splitter1.TabIndex = 3068;
            this.splitter1.TabStop = false;
            // 
            // txtSORefAccount
            // 
            this.txtSORefAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSORefAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSORefAccount.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSORefAccount.Location = new System.Drawing.Point(779, 1);
            this.txtSORefAccount.Name = "txtSORefAccount";
            this.txtSORefAccount.Size = new System.Drawing.Size(102, 22);
            this.txtSORefAccount.TabIndex = 3067;
            // 
            // labelSOrefAcc
            // 
            this.labelSOrefAcc.AutoSize = true;
            this.labelSOrefAcc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSOrefAcc.Location = new System.Drawing.Point(712, 5);
            this.labelSOrefAcc.Name = "labelSOrefAcc";
            this.labelSOrefAcc.Size = new System.Drawing.Size(69, 16);
            this.labelSOrefAcc.TabIndex = 318;
            this.labelSOrefAcc.Text = "เลขที่ใบยา";
            this.labelSOrefAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAesthetic);
            this.tabControl.Controls.Add(this.tabTreatment);
            this.tabControl.Controls.Add(this.tabSurgery);
            this.tabControl.Controls.Add(this.tabHair);
            this.tabControl.Controls.Add(this.tabWellness_Antiaging);
            this.tabControl.Controls.Add(this.tabPromotion);
            this.tabControl.Controls.Add(this.tabPharmacy);
            this.tabControl.Controls.Add(this.tabAttachFile);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1276, 91);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabAesthetic
            // 
            this.tabAesthetic.Controls.Add(this.panel10);
            this.tabAesthetic.Location = new System.Drawing.Point(4, 25);
            this.tabAesthetic.Name = "tabAesthetic";
            this.tabAesthetic.Size = new System.Drawing.Size(1268, 62);
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
            this.panel10.Size = new System.Drawing.Size(1268, 62);
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
            this.dgvAestheticList.Location = new System.Drawing.Point(8, 34);
            this.dgvAestheticList.Name = "dgvAestheticList";
            //this.dgvAestheticList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvAestheticList.RowTemplate.ReadOnly = true;
            this.dgvAestheticList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAestheticList.Size = new System.Drawing.Size(1251, 26);
            this.dgvAestheticList.TabIndex = 148;
            this.dgvAestheticList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAestheticList_CellContentClick);
            this.dgvAestheticList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvAestheticList_RowPostPaint);
            // 
            // tabTreatment
            // 
            this.tabTreatment.Controls.Add(this.panel7);
            this.tabTreatment.Location = new System.Drawing.Point(4, 25);
            this.tabTreatment.Name = "tabTreatment";
            this.tabTreatment.Size = new System.Drawing.Size(1268, 62);
            this.tabTreatment.TabIndex = 6;
            this.tabTreatment.Text = "TREATMENT";
            this.tabTreatment.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvTreatmentList);
            this.panel7.Controls.Add(this.txtFindTreatment);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1268, 62);
            this.panel7.TabIndex = 152;
            // 
            // dgvTreatmentList
            // 
            this.dgvTreatmentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTreatmentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTreatmentList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTreatmentList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTreatmentList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTreatmentList.Location = new System.Drawing.Point(9, 34);
            this.dgvTreatmentList.Name = "dgvTreatmentList";
            //this.dgvTreatmentList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvTreatmentList.RowTemplate.ReadOnly = true;
            this.dgvTreatmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTreatmentList.Size = new System.Drawing.Size(1256, 119);
            this.dgvTreatmentList.TabIndex = 148;
            this.dgvTreatmentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTreatmentList_CellContentClick);
            this.dgvTreatmentList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTreatmentList_RowPostPaint);
            // 
            // txtFindTreatment
            // 
            this.txtFindTreatment.Location = new System.Drawing.Point(53, 4);
            this.txtFindTreatment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindTreatment.Name = "txtFindTreatment";
            this.txtFindTreatment.Size = new System.Drawing.Size(241, 23);
            this.txtFindTreatment.TabIndex = 143;
            this.txtFindTreatment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindTreatment_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 142;
            this.label2.Text = "Find :";
            // 
            // tabSurgery
            // 
            this.tabSurgery.Controls.Add(this.panel9);
            this.tabSurgery.Location = new System.Drawing.Point(4, 25);
            this.tabSurgery.Name = "tabSurgery";
            this.tabSurgery.Size = new System.Drawing.Size(1268, 62);
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
            this.panel9.Size = new System.Drawing.Size(1268, 62);
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
            this.dgvSurgeryList.Size = new System.Drawing.Size(1251, 32);
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
            // tabHair
            // 
            this.tabHair.Controls.Add(this.panel5);
            this.tabHair.Location = new System.Drawing.Point(4, 25);
            this.tabHair.Name = "tabHair";
            this.tabHair.Size = new System.Drawing.Size(1268, 62);
            this.tabHair.TabIndex = 4;
            this.tabHair.Text = "HAIR";
            this.tabHair.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvHairList);
            this.panel5.Controls.Add(this.txtFindHair);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1268, 62);
            this.panel5.TabIndex = 150;
            // 
            // dgvHairList
            // 
            this.dgvHairList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHairList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHairList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvHairList.BackgroundColor = System.Drawing.Color.White;
            this.dgvHairList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHairList.Location = new System.Drawing.Point(9, 34);
            this.dgvHairList.Name = "dgvHairList";
            //this.dgvHairList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvHairList.RowTemplate.ReadOnly = true;
            this.dgvHairList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHairList.Size = new System.Drawing.Size(1251, 119);
            this.dgvHairList.TabIndex = 148;
            this.dgvHairList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHairList_CellContentClick);
            this.dgvHairList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHairList_RowPostPaint);
            // 
            // txtFindHair
            // 
            this.txtFindHair.Location = new System.Drawing.Point(53, 4);
            this.txtFindHair.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindHair.Name = "txtFindHair";
            this.txtFindHair.Size = new System.Drawing.Size(241, 23);
            this.txtFindHair.TabIndex = 143;
            this.txtFindHair.Enter += new System.EventHandler(this.txtFindHair_Enter);
            this.txtFindHair.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindHair_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 142;
            this.label9.Text = "Find :";
            // 
            // tabWellness_Antiaging
            // 
            this.tabWellness_Antiaging.Controls.Add(this.panel3);
            this.tabWellness_Antiaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWellness_Antiaging.Location = new System.Drawing.Point(4, 25);
            this.tabWellness_Antiaging.Margin = new System.Windows.Forms.Padding(0);
            this.tabWellness_Antiaging.Name = "tabWellness_Antiaging";
            this.tabWellness_Antiaging.Size = new System.Drawing.Size(1268, 62);
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
            this.panel3.Size = new System.Drawing.Size(1268, 62);
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
            this.dgvWellness_AntiagingList.Size = new System.Drawing.Size(1251, 32);
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
            // tabPromotion
            // 
            this.tabPromotion.Controls.Add(this.panel2);
            this.tabPromotion.Location = new System.Drawing.Point(4, 25);
            this.tabPromotion.Name = "tabPromotion";
            this.tabPromotion.Size = new System.Drawing.Size(1268, 62);
            this.tabPromotion.TabIndex = 9;
            this.tabPromotion.Text = "Promotion";
            this.tabPromotion.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFindPro);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.dgvPromotionList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1268, 62);
            this.panel2.TabIndex = 153;
            // 
            // txtFindPro
            // 
            this.txtFindPro.Location = new System.Drawing.Point(53, 4);
            this.txtFindPro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindPro.Name = "txtFindPro";
            this.txtFindPro.Size = new System.Drawing.Size(241, 23);
            this.txtFindPro.TabIndex = 143;
            this.txtFindPro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindPro_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 16);
            this.label15.TabIndex = 142;
            this.label15.Text = "Find :";
            // 
            // dgvPromotionList
            // 
            this.dgvPromotionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPromotionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPromotionList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPromotionList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPromotionList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPromotionList.Location = new System.Drawing.Point(8, 34);
            this.dgvPromotionList.Name = "dgvPromotionList";
            //this.dgvPromotionList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvPromotionList.RowTemplate.ReadOnly = true;
            this.dgvPromotionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromotionList.Size = new System.Drawing.Size(1251, 32);
            this.dgvPromotionList.TabIndex = 148;
            this.dgvPromotionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromotionList_CellContentClick);
            this.dgvPromotionList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPromotionList_RowPostPaint);
            // 
            // tabPharmacy
            // 
            this.tabPharmacy.Controls.Add(this.panel6);
            this.tabPharmacy.Location = new System.Drawing.Point(4, 25);
            this.tabPharmacy.Name = "tabPharmacy";
            this.tabPharmacy.Size = new System.Drawing.Size(1268, 62);
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
            this.panel6.Size = new System.Drawing.Size(1268, 62);
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
            this.dgvPharmacyList.Size = new System.Drawing.Size(1251, 32);
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
            this.tabAttachFile.Controls.Add(this.panel8);
            this.tabAttachFile.Location = new System.Drawing.Point(4, 25);
            this.tabAttachFile.Name = "tabAttachFile";
            this.tabAttachFile.Size = new System.Drawing.Size(1268, 62);
            this.tabAttachFile.TabIndex = 7;
            this.tabAttachFile.Text = "ATTACH FILE";
            this.tabAttachFile.UseVisualStyleBackColor = true;
            // 
            // dgvFile
            // 
            this.dgvFile.AllowUserToAddRows = false;
            this.dgvFile.AllowUserToDeleteRows = false;
            this.dgvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFile.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvFile.BackgroundColor = System.Drawing.Color.White;
            this.dgvFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFile.Location = new System.Drawing.Point(0, 30);
            this.dgvFile.Name = "dgvFile";
            //this.dgvFile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvFile.RowTemplate.ReadOnly = true;
            this.dgvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFile.Size = new System.Drawing.Size(1268, 32);
            this.dgvFile.TabIndex = 289;
            this.dgvFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFile_CellContentClick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtFilePath);
            this.panel8.Controls.Add(this.btnAddFile);
            this.panel8.Controls.Add(this.txtFileName);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.button2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1268, 30);
            this.panel8.TabIndex = 290;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(3, 3);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(423, 23);
            this.txtFilePath.TabIndex = 284;
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFile.Location = new System.Drawing.Point(823, 1);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(26, 26);
            this.btnAddFile.TabIndex = 286;
            this.btnAddFile.BtnClick += new AryuwatSystem.UserControls.ButtonAdd.ButtonClick(this.btnAddFile_BtnClick);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(534, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(283, 23);
            this.txtFileName.TabIndex = 288;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(471, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 16);
            this.label14.TabIndex = 142;
            this.label14.Text = "ชื่อไฟล์ :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 23);
            this.button2.TabIndex = 285;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelGridSelect
            // 
            this.panelGridSelect.Controls.Add(this.groupBox1);
            this.panelGridSelect.Controls.Add(this.panel4);
            this.panelGridSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGridSelect.Location = new System.Drawing.Point(0, 91);
            this.panelGridSelect.Name = "panelGridSelect";
            this.panelGridSelect.Size = new System.Drawing.Size(1276, 291);
            this.panelGridSelect.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewSelectList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1276, 263);
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
            this.dataGridViewSelectList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewSelectList.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewSelectList.Name = "dataGridViewSelectList";
            this.dataGridViewSelectList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewSelectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectList.Size = new System.Drawing.Size(1270, 241);
            this.dataGridViewSelectList.TabIndex = 150;
            this.dataGridViewSelectList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewSelectList_CellBeginEdit);
            this.dataGridViewSelectList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellClick);
            this.dataGridViewSelectList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellEndEdit);
            this.dataGridViewSelectList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSelectList_CellFormatting);
            this.dataGridViewSelectList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseClick);
            this.dataGridViewSelectList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseDoubleClick);
            this.dataGridViewSelectList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewSelectList_CurrentCellDirtyStateChanged);
            this.dataGridViewSelectList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewSelectList_DataError);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.lbProCredit);
            this.panel4.Controls.Add(this.lbPromotion);
            this.panel4.Controls.Add(this.buttonAddDown);
            this.panel4.Controls.Add(this.buttonDeleteUp);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1276, 28);
            this.panel4.TabIndex = 4;
            // 
            // lbProCredit
            // 
            this.lbProCredit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbProCredit.Location = new System.Drawing.Point(766, 5);
            this.lbProCredit.Name = "lbProCredit";
            this.lbProCredit.Size = new System.Drawing.Size(507, 26);
            this.lbProCredit.TabIndex = 149;
            this.lbProCredit.Text = "Balances/Credit";
            this.lbProCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbProCredit.Visible = false;
            // 
            // lbPromotion
            // 
            this.lbPromotion.AutoSize = true;
            this.lbPromotion.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbPromotion.Location = new System.Drawing.Point(3, 14);
            this.lbPromotion.Name = "lbPromotion";
            this.lbPromotion.Size = new System.Drawing.Size(129, 16);
            this.lbPromotion.TabIndex = 148;
            this.lbPromotion.Text = "ชื่อลูกค้า/Customer";
            // 
            // buttonAddDown
            // 
            this.buttonAddDown.Location = new System.Drawing.Point(616, 1);
            this.buttonAddDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonAddDown.Name = "buttonAddDown";
            this.buttonAddDown.Size = new System.Drawing.Size(30, 26);
            this.buttonAddDown.TabIndex = 146;
            this.buttonAddDown.BtnClick += new AryuwatSystem.UserControls.ButtonRigth.ButtonClick(this.buttonAddDown_BtnClick);
            // 
            // buttonDeleteUp
            // 
            this.buttonDeleteUp.Location = new System.Drawing.Point(582, 1);
            this.buttonDeleteUp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonDeleteUp.Name = "buttonDeleteUp";
            this.buttonDeleteUp.Size = new System.Drawing.Size(30, 26);
            this.buttonDeleteUp.TabIndex = 147;
            this.buttonDeleteUp.BtnClick += new AryuwatSystem.UserControls.ButtonLeft.ButtonClick(this.buttonDeleteUp_BtnClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.textBoxNormal);
            this.panel1.Controls.Add(this.labelNormal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.cboBranch);
            this.panel1.Controls.Add(this.label101);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtPriceTotal);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 382);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1276, 121);
            this.panel1.TabIndex = 151;
            // 
            // textBoxNormal
            // 
            this.textBoxNormal.BackColor = System.Drawing.Color.Black;
            this.textBoxNormal.Font = new System.Drawing.Font("Tahoma", 14F);
            this.textBoxNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBoxNormal.Location = new System.Drawing.Point(769, 41);
            this.textBoxNormal.Name = "textBoxNormal";
            this.textBoxNormal.ReadOnly = true;
            this.textBoxNormal.Size = new System.Drawing.Size(140, 30);
            this.textBoxNormal.TabIndex = 3083;
            this.textBoxNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelNormal
            // 
            this.labelNormal.AutoSize = true;
            this.labelNormal.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.labelNormal.Location = new System.Drawing.Point(653, 42);
            this.labelNormal.Name = "labelNormal";
            this.labelNormal.Size = new System.Drawing.Size(110, 29);
            this.labelNormal.TabIndex = 3082;
            this.labelNormal.Text = "ราคาเต็ม";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 16);
            this.label5.TabIndex = 3076;
            this.label5.Text = "หมายเหตุ(Remark)";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(143, 5);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(475, 60);
            this.txtRemark.TabIndex = 3075;
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.DropDownWidth = 200;
            this.cboBranch.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Items.AddRange(new object[] {
            "=== โปรดระบุ ===",
            "ผู้บริหาร",
            "Dermatologist  (หมอผิวพรรณและความงาม)",
            "Surgeon (หมอผ่าตัด)",
            "Hair Transplantation doctor (หมอปลูกผม)",
            "Anesthesiologist (หมอดมยา)",
            "Pharmacist",
            "พยาบาล",
            "Physical  TP",
            "Tp",
            "Marketing",
            "Cashier",
            "Accounting",
            "Operator (พนักงานป้อนข้อมูล)",
            "พนักงานทั่วไป"});
            this.cboBranch.Location = new System.Drawing.Point(745, 7);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(241, 27);
            this.cboBranch.TabIndex = 3073;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label101.Location = new System.Drawing.Point(625, 10);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(123, 19);
            this.label101.TabIndex = 3074;
            this.label101.Text = " สาขา(Branch)";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::AryuwatSystem.Properties.Resources.print_printer_resize;
            this.btnPrint.Location = new System.Drawing.Point(6, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(40, 37);
            this.btnPrint.TabIndex = 3070;
            this.toolTip1.SetToolTip(this.btnPrint, "Print MO SO");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1159, 48);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 39);
            this.btnCancel.TabIndex = 269;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1049, 48);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 39);
            this.btnSave.TabIndex = 267;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtPriceTotal
            // 
            this.txtPriceTotal.BackColor = System.Drawing.Color.Black;
            this.txtPriceTotal.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtPriceTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPriceTotal.Location = new System.Drawing.Point(769, 74);
            this.txtPriceTotal.Name = "txtPriceTotal";
            this.txtPriceTotal.ReadOnly = true;
            this.txtPriceTotal.Size = new System.Drawing.Size(140, 36);
            this.txtPriceTotal.TabIndex = 271;
            this.txtPriceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(909, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 29);
            this.label13.TabIndex = 270;
            this.label13.Text = "บาท/Bth.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(639, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 270;
            this.label4.Text = "รวม/Total";
            // 
            // panelName
            // 
            this.panelName.Controls.Add(this.comboBoxByDr);
            this.panelName.Controls.Add(this.label10);
            this.panelName.Controls.Add(this.labelKey1);
            this.panelName.Controls.Add(this.checkBoxOld);
            this.panelName.Controls.Add(this.labelCN);
            this.panelName.Controls.Add(this.radioPRO);
            this.panelName.Controls.Add(this.radioWE);
            this.panelName.Controls.Add(this.radioSU);
            this.panelName.Controls.Add(this.radioAE);
            this.panelName.Controls.Add(this.radioButtonSO);
            this.panelName.Controls.Add(this.radioButtonMO);
            this.panelName.Controls.Add(this.txtMO);
            this.panelName.Controls.Add(this.txtSoRef);
            this.panelName.Controls.Add(this.comboBoxCommission1);
            this.panelName.Controls.Add(this.comboBoxCommission2);
            this.panelName.Controls.Add(this.txtSONo);
            this.panelName.Controls.Add(this.btnRunning);
            this.panelName.Controls.Add(this.label3);
            this.panelName.Controls.Add(this.dateTimePickerCreate);
            this.panelName.Controls.Add(this.pictureBoxRefreshProduct);
            this.panelName.Controls.Add(this.txtBalanceRef);
            this.panelName.Controls.Add(this.lblBalanceRef);
            this.panelName.Controls.Add(this.lblRefVN);
            this.panelName.Controls.Add(this.btnBrowse);
            this.panelName.Controls.Add(this.txtCustomerName);
            this.panelName.Controls.Add(this.labelref1);
            this.panelName.Controls.Add(this.label8);
            this.panelName.Controls.Add(this.label6);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(1276, 96);
            this.panelName.TabIndex = 145;
            this.panelName.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // comboBoxByDr
            // 
            this.comboBoxByDr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxByDr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxByDr.Location = new System.Drawing.Point(779, 71);
            this.comboBoxByDr.Name = "comboBoxByDr";
            this.comboBoxByDr.Size = new System.Drawing.Size(207, 24);
            this.comboBoxByDr.TabIndex = 319;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(692, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 318;
            this.label10.Text = "ชื่อแพทย์/Dr.";
            // 
            // labelKey1
            // 
            this.labelKey1.Location = new System.Drawing.Point(988, 70);
            this.labelKey1.Name = "labelKey1";
            this.labelKey1.Size = new System.Drawing.Size(279, 22);
            this.labelKey1.TabIndex = 149;
            this.labelKey1.Text = "label5";
            this.labelKey1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxOld
            // 
            this.checkBoxOld.AutoSize = true;
            this.checkBoxOld.Location = new System.Drawing.Point(1205, 46);
            this.checkBoxOld.Name = "checkBoxOld";
            this.checkBoxOld.Size = new System.Drawing.Size(66, 20);
            this.checkBoxOld.TabIndex = 317;
            this.checkBoxOld.Text = "OldKey";
            this.checkBoxOld.UseVisualStyleBackColor = true;
            // 
            // labelCN
            // 
            this.labelCN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCN.Location = new System.Drawing.Point(655, 23);
            this.labelCN.Name = "labelCN";
            this.labelCN.Size = new System.Drawing.Size(123, 16);
            this.labelCN.TabIndex = 316;
            this.labelCN.Text = "CN";
            this.labelCN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioPRO
            // 
            this.radioPRO.AutoCheck = false;
            this.radioPRO.AutoSize = true;
            this.radioPRO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPRO.Location = new System.Drawing.Point(289, 37);
            this.radioPRO.Name = "radioPRO";
            this.radioPRO.Size = new System.Drawing.Size(62, 23);
            this.radioPRO.TabIndex = 315;
            this.radioPRO.Text = "PRO";
            this.radioPRO.UseVisualStyleBackColor = true;
            this.radioPRO.Click += new System.EventHandler(this.radioPRO_Click);
            // 
            // radioWE
            // 
            this.radioWE.AutoCheck = false;
            this.radioWE.AutoSize = true;
            this.radioWE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioWE.Location = new System.Drawing.Point(289, 16);
            this.radioWE.Name = "radioWE";
            this.radioWE.Size = new System.Drawing.Size(53, 23);
            this.radioWE.TabIndex = 314;
            this.radioWE.Text = "WE";
            this.radioWE.UseVisualStyleBackColor = true;
            this.radioWE.CheckedChanged += new System.EventHandler(this.radioWE_CheckedChanged);
            this.radioWE.Click += new System.EventHandler(this.radioWE_Click);
            // 
            // radioSU
            // 
            this.radioSU.AutoCheck = false;
            this.radioSU.AutoSize = true;
            this.radioSU.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSU.Location = new System.Drawing.Point(238, 37);
            this.radioSU.Name = "radioSU";
            this.radioSU.Size = new System.Drawing.Size(49, 23);
            this.radioSU.TabIndex = 313;
            this.radioSU.Text = "SU";
            this.radioSU.UseVisualStyleBackColor = true;
            this.radioSU.CheckedChanged += new System.EventHandler(this.radioSU_CheckedChanged);
            this.radioSU.Click += new System.EventHandler(this.radioSU_Click);
            // 
            // radioAE
            // 
            this.radioAE.AutoCheck = false;
            this.radioAE.AutoSize = true;
            this.radioAE.Checked = true;
            this.radioAE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAE.Location = new System.Drawing.Point(238, 16);
            this.radioAE.Name = "radioAE";
            this.radioAE.Size = new System.Drawing.Size(49, 23);
            this.radioAE.TabIndex = 312;
            this.radioAE.Text = "AE";
            this.radioAE.UseVisualStyleBackColor = true;
            this.radioAE.CheckedChanged += new System.EventHandler(this.radioAE_CheckedChanged);
            this.radioAE.Click += new System.EventHandler(this.radioAE_Click);
            // 
            // radioButtonSO
            // 
            this.radioButtonSO.AutoSize = true;
            this.radioButtonSO.Checked = true;
            this.radioButtonSO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSO.Location = new System.Drawing.Point(12, 11);
            this.radioButtonSO.Name = "radioButtonSO";
            this.radioButtonSO.Size = new System.Drawing.Size(49, 23);
            this.radioButtonSO.TabIndex = 311;
            this.radioButtonSO.TabStop = true;
            this.radioButtonSO.Text = "SO";
            this.radioButtonSO.UseVisualStyleBackColor = true;
            this.radioButtonSO.CheckedChanged += new System.EventHandler(this.radioButtonSO_CheckedChanged);
            // 
            // radioButtonMO
            // 
            this.radioButtonMO.AutoSize = true;
            this.radioButtonMO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMO.Location = new System.Drawing.Point(12, 38);
            this.radioButtonMO.Name = "radioButtonMO";
            this.radioButtonMO.Size = new System.Drawing.Size(53, 23);
            this.radioButtonMO.TabIndex = 310;
            this.radioButtonMO.Text = "MO";
            this.radioButtonMO.UseVisualStyleBackColor = true;
            this.radioButtonMO.CheckedChanged += new System.EventHandler(this.radioButtonMO_CheckedChanged);
            this.radioButtonMO.Click += new System.EventHandler(this.radioButtonMO_Click);
            // 
            // txtMO
            // 
            this.txtMO.BackColor = System.Drawing.Color.Black;
            this.txtMO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMO.Location = new System.Drawing.Point(65, 36);
            this.txtMO.Name = "txtMO";
            this.txtMO.Size = new System.Drawing.Size(167, 27);
            this.txtMO.TabIndex = 152;
            this.txtMO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSoRef
            // 
            this.txtSoRef.BackColor = System.Drawing.Color.Black;
            this.txtSoRef.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtSoRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtSoRef.Location = new System.Drawing.Point(473, 38);
            this.txtSoRef.Name = "txtSoRef";
            this.txtSoRef.Size = new System.Drawing.Size(145, 24);
            this.txtSoRef.TabIndex = 308;
            this.txtSoRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSoRef.Visible = false;
            // 
            // comboBoxCommission1
            // 
            this.comboBoxCommission1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCommission1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxCommission1.Location = new System.Drawing.Point(779, 44);
            this.comboBoxCommission1.Name = "comboBoxCommission1";
            this.comboBoxCommission1.Size = new System.Drawing.Size(207, 24);
            this.comboBoxCommission1.TabIndex = 306;
            // 
            // comboBoxCommission2
            // 
            this.comboBoxCommission2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCommission2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxCommission2.FormattingEnabled = true;
            this.comboBoxCommission2.Location = new System.Drawing.Point(991, 44);
            this.comboBoxCommission2.Name = "comboBoxCommission2";
            this.comboBoxCommission2.Size = new System.Drawing.Size(207, 24);
            this.comboBoxCommission2.TabIndex = 305;
            // 
            // txtSONo
            // 
            this.txtSONo.BackColor = System.Drawing.Color.Black;
            this.txtSONo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSONo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtSONo.Location = new System.Drawing.Point(65, 8);
            this.txtSONo.Name = "txtSONo";
            this.txtSONo.Size = new System.Drawing.Size(167, 27);
            this.txtSONo.TabIndex = 155;
            this.txtSONo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRunning
            // 
            this.btnRunning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunning.Image = global::AryuwatSystem.Properties.Resources._019356d2_9013_4000_84c5_25bc6fdd8c13;
            this.btnRunning.Location = new System.Drawing.Point(623, 34);
            this.btnRunning.Name = "btnRunning";
            this.btnRunning.Size = new System.Drawing.Size(23, 27);
            this.btnRunning.TabIndex = 153;
            this.btnRunning.TabStop = false;
            this.btnRunning.Visible = false;
            this.btnRunning.Click += new System.EventHandler(this.btnRunning_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1051, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 151;
            this.label3.Text = "Date :";
            // 
            // dateTimePickerCreate
            // 
            this.dateTimePickerCreate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCreate.Location = new System.Drawing.Point(1099, 9);
            this.dateTimePickerCreate.Name = "dateTimePickerCreate";
            this.dateTimePickerCreate.ShowUpDown = true;
            this.dateTimePickerCreate.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerCreate.TabIndex = 150;
            // 
            // pictureBoxRefreshProduct
            // 
            this.pictureBoxRefreshProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRefreshProduct.Image = global::AryuwatSystem.Properties.Resources.pharmacy_2561;
            this.pictureBoxRefreshProduct.Location = new System.Drawing.Point(1205, 6);
            this.pictureBoxRefreshProduct.Name = "pictureBoxRefreshProduct";
            this.pictureBoxRefreshProduct.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxRefreshProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRefreshProduct.TabIndex = 149;
            this.pictureBoxRefreshProduct.TabStop = false;
            this.pictureBoxRefreshProduct.Click += new System.EventHandler(this.pictureBoxRefreshProduct_Click);
            this.pictureBoxRefreshProduct.MouseHover += new System.EventHandler(this.pictureBoxRefreshProduct_MouseHover);
            // 
            // txtBalanceRef
            // 
            this.txtBalanceRef.BackColor = System.Drawing.Color.Black;
            this.txtBalanceRef.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtBalanceRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtBalanceRef.Location = new System.Drawing.Point(473, 9);
            this.txtBalanceRef.Name = "txtBalanceRef";
            this.txtBalanceRef.Size = new System.Drawing.Size(145, 24);
            this.txtBalanceRef.TabIndex = 147;
            this.txtBalanceRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceRef.Visible = false;
            // 
            // lblBalanceRef
            // 
            this.lblBalanceRef.AutoSize = true;
            this.lblBalanceRef.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalanceRef.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBalanceRef.Location = new System.Drawing.Point(352, 16);
            this.lblBalanceRef.Name = "lblBalanceRef";
            this.lblBalanceRef.Size = new System.Drawing.Size(121, 17);
            this.lblBalanceRef.TabIndex = 146;
            this.lblBalanceRef.Text = "ยอดยกมา/Credit";
            this.lblBalanceRef.Visible = false;
            // 
            // lblRefVN
            // 
            this.lblRefVN.AutoSize = true;
            this.lblRefVN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRefVN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRefVN.Location = new System.Drawing.Point(369, 40);
            this.lblRefVN.Name = "lblRefVN";
            this.lblRefVN.Size = new System.Drawing.Size(104, 17);
            this.lblRefVN.TabIndex = 145;
            this.lblRefVN.Text = "อ้างอิง SO Ref.";
            this.lblRefVN.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(1024, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 29);
            this.btnBrowse.TabIndex = 144;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(778, 10);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(247, 27);
            this.txtCustomerName.TabIndex = 143;
            // 
            // labelref1
            // 
            this.labelref1.AutoSize = true;
            this.labelref1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelref1.Location = new System.Drawing.Point(621, 14);
            this.labelref1.Name = "labelref1";
            this.labelref1.Size = new System.Drawing.Size(37, 17);
            this.labelref1.TabIndex = 309;
            this.labelref1.Text = "Bth.";
            this.labelref1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(665, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 307;
            this.label8.Text = "ชื่อผู้ขาย/Consult";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(652, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 16);
            this.label6.TabIndex = 142;
            this.label6.Text = "ชื่อลูกค้า/Customer";
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
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmDoctorMedicalOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 599);
            this.Controls.Add(this.FrmDoctorMedicalOrder_Fill_Panel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "FrmDoctorMedicalOrder";
            this.Text = "MEDICAL  ORDER Promotion / ใบสั่งการรักษา";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDoctorMedicalOrder_FormClosing);
            this.Load += new System.EventHandler(this.FrmDoctorMedicalOrder_Load);
            this.Shown += new System.EventHandler(this.FrmDoctorMedicalOrder_Shown);
            this.FrmDoctorMedicalOrder_Fill_Panel.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelProductList.ResumeLayout(false);
            this.panelProductList.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabAesthetic.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAestheticList)).EndInit();
            this.tabTreatment.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatmentList)).EndInit();
            this.tabSurgery.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeryList)).EndInit();
            this.tabHair.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHairList)).EndInit();
            this.tabWellness_Antiaging.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellness_AntiagingList)).EndInit();
            this.tabPromotion.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotionList)).EndInit();
            this.tabPharmacy.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPharmacyList)).EndInit();
            this.tabAttachFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelGridSelect.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRunning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefreshProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FrmDoctorMedicalOrder_Fill_Panel;
        private System.Windows.Forms.Panel panelList;
        private UserControls.CollapsibleSplitter collapsibleSplitter1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPharmacy;
        private System.Windows.Forms.TabPage tabSurgery;
        private System.Windows.Forms.Panel panelProductList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabHair;
        private System.Windows.Forms.TextBox txtFindHair;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvHairList;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvPharmacyList;
        private UserControls.ButtonRigth buttonAddDown;
        private System.Windows.Forms.TextBox txtFindPharmacy;
        private UserControls.ButtonLeft buttonDeleteUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabPage tabAesthetic;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dgvAestheticList;
        private System.Windows.Forms.TextBox txtFindAes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabTreatment;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvTreatmentList;
        private System.Windows.Forms.TextBox txtFindTreatment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvSurgeryList;
        private System.Windows.Forms.TextBox txtFindSurgery;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabAttachFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private UserControls.ButtonAdd btnAddFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.DataGridView dgvFile;
        internal System.Windows.Forms.Label lblBalanceRef;
        internal System.Windows.Forms.Label lblRefVN;
        internal System.Windows.Forms.TextBox txtBalanceRef;
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
        private System.Windows.Forms.TextBox txtPriceTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridViewSelectList;
        private System.Windows.Forms.PictureBox pictureBoxRefreshProduct;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnRunning;
        internal System.Windows.Forms.TextBox txtMO;
        internal System.Windows.Forms.TextBox txtSONo;
        private System.Windows.Forms.ComboBox comboBoxCommission1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCommission2;
        private System.Windows.Forms.TextBox txtSoRef;
        private System.Windows.Forms.Label labelref1;
        private RadioButton radioButtonSO;
        private RadioButton radioButtonMO;
        private RadioButton radioWE;
        private RadioButton radioSU;
        private RadioButton radioAE;
        private TabPage tabPromotion;
        private Panel panel2;
        private TextBox txtFindPro;
        private Label label15;
        private DataGridView dgvPromotionList;
        private RadioButton radioPRO;
        private Label lbPromotion;
        private Label lbProCredit;
        private Label labelCN;
        private Button btnPrint;
        private CheckBox checkBoxOld;
        private ComboBox cboBranch;
        private Label label101;
        private TextBox txtSORefAccount;
        private Label labelSOrefAcc;
        private Splitter splitter1;
        private Panel panel8;
        private Label label5;
        private TextBox txtRemark;
        private Label labelKey1;
        private ComboBox comboBoxByDr;
        private Label label10;
        private TextBox textBoxNormal;
        private Label labelNormal;


    }
}