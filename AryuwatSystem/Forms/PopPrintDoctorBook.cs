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
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace AryuwatSystem.Forms.FRMReport
{
    public partial class PopPrintDoctorBook : Form
    {
        DataTable dtx = new DataTable();
        public string title = "";
        public string RoomID = "";
        public string RoomName = "";
        public string BranchName = "";
        //private DataTable dtDoc;
        public DateTime startDate;
        public DateTime EndDate;
        public string BranchId;
        public PopPrintDoctorBook()
        {
            InitializeComponent();
        }
        public PopPrintDoctorBook(DataTable dt)
        {
            InitializeComponent();
          //  dt = setValues(dt);
            this.Text = title;
            dtx = dt;
            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = null;
            //dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.Tag = title;
            //for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            //{
            //    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}
            //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.dataGridView1.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //{
            //    int colw = dataGridView1.Columns[i].Width;
            //    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    dataGridView1.Columns[i].Width = colw;
            //}
          

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

                foreach (DataRow item in dtx.Rows)
                {
                    int x = item["DiffDateMM"] + "" == "" ? 0 : Convert.ToInt16(item["DiffDateMM"] + "");
                    if (x == 0) continue;
                    int endColiumn = x / 30;
                    foreach (DataColumn c in dtx.Columns)
                    {
                        if (c.Ordinal > 7 && item[c] + "" != "")
                        {
                            //item[c.Ordinal] ="_" ;
                            for (int i = 1; i <= endColiumn; i++)
                            {
                                item[c.Ordinal + i] = item["TimeStart"] + "";
                            }
                           
                            break;
                        }
                    }
                }
               
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
                            sql = string.Format("[Date]='{0}'", dgvData.Columns[cindex].Name);
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
                    if (dataDetail.Columns.Contains("PriceAfterDis") || dataDetail.Columns.Contains("NetIncome"))//Date  yyyy/mm/dd
                        sql = string.Format("[{0}]='{1}' and {2} >=0 ", dgvData.Columns[0].Name, dgvData.Columns[cindex].Name, dgvData[0, rindex].Value);
                    else sql = string.Format("[{0}]='{1}' and {2}<>''", dgvData.Columns[0].Name, dgvData.Columns[cindex].Name,dgvData[0, rindex].Value);
                }
                if (!dataDetail.Select(sql).Any()) return;
                DataTable dtemp = dataDetail.Select(sql).CopyToDataTable();
                foreach (DataColumn c in dataDetail.Columns)
                {
                    if (c.ColumnName != dgvData.Columns[cindex].Name && c.ColumnName.ToLower() != "updatedate" && c.ColumnName.ToLower() != "priceafterdis" && c.ColumnName.ToLower() != "netincome" && c.ColumnName.ToLower() != "date" && c.ColumnName.ToLower() != "refmo" && c.ColumnName.ToLower() != "cn" && c.ColumnName.ToLower() != "sono" && c.ColumnName.ToLower() != "vn" && c.ColumnName.ToLower() != "mo" && c.ColumnName.ToLower() != "ms_code" && c.ColumnName.ToLower() != "ms_name")
                        dtemp.Columns.Remove(c.ColumnName);

                }
                //==================DataTable  original========================
                PopPrintDoctorBook pg = new PopPrintDoctorBook(dtemp);
                pg.Text = key;
                pg.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Bitmap bmp;
        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            try
            {

                //PrintDGV.Print_DataGridViewA4Portrait(dataGridView1);
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                obj.PrintType = RoomName;
                obj.Remark = txtRemark.Text;

                string Title =String.Format("{0:MMMM, yyyy} {1}", Convert.ToDateTime(EndDate), BranchName);
                obj.ForDate = Title;

                obj.FormName = "RptDoctorAtten";
                obj.FormName = "RptDoctorAtten";


                obj.dt = dtx;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
               
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
            //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        //private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (e.ColumnIndex < 7) return;

        //    //    if (e.Value + "" != "")
        //    //    {
        //    //        e.CellStyle.BackColor = Color.AntiqueWhite;
        //    //        e.CellStyle.ForeColor = Color.AntiqueWhite;
        //    //        e.Value = "xxxx";
        //    //    }
        //    //    //int x = dataGridView1.Rows[e.RowIndex].Cells["DiffDateMM"].Value + "" == "" ? 0 : Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["DiffDateMM"].Value + "");
        //    //    //if (x==0) return;
        //    //    //int endColiumn = x / 30;
        //    //    //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + endColiumn].Value = dataGridView1.Rows[e.RowIndex].Cells["TimeEnd"].Value;
        //    //    //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + endColiumn].Style.BackColor = Color.AntiqueWhite;

        //    //}
        //    //catch (Exception ex)
        //    //{
                
              
        //    //}
        //}

        private void buttonExp_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "Excel file(*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        //wb.AddWorksheet("Data");
                        //wb.Worksheet("Data").Row(1).Cell(1).Value = title;
                        //dtx.TableName = title.Replace(@"/","") ;
                        wb.Worksheets.Add(dtx);
                        
                        wb.SaveAs(saveFileDialog1.FileName);
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            Process.Start(saveFileDialog1.FileName);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void PopPrintDoctorBook_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns[0].Width = 80;
            //this.dataGridView1.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                int colw = dataGridView1.Columns[i].Width;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[i].Width = colw;
            }

           
            dataGridView1.Tag = title;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = 150;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
//                printDocument1.Print();
             

                Bitmap bmpScreenshot;
                Graphics gfxScreenshot;
                //btnSave.Visible = false;
                //pictureBoxExport.Visible = false;
                //button2.Visible = false;
                //panelLeft.BackColor = Color.White;
                // calendar1.BackColor = Color.Transparent;

                bmpScreenshot = new Bitmap(dataGridView1.Bounds.Width, dataGridView1.Bounds.Height, PixelFormat.Format24bppRgb);
                gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(PointToScreen(dataGridView1.Location).X, PointToScreen(dataGridView1.Location).Y, 0, 0, dataGridView1.Bounds.Size, CopyPixelOperation.SourcePaint);
                string filePath = Application.StartupPath + @"\CaptureSourcePaint.jpg";
                bmpScreenshot.Save(filePath, ImageFormat.Jpeg);
                FileInfo f = new FileInfo(filePath);
                if (f.Exists) Process.Start(filePath);
                gfxScreenshot.Dispose();
                // panelLeft.BackColor = Color.LightBlue;
                //calendar1.BackColor=
                //btnSave.Visible = true;
                //pictureBoxExport.Visible = true;
                //button2.Visible = true;

            }
            catch (Exception ex)
            {
                //btnSave.Visible = true;
                //pictureBoxExport.Visible = true;
                //button2.Visible = true;
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ////Create bitmap
            //Bitmap image = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            ////Create form
            //Form f = new Form();
            ////add datagridview to the form
            //f.Controls.Add(dataGridView1);
            ////set the size of the form to the size of the datagridview
            //f.Size = dataGridView1.Size;
            ////draw the datagridview to the bitmap
            //dataGridView1.DrawToBitmap(image, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            ////dispose the form
            //f.Dispose();
            ////print
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            //if (e.RowIndex < 1 || e.ColumnIndex < 0)
            //    return;
            //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            //{
            //    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            //}
            //else
            //{
            //    e.AdvancedBorderStyle.Top = dataGridView1.AdvancedCellBorderStyle.All;
            //}  

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex == 0)
            //    return;
            //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            //{
            //    e.Value = "";
            //    e.FormattingApplied = true;
            //    ////Obtain a reference to the newly created DataGridViewRow 
            //    //var row = this.dataGridView1.Rows[e.RowIndex];

            //    ////Now this won't fail since the row and columns exist 
            //    //row.Cells[e.ColumnIndex].Value = "";
            //    //row = this.dataGridView1.Rows[e.RowIndex -1];

            //    ////Now this won't fail since the row and columns exist 
            //    //row.Cells[e.ColumnIndex].Value = "";
            //}
        }
        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView1[column, row];
            DataGridViewCell cell2 = dataGridView1[column, row - 1];
            if (cell1.Value+"" == "" || cell2.Value+"" == "")
            {
                return false;
            }
            return cell1.Value+"" == cell2.Value+"";
            //if (cell1.Value == null || cell2.Value== null)
            //{
            //    return false;
            //}
            //return cell1.Value.ToString() == cell2.Value.ToString();
        }
        private void bindData()
        {
            try
            {
                  DataSet ds = new Business.BookingRoom().PrintDoctorSign(startDate, EndDate, BranchId,RoomID);
                  dataGridView1.DataSource = null;
                  dataGridView1.DataSource = ds.Tables[0];
                  dtx = ds.Tables[0];
                //dataGridView1.Columns[0].Width = 80;
                //this.dataGridView1.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                //dataGridView1.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    int colw = dataGridView1.Columns[i].Width;
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns[i].Width = colw;
                }


                dataGridView1.Tag = title;
                dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dataGridView1.Columns[dataGridView1.ColumnCount-1].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radioR23_Click(object sender, EventArgs e)
        {
            RoomID = "R23";
            RoomName = radioR23.Text;
            title = String.Format("{0} / {1:MMMM, yyyy} {2}", RoomName, Convert.ToDateTime(EndDate), BranchName);
            dataGridView1.Tag = title;
            bindData();
        }

        private void radioR24_Click(object sender, EventArgs e)
        {
            RoomID = "R24";
            RoomName = radioR24.Text;
            title = String.Format("{0} / {1:MMMM, yyyy} {2}", RoomName, Convert.ToDateTime(EndDate), BranchName);
            dataGridView1.Tag = title;
            bindData();
        }

        private void radioR25_Click(object sender, EventArgs e)
        {
            RoomID = "R25";
            RoomName = radioR25.Text;
            title = String.Format("{0} / {1:MMMM, yyyy} {2}", RoomName, Convert.ToDateTime(EndDate), BranchName);
            dataGridView1.Tag = title;
            bindData();
        }

        private void radioR29_Click(object sender, EventArgs e)
        {
            RoomID = "R29";
            RoomName = radioR29.Text;
            title = String.Format("{0} / {1:MMMM, yyyy} {2}", RoomName, Convert.ToDateTime(EndDate), BranchName);
            dataGridView1.Tag = title;
            bindData();
        }

        private void radioR30_Click(object sender, EventArgs e)
        {
            RoomID = "R30";
            RoomName = radioR30.Text;
            title = String.Format("{0} / {1:MMMM, yyyy} {2}", RoomName, Convert.ToDateTime(EndDate), BranchName);
            dataGridView1.Tag = title;
            bindData();
        }
    }
}
