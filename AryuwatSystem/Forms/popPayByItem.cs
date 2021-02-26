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

namespace AryuwatSystem.Forms
{
    public partial class popPayByItem : Form
    {
        public string CN { get; set; }
        public string VN { get; set; }
        public string MS_Code { get; set; }
        public string SOno { get; set; }
        public string ListOrder { get; set; }
        public string PriceAfterDis { get; set; }
        public string Product { get; set; }
        //public string PayRefID { get; set; }
        public Dictionary<string, List<MembersTrans>> dicMemberTran = new Dictionary<string, List<MembersTrans>>();
        public bool UsedForm = false;
        public bool DisableSave = false;
        static popPayByItem _objMe = null;
        public List<MembersTrans> member = new List<MembersTrans>();
        DataSet ds = null;
        public popPayByItem()
        {
            InitializeComponent();
        }

      
      
        public static popPayByItem GetInstance()
        {
            if (_objMe == null)
            {
                _objMe = new popPayByItem();
            }
            return _objMe;
        }
        private void popPayByItem_Load(object sender, EventArgs e)
        {
            this.Text = MS_Code + "-" + ListOrder + "/" + Product + "/(" + PriceAfterDis + ")";
            try
            {
                member = new List<MembersTrans>();

                DataSet ds = new Business.SumOfTreatment().SelectPayByItem(SOno, MS_Code, ListOrder);
                if (ds.Tables.Count <= 0) return;

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    object[] myItems = {
                                                     item["CashMoney"]+""==""?"":Convert.ToDouble(item["CashMoney"]+"").ToString("###,###,###.##"),
                                                     item["MoneyCredit"]+""==""?"":Convert.ToDouble(item["MoneyCredit"]+"").ToString("###,###,###.##"),
                                                     item["PayDate"]+""==""?"":Convert.ToDateTime(item["PayDate"]+"").ToString("yyy/MM/dd"),
                                                     item["PayRefID"]+""
                                                     
                                           };
                    dataGridViewCashTransfer.Rows.Add(myItems);
                }
                //dataGridViewCashTransfer.ClearSelection();

                DerUtility.GetSetInputKeyBorad("english");
                if (DisableSave)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "จะไม่สามารถแก้ไขข้อมูลได้เนื่องจาก เกินกำหนดเวลา หรือตัดคอร์สไปแล้ว");
                    btnOK.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void setCheckMemberTrans()
        {
            try 
	        {
                if (!dicMemberTran.Any()) return;
                if (dicMemberTran.ContainsKey(MS_Code))
                {
                    List<Entity.MembersTrans> ls=dicMemberTran[MS_Code];
                   
                    foreach (Entity.MembersTrans item in ls)
                    {
                        foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                        {
                            //string c = row.Cells["CN"].Value + "";
                            //DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                            //if (item.CN.ToLower() == c.ToLower())
                            //{
                            //    chk.Value = true;
                            //}
                        }
                    }
                }

	        }
	        catch (Exception ex)
	        {
		        MessageBox.Show(ex.Message);
	        }
        }
        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

     

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                List<Entity.CreditCardSOT> lsInfo = new List<CreditCardSOT>();
                
                foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                {
                    //if(row.Cells["CashCurrent"].Value + ""=="")continue;

                    Entity.CreditCardSOT info = new CreditCardSOT();
                    info.SO = SOno;
                    info.MS_Code = this.MS_Code;
                    info.ListOrder=this.ListOrder;

                    info.CashMoney = row.Cells["CashCurrent"].Value + ""==""?0:Convert.ToDecimal(row.Cells["CashCurrent"].Value + "");
                    info.MoneyCredit = row.Cells["MoneyCredit"].Value + "" == "" ? 0 : Convert.ToDecimal(row.Cells["MoneyCredit"].Value + "");
                    info.DateUpdate = row.Cells["PayDate"].Value + ""==""?DateTime.Now:Convert.ToDateTime(row.Cells["PayDate"].Value + "");
                    
                    info.PayRefID = row.Cells["PayRefID"].Value + "";
                    
                    lsInfo.Add(info);
                }


                var intmember = new Business.SumOfTreatment().InsertPayByItem(lsInfo);
        
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

