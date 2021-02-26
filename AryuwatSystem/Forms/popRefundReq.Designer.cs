namespace AryuwatSystem.Forms
{
    partial class popRefundReq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popRefundReq));
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelShow = new System.Windows.Forms.Label();
            this.txtRefundDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelBankDetail = new System.Windows.Forms.Panel();
            this.txtPayCustName = new System.Windows.Forms.TextBox();
            this.comboBoxBank = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPayBankNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textboxFormatDoubleRefund = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxMoneyType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRefundSince = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRFD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxByDr = new System.Windows.Forms.ComboBox();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.txtConsult = new System.Windows.Forms.TextBox();
            this.txtCustname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewSelectList = new System.Windows.Forms.DataGridView();
            this.MS_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceAfterDis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelSO = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.checkBoxApproved = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panelBankDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnNo.Location = new System.Drawing.Point(1094, 423);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(105, 46);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "ปิด";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnYes.Location = new System.Drawing.Point(958, 423);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(105, 46);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "บันทึก";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(113, 31);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(317, 36);
            this.comboBoxType.TabIndex = 3081;
            // 
            // labelShow
            // 
            this.labelShow.AutoSize = true;
            this.labelShow.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.labelShow.Location = new System.Drawing.Point(18, 31);
            this.labelShow.Name = "labelShow";
            this.labelShow.Size = new System.Drawing.Size(76, 28);
            this.labelShow.TabIndex = 3080;
            this.labelShow.Text = "เลือกสาเหตุ";
            this.labelShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRefundDate
            // 
            this.txtRefundDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRefundDate.Location = new System.Drawing.Point(83, 74);
            this.txtRefundDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefundDate.Mask = "00/00/0000";
            this.txtRefundDate.Name = "txtRefundDate";
            this.txtRefundDate.Size = new System.Drawing.Size(130, 29);
            this.txtRefundDate.TabIndex = 3083;
            this.txtRefundDate.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 28);
            this.label1.TabIndex = 3084;
            this.label1.Text = "จำนวนเงิน";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label2.Location = new System.Drawing.Point(40, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 28);
            this.label2.TabIndex = 3085;
            this.label2.Text = "วันที่";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 28);
            this.label3.TabIndex = 3087;
            this.label3.Text = "หมายเหตุ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(83, 110);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(277, 76);
            this.txtRemark.TabIndex = 3088;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelBankDetail);
            this.groupBox1.Controls.Add(this.textboxFormatDoubleRefund);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtRefundDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxMoneyType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(539, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 202);
            this.groupBox1.TabIndex = 3089;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "วิธีรับเงิน";
            // 
            // panelBankDetail
            // 
            this.panelBankDetail.Controls.Add(this.txtPayCustName);
            this.panelBankDetail.Controls.Add(this.comboBoxBank);
            this.panelBankDetail.Controls.Add(this.label5);
            this.panelBankDetail.Controls.Add(this.label6);
            this.panelBankDetail.Controls.Add(this.txtPayBankNumber);
            this.panelBankDetail.Controls.Add(this.label12);
            this.panelBankDetail.Location = new System.Drawing.Point(379, 69);
            this.panelBankDetail.Name = "panelBankDetail";
            this.panelBankDetail.Size = new System.Drawing.Size(281, 122);
            this.panelBankDetail.TabIndex = 3107;
            this.panelBankDetail.Visible = false;
            // 
            // txtPayCustName
            // 
            this.txtPayCustName.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.txtPayCustName.Location = new System.Drawing.Point(58, 3);
            this.txtPayCustName.Name = "txtPayCustName";
            this.txtPayCustName.Size = new System.Drawing.Size(219, 36);
            this.txtPayCustName.TabIndex = 3102;
            // 
            // comboBoxBank
            // 
            this.comboBoxBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBank.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.comboBoxBank.FormattingEnabled = true;
            this.comboBoxBank.Location = new System.Drawing.Point(58, 43);
            this.comboBoxBank.Name = "comboBoxBank";
            this.comboBoxBank.Size = new System.Drawing.Size(219, 36);
            this.comboBoxBank.TabIndex = 3106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label5.Location = new System.Drawing.Point(1, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 28);
            this.label5.TabIndex = 3097;
            this.label5.Text = "ธนาคาร";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label6.Location = new System.Drawing.Point(17, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 28);
            this.label6.TabIndex = 3098;
            this.label6.Text = "เลขที่";
            // 
            // txtPayBankNumber
            // 
            this.txtPayBankNumber.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.txtPayBankNumber.Location = new System.Drawing.Point(58, 83);
            this.txtPayBankNumber.Name = "txtPayBankNumber";
            this.txtPayBankNumber.Size = new System.Drawing.Size(219, 36);
            this.txtPayBankNumber.TabIndex = 3099;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label12.Location = new System.Drawing.Point(30, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 28);
            this.label12.TabIndex = 3103;
            this.label12.Text = "ชื่อ";
            // 
            // textboxFormatDoubleRefund
            // 
            this.textboxFormatDoubleRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textboxFormatDoubleRefund.Location = new System.Drawing.Point(83, 35);
            this.textboxFormatDoubleRefund.Name = "textboxFormatDoubleRefund";
            this.textboxFormatDoubleRefund.Size = new System.Drawing.Size(130, 29);
            this.textboxFormatDoubleRefund.TabIndex = 3082;
            this.textboxFormatDoubleRefund.Leave += new System.EventHandler(this.textboxFormatDoubleRefund_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label13.Location = new System.Drawing.Point(343, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 28);
            this.label13.TabIndex = 3105;
            this.label13.Text = "ประเภทรับเงิน";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxMoneyType
            // 
            this.comboBoxMoneyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMoneyType.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.comboBoxMoneyType.FormattingEnabled = true;
            this.comboBoxMoneyType.Location = new System.Drawing.Point(436, 27);
            this.comboBoxMoneyType.Name = "comboBoxMoneyType";
            this.comboBoxMoneyType.Size = new System.Drawing.Size(220, 36);
            this.comboBoxMoneyType.TabIndex = 3104;
            this.comboBoxMoneyType.SelectedIndexChanged += new System.EventHandler(this.comboBoxMoneyType_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelShow);
            this.groupBox2.Controls.Add(this.txtRefundSince);
            this.groupBox2.Controls.Add(this.comboBoxType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.groupBox2.Location = new System.Drawing.Point(12, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 165);
            this.groupBox2.TabIndex = 3090;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "สาเหตุ";
            // 
            // txtRefundSince
            // 
            this.txtRefundSince.Location = new System.Drawing.Point(113, 69);
            this.txtRefundSince.Multiline = true;
            this.txtRefundSince.Name = "txtRefundSince";
            this.txtRefundSince.Size = new System.Drawing.Size(317, 86);
            this.txtRefundSince.TabIndex = 3089;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.label4.Location = new System.Drawing.Point(45, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 28);
            this.label4.TabIndex = 3090;
            this.label4.Text = "เนื่องจาก";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRFD);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.comboBoxByDr);
            this.groupBox3.Controls.Add(this.txtBuy);
            this.groupBox3.Controls.Add(this.txtConsult);
            this.groupBox3.Controls.Add(this.txtCustname);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(521, 233);
            this.groupBox3.TabIndex = 3091;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "รายละเอียด";
            // 
            // txtRFD
            // 
            this.txtRFD.Font = new System.Drawing.Font("TH Sarabun New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFD.Location = new System.Drawing.Point(107, 25);
            this.txtRFD.Name = "txtRFD";
            this.txtRFD.ReadOnly = true;
            this.txtRFD.Size = new System.Drawing.Size(154, 39);
            this.txtRFD.TabIndex = 3108;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("TH Sarabun New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(40, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 32);
            this.label11.TabIndex = 3107;
            this.label11.Text = "RFD No.";
            // 
            // comboBoxByDr
            // 
            this.comboBoxByDr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxByDr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxByDr.Location = new System.Drawing.Point(107, 189);
            this.comboBoxByDr.Name = "comboBoxByDr";
            this.comboBoxByDr.Size = new System.Drawing.Size(394, 36);
            this.comboBoxByDr.TabIndex = 3106;
            // 
            // txtBuy
            // 
            this.txtBuy.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.txtBuy.Location = new System.Drawing.Point(181, 148);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(320, 36);
            this.txtBuy.TabIndex = 3104;
            this.txtBuy.Text = "1234567890";
            // 
            // txtConsult
            // 
            this.txtConsult.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.txtConsult.Location = new System.Drawing.Point(107, 108);
            this.txtConsult.Name = "txtConsult";
            this.txtConsult.Size = new System.Drawing.Size(394, 36);
            this.txtConsult.TabIndex = 3104;
            this.txtConsult.Text = "นายรัตนะ โคตรสมบัติ";
            // 
            // txtCustname
            // 
            this.txtCustname.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.txtCustname.Location = new System.Drawing.Point(107, 68);
            this.txtCustname.Name = "txtCustname";
            this.txtCustname.Size = new System.Drawing.Size(394, 36);
            this.txtCustname.TabIndex = 3103;
            this.txtCustname.Text = "นายรัตนะ โคตรสมบัติ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(18, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 28);
            this.label10.TabIndex = 3094;
            this.label10.Text = "แพทย์ผู้รักษา";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(22, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 28);
            this.label9.TabIndex = 3093;
            this.label9.Text = "วันที่ จำนวนเงินที่ซื้อคอร์ส";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(22, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 28);
            this.label8.TabIndex = 3092;
            this.label8.Text = "ชื่อ Consult";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(20, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 28);
            this.label7.TabIndex = 3091;
            this.label7.Text = "ชื่อลูกค้า/CN";
            // 
            // dataGridViewSelectList
            // 
            this.dataGridViewSelectList.AllowUserToAddRows = false;
            this.dataGridViewSelectList.AllowUserToDeleteRows = false;
            this.dataGridViewSelectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewSelectList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSelectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MS_Code,
            this.MS_Name,
            this.ListOrder,
            this.PriceAfterDis});
            this.dataGridViewSelectList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewSelectList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewSelectList.Location = new System.Drawing.Point(3, 51);
            this.dataGridViewSelectList.MultiSelect = false;
            this.dataGridViewSelectList.Name = "dataGridViewSelectList";
            this.dataGridViewSelectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectList.Size = new System.Drawing.Size(654, 150);
            this.dataGridViewSelectList.TabIndex = 3106;
            this.dataGridViewSelectList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
            // 
            // MS_Code
            // 
            this.MS_Code.HeaderText = "Code";
            this.MS_Code.Name = "MS_Code";
            this.MS_Code.Visible = false;
            // 
            // MS_Name
            // 
            this.MS_Name.HeaderText = "Name";
            this.MS_Name.Name = "MS_Name";
            this.MS_Name.Width = 400;
            // 
            // ListOrder
            // 
            this.ListOrder.HeaderText = "ListOrder";
            this.ListOrder.Name = "ListOrder";
            this.ListOrder.Visible = false;
            this.ListOrder.Width = 40;
            // 
            // PriceAfterDis
            // 
            this.PriceAfterDis.HeaderText = "ราคา";
            this.PriceAfterDis.Name = "PriceAfterDis";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelSO);
            this.groupBox5.Controls.Add(this.dataGridViewSelectList);
            this.groupBox5.Font = new System.Drawing.Font("TH Sarabun New", 15.75F);
            this.groupBox5.Location = new System.Drawing.Point(539, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(660, 204);
            this.groupBox5.TabIndex = 3093;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "รายการ";
            // 
            // labelSO
            // 
            this.labelSO.AutoSize = true;
            this.labelSO.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelSO.Location = new System.Drawing.Point(6, 20);
            this.labelSO.Name = "labelSO";
            this.labelSO.Size = new System.Drawing.Size(103, 28);
            this.labelSO.TabIndex = 3107;
            this.labelSO.Text = "SO/MO/RefMo";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::AryuwatSystem.Properties.Resources.print_printer_resize;
            this.btnPrint.Location = new System.Drawing.Point(119, 431);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(40, 37);
            this.btnPrint.TabIndex = 3094;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // checkBoxApproved
            // 
            this.checkBoxApproved.AutoSize = true;
            this.checkBoxApproved.Enabled = false;
            this.checkBoxApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.checkBoxApproved.ForeColor = System.Drawing.Color.ForestGreen;
            this.checkBoxApproved.Location = new System.Drawing.Point(193, 437);
            this.checkBoxApproved.Name = "checkBoxApproved";
            this.checkBoxApproved.Size = new System.Drawing.Size(104, 24);
            this.checkBoxApproved.TabIndex = 3098;
            this.checkBoxApproved.Text = "Approved";
            this.checkBoxApproved.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = true;
            this.btnDel.Image = global::AryuwatSystem.Properties.Resources.x_256;
            this.btnDel.Location = new System.Drawing.Point(12, 420);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(51, 58);
            this.btnDel.TabIndex = 3099;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ListOrder";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 20;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ราคา";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // popRefundReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 480);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.checkBoxApproved);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popRefundReq";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Refund Req";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.popRefundReq_FormClosing);
            this.Load += new System.EventHandler(this.popRefundReq_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelBankDetail.ResumeLayout(false);
            this.panelBankDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelShow;
        private UserControls.TextboxFormatDouble textboxFormatDoubleRefund;
        private System.Windows.Forms.MaskedTextBox txtRefundDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRefundSince;
        private System.Windows.Forms.TextBox txtPayCustName;
        private System.Windows.Forms.TextBox txtPayBankNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.TextBox txtConsult;
        private System.Windows.Forms.TextBox txtCustname;
        private System.Windows.Forms.DataGridView dataGridViewSelectList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxMoneyType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelSO;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox comboBoxBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel panelBankDetail;
        private System.Windows.Forms.ComboBox comboBoxByDr;
        private System.Windows.Forms.CheckBox checkBoxApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceAfterDis;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtRFD;
        private System.Windows.Forms.Label label11;
    }
}