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

namespace AryuwatSystem.Forms
{
    public partial class FrmFreeGiftVoucher : DockContent
    {
        private Entity.GiftVoucher_Barter info;
        public DerUtility.AccessType FormType { get; set; }
        public string GiftCode { get; set; }
        public double PriceCredit { get; set; }
        public string Sono = "";
        public string VN = "";
        public string CN = "";
        public string CustomerName = "";
        public string MS_Name = "";
        public string MS_Code = "";
        public string ListOrder = "";
        bool ISPreview = false;
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        private int pIntseq = 1;
        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        public FrmFreeGiftVoucher()
        {
            InitializeComponent();
            //SetColumns();
            txtFindName.Text = "ค้นหา Voucher อย่างเช่น 001";
            txtFindName.GotFocus += new EventHandler(txtFindName_GotFocus);
            txtFindName.LostFocus += new EventHandler(txtFindName_LostFocus);
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmGiftVoucher_Closing);
        }

        void txtFindName_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (txtFindName.Text == "ค้นหา Voucher อย่างเช่น 001")
                {
                    txtFindName.Text = "";
                }
            }
            catch (Exception)
            {
                
               
            }
    
        }

        void txtFindName_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFindName.Text))
                    txtFindName.Text = "ค้นหา Voucher อย่างเช่น 001";
            
            }
            catch (Exception)
            {
                
               
            }

        }


        void FrmGiftVoucher_Closing(object sender, CancelEventArgs e)
        {
            //Statics.frmGiftVoucher = null;
        }
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
            SelectGift();
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            //CallForm(CallMode.Preview);
        }

        private void menuDel_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    dgvData.ClearSelection();
                    //dgvData.Rows[OldrowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    OldrowIndex = e.RowIndex;
                    contextMenuStrip1.Show(MousePosition);
                }
            }
            catch
            {
                return;
            }
        }
     

        //private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
        //    e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
        //                          e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //}


        #endregion

        private void DeleteData()
        {
            try
            {

         
            if (dgvData.CurrentRow.Index == -1) return;
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["GiftCode"].Value + "") != DialogResult.Yes) return;
            try
            {
                Entity.GiftVoucher_Barter info = new GiftVoucher_Barter();
                info.QueryType = "DeleteGiftVoucher";
                info.GiftCode = dgvData.CurrentRow.Cells["GiftCode"].Value + "";
                int? intStatus = new Business.GiftVoucher_Barter().DeleteGiftVoucher(info);
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                BindGiftVoucher(1);
                
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonCancel_BtnClick()
        {
            Statics.frmFreeGiftVoucher = null;
            this.Close();
        }
 
        public void BindGiftVoucher(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvData.DataSource = null;
                dgvData.Columns.Clear();
                if(dgvData.RowCount>0)
                dgvData.Rows.Clear();
                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                {
                    column.AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.FlatStyle = FlatStyle.Standard;
                    column.ThreeState = false;
                    column.Name = "ChkMove";
                    column.HeaderText = "";
                    column.CellTemplate = new DataGridViewCheckBoxCell();
                    column.CellTemplate.Style.BackColor = Color.LemonChiffon;
                }


                dgvData.Columns.Add(column); //0
                pIntseq = _pIntseq;
                 info = new Entity.GiftVoucher_Barter() { PageNumber = _pIntseq };
                 if (!string.IsNullOrEmpty(txtFindName.Text.Trim()))
                {
                    info.GiftCode = "%" + txtFindName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtFindName.Text))
                {
                    info.GiftDetail = "%" + txtFindName.Text + "%";
                }
                info.QueryType = "SEARCHGift";
                 dataTable = new Business.GiftVoucher_Barter().SelectGiftVoucher_Barter(info).Tables[0];
                
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dataTable.Rows.Count <= 0)
                {
                    //ngbMain.CurrentPage = 0;
                    //ngbMain.TotalPage = 0;
                    //ngbMain.TotalRecord = 0;
                    //ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                //foreach (DataRowView item in dt.DefaultView)
                //{
                //  //  PRO_Code
                //  //PRO_Name
                //  //DateStart
                //  //DateEnd
                //  //CreateDate
                //  //CreateBy
                //  //UpdateDate
                //  //UpdateBy
                //  //ProPrice
                //  //PRO_Active
                //  //Remark
                //    var myItems = new[]
                //                      {
                //                          item["PRO_Code"] + "",
                //                          item["PRO_Name"]+"",
                //                          string.IsNullOrEmpty(item["ProPrice"] + "") ? "0" : Convert.ToDouble(item["ProPrice"] + "").ToString("###,###,###.##"),
                //                         Convert.ToDateTime(item["DateStart"] + "").ToString("yyyy-MM-dd") ,
                //                          Convert.ToDateTime(item["DateEnd"] + "").ToString("yyyy-MM-dd") ,
                //                          item["PRO_Active"] + "" ,
                //                          item["Remark"] + "" ,
                //                           item["Pro_Type"] + "" 
                //                      };
                //    dgvData.Rows.Add(myItems);
                //    if (lngTotalPage != 0) continue;
                //    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                //    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                  
                //}
                //dgvData.Columns["ProPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.DataSource = null;
                dgvData.DataSource = dataTable;
                
                //ngbMain.CurrentPage = _pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                DerUtility.MouseOff(this);
              //  RefreshText();
                //txtFindName.Text = GiftCode;

            
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
              //  SetNumberAllRows();
            }
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
    
        private void SelectGift()
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1 || dgvData.CurrentRow.Cells["GiftCode"].Value + ""=="") return;
                GiftCode = dgvData.CurrentRow.Cells["GiftCode"].Value + "";
                PriceCredit = dgvData.CurrentRow.Cells["PriceCredit"].Value + "" == "" ? 0 : Convert.ToDouble(dgvData.CurrentRow.Cells["PriceCredit"].Value + "");
                
                //this.Close();
                //this.Visible = false;
                //MessageBox.Show(Statics.frmGiftVoucher.GiftCode);
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        private void buttonFind_BtnClick()
        {
            BindGiftVoucher(1);
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    FrmGiftVoucherEdit fm = new FrmGiftVoucherEdit();
                    fm.Import = false;
                    fm.IsEdit=true;
                    GiftCode=dgvData.CurrentRow.Cells["GiftCode"].Value + "";
                    Sono = dgvData.CurrentRow.Cells["Sono"].Value + "";
                    MS_Code = dgvData.CurrentRow.Cells["MS_Code"].Value + "";
                    ListOrder = dgvData.CurrentRow.Cells["ListOrder"].Value + "";
                    fm.GiftCode = GiftCode;
                    fm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFindCode_TextChanged(object sender, EventArgs e)
        {
            //BindPromotion(1);
        }

        private void txtFindName_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if(dataTable!=null)
            //    dataTable.DefaultView.RowFilter = string.Format("[GiftCode] LIKE '%{0}%' or [GiftDetail] LIKE '%{1}%'", txtFindName.Text, txtFindName.Text);
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
        }



        private void buttonFind1_BtnClick()
        {
            BindGiftVoucher(1);
        }

     

        private void txtFindName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindGiftVoucher(1);
        }

        private void buttonFind1_BtnClick_1()
        {
            BindGiftVoucher(1);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount > 0 && dgvData.CurrentRow.Index >= 0)
            {
                SelectGift();
                this.Visible = false;
            }
            else {
                GiftCode = "";
                this.Visible = false;
            }
        }

        private void FrmGiftVoucher_Load(object sender, EventArgs e)
        {
            
            //BindGiftVoucher(1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >=0)
                {
                    //SelectGift();
                    if (dgvData.Rows.Count < 0 || dgvData.CurrentRow == null) return;
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[dgvData.CurrentRow.Index].Cells[0];
                    //if (dgvData.CurrentCell.ColumnIndex != 0) return;
                    foreach (DataGridViewRow item in dgvData.Rows)
                    {
                        item.Cells[0].Value = false;
                    }
                    if (ch1.Value == null)
                        ch1.Value = false;
                    switch (ch1.Value.ToString())
                    {
                        case "True":
                            ch1.Value = false;
                            break;
                        case "False":
                            ch1.Value = true;
                            break;
                    }
                    if (IsExpired(dgvData.Rows[dgvData.CurrentRow.Index].Cells["DateEnd"].Value + "") || dgvData.Rows[e.RowIndex].Cells["Gift_Active"].Value + "" == "N" && !Userinfo.IsAdmin.Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))
                    { 
                        ch1.Value = false;
                        MessageBox.Show("Voucher Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool IsExpired(string specificDate)
        {
            bool flag = false;
            DateTime currentDate = DateTime.Now.Date;

            DateTime target;

            if (DateTime.TryParse(specificDate, out target))
            {
                flag = target < currentDate;
            }

            return flag;
        }
        private void buttonAdd1_BtnClick()
        {
            try
            {
                FrmGiftVoucherEdit frm = new FrmGiftVoucherEdit();
                frm.Import = false;
                frm.CN = CN;
                //frm.CustomerName = txtCustomerName.Text; ;
                frm.SOno = Sono;
                frm.VN = VN;
                frm.MS_Code = MS_Code;
                frm.ListOrder = ListOrder;
                frm.CustomerName = CustomerName;
          
                if (frm.ShowDialog() != DialogResult.Yes) return;
                
                txtFindName.Text = frm.GiftCode;
                BindGiftVoucher(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete1_BtnClick()
        {
            try
            {
                DeleteData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGiftVoucherEdit fm = new FrmGiftVoucherEdit();
                fm.Import = true;
                if (fm.ShowDialog() != DialogResult.Yes) return;
                txtFindName.Text = fm.GiftCode;
                BindGiftVoucher(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                      e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
                if (dgvData.Rows[e.RowIndex].Cells["Gift_Active"].Value + "" != "Y")
                {
                    //dgvData.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    dgvData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                    dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
            catch (Exception )
            {
              
            }
            
        }

        private void txtFindName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void buttonFind2_BtnClick()
        {
            BindGiftVoucher(1);
        }

       

        

    }
}
