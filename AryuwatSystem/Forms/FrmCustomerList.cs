using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Properties;
using WeifenLuo.WinFormsUI.Docking;
using Entity;
using AryuwatSystem.Forms.FRMReport;
using RDNIDWRAPPER;

namespace AryuwatSystem.Forms
{
    public partial class FrmCustomerList : DockContent, IForm
    {
        public FrmCustomerList()
        {
            InitializeComponent();
        }

        SmardCard_FIELD SmardCard;
        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            DeleteData();
        }

        void IForm.IsRefresh()
        {
            BindDataCustomer(1);
        }

        void IForm.IsEdit()
        {
            CallForm(CallMode.Update);
        }

        void IForm.IsPrint()
        {

            PrintReport();
          
        }

        void IForm.IsNew()
        {
            NewCustomer();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        #region Private Member
        /// <summary>
        /// CNL (Local) CNA (Agency) และ CNM (Manager)  
        /// </summary>
        public string TypeCustomer { get; set; }
        private int rowIndex = 0;
        private int pIntseq = 1;
        DataTable dtCn = new DataTable();
        //private string customerID;
        #endregion
        #region Propertie
        //public string CustomerID
        //{
        //    get { return customerID(); }
        //    set { customerID = value; }

        //}
        #endregion

        private void NewCustomer()
        {
            //Statics.frmCustormerSetting = new FrmCustomerSetting();
            //Statics.frmCustormerSetting.BackColor = Color.FromArgb(255, 230, 217);
            //Statics.frmCustormerSetting.Text = Text + Statics.StrAdd;
            //Statics.frmCustormerSetting.Show(Statics.frmMain.dockPanel1);
            PopTypeCustomer obj = new PopTypeCustomer();
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.BackColor = Color.FromArgb(255, 230, 217);
            obj.ShowDialog();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            InitialControls();
            BindDataCustomer(1);
            if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
            {
                menuDel.Visible = false;
            }
            else
            {
                menuDel.Visible = true;
            }
        }

        private void InitialControls()
        {
            SetColumns();
            AddEvent();
        }


        private void PrintReport()
        {
            var info = new Entity.Customer();
            if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
            {
                info.CN = "%" + txtCN.Text + "%";
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                info.TName = "%" + txtName.Text + "%";
            }
            if (!string.IsNullOrEmpty(txtSurname.Text.Trim()))
            {
                info.TSurname = "%" + txtSurname.Text + "%";
            }
            if (!string.IsNullOrEmpty(txtMobile.Text.Trim()))
            {
                info.Mobile1 = "%" + txtMobile.Text + "%";
            }
            DataSet ds = new Business.Customer().SelectCustomerWhereCause(info);

            FrmPreviewRpt obj = new FrmPreviewRpt();
            obj.FormName = "RptCustomerList";
            obj.DataSetReport = ds;
            obj.MaximizeBox = true;
            obj.ShowDialog();
        }

        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvData);
            //dgvData.Columns.Add("CN", "CN");
            dgvData.Columns.Add("CN", "CN");
            dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
            dgvData.Columns.Add("FullNameEng", "Name-Surname");
            dgvData.Columns.Add("Gender", "Gender (เพศ)");
            dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
            dgvData.Columns.Add("Branch", "สาขา");
            dgvData.Columns.Add("Print", "Print");
            dgvData.Columns.Add("MemID", "MemID");

            //dgvData.Columns["CN"].Visible = false;

