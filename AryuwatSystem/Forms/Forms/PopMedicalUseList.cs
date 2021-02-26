using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace DermasterSystem.Forms
{
    public partial class PopMedicalUseList : DockContent, IForm
    {
        public PopMedicalUseList()
        {
            InitializeComponent();
            dataGridViewSelectList.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridViewSelectList_CellMouseMove);
            dataGridViewSelectList.CellContentClick += new DataGridViewCellEventHandler(dataGridViewSelectList_CellContentClick);
        }
        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            //DeleteData();
        }

        void IForm.IsRefresh()
        {
            //BindDataCustomer(1);
        }

        void IForm.IsEdit()
        {
            //UpdateDataCustomer();
        }

        void IForm.IsPrint()
        {

        }

        void IForm.IsNew()
        {
            //NewCustomer();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
        public string VN { get; set; }
        public string CN { get; set; }      
        private string customerType;
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

        private void PopMedicalUseList_Load(object sender, EventArgs e)
        {
           
            SetColumnDgvSelectList();

            if (!string.IsNullOrEmpty(VN))
            {
                BindData();
            }
        }

        private void SetColumnDgvSelectList()
        {
            //Utility.SetPropertyDgv(dgvHairSelect);
            dataGridViewSelectList.AllowUserToAddRows = false;
            dataGridViewSelectList.DefaultCellStyle.BackColor = Color.DarkGray;
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
            dataGridViewSelectList.Columns.Add(column); //0
            dataGridViewSelectList.Columns.Add("Code", "Code");//1
            dataGridViewSelectList.Columns["Code"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Name", "Name");//2
            dataGridViewSelectList.Columns["Name"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Amount", "Amount");//3
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Amount"].Width = 30;

            dataGridViewSelectList.Columns.Add("No./Course", "No./Course");//4
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["No./Course"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Total", "Total");//5
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Total"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Total"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Used", "Used");//6
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Used"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Balance", "Balance");//7
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Balance"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Balance"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Price/Unit", "Price/Unit");//8
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Price/Unit"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("PriceTotal", "PriceTotal");//9
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["PriceTotal"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Other", "Other");
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.BackColor = Color.LemonChiffon;

            DataGridViewCheckBoxColumn colChkComp = new DataGridViewCheckBoxColumn();
            {
                colChkComp.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkComp.FlatStyle = FlatStyle.Standard;
                colChkComp.ThreeState = false;
                colChkComp.Name = "ChkCom";
                colChkComp.HeaderText = "Comp.";
                colChkComp.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(colChkComp);

            DataGridViewCheckBoxColumn colChkMar = new DataGridViewCheckBoxColumn();
            {
                colChkMar.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkMar.FlatStyle = FlatStyle.Standard;
                colChkMar.ThreeState = false;
                colChkMar.Name = "ChkMar";
                colChkMar.HeaderText = "M.Budget";
                colChkMar.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(colChkMar);

            DataGridViewCheckBoxColumn colChkGiftv = new DataGridViewCheckBoxColumn();
            {
                colChkGiftv.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkGiftv.FlatStyle = FlatStyle.Standard;
                colChkGiftv.ThreeState = false;
                colChkGiftv.Name = "ChkGiftv";
                colChkGiftv.HeaderText = "Gift V.";
                colChkGiftv.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(colChkGiftv);
            DataGridViewCheckBoxColumn colChkSub = new DataGridViewCheckBoxColumn();
            {
                colChkSub.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkSub.FlatStyle = FlatStyle.Standard;
                colChkSub.ThreeState = false;
                colChkSub.Name = "ChkSub";
                colChkSub.HeaderText = "Subject";
                colChkSub.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(colChkSub);
            dataGridViewSelectList.Columns.Add("Tab", "Tab");

            DataGridViewImageColumn ColUse = new DataGridViewImageColumn();
            {
                ColUse.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColUse.CellTemplate = new DataGridViewImageCell();
                ColUse.Name = "BtnUse";
                ColUse.HeaderText = "Course (Record)";
            }
            dataGridViewSelectList.Columns.Add(ColUse);
        }

        private void dataGridViewSelectList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Can potentially throw an 'IndexOutOfRangeException' if not checked.4.    
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && (e.ColumnIndex == dataGridViewSelectList.Columns["BtnUse"].Index))
            {
                this.Cursor = Cursors.Hand;
            }
            else { Cursor = Cursors.Default; }
        }

        private void BindData()
        {
            try
            {
                Entity.MedicalOrder info;
                DataSet ds = new Business.MedicalOrder().SelectMedicalOrderById(VN);
                DataTable dtCust = ds.Tables[0];
                DataTable dtSup = ds.Tables[1];
                DataTable dtStuff = ds.Tables[2];
                DataTable dtDoc = ds.Tables[3];
                CN = dtCust.Rows[0]["CN"] + "";
                customerType = dtCust.Rows[0]["CustomerType"] + "";
                txtCustomerName.Text = dtCust.Rows[0]["FullNameThai"] + "" == "" ? dtCust.Rows[0]["FullNameEng"] + "" : dtCust.Rows[0]["FullNameThai"] + "";

                DataTable dtSupGroup = GroupByMultiple("MergStatus", dtSup); // Group Layer
                foreach (DataRow rw in dtSupGroup.Rows)
                {
                    string expression = "MergStatus ='" + rw["MergStatus"] + "'";
                    foreach (DataRow dr in dtSup.Select(expression))
                    {
                        string[] ms_code = (dr["MergStatus"] + "").Split(':');
                        if (ms_code.Length > 1)
                        {
                            string msCode = "";
                            string msName = "";
                            string strAmount = "";
                            string strNumCouse = "";
                            string strTotal = "";
                            string strUsed = "";
                            string strBalance = "";
                            string strPriceUnit = "";
                            string strPriceTotal = "";
                            double doublePriceTotal = 0;
                            double doubleAmount = 0;
                            double doublePriceUnit = 0;
                            string strTab = "";

                            string FreeAmount = "";
                            string Complimentary = "";
                            string MarketingBudget = "";
                            string Gift = "";
                            string Subject = "";
                            string MedicalTab = "";

                            foreach (var s in ms_code)
                            {
                                string mscode = "MS_Code ='" + s + "'";
                                foreach (DataRow drmerg in dtSup.Select(mscode)) //Loop Merg
                                {
                                    //==========================Merg Item=======================
                                    List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
                                    rowsToDelete = new List<DataGridViewRow>();

                                    //rowsToDelete.Add(item);

                                    if (msCode != "") msCode += ":";
                                    msCode += drmerg["MS_Code"] + "";

                                    if (msName != "") msName += ":";
                                    msName += drmerg["MS_Name"] + "";

                                    if (strAmount != "") strAmount += ":";
                                    strAmount += drmerg["Amount"] + "";

                                    if (strNumCouse != "") strNumCouse += ":";
                                    strNumCouse += drmerg["MS_Number_C"] + "";


                                    double dblTotal = (double.Parse(drmerg["Amount"] + "") *
                                                       (drmerg["MS_Number_C"] + "" == ""
                                                            ? 0
                                                            : double.Parse(drmerg["MS_Number_C"] + "")));
                                    if (strTotal != "") strTotal += ":";
                                    strTotal += dblTotal;

                                    if (strUsed != "") strUsed += ":";
                                    strUsed += drmerg["NumOfUse"] + "";


                                    if (strBalance != "") strBalance += ":";
                                    strBalance += (dblTotal - double.Parse(drmerg["NumOfUse"] + "")).ToString("###,##0.00");

                                    double dblCL = drmerg["MS_CLPrice"] + "" == ""
                                                       ? 0
                                                       : double.Parse(drmerg["MS_CLPrice"] + "");
                                    double dblCA = drmerg["MS_CAPrice"] + "" == ""
                                                       ? 0
                                                       : double.Parse(drmerg["MS_CAPrice"] + "");
                                    double pricePerUnit = dtCust.Rows[0]["CustomerType"] + "" == "CNT" ? dblCL : dblCA;

                                    if (strPriceUnit != "") strPriceUnit += ":";
                                    strPriceUnit += pricePerUnit.ToString("###,##0.00");

                                    doublePriceTotal += (double.Parse(drmerg["Amount"] + "") * pricePerUnit);

                                    //if (strTab != "") strTab += ":";

                                    strTab = drmerg["MedicalTab"] + "";
                                    doubleAmount = Convert.ToDouble(drmerg["Amount"] + "");
                                    //doublePriceUnit = Convert.ToDouble(dr["Price/Unit"] + "");
                                    doublePriceTotal += doubleAmount * doublePriceUnit;

                                    if (!string.IsNullOrEmpty(VN))
                                    {
                                        Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                                        supplieInfo.VN = VN;
                                        supplieInfo.MS_Code = drmerg["MS_Code"] + "";
                                        listSup.Add(supplieInfo);
                                    }

                                    FreeAmount = drmerg["FreeAmount"] + "";
                                    Complimentary = drmerg["Complimentary"] + "";
                                    MarketingBudget = drmerg["MarketingBudget"] + "";
                                    Gift = drmerg["Gift"] + "";
                                    Subject = drmerg["Subject"] + "";
                                    MedicalTab = drmerg["MedicalTab"] + "";
                                }

                                //==========================Merg Item=======================
                                //MergItem();
                            }
                            //Add New Row
                            object[] myItems = {
                                                   false,
                                                   msCode,
                                                   msName,
                                                   strAmount, //จำนวนที่ซื้อ
                                                   strNumCouse, //Num/Couse
                                                   strTotal, //Total
                                                   strUsed, //Use
                                                   strBalance, //Balance
                                                   strPriceUnit, //Price/Unit
                                                   doublePriceTotal.ToString("###,##0.00"), //PriceTotal
                                                   //imageList1.Images[0],
                                                   FreeAmount,
                                                   Complimentary == "Y" ? true : false,
                                                   MarketingBudget == "Y" ? true : false,
                                                   Gift == "Y" ? true : false,
                                                   Subject == "Y" ? true : false,
                                                   MedicalTab,
                                                   imageList1.Images[4],
                                               };
                            dataGridViewSelectList.Rows.Add(myItems);
                        }
                        else
                        {
                            double dblTotal = (double.Parse(dr["Amount"] + "") * (dr["MS_Number_C"] + "" == "" ? 0 : double.Parse(dr["MS_Number_C"] + "")));
                            double dblCL = dr["MS_CLPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CLPrice"] + "");
                            double dblCA = dr["MS_CAPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CAPrice"] + "");
                            double pricePerUnit = dtCust.Rows[0]["CustomerType"] + "" == "CNT" ? dblCL : dblCA;

                            object[] myItems = {
                                               false,
                                               dr["MS_Code"] + "",
                                               dr["MS_Name"] + "",
                                               dr["Amount"] + "",
                                               dr["MS_Number_C"] + "",
                                               dblTotal.ToString("###,##0.00"),
                                               dr["NumOfUse"] + "",
                                               (dblTotal - double.Parse(dr["NumOfUse"] + "")).ToString("###,##0.00"),
                                               pricePerUnit.ToString("###,##0.00"),
                                               (double.Parse(dr["Amount"] + "")*pricePerUnit).ToString("###,##0.00"),
                                               //imageList1.Images[0],
                                               //dr["FlagUse"]+""== "1"?false:true,
                                               
                                               dr["FreeAmount"] + "",
                                               dr["Complimentary"] + "" == "Y" ? true : false,
                                               dr["MarketingBudget"] + "" == "Y" ? true : false,
                                               dr["Gift"] + "" == "Y" ? true : false,
                                               dr["Subject"] + "" == "Y" ? true : false,
                                               dr["MedicalTab"] + "",
                                               imageList1.Images[4],
                                           };
                            dataGridViewSelectList.Rows.Add(myItems);
                        }
                        break;
                    }
                }
                //foreach (DataRow dr in dtSup.Rows)
                //{

                //}
                SumPriceMedicalOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewSelectList.Columns["BtnUse"].Index)
            {
                PopMedicalUsed obj = new PopMedicalUsed();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(170, 232, 229);
                obj.CN = CN;
                obj.VN = VN;
                obj.MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                obj.SupplieName = dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].Value + "";
                obj.AmountTotal = dataGridViewSelectList.Rows[e.RowIndex].Cells["Total"].Value + "";
                obj.AmountUsed = dataGridViewSelectList.Rows[e.RowIndex].Cells["Used"].Value + "";
                obj.AmountBalance = dataGridViewSelectList.Rows[e.RowIndex].Cells["Balance"].Value + "";
                obj.TabName = dataGridViewSelectList.CurrentRow.Cells["Tab"].Value + "";
                obj.CustomerName = txtCustomerName.Text;
                //obj.MedicalOrderUseTranss = MedicalOrderUseTranss;
                //obj.MedicalStuffs = MedicalStuffs;
                obj.ShowDialog();

                //if (obj.MedicalOrderUseTranss != null)
                //{
                //    MedicalOrderUseTranss.AddRange(obj.MedicalOrderUseTranss);
                //}
                //MedicalStuffs = obj.MedicalStuffs;
            }
        }

        public DataTable GroupByMultiple(string i_sGroupByColumn, DataTable dataSource)
        {
            var dv = new DataView(dataSource);
            //getting distinct values for group column
            dv.Sort = i_sGroupByColumn + " ASC";
            DataTable dtGroup = dv.ToTable(true, new[] { i_sGroupByColumn });
            return dtGroup;
        }

        private void SumPriceMedicalOrder()
        {
            double dblTotal = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => double.Parse(row.Cells["PriceTotal"].Value + ""));

            txtPriceTotal.Text = dblTotal.ToString("###,##0.00");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }


    }
}
