using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace AryuwatSystem.Forms
{
    public partial class FrmFreeComplication : DockContent
    {
        private Entity.GiftVoucher_Barter info;
        public DerUtility.AccessType FormType { get; set; }
        public string ApploveID1="";
        public string ApploveID2 = "";
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        private int pIntseq = 1;
        public string Sono = "";
        public string VN = "";
        public string CN = "";
        public string CustomerName = "";
        public string MS_Name = "";
        
        public string MS_Code = "";
        public double MS_Price = 0;
        public double Amount = 1;
        public string ListOrder = "";
        bool ISPreview = false;

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        public FrmFreeComplication()
        {
            InitializeComponent();
            //SetColumns();
           
            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmComplication_Closing);
        }


        void FrmComplication_Closing(object sender, CancelEventArgs e)
        {
            //Statics.FrmComplication = null;
        }
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
            SelectApplove();
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            //CallForm(CallMode.Preview);
        }

  


        #endregion

        
        private void buttonCancel_BtnClick()
        {
            Statics.frmFreeComplication = null;
            this.Close();
        }


        public void BindApproveComplication(int _pIntseq)
        {
            try
            {
                DataTable dtmb = Entity.Userinfo.MoConfig.Select("[key]='ApproveComplicationDR'").CopyToDataTable();
                comboBoxApplove1.DataSource = dtmb;
                comboBoxApplove1.ValueMember = "Code";
                comboBoxApplove1.DisplayMember = "values";
                comboBoxApplove1.SelectedValue = ApploveID1;

                DataTable dtmb2 = Entity.Userinfo.MoConfig.Select("[key]='ApproveComplication'").CopyToDataTable();
                comboBoxApplove2.DataSource = dtmb2;
                comboBoxApplove2.ValueMember = "Code";
                comboBoxApplove2.DisplayMember = "values";
                comboBoxApplove2.SelectedValue = ApploveID2;
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                //DerUtility.MouseOff(this);
                return;
            }
            finally
            {
               
            }
        }

        private void SelectApplove()
        {
            try
            {

                if (comboBoxApplove1.SelectedValue + "" == "" || comboBoxApplove2.SelectedValue + ""=="")
                {
                    MessageBox.Show("กรุณา เลือกผู้อนุมัติ ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ApploveID1 = comboBoxApplove1.SelectedValue + "";
                ApploveID2 = comboBoxApplove2.SelectedValue + "";
                
                //this.Close();
                this.Visible = false;
                //MessageBox.Show(Statics.FrmComplication.GiftCode);
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      


        private void btnSelect_Click(object sender, EventArgs e)
        {
                SelectApplove();
        }

        private void FrmComplication_Load(object sender, EventArgs e)
        {
            BindApproveComplication(1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    

        private void comboBoxApplove2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxApplove2.SelectedValue == comboBoxApplove1.SelectedValue)
                {
                    comboBoxApplove2.SelectedValue = ""; 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxApplove1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxApplove2.SelectedValue == comboBoxApplove1.SelectedValue)
                {
                    comboBoxApplove1.SelectedValue = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxApplove1.SelectedValue + "" == "" || comboBoxApplove2.SelectedValue + "" == "")
                {
                    MessageBox.Show("กรุณา เลือกผู้อนุมัติ ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ISPreview = true;
                SignAndSave(ISPreview);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSignature_Click(object sender, EventArgs e)
        {
            if (comboBoxApplove1.SelectedValue + "" == "" || comboBoxApplove2.SelectedValue + "" == "")
            {
                MessageBox.Show("กรุณา เลือกผู้อนุมัติ ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (
       DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "สร้างแบบฟอร์มใหม่/New Paper") == DialogResult.Yes)
            {
                ISPreview = false;
                SignAndSave(ISPreview);
            }
        }

        private void SignAndSave(bool ISPreview)
        {
            try
            {
                string Local_Folder = string.Format(@"{0}\MEDICALDOC\FreeTrans\{1}\", Application.StartupPath, CN);
                string FullPath = Local_Folder + "NewPaper1.pdf";
                string filename = string.Format("{0}_{1}_{2}_{3}.pdf", Sono, VN, MS_Code, ListOrder);
                string path = string.Format(@"{0}\Customers\{1}\", Application.StartupPath, CN);
                string remote_path = string.Format(@"\MEDICALDOC\FreeTrans\{0}\", CN);
                if (!Directory.Exists(Local_Folder)) Directory.CreateDirectory(Local_Folder);//LocalPath
                string saveFullPath = Local_Folder + filename;//Local
                if (File.Exists(saveFullPath)) File.Delete(saveFullPath);
                if (ISPreview && DerClass.DerUtility.DownLoadImage(saveFullPath, remote_path, filename))
                {
                    FullPath = saveFullPath;
                }
                else //new
                {
                    saveFullPath = "";


                    // Step 1: Creating System.IO.FileStream object

                    if (!Directory.Exists(Local_Folder)) Directory.CreateDirectory(Local_Folder);
                    if (File.Exists(FullPath)) File.Delete(FullPath);

                    using (FileStream fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    // Step 2: Creating iTextSharp.text.Document object  Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);


                    using (Document doc = new Document(PageSize.A5.Rotate(), 30f, 10f, 20f, 10f))//PageSize.A4, 0f, 10f, 100f, 0f
                    // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                    // It helps to write the Document to the Specified FileStream


                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        // Step 4: Openning the Document
                        writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;

                        writer.PdfVersion = PdfWriter.VERSION_1_6;
                        writer.SetFullCompression();

                        doc.Open();
                        BaseFont bf = BaseFont.CreateFont(Application.StartupPath + "/THSarabunNew Bold.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                        iTextSharp.text.Font underline = new iTextSharp.text.Font(bf, 24f, 4, BaseColor.BLACK);
                    
                        doc.Add(new Paragraph(this.Text, underline));

                        PdfContentByte cb = writer.DirectContent;
                        // we tell the ContentByte we're ready to draw text
                        cb.BeginText();
                        // we draw some text on a certain position
                        //cb.SetFontAndSize(bf, 24);
                        //cb.SetTextMatrix(30, 390);
                        //cb.ShowText(string.Format("{0}", this.Text));

                        cb.SetFontAndSize(bf, 22);
                        cb.SetTextMatrix(30, 330);
                        cb.ShowText(string.Format("ชื่อลูกค้า {0} ({1})", CustomerName, CN));

                        cb.SetFontAndSize(bf, 14);
                        cb.SetTextMatrix(450, 400);
                        cb.ShowText(string.Format("{0}", Sono));
                        cb.SetFontAndSize(bf, 13);
                        cb.SetTextMatrix(450, 390);
                        cb.ShowText(string.Format("{0}", VN));

                        //cb.SetFontAndSize(bf, 10);
                        //cb.SetTextMatrix(500, 380);
                        //cb.ShowText(string.Format("ซื้อที่/Branch {0}", BranchName));

                        cb.SetFontAndSize(bf, 20);
                        cb.SetTextMatrix(30, 300);
                        cb.ShowText(string.Format("รายการ {0}", MS_Name.Replace("()", "")));//

                        cb.SetTextMatrix(30, 280);
                        cb.ShowText(string.Format("จำนวน    {0}     ราคา    {1}", Amount, (Amount * MS_Price).ToString("###,###,###.##")));///

                   

                        //cb.SetTextMatrix(30, 270);
                        //cb.ShowText(string.Format("หมายเหตุ/Remark      {0}", txtNote.Text));///"Text at position 30,340."
                        //cb.SetTextMatrix(300, 270);
                        //cb.ShowText(string.Format("คงเหลือ/Balance         {0}", ""));//"Text at position 300,340."

                        double TotalAmount = 0;
                        double UsedAmount = 0;
                        double PriceAfterDis = 0;


                        //TotalAmount = dataGridViewSelectList.CurrentRow.Cells["Total"].Value + "" == "" ? 0 : Convert.ToDouble((dataGridViewSelectList.CurrentRow.Cells["Total"].Value + "").Replace(",", ""));
                        //UsedAmount = dgvUsedTrans.CurrentRow.Cells["AmountBalance"].Value + "" == "" ? 0 : Convert.ToDouble((dgvUsedTrans.CurrentRow.Cells["AmountBalance"].Value + "").Replace(",", ""));
                        //PriceAfterDis = dataGridViewSelectList.CurrentRow.Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDouble((dataGridViewSelectList.CurrentRow.Cells["PriceTotal"].Value + "").Replace(",", ""));

                        //if (ProCreditType == false)
                        //    ProCredit = ((PriceAfterDis / TotalAmount) * UsedAmount);


                        //cb.SetTextMatrix(30, 250);
                        //cb.ShowText(string.Format("วงเงินคงเหลือ/Balance(THB)      {0}", ProCredit.ToString("###,###,###,##0.00")));///"Text at position 30,340."


                        //cb.SetFontAndSize(bf, 16);
                        //cb.SetTextMatrix(30, 230);
                        //cb.ShowText(string.Format("วันที่ {0}   อ้างอิงใบยา/Ref.MO {1}   ใช้บริการ/Branch {2}", dgvUsedTrans.Rows[e.RowIndex].Cells["DateOfUse"].Value + "", dgvUsedTrans.Rows[e.RowIndex].Cells["RefMO"].Value + "", dgvUsedTrans.Rows[e.RowIndex].Cells["Branch"].Value + ""));///"Text at position 30,340."
                        ///
                        //===============Line
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextMatrix(30, 80);
                        cb.ShowText("..........................................................................................................................................................................................................................................................................................................................");///"Text at position 30,340."
                                                                                                                                                                                                                                                                                                                                                                  ///
                        cb.SetFontAndSize(bf, 16);
                        cb.SetTextMatrix(30, 60);
                        cb.ShowText(string.Format("อนุมัติโดย/Approve By.  {0}", comboBoxApplove1.Text+"          "+comboBoxApplove2.Text));///"Text at position 30,340."
                        //cb.SetTextMatrix(180, 60);
                        //cb.ShowText(string.Format("{0}", comboBoxApplove2.Text));///"Text at position 30,340."
                                                                                                               ///
                        // we tell the contentByte, we've finished drawing text
                        cb.EndText();

                        doc.Close();
                        //writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);


                        writer.CompressionLevel = 20;// PdfStream.BEST_COMPRESSION;
                        writer.SetFullCompression();


                    }
                }
                if (File.Exists(FullPath))
                {

                    Process.Start(FullPath);
                    Process[] _proceses = null;
                    _proceses = Process.GetProcesses();
                    bool ISClose = true;

                    if (ISPreview == false)
                    {
                        while (ISClose)
                        {
                            ISClose = false;
                            foreach (Process proces in _proceses)
                            {
                                if (proces.ProcessName.Contains("Xodo"))
                                {
                                    ISClose = true;
                                    //Thread.Sleep(10);
                                    Application.DoEvents();
                                }
                            }
                            Application.DoEvents();
                            _proceses = Process.GetProcesses();
                        }
                        FileInfo f = new FileInfo(FullPath);
                        bool sav = false;
                        if (f.Length > 0)
                        {
                            Application.DoEvents();
                            sav = DerClass.DerUtility.SaveImage(FullPath, remote_path, filename);
                        }
                        this.BringToFront();
                        if (sav)
                        {
                            MessageBox.Show("Save complete.");
                        }
                        else MessageBox.Show("Save fail.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

    }
}
