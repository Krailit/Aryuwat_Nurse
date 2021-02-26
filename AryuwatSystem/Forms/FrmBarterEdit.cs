using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.Forms
{
    public partial class FrmBarterEdit : Form
    {
      public bool Import = false;
      private DataTable dtImport = new DataTable();
        public FrmBarterEdit()
        {
            InitializeComponent();
        }

        private void buttonSave1_BtnClick()
        {
            try
            {
                SaveImport(dtImport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveImport(DataTable dt)
        {
            try
            {
                int i = 0;
                int c = 0;
                StringBuilder sb=new StringBuilder();
                foreach (DataRow item in dt.Rows)
                {
                    c++;
                    i++;
                    //sb.Append(string.Format("INSERT INTO dbo.GiftVoucher(GiftCode,PriceCredit,GiftDetail,DateStart,DateEnd,Gift_Active) VALUES('{0}',{1},'{2}','{3}','{4}','{5}');", item["GiftCode"], item["PriceCredit"], item["GiftDetail"], item["DateStart"] + "" == "" ? DBNull.Value+"" : item["DateStart"] + "", item["DateEnd"] + "" == "" ? DBNull.Value+"" : item["DateEnd"] + "", item["Gift_Active"]));
                    sb.Append(string.Format("INSERT INTO dbo.Barter(BarterCode,PriceCredit,BarterDetail,Barter_Active) VALUES('{0}',{1},'{2}','{3}');", item["BarterCode"], item["PriceCredit"], item["BarterDetail"], item["Barter_Active"]));
                    if (c == 50 || i == dt.Rows.Count)
                    {
                        int exc = new Business.GiftVoucher_Barter().ImportBarter(sb.ToString());
                        c = 0;
                        sb = new StringBuilder();
                    }
              
                    
                }
                MessageBox.Show("Saved");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmBarterEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (Import)
                {
                    OpenFileDialog filedlgExcel = new OpenFileDialog();
                    filedlgExcel.Title = "Select file";
                    filedlgExcel.InitialDirectory = @"c:\";
                    //filedlgExcel.FileName = textBox1.Text;
                    filedlgExcel.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                    filedlgExcel.FilterIndex = 1;
                    filedlgExcel.RestoreDirectory = true;
                    if (filedlgExcel.ShowDialog() == DialogResult.OK && filedlgExcel.FileName != "")
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dtImport = DatasExcel(filedlgExcel.FileName);
                    }
                }
                else
                {
                     dtImport = new DataTable();
                     dtImport.Columns.Add("BarterCode", typeof(string));
                     dtImport.Columns.Add("PriceCredit", typeof(int));
                     dtImport.Columns.Add("BarterDetail", typeof(string));
                     dtImport.Columns.Add("Barter_Active", typeof(string));
                     dataGridView1.DataSource = dtImport;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static DataTable DatasExcel(string filename)
        {

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;


            var missing = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filename, false, true, missing, missing, missing, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range xlRange = xlWorkSheet.UsedRange;
            Array myValues = (Array)xlRange.Cells.Value2;

            int vertical = myValues.GetLength(0);
            int horizontal = myValues.GetLength(1);

            System.Data.DataTable dt = new System.Data.DataTable();

            // must start with index = 1
            // get header information
            for (int i = 1; i <= horizontal; i++)
            {
                dt.Columns.Add(new DataColumn(myValues.GetValue(1, i).ToString()));
            }

            // Get the row information
            for (int a = 2; a <= vertical; a++)
            {
                object[] poop = new object[horizontal];
                for (int b = 1; b <= horizontal; b++)
                {
                    poop[b - 1] = myValues.GetValue(a, b);
                }
                DataRow row = dt.NewRow();
                row.ItemArray = poop;
                dt.Rows.Add(row);
            }

            //assign table to default data grid view
            //dataGridView1.DataSource = dt;

            xlWorkBook.Close(true, missing, missing);
            xlApp.Quit();
            return dt;

        }

        private void buttonAdd1_BtnClick()
        {
            try
            {
                //txtCredit.Text = "";
                //txtDetail.Text = "";
                //txtGiftCode.Text = "";
                //object[] myItems = {
                //                          txtGiftCode.Text,
                //                          txtCredit.Text ,
                //                          txtDetail.Text,
                //                          "Y"
                //                      };
                //dataGridView1.Rows.Add(myItems);                
                dtImport.Rows.Add(txtGiftCode.Text, Convert.ToDecimal( txtCredit.Text),   txtDetail.Text, "Y");
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
