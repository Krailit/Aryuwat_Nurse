using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;

namespace DermasterSystem.Forms
{
    public partial class PopUserGroup : Form
    {
        private SqlDataAdapter sqlDataAdapterPersonnelType;

        private string connectionString;
        private SqlConnection sqlConnection;
        private SqlCommandBuilder sqlCommandBuilder;
        private string selectQueryString;
        private DataTable dataTablePersonnelType;
        private BindingSource bindingSource;
        public PopUserGroup()
        {
            InitializeComponent();
        }

        private void PopUserGroup_Load(object sender, EventArgs e)
        {
            FillUserGroup();
        }
        private void FillUserGroup()
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["connectionString"];
                sqlConnection = new SqlConnection(connectionString);
                selectQueryString = "SELECT * FROM [UserGroup]";

                sqlConnection.Open();

                sqlDataAdapterPersonnelType = new SqlDataAdapter(selectQueryString, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterPersonnelType);

                dataTablePersonnelType = new DataTable();
                sqlDataAdapterPersonnelType.Fill(dataTablePersonnelType);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTablePersonnelType;

                dataGridViewUserGroup.DataSource = bindingSource;

                // to hide Identity column
                dataGridViewUserGroup.Columns[0].Visible = false;
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
