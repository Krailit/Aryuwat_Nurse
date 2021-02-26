using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.Forms.PrintGridView;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms.FRMReport
{
    public partial class PopGridDetail : Form
    {
        public PopGridDetail()
        {
            InitializeComponent();
        }
        public PopGridDetail(DataTable dt)
        {
            InitializeComponent();
            dt = setValues(dt);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
        }
        private DataTable setValues(DataTable dt)
        {
            DataTable dtx = new DataTable();
            foreach (DataColumn c in dt.Columns)
            {
                dtx.Columns.Add(c.ColumnName);
            }
            //dtx=dt.Clone();
            try
            {
                if (dt.Columns.Contains("PriceAfterDis") || dt.Columns.Contains("NetIncome"))
                {
                    int r = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow row = dtx.NewRow();
                        foreach (DataColumn c in dt.Columns)
                        {
                            if (c.ColumnName.ToLower() != "updatedate" && c.ColumnName.ToLower() != "date" && c.ColumnName.ToLower() != "sono" && c.ColumnName.ToLower() != "refmo" && c.ColumnName.ToLower() != "cn" && c.ColumnName.ToLower() != "vn" && c.ColumnName.ToLower() != "mo" && c.ColumnName.ToLower() != "ms_code" && c.ColumnName.ToLower() != "ms_name")
                            {
                                //dr[c] = Convert.ToDecimal(dr[c.ColumnName]).ToString("###,###,###,###");
                                ////dtx.Rows[r][c.ColumnName] = Convert.ToDecimal(dr[c.ColumnName]).ToString("###,###,###,###");
                                string xx = dr[c.ColumnName]+""==""?"":Convert.ToDecimal(dr[c.ColumnName]).ToString("###,###,###,###");
                                row[c.ColumnName] = xx;
                            }
                            else
                                row[c.ColumnName] = dr[c.ColumnName];
                        }
                        dtx.Rows.Add(row);
                    }
                }
                else dtx = dt.Copy();
            }
            catch (Exception ex)
            {
             
            }
            return dtx;
        }
        public void PopUpDetail(System.Windows.Forms.DataGridView dgvData, int cindex, int rindex, DataTable dataDetail)
        {
            try
            {
                ////==================DataTable  original========================
                //if (rindex<0 ||cindex == 0 || dgvData[cindex, rindex].Value + "" == "") return;
                //string key = string.Format("{0} {1}:{2} {3}", dgvData.Columns[0].Name, dgvData[0, rindex].Value + "", dgvData.Columns[cindex].Name, dgvData[cindex, rindex].Value + "");
                //string sql = "";
                //if (dgvData[0, rindex].Value.ToString().ToLower() == "total")
                //{
                //    if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))
                //        sql = string.Format("[{0}]>=0", dgvData.Columns[cindex].Name);
                //    else sql = string.Format("[{0}]<>''", dgvData.Columns[cindex].Name);
                //}
                //else
                //{
                //    if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))//Date  yyyy/mm/dd
                //        sql = string.Format("[{0}]='{1}' and {2} >=0 ", dgvData.Columns[0].Name, dgvData[0, rindex].Value, dgvData.Columns[cindex].Name);
                //    else sql = string.Format("[{0}]='{1}' and {2}<>''", dgvData.Columns[0].Name, dgvData[0, rindex].Value, dgvData.Columns[cindex].Name);
                //}
                //if (!dataDetail.Select(sql).Any()) return;
                //DataTable dtemp = dataDetail.Select(sql).CopyToDataTable();
                //foreach (DataColumn c in dataDetail.Columns)
                //{
                //    if (c.ColumnName != dgvData.Columns[cindex].Name && c.ColumnName.ToLower() != "updatedate" && c.ColumnName.ToLower() != "priceafterdis" && c.ColumnName.ToLower() != "netincome" && c.ColumnName.ToLower() != "date" && c.ColumnName.ToLower() != "refmo" && c.ColumnName.ToLower() != "cn" && c.ColumnName.ToLower() != "sono" && c.ColumnName.ToLower() != "vn" && c.ColumnName.ToLower() != "mo" && c.ColumnName.ToLower() != "ms_code" && c.ColumnName.ToLower() != "ms_name")
                //        dtemp.Columns.Remove(c.ColumnName);
                   
                //}
                ////==================DataTable  original========================
                //==================DataTable  TranForm========================
                if (rindex < 0 || cindex <= 0 || dgvData[cindex, rindex].Value + "" == "") return;
                string key = string.Format("{0} {1}:{2} {3}", dgvData.Columns[0].Name, dgvData[0, rindex].Value + "", dgvData.Columns[cindex].Name, dgvData[cindex, rindex].Value + "");
                string sql = "";
                if (dgvData.Columns[cindex].Name.ToLower() == "total" && dgvData[0, rindex].Value.ToString().ToLower() == "total")//Total Column สุดท้ายและ แถวสุดท้าย
                {
                    //if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))
                    //    sql = string.Format("[{0}]>=0", dgvData[0, rindex].Value.ToString());
                    //else sql = string.Format("[{0}]<>''", dgvData[0, rindex].Value.ToString());
                    //if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))
                    //    sql = string.Format("[{0}]>=0", dgvData.Columns[cindex].Name);
                    //else sql = string.Format("[Date]='{0}'", dgvData.Columns[cindex].Name);
                }
                else if (dgvData.Columns[cindex].Name.ToLower() == "total" && dgvData[0, rindex].Value.ToString().ToLower() != "total")//Total Column สุดท้ายและ แถวสุดท้าย
                {
                    if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))
                        sql = string.Format("[{0}]>=0", dgvData[0, rindex].Value);
                    else 
                        sql = string.Format("[{0}]<>''", dgvData[0, rindex].Value);
                   
                }
                else if (dgvData[0, rindex].Value.ToString().ToLower() == "total")//Total Row สุดท้าย
                {
                    if (dataDetail.Columns.Contains("date"))
                    {
                        //if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))
                        //    sql = string.Format("[{0}]>=0", dgvData.Columns[cindex].Name);
                        //else 
                        string dat = dataDetail.Rows[0]["Date"].ToString().Substring(0, 8);//เพราะสาวน้อย ตัดให้วันที่เหลือ วันอย่างเดียว dd
                        sql = string.Format("[Date]='{0}'", dat+dgvData.Columns[cindex].Name);
                    }
                    else if (dataDetail.Columns.Contains("month"))
                    {
                        if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))
                            sql = string.Format("[Month]>={0}", dgvData.Columns[cindex].Name);
                        else sql = string.Format("[Month]='{0}'", dgvData.Columns[cindex].Name);
                    }
                }
                else
                {
                    if ((dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome") )&& !dataDetail.Columns.Contains("month"))//Date  yyyy/mm/dd
                    {
                        string dat = dataDetail.Rows[0]["Date"].ToString().Substring(0, 8);
                        sql = string.Format("[{0}]='{1}' and {2} >=0 ", dgvData.Columns[0].Name, dat + dgvData.Columns[cindex].Name, dgvData[0, rindex].Value);
                    }
                    else if ((dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome")) && dataDetail.Columns.Contains("month"))//month 
                    {
                        //string dat = dataDetail.Rows[0]["Month"].ToString();//เพราะสาวน้อย ตัดให้วันที่เหลือ วันอย่างเดียว dd
                        sql = string.Format("[{0}]='{1}' and {2}>=0", dgvData.Columns[0].Name, dgvData.Columns[cindex].Name, dgvData[0, rindex].Value);
                    }
                    else
                    {
                        string dat="";
                        if (dataDetail.Columns.Contains("month"))
                            dat = dgvData.Columns[cindex].Name;
                        else
                        {
                            dat = dataDetail.Rows[0]["Date"].ToString().Substring(0, 8);
                            dat += dgvData.Columns[cindex].Name;
                        }
                        sql = string.Format("[{0}]='{1}' and {2}<>''", dgvData.Columns[0].Name,dat , dgvData[0, rindex].Value);
                    }
                }
                if (!dataDetail.Select(sql).Any()) return;
                DataTable dtemp = dataDetail.Select(sql).CopyToDataTable();
                foreach (DataColumn c in dataDetail.Columns)
                {
                    if (c.ColumnName != dgvData.Columns[cindex].Name && c.ColumnName.ToLower() != "updatedate" && c.ColumnName.ToLower() != "priceafterdis" && c.ColumnName.ToLower() != "netincome" && c.ColumnName.ToLower() != "date" && c.ColumnName.ToLower() != "refmo" && c.ColumnName.ToLower() != "cn" && c.ColumnName.ToLower() != "sono" && c.ColumnName.ToLower() != "vn" && c.ColumnName.ToLower() != "mo" && c.ColumnName.ToLower() != "ms_code" && c.ColumnName.ToLower() != "ms_name" && c.ColumnName.ToLower() != "listorder" && c.ColumnName.ToLower() != "customer" && c.ColumnName.ToLower() != "customer2")
                        dtemp.Columns.Remove(c.ColumnName);

                }
                //==================DataTable  original========================
                PopGridDetail pg = new PopGridDetail(dtemp);
                pg.Text = key;
                pg.ShowDialog();

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
                PrintDGV.Print_DataGridView(dataGridView1);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CallForm(e.RowIndex);  
        }
        private void CallForm(int rowIndex)
        {
            try
            {
                if (rowIndex < 0) return;
                string mo = dataGridView1.Rows[rowIndex].Cells["MO"].Value + "";
                string so = dataGridView1.Rows[rowIndex].Cells["SONo"].Value + "";
                if (rowIndex < 0 || (mo == "" && so == "")) return;
                    Statics.frmMedicalOrderSettingPro = new FrmMedicalOrderSettingPro();
                    //if (cMode == Statics.CallMode.Preview)
                    //{
                    //    Statics.frmMedicalOrderSettingPro.FormType = Utility.AccessType.DisplayOnly;
                    //    Statics.frmMedicalOrderSettingPro.Text = Text + Statics.StrPreview;
                    //}
                    //else if (cMode == Statics.CallMode.Update)
                    //{
                    Statics.frmMedicalOrderSettingPro.FormType = DerUtility.AccessType.Update;
                    Statics.frmMedicalOrderSettingPro.Text = string.Format("{0}/{1}",so,mo);
                    //}


                    Statics.frmMedicalOrderSettingPro.VN = mo;
                    //if(dgvData.Rows[rowIndex].Cells["VN"].Value + ""=="")
                    Statics.frmMedicalOrderSettingPro.SO = so;
                    //Statics.frmMedicalOrderSettingPro.MedStatus_Code = dataGridView1.Rows[rowIndex].Cells["MedStatus_Code"].Value + "";

                    Statics.frmMedicalOrderSettingPro.BackColor = Color.FromArgb(255, 230, 217);
                    Statics.frmMedicalOrderSettingPro.Show(Statics.frmMain.dockPanel1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CallForm(string so,string mo)
        {
            try
            {
                if (mo == "" && so == "") return;
                Statics.frmMedicalOrderSettingPro = new FrmMedicalOrderSettingPro();
                Statics.frmMedicalOrderSettingPro.FormType = DerUtility.AccessType.Update;
                Statics.frmMedicalOrderSettingPro.Text = string.Format("{0}/{1}", so, mo);
                Statics.frmMedicalOrderSettingPro.VN = mo;
                Statics.frmMedicalOrderSettingPro.SO = so;

                Statics.frmMedicalOrderSettingPro.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmMedicalOrderSettingPro.Show(Statics.frmMain.dockPanel1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
    }
}
