using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Diagnostics;

namespace AryuwatSystem.Forms
{
    public partial class FrmCommissionHeadCheck : DockContent
    {

        DataSet dsSurgeryFee;
        private Dictionary<double, double> DicComRate;
        double Sales = 0;
        double Commission = 0;
        private string EMPTypID = "";
        public bool SurgiFeeTYP = true;
        DataTable dtSurgicalFee_Position = new DataTable();
        Dictionary<string,string>dicPosition=new Dictionary<string,string> ();
        public FrmCommissionHeadCheck()
        {
            InitializeComponent();
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;
            txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtStartdate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy/MM/dd");
            //cboSurgicalFeeTyp.ItemHeight = 500;
            cboSurgicalFeeTyp.DropDownHeight = 800;
            
        }
        private void ngbMain_MoveFirst()
        {
            BindDataCommission(1);
        }

        private void ngbMain_MoveLast()
        {
            BindDataCommission(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindDataCommission(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindDataCommission(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        private void buttonFind_BtnClick()
        {
            BindDataCommission(1);
        }
        private void setColumn()
        {
            
            for (int i = 0; i < dgvData.Columns.Count - 1; i++)
            {
                dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvData.Columns.Count; i++)
            {
                int colw = dgvData.Columns[i].Width;
                dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvData.Columns[i].Width = colw;
            }
        }
        public void BindDataCommission(int _pIntseq)
        {
            try
            {
                Sales = 0;
                int count=0;
                setColumn();
                if (dgvData.Rows.Count>0)dgvData.Rows.RemoveAt(0);
                dgvData.Rows.Clear();
                dgvData.DataSource = null;
                //int pIntseq = _pIntseq;
                 SurgeryFee info = new SurgeryFee(); 
              
                
                //if (dtpDateStart.Checked)
                //{
                //    info.whereDate = wdate+" >='" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateEnd.Checked)
                //{
                //    info.whereDate = wdate + " <='" + dtpDateStart.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateStart.Checked && dtpDateEnd.Checked)
                //{
                //    info.whereDate = wdate + " between ('" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "') and ('" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "')";
                //}
                 info.Position_Type = "'"+cboSurgicalFeeTyp.Text + "'";
                 if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                 {
                     info.StartDate =  "'"+txtStartdate.Text+"'";
                 }
                 if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                 {
                     info.EndDate = "'" + Convert.ToDateTime(txtEnddate.Text).AddDays(1).ToString("yyyy/MM/dd") + "'";
                 }
                 info.whereDate = string.Format(" and (Sur.DateUpdate between '{0}' and '{1}' )", info.StartDate, info.EndDate);
                //if (!dtpDateStart.Checked && !dtpDateEnd.Checked)
                //{
                //    info.whereDate = " 1=1 ";
                //}
                 info.EN = "";
                string[] positionx;
                string wherein="";
                info.Position_ID = "";
                if (!string.IsNullOrEmpty(cboPosition.Text))
                {
                    positionx = cboPosition.Text.Split(',');
                    if (positionx.Any())
                    {
                        foreach (string item in positionx)
	                    {
                            string key = dicPosition.FirstOrDefault(x => x.Value == item.Trim().Replace(",","")).Key;
                            wherein += string.Format("'{0}',", key);
	                    }


                        //info.Position_ID = wherein.Remove(wherein.Length-1);
                        info.Position_ID = string.Format(" and MStuff.Position_ID in({0}) ", wherein.Remove(wherein.Length - 1));
                    }
                }
                
                //info.QueryType = EMPTypID == "17" ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
                info.QueryType = "SELECTHEADCHECK";// radioButtonSale.Checked ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
                 dsSurgeryFee = new Business.StuffCommission().SelectSurgeryFee(info);

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsSurgeryFee.Tables.Count <= 0)
                {
                    if (dsSurgeryFee.Tables[0].Rows.Count <= 0)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                        return;
                    }
                }
               
                if(dsSurgeryFee.Tables[0].Columns.Count<2)return;
            
                    foreach (DataRowView item in dsSurgeryFee.Tables[0].DefaultView)
                    {
                        //this.VN,this.MS_Name,this.CourseUse,this.ProcedureDate,this.StartTime,this.EndTime,this.Money});
                        double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                        var myItems = new IComparable[]
                                      {
                                          item["VN"] + "",
                                          item["RefMO"] + "",
                                          item["sono"] + "",
                                          item["CN"] + "",
                                          item["CustFullNameThai"] + "",
                                          item["CN_USED"] + "",
                                          item["CustUseFullNameThai"] + "",
                                          item["FullNameThai"] + "",
                                          item["MS_Name"] + "",
                                          item["Position_Name"] + "",
                                          item["ProcedureDate"] + ""==""?"":Convert.ToDateTime(item["ProcedureDate"] + "").ToString("dd/MM/yyyy"),
                                          item["StartProcedure"] + ""==""?"":Convert.ToDateTime(item["StartProcedure"] + "").ToString("HH:mm:00"),
                                          item["EndProcedure"] + ""==""?"":Convert.ToDateTime(item["EndProcedure"] + "").ToString("HH:mm:00"),
                                          m.ToString("#,###,###.##"),
                                           item["Complimentary"]+""== "Y"?true:false ,
                                           item["MarketingBudget"]+""== "Y"?true:false,
                                           item["Gift"]+""== "Y"?true:false,
                                           item["Subject"]+""== "Y"?true:false
                                      };
                        dgvData.Rows.Add(myItems);
                        Sales += m;
                        count++;
                    
                    }
              
                CalCommission();

                DerUtility.FindTotalPage(count, ref lngTotalPage);
                lngTotalRecord = count;

                if (dsSurgeryFee.Tables[0].Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                else
                {
                    ngbMain.CurrentPage = _pIntseq;
                    ngbMain.TotalPage = lngTotalPage;
                    ngbMain.TotalRecord = lngTotalRecord;
                    ngbMain.Updates();
                }
                setColumn();
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                
                return;
            }
            finally
            {
            }
        }
        private void CalCommission()
        {
            int level=0;
            foreach (KeyValuePair<double,double> valuePair in DicComRate)
            {

                if (Sales > valuePair.Key && level < DicComRate.Count-1)
                {
                    level++;
                    continue;
                }
                Commission = Sales*valuePair.Value;
                level++;
                break;
               
            }

        }
        private void btnFindEMP_Click(object sender, EventArgs e)
        {
            PopEMP();
        }
        private void PopEMP()
        {
            try
            {
                    PopEmpSearch obj = new PopEmpSearch();
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.WindowState = FormWindowState.Normal;
                    obj.BackColor = Color.FromArgb(255, 230, 217);
                    obj.multiSelect = false;
                    obj._queryType = "LISTNAMECOMMISSION";
                    obj.ShowDialog();

             
                    EMPTypID=obj.EmployeeTypeId;
                    BindDataCommission(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCommissionHeadCheck_Load(object sender, EventArgs e)
        {
            
            BindCommissionRate();
            BindSurgicalFeeType_Position();
            //PopEMP();
           // BindDataCommission(1);
        }
        private void BindCommissionRate()
        {
            try
            {
                DicComRate=new Dictionary<double, double>();
                DataSet dsComRate = new Business.StuffCommission().SelectCommissionRate();
                if(dsComRate.Tables.Count>0)
                {
                    foreach (DataRow dr in from DataRow dr in dsComRate.Tables[0].Rows where dr["Sales"] + "" != "" where !DicComRate.ContainsKey(Convert.ToDouble(dr["Sales"]+"")) select dr)
                    {
                        DicComRate.Add(Convert.ToDouble(dr["Sales"]+""),Convert.ToDouble(dr["Com_Rate"]+""));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void BindSurgicalFeeType_Position()
        {
            try
            {
                DataSet dsComRate = new Business.StuffCommission().SurgicalFeeType_Position();

                if (dsComRate.Tables.Count > 0)
                {
                    dtSurgicalFee_Position=dsComRate.Tables[0];
                    DataView view = new DataView(dtSurgicalFee_Position);
                    //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                    DataTable distinctValues = view.ToTable(true, "Position_Type");
                    cboPosition.Items.Clear();
                    
                    foreach (DataRow item in distinctValues.Rows)
                    {
                            cboSurgicalFeeTyp.Items.Add(item["Position_Type"]);  
                    }
                    cboSurgicalFeeTyp.SelectedIndex = 0;
                   
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindPosition(string typ)
        {
            try
            {
                    DataView view = new DataView(dtSurgicalFee_Position);
                    //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                    string @where=string.Format("Position_Type='{0}'",typ);
                DataTable distinctValues =new DataTable();
                cboPosition.Items.Clear();
                dicPosition = new Dictionary<string, string>();
                   if (dtSurgicalFee_Position.Select(@where).Any())
                       {
                       distinctValues=dtSurgicalFee_Position.Select(@where).CopyToDataTable();
                       foreach (DataRow item in distinctValues.Rows)
	                    {
		                     if(!dicPosition.ContainsKey(item["Position_ID"]+""))
                            {
                                dicPosition.Add(item["Position_ID"] + "", item["Position_Name"].ToString().Replace(",", ""));
                               
                                cboPosition.Items.Add(item["Position_Name"]);  
                            }
	                    }
                           
                       }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void FrmCommissionHeadCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommissionHeadCheck = null;
          }

        private void cboSurgicalFeeTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPosition(cboSurgicalFeeTyp.Text);
        }

        private void txtStartdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtStartdate);
        }

        private void txtEnddate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtEnddate);
        }
        private void SelectDate(TextBox txt)
        {
            try
            {
                PopDateTime pp = new PopDateTime();
                DateTime d;
                if (txt.Text.Trim() != "")
                    pp.SelecttDate = Convert.ToDateTime(txt.Text.Trim());// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                else
                    pp.SelecttDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate);
                if (pp.ShowDialog() == DialogResult.OK)
                {
                    //txt.Text = pp.SelecttDate.Date.ToString("dd/MM/yyyy");
                    txt.Text = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
              if (e.KeyCode == Keys.Return)
                  BindDataCommission(1);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
              if (e.KeyCode == Keys.Return)
                  BindDataCommission(1);
        }

        private DataSet DGVTODatable()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    dt.Columns.Add(dgvData.Columns[i].Name);
                }
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dgvData.Columns.Count; j++)
                    {
                        dr[dgvData.Columns[j].Name] = row.Cells[j].Value + "";
                    }

                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
        private void buttonExport1_BtnClick()
        {
            try
            {
                saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "Excel file(*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    //ExcelHelper.ExportToExcel(dsData, saveFileDialog1.FileName, "");


                    // dt = city.GetAllCity();//your datatable
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        wb.Worksheets.Add(DGVTODatable());//dsSurgeryFee.Tables[0]

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

        private void txtStartdate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtEnddate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }
      
    }
}
