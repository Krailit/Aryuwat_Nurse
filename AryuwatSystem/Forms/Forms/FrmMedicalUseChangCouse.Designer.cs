using System.Windows.Forms;
using DermasterSystem.UserControls;
using System.ComponentModel;
using System.Data;
using DermasterSystem.Data;
using System.Collections.Generic;
using System.Drawing;
using System;
namespace DermasterSystem.Forms
{
    partial class FrmMedicalUseChangCouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicalUseChangCouse));
            this.dataGridViewSelectList = new System.Windows.Forms.DataGridView();
            this.panelName = new System.Windows.Forms.Panel();
            this.txtCustomerName = new System.Windows.Forms.Label();
            this.labelCN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMO = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalanceRef = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsedTrans = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.radioButtonUse = new System.Windows.Forms.RadioButton();
            this.radioButtonPay = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbalances = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewMedPriceTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPriceTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNewMO = new System.Windows.Forms.TextBox();
            this.buttonNewMO = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddDown = new DermasterSystem.UserControls.ButtonRigth();
            this.buttonDeleteUp = new DermasterSystem.UserControls.ButtonLeft();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).BeginInit();
            this.panelName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSelectList
            // 
            this.dataGridViewSelectList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSelectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewSelectList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSelectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSelectList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewSelectList.Location = new System.Drawing.Point(0, 47);
            this.dataGridViewSelectList.Name = "dataGridViewSelectList";
            this.dataGridViewSelectList.ReadOnly = true;
            this.dataGridViewSelectList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewSelectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewSelectList.Size = new System.Drawing.Size(952, 189);
            this.dataGridViewSelectList.TabIndex = 151;
            this.dataGridViewSelectList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellClick);
            this.dataGridViewSelectList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellContentClick);
            this.dataGridViewSelectList.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseMove);
            this.dataGridViewSelectList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewSelectList_CellPainting);
            this.dataGridViewSelectList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
            // 
            // panelName
            // 
            this.panelName.Controls.Add(this.txtCustomerName);
            this.panelName.Controls.Add(this.labelCN);
            this.panelName.Controls.Add(this.label3);
            this.panelName.Controls.Add(this.lbMO);
            this.panelName.Controls.Add(this.label2);
            this.panelName.Controls.Add(this.label1);
            this.panelName.Controls.Add(this.txtBalanceRef);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(952, 47);
            this.panelName.TabIndex = 152;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AutoSize = true;
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(316, 6);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(83, 19);
            this.txtCustomerName.TabIndex = 142;
            this.txtCustomerName.Text = "ชื่อลูกค้า :";
            this.txtCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCN
            // 
            this.labelCN.AutoSize = true;
            this.labelCN.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelCN.Location = new System.Drawing.Point(317, 27);
            this.labelCN.Name = "labelCN";
            this.labelCN.Size = new System.Drawing.Size(43, 18);
            this.labelCN.TabIndex = 150;
            this.labelCN.Text = "CN : ";
            this.labelCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 154;
            this.label3.Text = "MO : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMO
            // 
            this.lbMO.AutoSize = true;
            this.lbMO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMO.Location = new System.Drawing.Point(56, 9);
            this.lbMO.Name = "lbMO";
            this.lbMO.Size = new System.Drawing.Size(51, 19);
            this.lbMO.TabIndex = 153;
            this.lbMO.Text = "MO : ";
            this.lbMO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 152;
            this.label2.Text = "ชื่อลูกค้า :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(277, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 151;
            this.label1.Text = "CN : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBalanceRef
            // 
            this.txtBalanceRef.BackColor = System.Drawing.Color.Black;
            this.txtBalanceRef.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtBalanceRef.Location = new System.Drawing.Point(969, 3);
            this.txtBalanceRef.Name = "txtBalanceRef";
            this.txtBalanceRef.Size = new System.Drawing.Size(141, 27);
            this.txtBalanceRef.TabIndex = 147;
            this.txtBalanceRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceRef.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(620, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 27);
            this.label4.TabIndex = 270;
            this.label4.Text = "มูลค่ารวม :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsedTrans);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 497);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "สรุปการเปลี่ยนหรือยกเลิกคอร์ส";
            // 
            // dgvUsedTrans
            // 
            this.dgvUsedTrans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsedTrans.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvUsedTrans.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsedTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsedTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsedTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsedTrans.Location = new System.Drawing.Point(3, 45);
            this.dgvUsedTrans.Name = "dgvUsedTrans";
            this.dgvUsedTrans.ReadOnly = true;
            this.dgvUsedTrans.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvUsedTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUsedTrans.Size = new System.Drawing.Size(946, 246);
            this.dgvUsedTrans.TabIndex = 283;
            this.dgvUsedTrans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsedTrans_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtRemark);
            this.panel3.Controls.Add(this.radioButtonUse);
            this.panel3.Controls.Add(this.radioButtonPay);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtbalances);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtNewMedPriceTotal);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtPriceTotal);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtNewMO);
            this.panel3.Controls.Add(this.buttonNewMO);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 291);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(946, 203);
            this.panel3.TabIndex = 282;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(52, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(196, 19);
            this.label12.TabIndex = 296;
            this.label12.Text = "สาเหตุการยกเลิกเนื่องจาก";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtRemark.Location = new System.Drawing.Point(57, 136);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(435, 58);
            this.txtRemark.TabIndex = 295;
            // 
            // radioButtonUse
            // 
            this.radioButtonUse.AutoSize = true;
            this.radioButtonUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.radioButtonUse.Location = new System.Drawing.Point(279, 83);
            this.radioButtonUse.Name = "radioButtonUse";
            this.radioButtonUse.Size = new System.Drawing.Size(225, 28);
            this.radioButtonUse.TabIndex = 294;
            this.radioButtonUse.Text = "เก็บไว้หักกับบริการครั้งต่อไป";
            this.radioButtonUse.UseVisualStyleBackColor = true;
            this.radioButtonUse.CheckedChanged += new System.EventHandler(this.radioButtonUse_CheckedChanged);
            // 
            // radioButtonPay
            // 
            this.radioButtonPay.AutoSize = true;
            this.radioButtonPay.Checked = true;
            this.radioButtonPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.radioButtonPay.Location = new System.Drawing.Point(53, 83);
            this.radioButtonPay.Name = "radioButtonPay";
            this.radioButtonPay.Size = new System.Drawing.Size(226, 28);
            this.radioButtonPay.TabIndex = 293;
            this.radioButtonPay.TabStop = true;
            this.radioButtonPay.Text = "ลดหนี้โดยจ่ายคืนเป็นเงินสด";
            this.radioButtonPay.UseVisualStyleBackColor = true;
            this.radioButtonPay.CheckedChanged += new System.EventHandler(this.radioButtonPay_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(656, 163);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 38);
            this.btnSave.TabIndex = 292;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(771, 163);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 38);
            this.btnCancel.TabIndex = 291;
            this.btnCancel.Text = "ปิด";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(639, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 27);
            this.label11.TabIndex = 290;
            this.label11.Text = "ยอดรวม :";
            // 
            // txtbalances
            // 
            this.txtbalances.BackColor = System.Drawing.Color.Black;
            this.txtbalances.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtbalances.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtbalances.Location = new System.Drawing.Point(748, 85);
            this.txtbalances.Name = "txtbalances";
            this.txtbalances.Size = new System.Drawing.Size(115, 33);
            this.txtbalances.TabIndex = 289;
            this.txtbalances.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(863, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 27);
            this.label7.TabIndex = 288;
            this.label7.Text = "บาท";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(555, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 27);
            this.label8.TabIndex = 287;
            this.label8.Text = "จ่ายเพิ่ม(คืนเงิน) :";
            // 
            // txtNewMedPriceTotal
            // 
            this.txtNewMedPriceTotal.BackColor = System.Drawing.Color.Black;
            this.txtNewMedPriceTotal.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtNewMedPriceTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtNewMedPriceTotal.Location = new System.Drawing.Point(748, 46);
            this.txtNewMedPriceTotal.Name = "txtNewMedPriceTotal";
            this.txtNewMedPriceTotal.Size = new System.Drawing.Size(115, 33);
            this.txtNewMedPriceTotal.TabIndex = 286;
            this.txtNewMedPriceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(863, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 27);
            this.label5.TabIndex = 285;
            this.label5.Text = "บาท";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(452, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(296, 27);
            this.label6.TabIndex = 284;
            this.label6.Text = "หัก มูลค่าสินค้า/บริการใหม่ :";
            // 
            // txtPriceTotal
            // 
            this.txtPriceTotal.BackColor = System.Drawing.Color.Black;
            this.txtPriceTotal.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtPriceTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPriceTotal.Location = new System.Drawing.Point(748, 7);
            this.txtPriceTotal.Name = "txtPriceTotal";
            this.txtPriceTotal.Size = new System.Drawing.Size(115, 33);
            this.txtPriceTotal.TabIndex = 283;
            this.txtPriceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(863, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 27);
            this.label13.TabIndex = 282;
            this.label13.Text = "บาท";
            // 
            // txtNewMO
            // 
            this.txtNewMO.BackColor = System.Drawing.Color.Black;
            this.txtNewMO.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtNewMO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtNewMO.Location = new System.Drawing.Point(173, 44);
            this.txtNewMO.Name = "txtNewMO";
            this.txtNewMO.Size = new System.Drawing.Size(175, 33);
            this.txtNewMO.TabIndex = 279;
            this.txtNewMO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonNewMO
            // 
            this.buttonNewMO.ImageIndex = 5;
            this.buttonNewMO.ImageList = this.imageList1;
            this.buttonNewMO.Location = new System.Drawing.Point(346, 43);
            this.buttonNewMO.Name = "buttonNewMO";
            this.buttonNewMO.Size = new System.Drawing.Size(43, 35);
            this.buttonNewMO.TabIndex = 281;
            this.buttonNewMO.UseVisualStyleBackColor = true;
            this.buttonNewMO.Click += new System.EventHandler(this.buttonNewMO_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chief_of_staff_add_128.png");
            this.imageList1.Images.SetKeyName(1, "chief_of_staff_write_128.png");
            this.imageList1.Images.SetKeyName(2, "delete_256ssss_black.png");
            this.imageList1.Images.SetKeyName(3, "progress_notes_ok_128.png");
            this.imageList1.Images.SetKeyName(4, "progress_notes_add_128.png");
            this.imageList1.Images.SetKeyName(5, "loupe_256ssss.png");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(48, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 27);
            this.label10.TabIndex = 280;
            this.label10.Text = "อ้างอิง MO :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(51, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(294, 27);
            this.label9.TabIndex = 278;
            this.label9.Text = "เปลี่ยนเป็นสินค้า/บริการใหม่";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonAddDown);
            this.panel2.Controls.Add(this.buttonDeleteUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 29);
            this.panel2.TabIndex = 282;
            // 
            // buttonAddDown
            // 
            this.buttonAddDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddDown.Location = new System.Drawing.Point(602, 2);
            this.buttonAddDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonAddDown.Name = "buttonAddDown";
            this.buttonAddDown.Size = new System.Drawing.Size(30, 26);
            this.buttonAddDown.TabIndex = 148;
            this.buttonAddDown.BtnClick += new DermasterSystem.UserControls.ButtonRigth.ButtonClick(this.buttonAddDown_BtnClick);
            // 
            // buttonDeleteUp
            // 
            this.buttonDeleteUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteUp.Location = new System.Drawing.Point(568, 2);
            this.buttonDeleteUp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonDeleteUp.Name = "buttonDeleteUp";
            this.buttonDeleteUp.Size = new System.Drawing.Size(30, 26);
            this.buttonDeleteUp.TabIndex = 149;
            this.buttonDeleteUp.BtnClick += new DermasterSystem.UserControls.ButtonLeft.ButtonClick(this.buttonDeleteUp_BtnClick);
            // 
            // FrmMedicalUseChangCouse
            // 
            this.ClientSize = new System.Drawing.Size(952, 733);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewSelectList);
            this.Controls.Add(this.panelName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "FrmMedicalUseChangCouse";
            this.Text = "เปลี่ยนหรือยกเลิกคอร์ส";
            this.Load += new System.EventHandler(this.FrmMedicalUseChangCouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).EndInit();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private ButtonRigth buttonAddDown;
        private ButtonLeft buttonDeleteUp;
        private Button buttonNewMO;
      
        public string customerType;
        private DataGridView dataGridViewSelectList;
        private DataGridView dgvUsedTrans;
        private DataSet ds;
        private DataTable dtCust;
        private DataTable dtDoc;
        private DataTable dtStuff;
        private DataTable dtSup;
        private GroupBox groupBox1;
        //private ImageList imageList1;
        private Entity.MedicalOrderUseTrans Info;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelCN;
        private Label lbMO;
        private List<MedicalOrderUseTrans> listMS_Code;
        private Panel panel2;
        private Panel panel3;
        private Panel panelName;
        public decimal PriceNewBalance;
        public decimal PriceNewVN;
        public decimal PriceTotal;
        private RadioButton radioButtonPay;
        private RadioButton radioButtonUse;
        private List<DataGridViewRow> rowsToDelete;
        internal TextBox txtBalanceRef;
        private TextBox txtbalances;
        private Label txtCustomerName;
        private TextBox txtNewMedPriceTotal;
        private TextBox txtNewMO;
        private TextBox txtPriceTotal;
        private TextBox txtRemark;
        private ImageList imageList1;


    }
}