using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class popSelectMedicalSupplies : Form
    {
        public string MainUnitCode { get; set; }
        public string SubUnitCode { get; set; }
        public string MainUnitName { get; set; }
        public string SubUnitName { get; set; }
        public string customerType { get; set; }
        public string SelectValues { get; set; }
        public string SelectText { get; set; }
        public string VN { get; set; }
        public string SONo { get; set; }
        public string MS_CodeM { get; set; }
        public string ListOrderM { get; set; }
        public decimal PriceTotal { get; set; }
        public decimal SUMPriceAfterDis = 0;
        public DataTable OldItem { get; set; }  
        List<string> LS = new List<string>();
        public List<Entity.SupplieTrans> listSupOther { get; set; }
        DataSet dataSet;
        public popSelectMedicalSupplies()
        {
            InitializeComponent();
     
        }

        private void SaveItem()
        {
            try
            {
                listSupOther = new List<Entity.SupplieTrans>();

                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)//product
                {
                    Entity.SupplieTrans st = new Entity.SupplieTrans();
                    st.VN = VN;
                    st.SONo = SONo;
                    st.MS_CodeM = MS_CodeM;
                    st.ListOrderM = ListOrderM;
                    st.MS_CodeS = item.Cells["MS_Code"].Value + "";
                    st.MS_Code = item.Cells["MS_Code"].Value + "";
                    st.MS_Name = item.Cells["MS_Name"].Value + "";
                    st.PriceAfterDis = item.Cells["PriceAfterDis"].Value + "" == "" ? 0 : Convert.ToDecimal(item.Cells["PriceAfterDis"].Value + "");
                    st.Amount = item.Cells["Amount"].Value + "" == "" ? 0 : Convert.ToDecimal(item.Cells["Amount"].Value + "");
                    st.UpPrice = item.Cells["UpPrice"].Value + "" == "" ? 0 : Convert.ToDecimal(item.Cells["UpPrice"].Value + "");
                    st.DiscountB = item.Cells["Discount"].Value + "" == "" ? 0 : Convert.ToDecimal(item.Cells["Discount"].Value + "");
                    DataGridViewCheckBoxCell chkCom = item.Cells["COM1"] as DataGridViewCheckBoxCell;
                    st.SaleCom = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                    chkCom = item.Cells["COM2"] as DataGridViewCheckBoxCell;
                    st.ByDr = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                    listSupOther.Add(st);
                }
                //var intmember = new Business.MedicalOrder().InsertSubItemOther(listSupOther);


                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.No;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            SaveItem();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void popSelectMedicalSupplies_Load(object sender, EventArgs e)
        {
            try
            {
                BindData();
                SumTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                BindMedicalSupplies(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BindData()
        {
            try
            {
                //DerUtility.MouseOn(this);
                if (dataGridView1.RowCount > 0) dataGridView1.Rows.Clear();
                
                
                //Entity.SupplieTrans info = new Entity.SupplieTrans() ;

                //info.QueryType = "SelectSubListItem";
                //info.VN = VN;
                //info.SONo = SONo;
                //info.MS_CodeM = MS_CodeM;
                //info.ListOrderM = ListOrderM;

                //DataSet ds = new Business.MedicalOrder().SelectSubItemOther(info);

                //if (ds.Tables.Count <= 0) return;
                //decimal MS_CLPrice = 0;
                //decimal MS_CAPrice = 0;
                //decimal MS_Price = 0;
                //decimal DIS = 0;
                //decimal PriceAfterDis = 0;
                //decimal Amount = 0;
                //decimal UpPrice = 0;
                //decimal Discount = 0;
                
                //DataTable dt = ds.Tables[0];
                foreach (DataRowView item in OldItem.DefaultView)
                {
                 
                    //MS_CLPrice = item["MS_CLPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_CLPrice"] + "");
                    //MS_CAPrice = item["MS_CAPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_CAPrice"] + "");
                    //PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    //UpPrice = item["UpPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["UpPrice"] + "");
                    //Discount = item["Discount"] + "" == "" ? 0 : Convert.ToDecimal(item["Discount"] + "");
                    //Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                    //MS_Price = (Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice : MS_CAPrice);
                    ////DIS = (MS_Price*Amount) - PriceAfterDis;
                    object[] myItems = {
                                          false,
                                          item["Section_Code"] + "",
                                          item["Section_Name"]+"",
                                          //MS_Price.ToString("###,###,###.##"),
                                          //Amount.ToString("###,###,###.##"),
                                          //Discount.ToString("###,###,###.##"),
                                          //  UpPrice.ToString("###,###,###.##"),
                                          //    PriceAfterDis.ToString("###,###,###.##"),
                                          // item["SaleCom"]+""=="Y"?true:false,
                                          // item["DrCom"]+""=="Y"?true:false,
                                      };
                    dataGridViewSelectList.Rows.Add(myItems);
                    LS.Add(item["Section_Code"] + "");

                }
              
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
                // SetNumberAllRows();
            }
        }
        public void BindMedicalSupplies(int _pIntseq)
        {
            try
            {
                //DerUtility.MouseOn(this);
                if (dataGridView1.RowCount > 0) dataGridView1.Rows.Clear();
                if (txtFind.Text.Length == 0) return;
                Entity.MedicalSupplies info = new Entity.MedicalSupplies() { PageNumber = _pIntseq };
                //if (!string.IsNullOrEmpty(txtFind.Text.Trim()))
                //{
                //    info.MS_Code = "%" + txtFind.Text + "%";
                //}
                if (!string.IsNullOrEmpty(txtFind.Text))
                {
                    info.MS_Name = "%" + txtFind.Text + "%";
                }
                info.BranchID = "EK";
                info.QueryType = "SEARCH";
                
                DataSet ds = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info);

                if(ds.Tables.Count<=0)return;
                decimal MS_CLPrice=0;
                decimal MS_CAPrice = 0;
                DataTable dt=ds.Tables[0];
                foreach (DataRowView item in dt.DefaultView)
                {
                    MS_CLPrice=item["MS_CLPrice"] + ""=="" ? 0: Convert.ToDecimal(item["MS_CLPrice"] + "");
                    MS_CAPrice = item["MS_CAPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_CAPrice"] + "");
                    object[] myItems = {
                                          false,
                                          item["MS_code"] + "",
                                          item["MS_Name"]+"",
                                         (Entity.Userinfo.PriceNormal.Contains(customerType)?MS_CLPrice:MS_CAPrice).ToString("###,###,###.##"),
                                          item["UnitName"] + "" ,
                                          item["SurgicalFeeNewTab"] + ""
                                      };
                    dataGridView1.Rows.Add(myItems);

                }
              
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
                // SetNumberAllRows();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindMedicalSupplies(1);
            }
        }

     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.EndEdit();
        }

        private void dataGridViewSelectList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewSelectList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                //decimal am = Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["Amount"].Value + "");
                //decimal price = dataGridViewSelectList.Rows[e.RowIndex].Cells["MS_Price"].Value + ""==""?0:Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["MS_Price"].Value + "");
                //decimal Discount = dataGridViewSelectList.Rows[e.RowIndex].Cells["Discount"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["Discount"].Value + "");
                //decimal UpPrice = dataGridViewSelectList.Rows[e.RowIndex].Cells["UpPrice"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["UpPrice"].Value + "");
                //decimal PriceAfterDis = ((price * am)+UpPrice) - Discount ;
                //dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceAfterDis"].Value = PriceAfterDis.ToString("###,###,###.##");
                //SumTotal();
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
            }
        }

        private void SumTotal()
        {
            try
            {
                btnYes.Enabled = false;
                SUMPriceAfterDis = 0;
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)//product
                    {
                        btnYes.Enabled = true;
                        break;
                    }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
              
                foreach (DataGridViewRow item in dataGridView1.Rows)//product
                {
                    if ((item.Cells[0].Value + "").ToLower() == "true")
                    {
                        object[] myItems = {
                                          false,
                                          item.Cells["MS_code0"].Value + "",
                                          item.Cells["MS_Name0"].Value+"",
                                         Convert.ToDecimal(item.Cells["MS_Price0"].Value+"").ToString("###,###,###.##"),//ราคาต่อหน่วย
                                          "1",//จำนวน
                                            "0",//ส่วนลด
                                            "0",//ส่วนเพิ่ม
                                            Convert.ToDecimal(item.Cells["MS_Price0"].Value+"").ToString("###,###,###.##"),//สุทธิ
                                                 (item.Cells["COM0"] + "").ToUpper()=="Y"?true:false
                                      };
                        if (LS.Contains(item.Cells["MS_code0"].Value + ""))
                        {
                            MessageBox.Show("รายการซ้ำ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        else LS.Add(item.Cells["MS_code0"].Value + "");

                        dataGridViewSelectList.Rows.Add(myItems);
                    }
                }
                SumTotal();
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
                // SetNumberAllRows();
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> lsDel = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)//product
                {
                    if ((item.Cells[0].Value + "").ToLower() == "true")
                    {
                        if (lsDel.Contains(item)) continue;
                        else lsDel.Add(item);
                    }
                }
                dataGridViewSelectList.AllowUserToAddRows = false;
               // dataGridViewSelectList.Rows.RemoveAt(dataGridViewSelectList.Rows.Count - 1);
                foreach (DataGridViewRow item in lsDel)
                {
                    //dataGridViewSelectList.Rows.RemoveAt(item);
                    dataGridViewSelectList.Rows.Remove(item);
                }
                SumTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewSelectList.EndEdit();
        }
    }

}
