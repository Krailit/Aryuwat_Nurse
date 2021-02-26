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
    public partial class FrmMedicalUseChangCouse : DockContent, IForm
    {
        // Methods
    public FrmMedicalUseChangCouse()
    {
        this.InitializeComponent();
    }

    public void BindData()
    {
        try
        {
            this.dataGridViewSelectList.Rows.Clear();
            DataSet set = new Business.MedicalOrder().SelectMedicalOrderById(this.VN);
            DataTable table = set.Tables[0];
            DataTable dataSource = set.Tables[1];
            DataTable table3 = set.Tables[2];
            DataTable table4 = set.Tables[3];
            DataTable table5 = set.Tables[5];
            DataTable table6 = set.Tables[6];
            if (table6.Rows.Count > 0)
            {
                this.txtNewMO.Text = table6.Rows[0]["VNNew"]+"";
                this.txtPriceTotal.Text = table6.Rows[0]["PriceTotal"]+"" == ""? "0" : Convert.ToDecimal(table6.Rows[0]["PriceTotal"]).ToString("##,###,###.##");
                this.txtNewMedPriceTotal.Text = table6.Rows[0]["PriceNewVN"]+"" == "" ? "0" : Convert.ToDecimal(table6.Rows[0]["PriceNewVN"]).ToString("##,###,###.##");
                this.txtbalances.Text = table6.Rows[0]["PriceNewBalance"]+"" == "" ? "0" : Convert.ToDecimal(table6.Rows[0]["PriceNewBalance"]).ToString("##,###,###.##");
                this.txtRemark.Text = table6.Rows[0]["Remark"]+"";
                this.radioButtonPay.Checked = table6.Rows[0]["PayCash"]+"" != "" && Convert.ToBoolean(table6.Rows[0]["PayCash"]);
                this.radioButtonUse.Checked = table6.Rows[0]["PayUse"] + "" != "" && Convert.ToBoolean(table6.Rows[0]["PayUse"]);
                this.PriceTotal = table6.Rows[0]["PriceTotal"]+"" == "" ? 0M : Convert.ToDecimal(table6.Rows[0]["PriceTotal"]);
                this.PriceNewVN = table6.Rows[0]["PriceNewVN"]+"" == "" ? 0M : Convert.ToDecimal(table6.Rows[0]["PriceNewVN"]);
                this.PriceNewBalance = table6.Rows[0]["PriceNewBalance"]+"" == "" ? 0M : Convert.ToDecimal(table6.Rows[0]["PriceNewBalance"]);
            }
            this.CN = table.Rows[0]["CN"] + "";
            this.customerType = table.Rows[0]["CustomerType"] + "";
            this.txtCustomerName.Text = table.Rows[0]["FullNameThai"] + "" == "" ? table.Rows[0]["FullNameEng"] + "" : table.Rows[0]["FullNameThai"]+"";
            this.labelCN.Text = table.Rows[0]["CN"] + "";
            this.lbMO.Text = this.VN;
            DataTable table7 = this.GroupByMultiple("MergStatus", dataSource);
            foreach (DataRow row in table7.Rows)
            {
                string filterExpression = "MergStatus ='" + row["MergStatus"] + "'";
                DataRow[] rowArray = dataSource.Select(filterExpression);
                int index = 0;
                while (index < rowArray.Length)
                {
                    double num4;
                    double num5;
                    double num6;
                    double num7;
                    object[] objArray;
                    string str22;
                    double num12;
                    DataRow row2 = rowArray[index];
                    string[] strArray = row2["MergStatus"].ToString().Split(':');
                    if (strArray.Length > 1)
                    {
                        string str2 = "";
                        string str3 = "";
                        string str4 = "";
                        string str5 = "";
                        string str6 = "";
                        string str7 = "";
                        string str8 = "";
                        string str9 = "";
                        string str11 = "";
                        double num = 0.0;
                        double num2 = 0.0;
                        double num3 = 0.0;
                        string str12 = "";
                        string str13 = "";
                        string str14 = "";
                        string str15 = "";
                        string str16 = "";
                        string str17 = "";
                        string str18 = "";
                        string str19 = "";
                        int rowindex = 0;
                        foreach (string str20 in strArray)
                        {
                            string str21 = "MS_Code ='" + str20 + "'";
                           
                            foreach (DataRow row3 in dataSource.Select(str21))
                            {
                                List<SupplieTrans> list = new List<SupplieTrans>();
                                this.rowsToDelete = new List<DataGridViewRow>();
                                if (str2 != "")
                                {
                                    str2 = str2 + ":";
                                }
                                str2 = str2 + row3["MS_Code"];
                                if (str3 != "")
                                {
                                    str3 = str3 + ":";
                                }
                                str3 = str3 + row3["MS_Name"];
                                if (str4 != "")
                                {
                                    str4 = str4 + ":";
                                }
                                str4 = str4 + row3["Amount"];
                                if (str5 != "")
                                {
                                    str5 = str5 + ":";
                                }
                                str5 = str5 + row3["MS_Number_C"];
                                num4 = double.Parse(row3["Amount"]+"") * (row3["MS_Number_C"]+"" == "" ? 1.0 : double.Parse(row3["MS_Number_C"]+""));
                                if (str6 != "")
                                {
                                    str6 = str6 + ":";
                                }
                                str6 = str6 + num4;
                                if (str7 != "")
                                {
                                    str7 = str7 + ":";
                                }
                                str7 = str7 + row3["AmountOfUse"];
                                str19 = row3["ExpireDate"]+"";
                                if (str8 != "")
                                {
                                    str8 = str8 + ":";
                                }
                                num12 = num4 - double.Parse(row3["AmountOfUse"]+"");
                                str8 = str8 + num12.ToString("###,###.##");
                                num5 = (row3["MS_CLPrice"] + "" == "") ? 0.0 : double.Parse(row3["MS_CLPrice"] + "");
                                num6 = row3["MS_CAPrice"]+"" == "" ? 0.0 : double.Parse(row3["MS_CAPrice"] + "");
                                num7 = (table.Rows[0]["CustomerType"]+"" == "CNT") || (table.Rows[0]["CustomerType"]+"" == "CNM") ? num5 : num6;
                                if (str9 != "")
                                {
                                    str9 = str9 + ":";
                                }
                                str9 = str9 + num7.ToString("###,###.##");
                                num += double.Parse(row3["Amount"] + "") * num7;
                                str12 = row3["MedicalTab"] + "";
                                num2 = Convert.ToDouble(row3["Amount"]);
                                str11 = row3["PayByItem"]+"" == "" ? "" : Convert.ToDouble(row3["PayByItem"]).ToString("###,###.##");
                                num += num2 * num3;
                                if (!string.IsNullOrEmpty(this.VN))
                                {
                                    SupplieTrans item = new SupplieTrans();
                                    item.VN = this.VN;
                                        item.MS_Code = row3["MS_Code"] + "";
                                    list.Add(item);
                                }
                                str13 = row3["FreeAmount"]+"";
                                str14 = row3["Complimentary"]+"";
                                str15 = row3["MarketingBudget"]+"";
                                str16 = row3["Gift"]+"";
                                str17 = row3["Subject"]+"";
                                str18 = row3["MedicalTab"]+"";
                            }
                        }
                        objArray = new object[] { 
                            false, str2, str3, str4, str5, str6, str7, str8, str9, num.ToString("###,###.##"), str11, str13, str19, str14 == "Y", str15 == "Y", str16 == "Y", 
                            str17 == "Y", str18
                         };
                        this.dataGridViewSelectList.Rows.Add(objArray);
                        //if (str11 == "")
                        //{
                        //    this.dataGridViewSelectList.Rows[rowindex].ReadOnly = true;
                        //}
                        rowindex++;
                        str22 = string.Format("MS_Code='{0}'", str2);
                        if (table5.Select(str22).Any<DataRow>())
                        {
                            this.dgvUsedTrans.Rows.Add(objArray);
                        }
                    }
                    else
                    {
                        num4 = double.Parse(row2["Amount"] + "") * ((double.Parse(row2["MS_Number_C"] + "") == 0.0) ? 1.0 : double.Parse(row2["MS_Number_C"] + ""));
                        num5 = row2["MS_CLPrice"]+"" == "" ? 0.0 : double.Parse(row2["MS_CLPrice"] + "");
                        num6 = row2["MS_CAPrice"]+"" == "" ? 0.0 : double.Parse(row2["MS_CAPrice"] + "");
                        num7 = table.Rows[0]["CustomerType"]+"" == "CNT" || table.Rows[0]["CustomerType"]+"" == "CNM" ? num5 : num6;
                        object[] objArray2 = new object[0x12];
                        objArray2[0] = false;
                        objArray2[1] = row2["MS_Code"];
                        objArray2[2] = row2["MS_Name"];
                        objArray2[3] = row2["Amount"];
                        objArray2[4] = row2["MS_Number_C"];
                        objArray2[5] = num4.ToString("###,###.##");
                        num12 = row2["AmountOfUse"]+"" == "" ? 0.0 : double.Parse(row2["AmountOfUse"] + "");
                        objArray2[6] = num12.ToString("###,##0.##");
                        num12 = num4 - (row2["AmountOfUse"]+"" == "" ? 0.0 : double.Parse(row2["AmountOfUse"] + ""));
                        objArray2[7] = num12.ToString("###,##0.##");
                        objArray2[8] = num7.ToString("###,###.##");
                        objArray2[9] = double.Parse(row2["PriceAfterDis"] + "") .ToString("###,###.##");// (double.Parse(row2["Amount"]+"") * num7).ToString("###,###.##");
                        objArray2[10] = ((double.Parse(row2["PriceAfterDis"] + "") / num4) * num12).ToString("###,###.##"); //row2["PayByItem"] + "" == "" ? "" : double.Parse(row2["PayByItem"] + "").ToString("###,##0.##");
                        objArray2[11] = row2["ExpireDate"] + "";
                        objArray2[12] = row2["Complimentary"]+"" == "Y";
                        objArray2[13] = row2["MarketingBudget"] + "" == "Y";
                        objArray2[14] = row2["Gift"]+"" == "Y";
                        objArray2[15] = row2["Subject"]+"" == "Y";
                        objArray2[16] = row2["MedicalTab"]+"";
                        objArray = objArray2;
                        this.dataGridViewSelectList.Rows.Add(objArray);
                        str22 = string.Format("MS_Code='{0}'", row2["MS_Code"]);
                        if (table5.Select(str22).Any<DataRow>())
                        {
                            this.dgvUsedTrans.Rows.Add(objArray);
                        }
                    }
                    break;
                }
            }
            this.dataGridViewSelectList.ClearSelection();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void BindDataUsed(string MS_Code)
    {
        try
        {
            Utility.MouseOn(this);
            this.dgvUsedTrans.Rows.Clear();
            MedicalOrderUseTrans info = new MedicalOrderUseTrans {
                CN = this.CN,
                VN = this.VN,
                MS_Code = MS_Code
            };
            if (!string.IsNullOrEmpty(info.VN))
            {
                DataTable table = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransById(info).Tables[0];
                foreach (DataRowView view in table.DefaultView)
                {
                    double num = Convert.ToDouble(string.IsNullOrEmpty(view["AmountOfUse"]+"") ? "1" : (view["AmountOfUse"] + "".Replace(",", "")));
                    object[] values = new object[] { view["ID"], num.ToString("###,###,###.##"), ((view["DateOfUse"]+"" != "") ? DateTime.Parse(view["DateOfUse"]+"").Date.ToShortDateString() : ""), view["CN_USED"], view["CO"], ((view["FullNameThai"]) != "") ? (view["FullNameThai"]) : (view["FullNameEng"]), this.imageList1.Images[2], this.imageList1.Images[3] };
                    this.dgvUsedTrans.Rows.Add(values);
                }
            }
            Utility.MouseOff(this);
        }
        catch (Exception exception)
        {
            Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, exception.Message);
            Utility.MouseOff(this);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Statics.frmMedicalOrderList.BindDataMedicalOrder(1);
        base.Close();
    }

    private void btnCancel_Click_1(object sender, EventArgs e)
    {
        base.Close();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        base.Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.txtNewMO.Text.Trim() == "")
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ MO อ้างอิง");
            }
            else
            {
                this.listMS_Code = new List<Data.MedicalOrderUseTrans>();
                this.Info = new Entity.MedicalOrderUseTrans(); 
                this.Info.VNClose = this.lbMO.Text;
                this.Info.VNNew = this.txtNewMO.Text.Trim();
                this.Info.CN = this.CN;
                this.Info.CreateBy = Userinfo.EN;
                this.Info.UpdateBy = Userinfo.EN;
                this.Info.PriceTotal = txtPriceTotal.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtPriceTotal.Text.Trim().Replace(",", ""));//new decimal?(this.PriceTotal);
                this.Info.PriceNewVN = new decimal?(this.PriceNewVN);
                this.Info.PriceNewBalance = txtbalances.Text.Trim()==""?0:Convert.ToDecimal(txtbalances.Text.Trim().Replace(",",""));
                this.Info.Remark = this.txtRemark.Text;
                this.Info.PayCash = this.radioButtonPay.Checked;
                this.Info.PayUse = this.radioButtonUse.Checked;
                this.Info.ListMs = new List<MedicalOrderUseTrans>();
                foreach (DataGridViewRow row in (IEnumerable) this.dgvUsedTrans.Rows)
                {
                    MedicalOrderUseTrans item = new MedicalOrderUseTrans();
                        item.MS_Code = row.Cells["Code"].Value+"";
                        item.MSPrice = new decimal?(row.Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(row.Cells["PriceTotal"].Value));
                        this.Info.ListMs.Add(item);
                }
                int? ss = new Business.MedicalOrder().InsertMedicalOrderMove(this.Info);
                if (ss!= -1)
                {
                    MessageBox.Show("บันทึกเรียบร้อยแล้ว");
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void buttonAddDown_BtnClick()
    {
        try
        {
            this.dataGridViewSelectList.ClearSelection();
            for (int i = 0; i < this.dataGridViewSelectList.RowCount; i++)
            {
                bool flag = false;
                if ((bool) this.dataGridViewSelectList.Rows[i].Cells[0].Value)
                {
                    foreach (DataGridViewRow row in (IEnumerable) this.dgvUsedTrans.Rows)
                    {
                        if (row.Cells["Code"].Value == this.dataGridViewSelectList.Rows[i].Cells["Code"].Value)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        if (this.dataGridViewSelectList.Rows[i].Cells["PricePerUnit"].Value == "") MessageBox.Show("");
                        object[] values = new object[] { 
                            false, this.dataGridViewSelectList.Rows[i].Cells["Code"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["Name"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["Amount"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["No./Course"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["Total"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["Used"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["Balance"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["Price/Unit"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["PriceTotal"].Value
                            //, this.dataGridViewSelectList.Rows[i].Cells["Other"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["PricePerUnit"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["ExpireDate"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["ChkCom"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["ChkMar"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["ChkGiftv"].Value
                            , this.dataGridViewSelectList.Rows[i].Cells["ChkSub"].Value, 
                            this.dataGridViewSelectList.Rows[i].Cells["Tab"].Value
                         };
                        this.dgvUsedTrans.Rows.Add(values);
                    }
                }
            }
            this.SumPrice();
            foreach (DataGridViewRow row in (IEnumerable) this.dataGridViewSelectList.Rows)
            {
                row.Cells[0].Value = false;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void buttonDeleteUp_BtnClick()
    {
        try
        {
            foreach (DataGridViewRow row in (IEnumerable) this.dgvUsedTrans.Rows)
            {
                if ((bool) row.Cells[0].Value)
                {
                    this.dgvUsedTrans.Rows.Remove(row);
                }
            }
            this.SumPrice();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void buttonNewMO_Click(object sender, EventArgs e)
    {
        this.NewMedicalOrder();
    }

    private void dataGridViewSelectList_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
        }
        catch (Exception)
        {
        }
    }

    private void dataGridViewSelectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (e.ColumnIndex == this.dataGridViewSelectList.Columns["ChkMove"].Index)
            {
                if ((bool) this.dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    this.dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    this.dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    private void dataGridViewSelectList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
    {
    }

    private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        SolidBrush brush = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
        e.Graphics.DrawString(Convert.ToString((int) (e.RowIndex + 1)), ((DataGridView) sender).DefaultCellStyle.Font, brush, (float) (e.RowBounds.Location.X + 20), (float) (e.RowBounds.Location.Y + 4));
    }

    void IForm.IsDelete()
    {
    }

    void IForm.IsEdit()
    {
    }

    void IForm.IsExit()
    {
    }

    void IForm.IsNew()
    {
    }

    void IForm.IsPrint()
    {
    }

    void IForm.IsRefresh()
    {
    }

    void IForm.IsSave()
    {
    }

    private void dgvUsedTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (e.ColumnIndex == this.dgvUsedTrans.Columns["ChkMove"].Index)
            {
                if ((bool) this.dgvUsedTrans.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    this.dgvUsedTrans.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    this.dgvUsedTrans.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    private void dgvUsedTrans_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        SolidBrush brush = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
        e.Graphics.DrawString(Convert.ToString((int) (e.RowIndex + 1)), ((DataGridView) sender).DefaultCellStyle.Font, brush, (float) (e.RowBounds.Location.X + 20), (float) (e.RowBounds.Location.Y + 4));
    }


    private void FrmMedicalUseChangCouse_Load(object sender, EventArgs e)
    {
        this.SetColumnDgvSelectList();
        this.SetColumnsUsed();
        if (!string.IsNullOrEmpty(this.VN))
        {
            this.BindData();
        }
    }

    public DataTable GroupByMultiple(string i_sGroupByColumn, DataTable dataSource)
    {
        DataView view = new DataView(dataSource) {
            Sort = i_sGroupByColumn + " ASC"
        };
        return view.ToTable(true, new string[] { i_sGroupByColumn });
    }

  

    private void NewMedicalOrder()
    {
        FrmMedicalOrderSetting setting = new FrmMedicalOrderSetting {
            BackColor = Color.FromArgb(170, 0xe8, 0xe5),
            Text = this.Text + "สถานะ [เพิ่ม]",
            RefVN = this.VN,
            RefCN = this.labelCN.Text,
            RefCN_Name = this.txtCustomerName.Text,
            PriceRef = this.txtPriceTotal.Text.Replace(",", ""),
            VN = this.txtNewMO.Text.Trim(),
            customerType = this.customerType
        };
        setting.ShowDialog();
        this.txtNewMO.Text = setting.MO;
        this.PriceTotal = (this.txtPriceTotal.Text.Replace(",", "") == "") ? 0M : Convert.ToDecimal(this.txtPriceTotal.Text.Replace(",", ""));
        this.PriceNewVN = (setting.SalePriceNew.ToString().Replace(",", "") == "") ? 0M : Convert.ToDecimal(setting.SalePriceNew.ToString().Replace(",", ""));
        this.PriceNewBalance = this.PriceTotal - this.PriceNewVN;
        this.txtNewMedPriceTotal.Text = this.PriceNewVN.ToString("##,###,###.##");
        this.txtbalances.Text = this.PriceNewBalance.ToString("##,###,###.##");
    }

    private void radioButtonPay_CheckedChanged(object sender, EventArgs e)
    {
        this.radioButtonUse.Checked = !this.radioButtonPay.Checked;
    }

    private void radioButtonUse_CheckedChanged(object sender, EventArgs e)
    {
        this.radioButtonPay.Checked = !this.radioButtonUse.Checked;
    }

    private void SetColumnDgvSelectList()
    {
        Utility.SetPropertyDgv(this.dataGridViewSelectList);
        this.dataGridViewSelectList.AllowUserToAddRows = false;
        this.dataGridViewSelectList.DefaultCellStyle.BackColor = Color.DarkGray;
        DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkMove",
            HeaderText = "",
            CellTemplate = new DataGridViewCheckBoxCell()
        };
        dataGridViewColumn.CellTemplate.Style.BackColor = Color.Beige;
        this.dataGridViewSelectList.Columns.Add(dataGridViewColumn);
        this.dataGridViewSelectList.Columns.Add("Code", "Code");
        //this.dataGridViewSelectList.Columns["Code"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("Name", "ข้อมูลการซื้อ");
        this.dataGridViewSelectList.Columns["Name"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("Amount", "Quanti");
        this.dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
        this.dataGridViewSelectList.Columns["Amount"].Width = 30;
        this.dataGridViewSelectList.Columns["Amount"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("No./Course", "No./Course");
        this.dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dataGridViewSelectList.Columns["No./Course"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("Total", "Total");
        this.dataGridViewSelectList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dataGridViewSelectList.Columns["Total"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("Used", "Used");
        this.dataGridViewSelectList.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dataGridViewSelectList.Columns["Used"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("Balance", "Balance");
        this.dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.BackColor = Color.LemonChiffon;
        this.dataGridViewSelectList.Columns["Balance"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("Price/Unit", "Price/Unit");
        this.dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dataGridViewSelectList.Columns["Price/Unit"].ReadOnly = true;
        this.dataGridViewSelectList.Columns.Add("PriceTotal", "ราคาหลังหักส่วลด");
        this.dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dataGridViewSelectList.Columns["PriceTotal"].ReadOnly = true;
        //this.dataGridViewSelectList.Columns.Add("PayByItem", "จ่ายแล้ว");
        //this.dataGridViewSelectList.Columns["PayByItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.dataGridViewSelectList.Columns["PayByItem"].DefaultCellStyle.ForeColor = Color.Blue;
        //this.dataGridViewSelectList.Columns["PayByItem"].ReadOnly = true;
        //this.dataGridViewSelectList.Columns["PayByItem"].Visible = false;
        this.dataGridViewSelectList.Columns.Add("PricePerUnit", "ราคาส่วนที่เหลือ");
        this.dataGridViewSelectList.Columns["PricePerUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["PricePerUnit"].DefaultCellStyle.BackColor = Color.LemonChiffon;
        this.dataGridViewSelectList.Columns["PricePerUnit"].Visible = true;
        this.dataGridViewSelectList.Columns.Add("ExpireDate", "Expire Date");
        this.dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.BackColor = Color.LemonChiffon;
        this.dataGridViewSelectList.Columns["ExpireDate"].ReadOnly = true;
        DataGridViewCheckBoxColumn column2 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkCom",
            HeaderText = "Comp.",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dataGridViewSelectList.Columns.Add(column2);
        DataGridViewCheckBoxColumn column3 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkMar",
            HeaderText = "M.Budget",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dataGridViewSelectList.Columns.Add(column3);
        DataGridViewCheckBoxColumn column4 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkGiftv",
            HeaderText = "Gift V.",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dataGridViewSelectList.Columns.Add(column4);
        DataGridViewCheckBoxColumn column5 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkSub",
            HeaderText = "Subject",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dataGridViewSelectList.Columns.Add(column5);
        this.dataGridViewSelectList.Columns.Add("Tab", "Tab");
        this.dataGridViewSelectList.Columns["Tab"].ReadOnly = true;
    }

    private void SetColumnsUsed()
    {
        Utility.SetPropertyDgv(this.dgvUsedTrans);
        this.dgvUsedTrans.AllowUserToAddRows = false;
        this.dgvUsedTrans.DefaultCellStyle.BackColor = Color.DarkGray;
        DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkMove",
            HeaderText = "",
            CellTemplate = new DataGridViewCheckBoxCell()
        };
        dataGridViewColumn.CellTemplate.Style.BackColor = Color.Beige;
        dataGridViewColumn.ReadOnly = false;
        this.dgvUsedTrans.Columns.Add(dataGridViewColumn);
        this.dgvUsedTrans.Columns.Add("Code", "Code");
        this.dgvUsedTrans.Columns["Code"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("Name", "ข้อมูลการซื้อ");
        this.dgvUsedTrans.Columns["Name"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("Amount", "Quanti");
        this.dgvUsedTrans.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
        this.dgvUsedTrans.Columns["Amount"].Width = 30;
        this.dgvUsedTrans.Columns["Amount"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("No./Course", "No./Course");
        this.dgvUsedTrans.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dgvUsedTrans.Columns["No./Course"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("Total", "Total");
        this.dgvUsedTrans.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dgvUsedTrans.Columns["Total"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("Used", "Used");
        this.dgvUsedTrans.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dgvUsedTrans.Columns["Used"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("Balance", "Balance");
        this.dgvUsedTrans.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dgvUsedTrans.Columns["Balance"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("Price/Unit", "Price/Unit");
        this.dgvUsedTrans.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dgvUsedTrans.Columns["Price/Unit"].ReadOnly = true;
        this.dgvUsedTrans.Columns.Add("PriceTotal", "ราคาหลังหักส่วนลด");
        this.dgvUsedTrans.Columns["PriceTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["PriceTotal"].DefaultCellStyle.ForeColor = Color.Blue;
        this.dgvUsedTrans.Columns["PriceTotal"].ReadOnly = true;
        //this.dgvUsedTrans.Columns.Add("PayByItem", "จ่ายแล้ว");
        //this.dgvUsedTrans.Columns["PayByItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.dgvUsedTrans.Columns["PayByItem"].DefaultCellStyle.ForeColor = Color.Blue;
        //this.dgvUsedTrans.Columns["PayByItem"].ReadOnly = true;
        //this.dgvUsedTrans.Columns["PayByItem"].Visible = false;
        this.dgvUsedTrans.Columns.Add("PricePerUnit", "ราคาส่วนที่เหลือ");
        this.dgvUsedTrans.Columns["PricePerUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["PricePerUnit"].DefaultCellStyle.BackColor = Color.LemonChiffon;
        this.dgvUsedTrans.Columns["PricePerUnit"].Visible = true;
        this.dgvUsedTrans.Columns.Add("ExpireDate", "Expire Date");
        this.dgvUsedTrans.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvUsedTrans.Columns["ExpireDate"].DefaultCellStyle.BackColor = Color.LemonChiffon;
        this.dgvUsedTrans.Columns["ExpireDate"].ReadOnly = true;
        DataGridViewCheckBoxColumn column2 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkCom",
            HeaderText = "Comp.",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dgvUsedTrans.Columns.Add(column2);
        DataGridViewCheckBoxColumn column3 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkMar",
            HeaderText = "M.Budget",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dgvUsedTrans.Columns.Add(column3);
        DataGridViewCheckBoxColumn column4 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkGiftv",
            HeaderText = "Gift V.",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dgvUsedTrans.Columns.Add(column4);
        DataGridViewCheckBoxColumn column5 = new DataGridViewCheckBoxColumn {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            FlatStyle = FlatStyle.Standard,
            ThreeState = false,
            Name = "ChkSub",
            HeaderText = "Subject",
            CellTemplate = new DataGridViewCheckBoxCell(),
            ReadOnly = true
        };
        this.dgvUsedTrans.Columns.Add(column5);
        this.dgvUsedTrans.Columns.Add("Tab", "Tab");
        this.dgvUsedTrans.Columns["Tab"].ReadOnly = true;
    }

    private void SumPrice()
    {
        try
        {
            this.txtPriceTotal.Text = this.dgvUsedTrans.Rows.Cast<DataGridViewRow>().Sum<DataGridViewRow>(((Func<DataGridViewRow, double>)(row => double.Parse(row.Cells["PricePerUnit"].Value + "" == "" ? "0" : row.Cells["PricePerUnit"].Value + "")))).ToString("###,###.##");

            this.PriceTotal = (this.txtPriceTotal.Text.Replace(",", "") == "") ? 0M : Convert.ToDecimal(this.txtPriceTotal.Text.Replace(",", ""));
            this.PriceNewVN = (txtNewMedPriceTotal.Text.Replace(",", "") == "") ? 0M : Convert.ToDecimal(txtNewMedPriceTotal.Text.Replace(",", ""));
            this.PriceNewBalance = this.PriceTotal - this.PriceNewVN;
            this.txtNewMedPriceTotal.Text = this.PriceNewVN.ToString("##,###,###.##");
            this.txtbalances.Text = this.PriceNewBalance.ToString("##,###,###.##");
        }
        catch (Exception)
        {
        }
    }

    // Properties
    public string CN { get; set; }

    public string VN { get; set; }

    private void dataGridViewSelectList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        try
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && dataGridViewSelectList.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[e.RowIndex].Cells[0];
                
                if (dataGridViewSelectList["PricePerUnit", e.RowIndex].Value == "")
                {
                    ch1.Value = false;
                    e.PaintBackground(e.CellBounds, false);
                    e.Handled = true;
                    dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                }

                //if (e.Value == null || !(bool)e.Value) {
                //    e.PaintBackground(e.CellBounds, false);
                //    e.Handled = true;
                //}
            }
        }
        catch (Exception)
        {
        }
    }
}
}

