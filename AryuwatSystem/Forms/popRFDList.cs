using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class popRFDList : DockContent
    {
        DataTable dtRFD = new DataTable();
        public popRFDList()
        {
            InitializeComponent();
            dateTimePickerSt.Value = DateTime.Now.Date.AddMonths(-1);
            dateTimePickerEnd.Value.AddDays(1);
        }

        private void buttonFind_BtnClick()
        {
            SearchRFD();
        }
        private void SearchRFD()
        {
            try
            {

               // ResetItem();
                if (dataGridViewREQItem.RowCount > 0)
                    dataGridViewREQItem.Rows.Clear();
                Entity.Refund info = new Entity.Refund();
                info.QueryType = "SelectRefund";

                info.StartDate = dateTimePickerSt.Value;
                info.EndDate = dateTimePickerEnd.Value.AddDays(1);


                DataSet ds = new Business.Refund().SelectRefund(info);
                if (ds.Tables.Count <= 0) return;

                dtRFD = ds.Tables[0];
                List<string> LSREQ = new List<string>();
                foreach (DataRowView item in dtRFD.DefaultView)
                {
                            //if (LSREQ.Contains(item["REQNo"] + "") || item["REQNo"] + "" == "") continue;
                            object[] myItems = 
                                                    {
                                                    Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(item["RefundDate"] + "")).ToString("dd/MM/yyyy"),
                                                    item["RFD"] + "",
                                                    item["RFDCust"] + "",
                                                    item["Refund"] + ""==""?"0":Convert.ToDecimal(item["Refund"] + "").ToString("###,###,###.##"),
                                                    item["RefundTypeName"] + "",//RefundTypeName
                                                    item["PayTypeText"] + "",
                                                    item["MS_Name"] + "",
                                                    (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[3]:new Bitmap(1, 1),
                                              };
                            dataGridViewREQItem.Rows.Add(myItems);
                            LSREQ.Add(item["RFD"] + "");
                    
                }
                //dataGridViewREQItem.ClearSelection();
                if (dataGridViewREQItem.RowCount > 0) dataGridViewREQItem.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void dataGridViewREQItem_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex < 0 || e.ColumnIndex<0) return;
        //        popRefundReq p = new popRefundReq();
        //        p.RFD = dataGridViewREQItem.Rows[e.RowIndex].Cells["RFD"].Value + "";
        //        p.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void dataGridViewREQItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dataGridViewREQItem_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                popRefundReq p = new popRefundReq();
                p.RFD = dataGridViewREQItem.Rows[e.RowIndex].Cells["RFD"].Value + "";
                p.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void popRFDList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Statics.poprfdList = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
