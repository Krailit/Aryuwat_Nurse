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
    public partial class popPersonnelType : Form
    {
        private SqlDataAdapter sqlDataAdapterPersonnelType;

        private string connectionString;
        private SqlConnection sqlConnection;
        private SqlCommandBuilder sqlCommandBuilder;
        private string selectQueryString;
        private DataTable dataTablePersonnelType;
        private BindingSource bindingSource;
        private BindingSource bindingSourceSubDistrict;
        private string currentGrid = "";
        private bool success = false;
        public popPersonnelType()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillPersonnelType();
            dataGridViewPersonnelType.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridViewPersonnelType_CellMouseClick);
        }

        void dataGridViewPersonnelType_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    toolStripMenuUpdate.Text += " จังหวัด";
            //    contextMenuStripPopMenu.Show(MousePosition);
            //}
            //else
            //{
            //    string param =dataGridViewPersonnelType.Rows[dataGridViewPersonnelType.CurrentCell.RowIndex].Cells["Code"].Value + "";
            //}
        }
        private void FillPersonnelType()
        {
            try
            {
                 connectionString = ConfigurationManager.AppSettings["connectionString"];
                sqlConnection = new SqlConnection(connectionString);
                selectQueryString = "SELECT PersonnelType_code as รหัส,PersonnelType_name as ชื่อตำแหน่ง,PersonnelType_Order as ลำดับ FROM [PersonnelType] order by PersonnelType_Order ";
         
                sqlConnection.Open();

                sqlDataAdapterPersonnelType = new SqlDataAdapter(selectQueryString, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterPersonnelType);

                dataTablePersonnelType = new DataTable();
                sqlDataAdapterPersonnelType.Fill(dataTablePersonnelType);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTablePersonnelType;

                dataGridViewPersonnelType.DataSource = bindingSource;
            
                // to hide Identity column
                //dataGridViewPersonnelType.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTablePersonnelType != null)
                {
                    sqlDataAdapterPersonnelType.Update(dataTablePersonnelType);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                }
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
                dataGridViewPersonnelType.Rows.RemoveAt(dataGridViewPersonnelType.CurrentRow.Index);
                sqlDataAdapterPersonnelType.Update(dataTablePersonnelType);
                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave1_BtnClick()
        {
            try
            {
                if (dataTablePersonnelType != null)
                {
                    sqlDataAdapterPersonnelType.Update(dataTablePersonnelType);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel1_BtnClick()
        {
            this.Close();
        }
    }
}
