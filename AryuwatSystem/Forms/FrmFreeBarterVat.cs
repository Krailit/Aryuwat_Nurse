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
    public partial class FrmFreeBarterVat : DockContent
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
        public FrmFreeBarterVat()
        {
            InitializeComponent();
            //SetColumns();
       
            dgvData.CellMouseClick += dgvData_CellMouseClick;

            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmGiftVoucher_Closing);
        }


        void FrmGiftVoucher_Closing(object sender, CancelEventArgs e)
        {
            //Statics.frmGiftVoucher = null;
        }
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
            SelectBarter();
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            //CallForm(CallMode.Preview);
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

     
        private void buttonCancel_BtnClick()
        {
            Statics.frmFreeBarterVat = null;
            this.Close();
        }
     

        public void BindBarter(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                //dgvData.Rows.Clear();
                dgvData.Columns.Clear();
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
                info.QueryType = "SEARCHBarter";
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
                txtFindName.Text = GiftCode;
                

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

        private void SetNumberAllRows()
        {
            long rowStart = (DerUtility.ROW_PER_PAGE * (pIntseq - 1));
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                rowStart += 1;
                dgvData.Rows[i].HeaderCell.Value = rowStart.ToString();
            }
        }
    
        private void SelectBarter()
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                GiftCode = dgvData.CurrentRow.Cells["BarterCode"].Value + "";
                PriceCredit = dgvData.CurrentRow.Cells["PriceCredit"].Value + "" == "" ? 0 : Convert.ToDouble(dgvData.CurrentRow.Cells["PriceCredit"].Value + "");
                
                //this.Close();
                this.Visible = false;
                //MessageBox.Show(Statics.frmGiftVoucher.GiftCode);
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void buttonFind_BtnClick()
        {
            BindBarter(1);
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex >= 0)
            {
                SelectBarter();
            
            }
        }

        private void txtFindCode_TextChanged(object sender, EventArgs e)
        {
            //BindPromotion(1);
        }

        private void txtFindName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataTable.DefaultView.RowFilter = string.Format("[BarterCode] LIKE '%{0}%' or [BarterDetail] LIKE '%{1}%'", txtFindName.Text, txtFindName.Text);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

      
        private void buttonFind1_BtnClick()
        {
            BindBarter(1);
        }

        private void txtFindName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindBarter(1);
        }

        private void buttonFind1_BtnClick_1()
        {
            BindBarter(1);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow.Index >= 0)
            {
                SelectBarter();
             
            }
        }

        private void FrmGiftVoucher_Load(object sender, EventArgs e)
        {
            BindBarter(1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
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
                    if (IsExpired(dgvData.Rows[dgvData.CurrentRow.Index].Cells["DateEnd"].Value + "") || dgvData.Rows[e.RowIndex].Cells["Barter_Active"].Value + "" == "N")
                    { ch1.Value = false; }

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
            DateTime currentDate = DateTime.Now;

            DateTime target;

            if (DateTime.TryParse(specificDate, out target))
            {
                flag = target < currentDate;
            }

            return flag;
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
                if (dgvData.Rows[e.RowIndex].Cells["Barter_Active"].Value + "" != "Y")
                {
                    dgvData.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                }
            }
            catch (Exception)
            {

            }
        }

        private void buttonAdd1_BtnClick()
        {
            try
            {
                FrmBarterEdit fm = new FrmBarterEdit();
                fm.Import = false;
                fm.ShowDialog();
                //BindGiftVoucher(1);
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
                FrmBarterEdit fm = new FrmBarterEdit();
                fm.Import = true;
                fm.ShowDialog();
                BindBarter(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteData()
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                                   Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["BarterCode"].Value + "") != DialogResult.Yes) return;
                try
                {
                    Entity.GiftVoucher_Barter info = new GiftVoucher_Barter();
                    info.QueryType = "DeleteBarter";
                    info.GiftCode = dgvData.CurrentRow.Cells["BarterCode"].Value + "";
                    int? intStatus = new Business.GiftVoucher_Barter().DeleteBarter(info);
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    BindBarter(1);

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

        private void txtFindName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        

    }
}