            dgvData.Columns["CN"].Width = 100;
            dgvData.Columns["FullNameThai"].Width = 150;
            dgvData.Columns["FullNameEng"].Width = 100;
            dgvData.Columns["Gender"].Width = 80;
            dgvData.Columns["Mobile"].Width = 100;
            dgvData.Columns["Branch"].Width = 100;
            dgvData.Columns["Print"].Width = 100;
            //dgvData.Columns["Address"].Width = 300;

        }

        private void AddEvent()
        {
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;

            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            buttonFind.BtnClick += buttonFind_BtnClick;
            btnRefresh.BtnClick += btnRefresh_BtnClick;
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(FrmCustomerList_KeyPress);
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
        }


        #region Event
        private void ngbMain_MoveFirst()
        {
            BindDataCustomer(1);
        }

        private void ngbMain_MoveLast()
        {
            BindDataCustomer(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindDataCustomer(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindDataCustomer(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void SetNumberAllRows()
        {
            long rowStart = (DerUtility.ROW_PER_PAGE * (pIntseq - 1));
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                rowStart += 1;
                dgvData.Rows[i].HeaderCell.Value = rowStart.ToString();
            }
        }

        private void buttonFind_BtnClick()
        {
            BindDataCustomer(1);
        }

        void btnRefresh_BtnClick()
        {
            txtCN.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtMobile.Text = "";
        }

        void FrmCustomerList_KeyPress(object sender, KeyPressEventArgs e)
        {
            DerUtility.SendKey(e.KeyChar);
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                if (e.Button == MouseButtons.Right)
                {
                    dgvData.ClearSelection();
                    //dgvData.Rows[rowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    contextMenuStrip1.Show(MousePosition);
                }
            }
            catch
            {
                return;
            }
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            CallForm(CallMode.Update);
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            CallForm(CallMode.Preview);
        }

        private void menuDel_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        #endregion

        public void BindDataCustomer(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                var info = new Entity.Customer { PageNumber = _pIntseq };
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    info.TName = "%" + txtName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSurname.Text.Trim()))
                {
                    info.TSurname = "%" + txtSurname.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtMobile.Text.Trim()))
                {
                    info.Mobile1 = "%" + txtMobile.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtIDCard.Text.Trim()))
                {
                    info.IdCard = "%" + txtIDCard.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtMemID.Text.Trim()))
                {
                    info.MemID = "%" + txtMemID.Text + "%";
                }
                
                DateTime date;
                if (DateTime.TryParse(txtBirthDate.Text, out date))
                {
                    info.DateBirthOther = AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtBirthDate.Text) ;
                    
                }

                info.BranchId = uBranch1.BranchId;

                dtCn = new Business.Customer().SelectCustomerPaging(info).Tables[0];

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dtCn.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dtCn.DefaultView)
                {
                    var myItems = new[]
                                      {
                                          //item["CN"] + "",
                                          item["CN"]+"",
                                          item["FullNameThai"] + "",
                                          item["FullNameEng"] + "",
                                          item["gender"] + "" ,
                                          item["Mobile"] + "",
                                          item["BranchName"] + "",
                                          item["BranchCust"] + "",
                                          item["MemID"] + ""
                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }

                //dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                //for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                //{
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //}
                //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //for (int i = 0; i < dgvData.Columns.Count; i++)
                //{
                //    int colw = dgvData.Columns[i].Width;
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    dgvData.Columns[i].Width = colw;
                //}
                dgvData.Columns["Branch"].Width = 300;
                ngbMain.CurrentPage = _pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
                SetNumberAllRows();
            }
        }

        private void CallForm(CallMode cMode)
        {
            Statics.frmCustormerSetting = new FrmCustomerSetting();
            //Statics.frmCustormerSetting.StartPosition = FormStartPosition.CenterScreen;
            //Statics.frmCustormerSetting.WindowState = FormWindowState.Maximized;
            //Statics.frmCustormerSetting.MdiParent = ActiveForm;
            if (cMode == CallMode.Preview)
            {
                Statics.frmCustormerSetting.FormType = DerUtility.AccessType.DisplayOnly;
                Statics.frmCustormerSetting.Text = Text+ Statics.StrPreview ;
            }
            else if (cMode == CallMode.Update)
            {
                Statics.frmCustormerSetting.FormType = DerUtility.AccessType.Update;
                Statics.frmCustormerSetting.Text = Text + Statics.StrEdit;
            }

            Statics.frmCustormerSetting.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
           
            Statics.frmCustormerSetting.BackColor = Color.FromArgb(255, 230, 217);
            Statics.frmCustormerSetting.Show(Statics.frmMain.dockPanel1);
        }

        private void DeleteData()
        {
            try
            {

         
            //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
            //{
            if (dgvData.CurrentRow.Index == -1) return;

            if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
            {
                //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่สามารถลบรายการนี้ได้เนื่องจาก มีการใช้หรือชำระเงินไปแล้ว\"Cannot delete.\"");
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Is not admin");
                return;
            }

            if (
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete +  dgvData.CurrentRow.Cells["CN"].Value + "") ==
                DialogResult.Yes)
            {
                try
                {
                    var info = new Entity.Customer();
                    info.CN = dgvData.CurrentRow.Cells["CN"].Value + "";
                    info.EN = Userinfo.EN;
                    if (new Business.Customer().DeleteCustomerById(info) > -1)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                        BindDataCustomer(1);
                    }
                }
                catch (Exception ex)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCustomerList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCustomerList = null;
        }

        private void FrmCustomerList_Activated(object sender, EventArgs e)
        {
            Statics.SetToolbar(true, true, true, true, true);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            rowIndex = e.RowIndex;
            CallForm(CallMode.Update);
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

        private void txtCN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataCustomer(1);
        }

        private void txtName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataCustomer(1);
        }

        private void txtMobile_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataCustomer(1);
        }

        private void txtSurname_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataCustomer(1);
        }

        private void btnRefresh_BtnClick_1()
        {
            //FrmLabelPA Flb = new FrmLabelPA();
            //Flb.ShowDialog();
        }

        private void printLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                //RowFilter rf = dtCn.DefaultView.RowFilter = string.Format("[CN] LIKE '%{0}%'", dgvData.CurrentRow.Cells["CN"].Value + "");

                DataView dataView = dtCn.DefaultView;
                dataView.RowFilter = string.Format("[CN] LIKE '%{0}%'", dgvData.Rows[rowIndex].Cells["CN"].Value + "");
                //dataView.RowFilter = string.Format("[CN] = '{0}' or [CN] = '{1}' or [CN] = '{2}'", "CNT56001268", "CNA60070053", "CNT60070071");




                DataTable data = dataView.ToTable();
         
                DateTime ToDate = DateTime.Now;
                try
                {
                    DateDifference dDiff = new DateDifference(Convert.ToDateTime(dataView.ToTable().Rows[0]["DateBirth"].ToString()), ToDate);
                    data.Rows[0]["age"] = dDiff;
                }
                catch (Exception)
                {
                    data.Rows[0]["age"] = "";
                   
                }
                
              
                
                var t = new TextPrompt("");
                t.ShowDialog();
                int numberCopy = 1;
                numberCopy =Convert.ToInt16(t.Value);
                if (numberCopy == 0) return;
                if (numberCopy > 1)
                {
                    for (int i = 0; i < numberCopy-1; i++)
                    {
                        DataRow dr = data.NewRow();
                        dr=data.Rows[0];
                        data.ImportRow(dr);
                    }
                }

                FrmPreviewRpt2Page obj = new FrmPreviewRpt2Page();
                //obj.FormName = "RptLabel3x2cm_1x";
                obj.FormName = "RptLabel6x3cm_1x";
                
                obj.dt = data;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void beforAfterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PopBeforAfterList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopBeforAfterList()
        {
            try 
	        {
                SwitchImageDuringZoomDemoForm frm = new SwitchImageDuringZoomDemoForm();
                frm.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                frm.ShowDialog();
                //FrmBeforAfterList frm = new FrmBeforAfterList();
                //frm.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                ////frm.VN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                //frm.ShowDialog();
	        }
	      catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void opdScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void oPDScanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                string CN_name = dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "";
                DataSet ds = new Business.Customer().SelectCustomerOpdScan(CN);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    popFileScanOPD pop = new popFileScanOPD();
                    pop.dtFileOPD = ds.Tables[0];
                    pop.CN = CN;
                    pop.CN_Name = CN_name;
                    pop.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No file scan.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCN_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtMobile_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtBirthDate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }

        private void txtSurname_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }

        private void checkCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCheckCourseList frm = new FrmCheckCourseList();
                //Statics.frmPersonnelSetting.Show(Statics.frmMain.dockPanel1);
                //FrmServiceReq frm = new FrmServiceReq();
                frm.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                frm.CustName = dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "";
                frm.Show(Statics.frmMain.dockPanel1);

                //if (Statics.frmServiceReq == null)
                //    {
                //        Statics.frmServiceReq = new FrmServiceReq();
                //        {
                //            Statics.frmServiceReq.BackColor = Color.FromArgb(255, 230, 217);
                //        };
                //        Statics.frmServiceReq.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                //        Statics.frmServiceReq.CustName = dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "";
                //        Statics.frmServiceReq.Show(Statics.frmMain.dockPanel1);
                //    }
                //    else
                //    {
                //        Statics.frmCustomerList.BringToFront();
                //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
        public byte[] String2Byte(string s)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.GetEncoding(874);
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            return asciiBytes;
        }
        private void ListCardReader()
        {
            byte[] szReaders = new byte[1024 * 2];
            int size = szReaders.Length;
            int numreader = RDNID.getReaderListRD(szReaders, size);
            if (numreader <= 0)
                return;
            String s = aByteToString(szReaders);
            String[] readlist = s.Split(';');
            if (readlist != null)
            {
                for (int i = 0; i < readlist.Length; i++)
                    m_ListReaderCard.Items.Add(readlist[i]);
                m_ListReaderCard.SelectedIndex = 0;
            }
        }

        public string aByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;

            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }
        private bool InitSamrtCard()
        {
            bool deviceOK = false;
            try
            {
                string fileName = Application.StartupPath + "\\RDNIDLib.DLD";
                if (System.IO.File.Exists(fileName) == false)
                {
                    MessageBox.Show("RDNIDLib.DLD not found");
                }

                System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                //this.Text = String.Format("R&D NID Card Plus C# {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
                byte[] _lic = String2Byte(fileName);

                int nres = 0;
                nres = RDNID.openNIDLibRD(_lic);
                if (nres != 0)
                {
                    String m;
                    m = String.Format(" error no {0} ", nres);
                    MessageBox.Show(m);
                }

                byte[] Licinfo = new byte[1024];

                RDNID.getLicenseInfoRD(Licinfo);
                string xx = aByteToString(Licinfo);

                byte[] Softinfo = new byte[1024];
                RDNID.getSoftwareInfoRD(Softinfo);
                string m_lblSoftwareInfo = aByteToString(Softinfo);

                ListCardReader();
                AryuwatSystem.Class.SmartCardReader sr = new Class.SmartCardReader();
                sr.SmardDevice = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);
                //SmardCard = sr.ReadCard();
                if (sr.SmardDevice.Length > 20)
                {
                    pictureBoxReadCard.Image = AryuwatSystem.Properties.Resources.smart_card_reader;
                    deviceOK = true;
                }
                else
                {
                    pictureBoxReadCard.Image = AryuwatSystem.Properties.Resources.smart_card_readerReload;
                    //MessageBox.Show("Connect SmartCard device.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    deviceOK = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return deviceOK;
        }
        private void pictureBoxReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (InitSamrtCard() == false)
                {
                    MessageBox.Show("Connect SmartCard device.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                AryuwatSystem.Class.SmartCardReader sr = new Class.SmartCardReader();
                sr.SmardDevice = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);

                try
                {
                    SmardCard = sr.ReadCard();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please insert ID card.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }


                //MessageBox.Show(SmardCard.NID_Number);

                //var callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ////picCustImage.Image =        SmardCard.MyImage.GetThumbnailImage(200, 300, callback, IntPtr.Zero);
                //picCustImage.Image = SmardCard.MyImage;


                ////_imagePaht = string.Format(@"{0}\Customers\Smartcard\{1}\{2}", Application.StartupPath, cn, cn);
                //ImageFormat format = ImageFormat.Jpeg;
                //_imagePaht = string.Format(@"{0}\Customers\Smartcard\{1}.{2}", Application.StartupPath, cn, format.ToString());
                //string path = string.Format(@"{0}\Customers\Smartcard\", Application.StartupPath);
                //if (!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}

                //SaveImage(imageToByteArray(SmardCard.MyImage));
                txtIDCard.Text = SmardCard.NID_Number;
                BindDataCustomer(1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labelยาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow.Index <0 ) return;

                List<Entity.MedicalSupplies> listSelectADD = new List<MedicalSupplies>();
                DataTable tableeat = new DataTable();
                DataTable tablecoat = new DataTable();

                popSearchSelectPA pop = new popSearchSelectPA();
                string nm = (dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "").Length > 10 ? dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "" : dgvData.Rows[rowIndex].Cells["FullNameEng"].Value + "";
                string cn= dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                pop.CustName = nm;
                //EK-CNA59090058
                string st = cn.Substring(2, 3);
                pop.customerType = st;
                pop.Text = string.Format("{0} ({1}){2}", pop.Text, cn, nm);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    listSelectADD = pop.listSelectADD;
                }

                if (!listSelectADD.Any()) return;

                tableeat.Columns.Add("PHName", typeof(string));
                tableeat.Columns.Add("CN", typeof(string));
                tableeat.Columns.Add("CustName", typeof(string));
                tableeat.Columns.Add("Amount", typeof(string));
                tableeat.Columns.Add("Perday", typeof(string));
                tableeat.Columns.Add("BeforeMeals", typeof(string));
                tableeat.Columns.Add("AfterMeals", typeof(string));
                tableeat.Columns.Add("Morning", typeof(string));
                tableeat.Columns.Add("Lunch", typeof(string));
                tableeat.Columns.Add("Evening", typeof(string));
                tableeat.Columns.Add("BeforeBed", typeof(string));
                tableeat.Columns.Add("Everyhours", typeof(string));
                tableeat.Columns.Add("eat", typeof(string));
                tableeat.Columns.Add("coat", typeof(string));
                tableeat.Columns.Add("coatArea", typeof(string));

                tablecoat.Columns.Add("PHName", typeof(string));
                tablecoat.Columns.Add("CN", typeof(string));
                tablecoat.Columns.Add("CustName", typeof(string));
                tablecoat.Columns.Add("Amount", typeof(string));
                tablecoat.Columns.Add("Perday", typeof(string));
                tablecoat.Columns.Add("BeforeMeals", typeof(string));
                tablecoat.Columns.Add("AfterMeals", typeof(string));
                tablecoat.Columns.Add("Morning", typeof(string));
                tablecoat.Columns.Add("Lunch", typeof(string));
                tablecoat.Columns.Add("Evening", typeof(string));
                tablecoat.Columns.Add("BeforeBed", typeof(string));
                tablecoat.Columns.Add("Everyhours", typeof(string));
                tablecoat.Columns.Add("eat", typeof(string));
                tablecoat.Columns.Add("coat", typeof(string));
                tablecoat.Columns.Add("coatArea", typeof(string));


                    foreach (MedicalSupplies item in listSelectADD)
                    {
                        if(item.coat=="Y")
                            tablecoat.Rows.Add(item.MS_Name, cn, nm, item.EatAmount, item.EatPerday, item.BeforeMeals, item.AfterMeals, item.Morning, item.Lunch, item.Evening, item.BeforeBed, item.Everyhours, item.eat, item.coat, item.coatArea);
                    }

                    foreach (MedicalSupplies item in listSelectADD)
                    {
                        if (item.eat == "Y")
                            tableeat.Rows.Add(item.MS_Name, cn, nm, item.EatAmount, item.EatPerday, item.BeforeMeals, item.AfterMeals, item.Morning, item.Lunch, item.Evening, item.BeforeBed, item.Everyhours, item.eat, item.coat, item.coatArea);
                    }

                    if (tableeat.Rows.Count > 0) //eat
                    {
                        FrmPreviewRpt2Page obj1 = new FrmPreviewRpt2Page();
                        obj1.Text = "ปริ้นยากิน";
                        if (pop.PrintEng)
                            obj1.FormName = "rtpLabelPA_E";
                        else
                            obj1.FormName = "rtpLabelPA";

                        obj1.dt = tableeat;
                        obj1.MaximizeBox = true;
                        obj1.TopMost = false;
                        obj1.Show();
                    }
                    if (tablecoat.Rows.Count > 0)//coat
                    {
                        FrmPreviewRpt2Page obj2 = new FrmPreviewRpt2Page();
                        obj2.Text = "ปริ้นยาทา";
                        if (pop.PrintEng)
                            obj2.FormName = "rtpLabelPA_coat_E";
                        else
                            obj2.FormName = "rtpLabelPA_coat";

                        obj2.dt = tablecoat;
                        obj2.MaximizeBox = true;
                        obj2.TopMost = false;
                        obj2.Show();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void memberCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                popAddMemberCard pop = new popAddMemberCard();
                pop.CustomerShow = (dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "").Length > 10 ? dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "" : dgvData.Rows[rowIndex].Cells["FullNameEng"].Value + "";
                pop.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                pop.OldMemID = dgvData.Rows[rowIndex].Cells["MemID"].Value + "";
                pop.CustomerShow += "(" + pop.CN + ")";
               pop.ShowDialog() ;
               dgvData.Rows[rowIndex].Cells["MemID"].Value = pop.newMemID;
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMemID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataCustomer(1);
        }

        private void printLabelForSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                //RowFilter rf = dtCn.DefaultView.RowFilter = string.Format("[CN] LIKE '%{0}%'", dgvData.CurrentRow.Cells["CN"].Value + "");

                DataView dataView = dtCn.DefaultView;
                dataView.RowFilter = string.Format("[CN] LIKE '%{0}%'", dgvData.Rows[rowIndex].Cells["CN"].Value + "");
                //dataView.RowFilter = string.Format("[CN] = '{0}' or [CN] = '{1}' or [CN] = '{2}'", "CNT56001268", "CNA60070053", "CNT60070071");




                DataTable data = dataView.ToTable();

                DateTime ToDate = DateTime.Now;
                try
                {
                    DateDifference dDiff = new DateDifference(Convert.ToDateTime(dataView.ToTable().Rows[0]["DateBirth"].ToString()), ToDate);
                    data.Rows[0]["age"] = dDiff;
                }
                catch (Exception)
                {
                    data.Rows[0]["age"] = "";

                }



                var t = new TextPrompt("");
                t.ShowDialog();
                int numberCopy = 1;
                numberCopy = Convert.ToInt16(t.Value);
                if (numberCopy == 0) return;
                if (numberCopy > 1)
                {
                    for (int i = 0; i < numberCopy - 1; i++)
                    {
                        DataRow dr = data.NewRow();
                        dr = data.Rows[0];
                        data.ImportRow(dr);
                    }
                }

                FrmPreviewRpt2Page obj = new FrmPreviewRpt2Page();
                //obj.FormName = "RptLabel3x2cm_1x";
                obj.FormName = "RptLabel6x3cm_1xForSale";

                obj.dt = data;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
