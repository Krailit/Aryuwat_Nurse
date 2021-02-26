using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class ucPivotTable : UserControl
    {
       public  DataTable dt = new DataTable();
       public DataTable newDt = new DataTable("Pivot");
        public ucPivotTable()
        {
            InitializeComponent();
        }
        public void ReloadColumn()
        {
            try
            {
                 if (dt != null)
                {
                    foreach (DataColumn dc in dt.Columns)
                        cboX.Items.Add(dc.ColumnName);
                    foreach (DataColumn dc in dt.Columns)
                        cboY.Items.Add(dc.ColumnName);
                    foreach (DataColumn dc in dt.Columns)
                        cboZ.Items.Add(dc.ColumnName);
                }
                 cboFunction.SelectedItem="SUM";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Dictionary<string, bool> dicco = new Dictionary<string, bool>();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string x = "";
                string y = "";
                string z = "";
                AggregateFunction fn = AggregateFunction.Sum;
                    	switch (cboFunction.Text)
	                    {
	                        case "Count":
		                    fn=AggregateFunction.Count;
		                    break;
	                        case "Sum":
                            fn = AggregateFunction.Sum;
		                    break;
                                  case "First":
		                    fn=AggregateFunction.First;
		                    break;
                                  case "Last":
		                    fn=AggregateFunction.Last;
		                    break;
                                  case "Average":
		                    fn=AggregateFunction.Average;
		                    break;
                                  case "Max":
		                    fn=AggregateFunction.Max;
		                    break;
                                  case "Min":
		                    fn=AggregateFunction.Min;
		                    break;
                                         case "Exists":
		                    fn=AggregateFunction.Exists;
		                    break;
	                    }

                if (cboX.SelectedItem != null)
                    x = cboX.SelectedItem.ToString();
                if (cboY.SelectedItem != null)
                    y = cboY.SelectedItem.ToString();
                if (cboZ.SelectedItem != null)
                    z = cboZ.SelectedItem.ToString();

                
                if (y != "" && z != "")
                {
                    PivotTable2 pvt = new PivotTable2(dt);
                    newDt = pvt.PivotData(x,z,fn,y);// PivotTable2.GetInversedDataTable(dt, x, y, z, txttNullValue.Text, chkSumValues.Checked);
                    //newDt = pvt.PivotData(x, z, fn, true, y);// PivotTable2.GetInversedDataTable(dt, x, y, z, txttNullValue.Text, chkSumValues.Checked);
                    dicco = pvt.dicColumn;
                    //newDt = PivotTable.GetInversedDataTable(dt, x, y, z, "-", true);
                }
                else
                {
                    //newDt = PivotTable.GetInversedDataTable(dt, x, y);
                    newDt = PivotTable.GetInversedDataTable(dt,x, y, z, "-", true);
                }

                newDt.TableName = "Pivot";
                dataGridView2.DataSource = newDt;

                foreach (DataGridViewColumn column in this.dataGridView2.Columns)
                {
                    //if (dicco.ContainsKey(column.Name)&& dicco[column.Name])
                    //{
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if(column.Name=="Total")
                        column.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9, FontStyle.Bold);
                    //    column.ValueType = typeof(Decimal);
                    //}
                }

                foreach (DataGridViewRow row in this.dataGridView2.Rows)
                {

                    if (row.Index == dataGridView2.RowCount-2)
                    {
                        //row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9, FontStyle.Bold);
                    }
                    
                }

                //int sum1 = 0, sum2 = 0;
                //for (int i = 0; i < dataGridView2.RowCount; i++)
                //{
                //    // we only sum the first and third column as an example
                //    for (int c = 1; c < dataGridView2.ColumnCount; c++)
                //    {
                //        sum1 += Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                //    }
                //    //sum1 += Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                //    //sum2 += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
                //}
                //// add the total row
                //string[] totalrow = new string[] { sum1.ToString(), "", sum2.ToString() };
                //dataGridView2.Rows.Add(totalrow);
                //// add a rowheadertitle
                //dataGridView2.RowHeadersWidth = 60;
                //dataGridView2.Rows[dataGridView2.RowCount - 1].HeaderCell.Value = "Total"; 
                //dt = newDt;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }
        }

        private void ucPivotTable_Load(object sender, EventArgs e)
        {
            try
            {
                newDt.TableName = "Pivot";
                cboFunction.SelectedItem = "SUM";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == 0 && e.RowIndex != this.dataGridView2.NewRowIndex)
                //    {
                        //double d = double.Parse(e.Value.ToString());
                        //e.Value = d.ToString("0.00##");
                   // }
            }
            catch (Exception ex)
            {
              
            }
        }
    }
}