            private void dataGridViewCashTransfer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                if (dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "" == "") return;
                if (e.ColumnIndex == dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayDate"].ColumnIndex)
                {
                    DateTime d;
                    d = DateTime.TryParse(dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayDate"].Value + "", out d) ? d : DateTime.Now;
                    dataGridViewCashTransfer["PayDate", dataGridViewCashTransfer.CurrentRow.Index].Value = String.Format("{0:yyyy/MM/dd}", d);
                }
                dataGridViewCashTransfer[0, dataGridViewCashTransfer.CurrentRow.Index].Value = Convert.ToDouble(dataGridViewCashTransfer[0, dataGridViewCashTransfer.CurrentRow.Index].Value + "" == "" ? "0" : dataGridViewCashTransfer[0, dataGridViewCashTransfer.CurrentRow.Index].Value).ToString("###,###,###.##");
                dataGridViewCashTransfer[1, dataGridViewCashTransfer.CurrentRow.Index].Value = Convert.ToDouble(dataGridViewCashTransfer[1, dataGridViewCashTransfer.CurrentRow.Index].Value + "" == "" ? "0" : dataGridViewCashTransfer[1, dataGridViewCashTransfer.CurrentRow.Index].Value).ToString("###,###,###.##");
                //else 
                //{
                //    //dataGridViewCashTransfer[e.ColumnIndex, dataGridViewCashTransfer.CurrentRow.Index].Value = Convert.ToDouble(dataGridViewCashTransfer[e.ColumnIndex, dataGridViewCashTransfer.CurrentRow.Index].Value).ToString("###,###,###.##");
                //    dataGridViewCashTransfer["PayRefID", dataGridViewCashTransfer.CurrentRow.Index].Value = (dataGridViewCashTransfer["PayRefID", dataGridViewCashTransfer.CurrentRow.Index].Value + "").Replace(",", "");
                //    //dataGridViewCashTransfer[e.ColumnIndex, dataGridViewCashTransfer.CurrentRow.Index].Value = Convert.ToDouble(dataGridViewCashTransfer[e.ColumnIndex, dataGridViewCashTransfer.CurrentRow.Index].Value).ToString("###,###,###.##");
                //}
                    double sum = 0;
                    foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                    {
                        if (row.Cells["CashCurrent"].Value + "" == "") continue;
                        sum = sum + Convert.ToDouble(row.Cells["CashCurrent"].Value + "" == "" ? "0" : row.Cells["CashCurrent"].Value + "") + Convert.ToDouble(row.Cells["MoneyCredit"].Value + "" == "" ? "0" : row.Cells["MoneyCredit"].Value + "");

                        //sum + = Convert.ToDateTime(row.Cells["PayDate"].Value + "");

                    }
                    if (Convert.ToDouble(PriceAfterDis) - sum < 0)
                    {
                        double Currentvalue = Convert.ToDouble(dataGridViewCashTransfer[0, dataGridViewCashTransfer.CurrentRow.Index].Value);
                        dataGridViewCashTransfer[0, dataGridViewCashTransfer.CurrentRow.Index].Value = Currentvalue + (Convert.ToDouble(PriceAfterDis) - sum);
                    }
                

            }
            catch (Exception ex)
            {
                 dataGridViewCashTransfer[1, dataGridViewCashTransfer.CurrentRow.Index].Value = "";
                 dataGridViewCashTransfer[0, dataGridViewCashTransfer.CurrentRow.Index].Value = "";
            }
        }

        private void dataGridViewCashTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayDate"].ColumnIndex && (dataGridViewCashTransfer.Rows[e.RowIndex].Cells["CashCurrent"].Value + "" != "" || dataGridViewCashTransfer.Rows[e.RowIndex].Cells["MoneyCredit"].Value + "" != ""))
                {
                    PopDateTime pp = new PopDateTime();
                    DateTime d;
                    pp.SelecttDate = DateTime.TryParse(dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayDate"].Value + "", out d) ? d : DateTime.Now;
                    //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("yyyy/MM/dd"));
                    if (pp.ShowDialog() == DialogResult.OK)
                    {
                        dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd_BtnClick()
        {

        }

        private void buttonDelete_BtnClick()
        {

        }

        private void popPayByItem_Shown(object sender, EventArgs e)
        {
            try
            {
                dataGridViewCashTransfer.Focus();
                this.dataGridViewCashTransfer.CurrentCell = this.dataGridViewCashTransfer[0, dataGridViewCashTransfer.Rows.Count == 0 ? 0 : dataGridViewCashTransfer.Rows.Count - 1];
                dataGridViewCashTransfer.BeginEdit(true);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

    }
}
