using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using System.IO;
using System.Diagnostics;

namespace AryuwatSystem.Forms
{
    public partial class popFileScanOPD : Form
    {
        public string CN = "";
        public string CN_Name = "";
        public DataTable dtFileOPD;
        public popFileScanOPD()
        {
            InitializeComponent();
        }
        private void SetColumnDgvFile()
        {
            try
            {
                dgvFile.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvFile_RowPostPaint);
                DerUtility.SetPropertyDgv(dgvFile);

                dgvFile.Columns.Add("DateScan", "วันที่");
                dgvFile.Columns.Add("FilePath", "FilePath");
                dgvFile.Columns.Add("FileName", "ชื่อไฟล์");
                dgvFile.Columns.Add("Detail", "รายละเอียด");
                //DataGridViewImageColumn colFile = new DataGridViewImageColumn();
                //{
                //    colFile.AutoSizeMode =
                //        DataGridViewAutoSizeColumnMode.DisplayedCells;
                //    colFile.CellTemplate = new DataGridViewImageCell();
                //    colFile.Name = "DelFile";
                //}
                //dgvFile.Columns.Add(colFile);
                DataGridViewImageColumn colDown = new DataGridViewImageColumn();
                {
                    colDown.AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colDown.CellTemplate = new DataGridViewImageCell();
                    colDown.Name = "OpenFile";
                }

                dgvFile.Columns.Add(colDown);
                dgvFile.Columns.Add("NewRow", "NewRow");
                dgvFile.Columns.Add("Id", "Id");

                dgvFile.Columns["DateScan"].Width = 60;
                dgvFile.Columns["FilePath"].Width = 200;
                dgvFile.Columns["Detail"].Width = 200;
                //dgvFile.Columns["DelFile"].Width = 40;
                dgvFile.Columns["OpenFile"].Width = 40;
                dgvFile.Columns["FilePath"].Visible = false;
                dgvFile.Columns["NewRow"].Visible = false;
                dgvFile.Columns["Id"].Visible = false;
                dgvFile.Columns["FileName"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void dgvFile_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        private void popFileScanOPD_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}({1})",CN_Name,CN);
            SetColumnDgvFile();
            //===============FileOPD===============
            //DataSet ds = new Business.Customer().SelectCustomerOpdScan(CN);
            //if (ds.Tables.Count == 0) return;

             
            if (dtFileOPD.Rows.Count > 0)
            {
                foreach (DataRow item in dtFileOPD.Rows)
                {
                    object[] myItems = {
                                             Convert.ToDateTime(item["DateScan"]+"").ToString("yyyy/MM/dd"),
                                            "",
                                              item["FileName"],
                                            item["Detail"],
                                            //imageList1.Images[2],
                                            imageList1.Images[1],
                                            "False",
                                            item["Id"]
                                            };
                    dgvFile.Rows.Add(myItems);
                }
                dgvFile.ClearSelection();
            }
        }

        private void dgvFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvFile.Columns["OpenFile"].Index)
                {
                    
                    DownLoadImage(dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "");

                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void DownLoadImage(string filenameWithExt)
        {
            try
            {
                string _imagetPath = string.Format(@"{0}\{1}\{2}\{3}\{4}", Application.StartupPath, "MEDICALDOC", CN, "FILEOPD", filenameWithExt);
                string Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FILEOPD", filenameWithExt);
                /* Create Object Instance */
                string Remote_Folder = string.Format(@"{0}\MEDICALDOC\{1}\{2}", Application.StartupPath, CN, "FILEOPD");
                DirectoryInfo df = new DirectoryInfo(Remote_Folder);
                if (!df.Exists)
                    df.Create();

                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
               
                ftpClient.download(Remote_imagetPath, _imagetPath);

                ftpClient = null;
                if (File.Exists(_imagetPath))
                    Process.Start(_imagetPath);
                else MessageBox.Show("File not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
