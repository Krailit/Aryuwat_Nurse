using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace DermasterSystem.Forms
{
    public partial class PopBaseAdministrative : Form
    {
        private SqlDataAdapter sqlDataAdapterProvince;
        private SqlDataAdapter sqlDataAdapterDistrict;
        private SqlDataAdapter sqlDataAdapterSubDistrict;
        private SqlCommandBuilder sqlCommandBuilder;
        private string connectionString;
        private SqlConnection sqlConnection;
        private string selectQueryString;
        private DataTable dataTableProvince;
        private DataTable dataTableDistrict;
        private DataTable dataTableSubDistrict;
        private BindingSource bindingSource;
        private BindingSource bindingSourceSubDistrict;
        private string currentGrid = "";
        private bool success = false;
        public PopBaseAdministrative()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillProvince();
            FillDistrict("");
            FillSubDistrict("");
            //dataGridViewProvince.SelectionChanged += new EventHandler(dataGridViewProvince_SelectionChanged);
            //dataGridViewDistrict.SelectionChanged += new EventHandler(dataGridViewDistrict_SelectionChanged);
            //dataGridViewSubDistrict.SelectionChanged += new EventHandler(dataGridViewSubDistrict_SelectionChanged);
            dataGridViewProvince.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridViewProvince_CellMouseClick);
            dataGridViewDistrict.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridViewDistrict_CellMouseClick);
            dataGridViewSubDistrict.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridViewSubDistrict_CellMouseClick);
        }

        void dataGridViewSubDistrict_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentGrid = "SUBDISTRICTS";
                toolStripMenuUpdate.Text += " ตำบล/แขวง";
                contextMenuStripPopMenu.Show(MousePosition);
            }
            else
            {
            }
        }

        void dataGridViewDistrict_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentGrid = "DISTRICTS";
                toolStripMenuUpdate.Text += " อำเภอ/เขต";
                contextMenuStripPopMenu.Show(MousePosition);
            }
            else
            {
                string param = dataGridViewDistrict.Rows[dataGridViewDistrict.CurrentCell.RowIndex].Cells["DCODE"].Value + "";
                FillSubDistrict(param);
            }
        }

        void dataGridViewProvince_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentGrid = "PROVINCES";
                toolStripMenuUpdate.Text += " จังหวัด";
                contextMenuStripPopMenu.Show(MousePosition);
            }
            else
            {
                string param =dataGridViewProvince.Rows[dataGridViewProvince.CurrentCell.RowIndex].Cells["Code"].Value + "";
                FillDistrict(param);
            }
        }

      
        private void FillProvince()
        {
            try
            {
                 connectionString = ConfigurationManager.AppSettings["connectionString"];
                sqlConnection = new SqlConnection(connectionString);
                selectQueryString = "SELECT ID, Province_code as Code,Province_name AS Name FROM Provinces";

                sqlConnection.Open();

                sqlDataAdapterProvince = new SqlDataAdapter(selectQueryString, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterProvince);

                dataTableProvince = new DataTable();
                sqlDataAdapterProvince.Fill(dataTableProvince);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTableProvince;

                dataGridViewProvince.DataSource = bindingSource;
            
                // to hide Identity column
                dataGridViewProvince.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillDistrict(string ProvinceCode)
        {
            try
            {
                if(string.IsNullOrEmpty(ProvinceCode))return;
                connectionString = ConfigurationManager.AppSettings["connectionString"];
                sqlConnection = new SqlConnection(connectionString);
                selectQueryString = "SELECT ID, PROVINCE_CODE as PCODE,District_code as DCode,District_name as DName FROM Districts where [PROVINCE_CODE]=" + ProvinceCode;

                sqlConnection.Open();

                sqlDataAdapterDistrict = new SqlDataAdapter(selectQueryString, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterDistrict);

                dataTableDistrict = new DataTable();
                sqlDataAdapterDistrict.Fill(dataTableDistrict);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTableDistrict;

                dataGridViewDistrict.DataSource = bindingSource;

                // to hide Identity column
                dataGridViewDistrict.Columns[0].Visible = false;

                dataGridViewSubDistrict.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillSubDistrict(string districtCode)
        {
            try
            {
                if (string.IsNullOrEmpty(districtCode)) return;
                connectionString = ConfigurationManager.AppSettings["connectionString"];
                sqlConnection = new SqlConnection(connectionString);
                selectQueryString = "SELECT ID,District_code as DCode,SubDistrict_code as SDCode,SubDistrict_name as SDName FROM SubDistricts where [DISTRICT_CODE]=" + districtCode;

                sqlConnection.Open();

                sqlDataAdapterSubDistrict = new SqlDataAdapter(selectQueryString, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterSubDistrict);

                dataTableSubDistrict = new DataTable();
                sqlDataAdapterSubDistrict.Fill(dataTableSubDistrict);
                bindingSourceSubDistrict = new BindingSource { DataSource = dataTableSubDistrict };

                dataGridViewSubDistrict.DataSource = bindingSourceSubDistrict;

                // to hide Identity column
                dataGridViewSubDistrict.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!isValidEmail(textBox1.Text.Trim()))
            {
                MessageBox.Show("Email invalid");
            }
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private void dataGridViewProvince_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridViewDistrict_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }
        private void addUpadateButton_Click(object sender, EventArgs e)
        {
            try
            {
               
             
               

                MessageBox.Show("บันทึกเรียบร้อบแล้ว");
            }
            catch (Exception exceptionObj)
            {
                //MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewProvince.Rows.RemoveAt(dataGridViewProvince.CurrentRow.Index);
                sqlDataAdapterProvince.Update(dataTableProvince);
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void toolStripMenuUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                success = false;
                switch (currentGrid)
                {
                    case "PROVINCES":
                        if (dataTableProvince != null)
                            sqlDataAdapterProvince.Update(dataTableProvince);
                        success = true;
                        break;
                    case "DISTRICTS":
                        if (dataTableDistrict != null)
                            sqlDataAdapterDistrict.Update(dataTableDistrict);
                        success = true;
                        break;
                    case "SUBDISTRICTS":
                        if (dataTableSubDistrict != null)
                            sqlDataAdapterSubDistrict.Update(dataTableSubDistrict);
                        success = true;
                        break;
                }
                if (success)
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }

        private void toolStripMenuDel_Click(object sender, EventArgs e)
        {
            try
            {
                success = false;
                switch (currentGrid)
                {
                    case "PROVINCES":
                        dataGridViewProvince.Rows.RemoveAt(dataGridViewProvince.CurrentRow.Index);
                        sqlDataAdapterProvince.Update(dataTableProvince);
                        success = true;
                        break;
                    case "DISTRICTS":
                        dataGridViewDistrict.Rows.RemoveAt(dataGridViewDistrict.CurrentRow.Index);
                        sqlDataAdapterDistrict.Update(dataTableDistrict);
                        success = true;
                        break;
                    case "SUBDISTRICTS":
                        dataGridViewSubDistrict.Rows.RemoveAt(dataGridViewSubDistrict.CurrentRow.Index);
                        sqlDataAdapterSubDistrict.Update(dataTableSubDistrict);
                        success = true;
                        break;
                }
                if (success)
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
