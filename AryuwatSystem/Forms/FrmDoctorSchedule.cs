using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace AryuwatSystem.Forms
{
    public partial class FrmDoctorSchedule : DockContent
    {
        DataSet ds=new DataSet();
        private string EMPName
        {
            get { return lblEmployeeName.Text; }
            set { lblEmployeeName.Text = value; }
        }
        private string EMPID
        {
            get { return lblEN.Text; }
            set { lblEN.Text = value; }
        }

        private bool firstLoad=true;
        private Dictionary<double, double> DicComRate;
        double Sales = 0;
        double Commission = 0;
        private string EMPTypID = "";
        public bool SurgiFeeTYP = true;

        public FrmDoctorSchedule()
        {
            InitializeComponent();
        }

        private void buttonFind_BtnClick()
        {
            BindDataSchedule(1);
        }
        private void setColumn()
        {
            if (EMPTypID == "17")//Sale Comission
            {
                dgvData.Columns["CourseUse"].HeaderText = "Amount";
                dgvData.Columns["StartTime"].Visible = false;
                dgvData.Columns["EndTime"].Visible = false;
            }
            else//Surgical Fee
            {
            
            }
        }
        public void BindDataSchedule(int _pIntseq)
        {
            try
            {
                firstLoad = false;
                Sales = 0;
               // setColumn();
                if (dgvData.Rows.Count>0)dgvData.Rows.RemoveAt(0);
                //dgvData.Rows.Clear();
                dgvData.DataSource = null;
                //int pIntseq = _pIntseq;
                ItemInfo info = new ItemInfo(); 
             
                string Cmndate = "DateShowStart";
                
                //if (dtpDateStart.Checked)
                //{
                //    info.whereDate = Cmndate + " >='" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateEnd.Checked)
                //{
                //    info.whereDate = Cmndate + " <='" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateStart.Checked && dtpDateEnd.Checked)
                //{
                //    info.whereDate = Cmndate + " between ('" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "') and ('" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "')";
                //}
                //if (!dtpDateStart.Checked && !dtpDateEnd.Checked)
                //{
                //    info.whereDate = " 1=1 ";
                //}
                info.DateShowStart = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtStartdate.Text)).AddHours(8).AddMinutes(30);// Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// StartDate.ToString();
                info.DateShowEnd = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtEnddate.Text)).AddDays(1);
                //info.DateShowStart = dtpDateStart.Value;
                //info.DateShowEnd = dtpDateEnd.Value;
                //if (cboDoctor.SelectedIndex<=0)return;
                info.DrID = cboDoctor.SelectedValue+"";
                 ds = new Business.BookingRoom().SelectDoctorSchedule(info);

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (ds.Tables.Count <= 0)
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                        return;
                    }
                }

                //if (ds.Tables[0].Columns.Count < 2) return;

                //foreach (DataRowView item in ds.Tables[0].DefaultView)
                //{
                //          //this.VN,this.MS_Name,this.CourseUse,this.ProcedureDate,this.StartTime,this.EndTime,this.Money});
                //    //double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                //    DateTime dateTimeStart = Convert.ToDateTime(item["DateShowStart"] + "");
                //    DateTime dateTimeEnd = Convert.ToDateTime(item["DateShowEnd"] + "");
                //    var myItems = new IComparable[]
                //                      {
                //                          item["CustName"] + "",
                //                          item["Treadment"] + "",
                //                          String.Format("{0:yyyy/MM/dd}", dateTimeStart),
                //                          dateTimeStart.ToString("HH:mm")+"",
                //                          dateTimeEnd.ToString("HH:mm")+"",
                //                          item["RoomName"] + ""
                //                      };
                //    dgvData.Rows.Add(myItems);
                //  }

                dgvData.DataSource=null;
                dgvData.DataSource = ds.Tables[0];
                lbCount.Text = "";
                lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));
               
              
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
            foreach (KeyValuePair<double,double> valuePair in DicComRate)
            {
                if (Sales > valuePair.Key) continue;
                Commission = Sales*valuePair.Value;
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

                    if (!string.IsNullOrEmpty(obj.StaffsName))
                        EMPName = obj.StaffsName.Replace(',',' ').Trim();
                    if (!string.IsNullOrEmpty(obj.EmployeeId))
                        EMPID = obj.EmployeeId.Replace(',', ' ').Trim();
                    EMPTypID=obj.EmployeeTypeId;
                   // BindDataCommission(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCommissionCheck_Load(object sender, EventArgs e)
        {
            lblEN.Text = "";
            lblEmployeeName.Text = "";
            BindDoctor();
            txtEnddate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStartdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //PopEMP();
           // BindDataCommission(1);
        }
        private void BindDoctor()
        {
            try
            {
                var info = new Entity.Personnel();
                info.QueryType = "LISTDOCTOR";
                DataTable dt = new Business.Personnel().SelectCustomerPaging(info).Tables[0];

                var dr = dt.NewRow();
                dr["EN"] = "";
                dr["FullNameThai"] = Statics.StrEmpty;
                dt.Rows.InsertAt(dr, 0);
                cboDoctor.Items.Clear();

                cboDoctor.DataSource = dt.DefaultView;
                cboDoctor.ValueMember = "EN";
                cboDoctor.DisplayMember = "FullNameThai";
                //  if (comboBoxCommission.Items.Contains(Entity.Userinfo.EN))
                cboDoctor.SelectedIndex = 0;
                //else
                //    comboBoxCommission.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        private void FrmCommissionCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommissionCheck = null;
          }

        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firstLoad)return;
            BindDataSchedule(1);
        }

        private void pictureBoxExport_Click(object sender, EventArgs e)
        {
            try
            {
                
                ExportFile exp = new ExportFile();
                //DataSet ds=new DataSet();
                //ds.Tables.Add();
                  SaveFileDialog saveDlg = new SaveFileDialog();
                //saveDlg.Filter = "Excel File (*.xls)|*.xls";
                saveDlg.Filter = "Excel(xlsx)|*.xlsx";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
              
                    DataSet dataSet=new DataSet();
                    dataSet.Tables.Add(exp.GetDataTableFromDGV(dgvData,"Result"));
                    //exp.Export(dataSet, saveDlg.FileName);
                    //exp.ExportUseCloseXML(dataSet, saveDlg.FileName);
                    //exp.ExportMultipleGridToOneExcel(exp.GetDataTableFromDGV(dgvData));
                    AryuwatSystem.Forms.ExcelHelper.ExportToExcel(dataSet, saveDlg.FileName,"");
                  
                }
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
                                      e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
            catch (Exception)
            {


            }
        }
    }
}
