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
using AryuwatSystem.Data;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AryuwatSystem.Forms
{
    public partial class popAddFileScan : Form
    {
        private string docFilePath;
        public popAddFileScan()
        {
            InitializeComponent();
        }

        private void dgvFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddFile_BtnClick()
        {

        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            try
            {
                  docFilePath = BrowseFile.BrowFileType("IMAGE");
                txtFilePath.Text = docFilePath;
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }

        private void btnAddFile_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Entity.MedicalOrderDoc medDocInfo;
            int run = 0;
            List<Entity.MedicalOrderDoc> listMedicalOrderDoc = new List<Entity.MedicalOrderDoc>();
            string idMaxFile = UtilityBackEnd.GenMaxSeqnoValuesFileScan("FILESCAN", UseTransId,"VN","CN");
           
            foreach (DataGridViewRow item in dgvFile.Rows)
            {
                if (item.Cells["NewRow"].Value + "" == "True")
                {
                    
                    medDocInfo = new Entity.MedicalOrderDoc();
                    medDocInfo.FileName = item.Cells["FileName"].Value + "";
                    
                    FileInfo fn = new FileInfo(item.Cells["FilePath"].Value + "");
                    if (idMaxFile == "") run = 0;
                    else
                    {
                        int re=idMaxFile.Length-idMaxFile.IndexOf('.');
                        idMaxFile = idMaxFile.Remove(idMaxFile.IndexOf('.'), re);
                        run = Convert.ToInt16(idMaxFile.Replace(UseTransId + "_", ""));
                    }
                    run++;
                    string KeyFileName = string.Format("{0}_{1}{2}", UseTransId, run, fn.Extension);
                    medDocInfo.FileName = KeyFileName;// +"_" + DateTime.Now.ToString("yyyyMMddHH");
                    medDocInfo.UseTransId = UseTransId;
                    medDocInfo.FilePath = item.Cells["FilePath"].Value + "";
                    medDocInfo.Detail = item.Cells["Detail"].Value + "";
                    medDocInfo.DateScan = DateTime.Now;
                    listMedicalOrderDoc.Add(medDocInfo);
                }
            }

            int? intStatus = new Business.MedicalOrder().InsertFileScan(listMedicalOrderDoc);

            foreach (Entity.MedicalOrderDoc medicalOrderDoc in listMedicalOrderDoc)
            {
                //Save File 
                //string    idMaxFile = UtilityBackEnd.GenMaxSeqnoValues("FIL");
                //  //string  strPrefix = idMaxFile.Substring(0, 7);
                //  //double runNo = double.Parse(idMax.Substring(7, 4));
                //  FileInfo fn = new FileInfo(medicalOrderDoc.FilePath);
                //  string KeyFileName = string.Format("{0}_{1}_{2}{3}", idMaxFile, SO, VN, fn.Extension);
                SaveImage(medicalOrderDoc.FileName, medicalOrderDoc.FilePath);
                //if (BrowseFile.MovefileOther(medicalOrderDoc.FilePath, "MEDICALDOC", medicalOrderDoc.FileName))
                //{

                //}
                //else
                //{
                //    MessageBox.Show("Save Image Fail.");
                //}
            }
            this.Close();
        }
        private void SaveImage(string keyIDFileNameWithExt, string _OrgimagePaht)
        {
            try
            {
                if (_OrgimagePaht == "") return;
                string Remote_imagetPath = "";
                Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse" ,keyIDFileNameWithExt);
                string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\{1}", CN, "FileScanCourse");

                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                if (ftpClient.directoryListSimple(Remote_Folder).Length <= 1)
                    ftpClient.createDirectory(Remote_Folder);
                /* Upload a File */
                ftpClient.upload(Remote_imagetPath, _OrgimagePaht);
                //FileInfo f = new FileInfo(_imagetPath);
                //if (!f.Exists)
                /* Download a File */
                //ftpClient.download(Remote_imagetPath, _OrgimagePaht);

                /* Delete a File */
                //  ftpClient.delete("etc/test.txt");

                /* Rename a File */
                //  ftpClient.rename("etc/test.txt", "test2.txt");

                /* Create a New Directory */
                // ftpClient.createDirectory("etc/test");

                ///* Get the Date/Time a File was Created */
                //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
                //Console.WriteLine(fileDateTime);

                ///* Get the Size of a File */
                //string fileSize = ftpClient.getFileSize("etc/test.txt");
                //Console.WriteLine(fileSize);

                ///* Get Contents of a Directory (Names Only) */
                //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < simpleDirectoryListing.C; i++) { Console.WriteLine(simpleDirectoryListing[i]); }

                ///* Get Contents of a Directory with Detailed File/Directory Info */
                //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
                /* Release Resources */
                ftpClient = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteFileFTP(string keyIDFileNameWithExt)
        {
            try
            {
                //if (_OrgimagePaht == "") return;
                string Remote_imagetPath = "";
                Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse", keyIDFileNameWithExt);
                //string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\", CN);

                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
               
                ftpClient.delete(Remote_imagetPath);

                ftpClient = null;
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
        public string UseTransId { get; set; }
        public string CN { get; set; }
        private void SetColumnDgvFile()
        {
            dgvFile.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvFile_RowPostPaint);
            DerUtility.SetPropertyDgv(dgvFile);

            dgvFile.Columns.Add("FilePath", "FilePath");
            dgvFile.Columns.Add("FileName", "ชื่อไฟล์");
            dgvFile.Columns.Add("Detail", "รายละเอียด");
            dgvFile.Columns.Add("DateScan", "วันที่");
            DataGridViewImageColumn colFile = new DataGridViewImageColumn();
            {
                colFile.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colFile.CellTemplate = new DataGridViewImageCell();
            }
            dgvFile.Columns.Add(colFile);
            DataGridViewImageColumn colDown = new DataGridViewImageColumn();
            {
                colDown.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDown.CellTemplate = new DataGridViewImageCell();
            }

            dgvFile.Columns.Add(colDown);
            dgvFile.Columns.Add("NewRow", "NewRow");
            dgvFile.Columns.Add("Id", "Id");

            dgvFile.Columns["FilePath"].Width = 200;
            dgvFile.Columns["Detail"].Width = 150;
            dgvFile.Columns["FilePath"].Visible = false;
            dgvFile.Columns["NewRow"].Visible = false;
            dgvFile.Columns["Id"].Visible = false;
        }
        private void popAddFileScan_Load(object sender, EventArgs e)
        {
            try
            {
                SetColumnDgvFile();
                DataSet ds = new Business.MedicalOrder().SelectFileScan(UseTransId);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    object[] myItems = {
                                      "",
                                       row["FileName"]+"",
                                       row["Detail"]+"",
                                      //Convert.ToDateTime(row["DateScan"]+"").ToString("yyyy-MM-dd"),
                                       String.Format("{0:g}", Convert.ToDateTime(row["DateScan"]+"")),
                                   imageList1.Images[2],
                                       imageList1.Images[1],
                                      
                                       "False",
                                         row["Id"]+""
                                   };
                    dgvFile.Rows.Add(myItems);
                }
            }
            catch (Exception)
            {
               
            }
        }

        private void btnAddFile_BtnClick_1()
        {
            try
            {


                if (txtFilePath.Text != "")
                {
                    if (txtFileName.Text == "")
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุชื่อไฟล์ \"Filename is empty\"");
                        return;
                    }
                    object[] myItems = {
                                       txtFilePath.Text,
                                       Path.GetFileName(txtFilePath.Text),
                                       txtFileName.Text,
                                       DateTime.Now,
                                       imageList1.Images[2],
                                       imageList1.Images[1],
                                       //imageList1.Images[9],
                                       //imageList1.Images[5],
                                       "True"
                                   };
                    dgvFile.Rows.Add(myItems);
                    txtFilePath.Text = "";
                    txtFileName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการลบไฟล์ \"Confirm delete.\"") == DialogResult.OK)
                    {
                        string FileName = dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                        string Id = UseTransId;// dgvFile.Rows[e.RowIndex].Cells["Id"].Value + "";
                        //string fnameFullFath = Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" +
                        //                       dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                        DeleteFileFTP(FileName);
                        //BrowseFile.Deletefile(fnameFullFath);
                        var intStatus = new Business.MedicalOrder().DeleteFileScan(Id, "DELETEFileScanDoctor");
                        dgvFile.Rows.RemoveAt(e.RowIndex);
                    }
                }
                if (e.ColumnIndex == 5)
                {

                    //string filePath _imagetPath= Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" + dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                    DownLoadImage(dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "");

                }
            }
            catch (Exception ex)
            {

            }
        }
        string _imagetPath = "";
        string Remote_imagetPath = "";
        string Remote_Folder = "";
        string filenameWithExt = "";
        private void DownLoadImage(string fileWithExt)
        {
            try
            {
                //string Remote_imagetPath = "";
                //Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse", keyIDFileNameWithExt);
                //string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\{1}", CN, "FileScanCourse");
                filenameWithExt = fileWithExt;
                 _imagetPath = string.Format(@"{0}\{1}\{2}\{3}", Application.StartupPath, "MEDICALDOC", CN, filenameWithExt);
                 Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse", filenameWithExt);
                 Remote_Folder=string.Format(@"\MEDICALDOC\{0}\{1}\", CN, "FileScanCourse");
                /* Create Object Instance */
                 string Local_Folder = string.Format(@"{0}\MEDICALDOC\{1}\", Application.StartupPath, CN);
                 DirectoryInfo df = new DirectoryInfo(Local_Folder);
                if (!df.Exists)
                    df.Create();

                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
               
                ftpClient.download(Remote_imagetPath, _imagetPath);

                ftpClient = null;
                if (File.Exists(_imagetPath))
                {
                    Process.Start(_imagetPath);//.WaitForExit();
                   // var process = Process.Start(_imagetPath,"");
                    //if (process != null && process.HasExited != true)
                    //{
                    //    process.WaitForExit();
                    //}
                    //else
                    //{
                    //    // Process is null or have exited
                    //}
                    //string ppFileName = @"C:\Program Files\WindowsApps\5E8FC25E.XodoDocs_4.0.2.0_x64__3v3sf0k6w2rec\Xodo_Windows10.exe";
                    //if (string.IsNullOrEmpty(ppFileName)) return;
                    //if (( Directory.Exists(ppFileName)) || ( File.Exists(ppFileName)))
                    //{

                    //    ProcessStartInfo pi = new ProcessStartInfo(ppFileName);
                    //    pi.Arguments = Path.GetFileName(ppFileName);
                    //    pi.UseShellExecute = true;
                    //    pi.WindowStyle = ProcessWindowStyle.Normal;
                    //    pi.Verb = "OPEN";

                    //    Process proc = new Process();
                    //    proc.StartInfo = pi;

                    //    proc.Start();
                    //}

                    //LaunchCommandLineApp(_imagetPath);

                    //string filename = _imagetPath;
                    //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@filename);

                    //System.Diagnostics.Process rfp = new System.Diagnostics.Process();
                    //rfp = System.Diagnostics.Process.Start(psi);

                    //rfp.WaitForExit(2000);

                    //if (rfp.HasExited)
                    //{
                    //    System.IO.File.Delete(filename);
                    //}

                    //execute other code after the program has closed

                    //ProcessStartInfo info = new ProcessStartInfo();

                    //info.Arguments = _imagetPath;// img.Tag.ToString(); // returns full path and name
                    //info.FileName = _imagetPath;// @"C:\Program Files\WindowsApps\5E8FC25E.XodoDocs_4.0.2.0_x64__3v3sf0k6w2rec\Xodo_Windows10.exe";
                    //info.UseShellExecute = true;
                    //Process process = Process.Start(info);
                    //if (process != null && process.HasExited != true)
                    //{
                    //    process.WaitForExit();
                    //}
                    //else
                    //{
                    //    // Process is null or have exited
                    //}
                    //process.WaitForExit();
                    //process.Exited += new EventHandler(process_Exited);
                    //process.Kill();
                  //  bool sav = DerClass.DerUtility.SaveImage(_imagetPath, Remote_imagetPath, filenameWithExt);
            
                }
                else MessageBox.Show("File not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveFileScan()
        {
            try
            {

           
            Entity.MedicalOrderDoc medDocInfo;
            int run = 0;
            List<Entity.MedicalOrderDoc> listMedicalOrderDoc = new List<Entity.MedicalOrderDoc>();
        //    string idMaxFile = UtilityBackEnd.GenMaxSeqnoValuesFileScan("FILESCAN", UseTransId,"VN","CN");

            foreach (DataGridViewRow item in dgvFile.Rows)
            {
                if (item.Cells["NewRow"].Value + "" == "True")
                {

                    medDocInfo = new Entity.MedicalOrderDoc();
                    medDocInfo.FileName = item.Cells["FileName"].Value + "";
                    medDocInfo.QueryType = "INSERTFileScanDoctor";
                    FileInfo fn = new FileInfo(item.Cells["FilePath"].Value + "");
                    //if (idMaxFile == "") run = 0;
                    //else
                    //{
                    //    int re = idMaxFile.Length - idMaxFile.IndexOf('.');
                    //    //idMaxFile = idMaxFile.Remove(idMaxFile.IndexOf('.'), re);
                    //    run = Convert.ToInt16(idMaxFile.Replace(UseTransId + "_", ""));
                    //}
                    //run++;
                   // string KeyFileName = string.Format("{0}_{1}{2}", UseTransId, run, fn.Extension);
                    string KeyFileName = "";
                    KeyFileName = string.Format("Course_{0}_{1}_{2}{3}", UseTransId, DateTime.Now.ToString("yyyymmddhhmmss"), (item.Index + 1), fn.Extension);
                    medDocInfo.FileName = KeyFileName;// +"_" + DateTime.Now.ToString("yyyyMMddHH");
                    medDocInfo.UseTransId = UseTransId;
                    medDocInfo.FilePath = item.Cells["FilePath"].Value + "";
                    medDocInfo.Detail = item.Cells["Detail"].Value + "";
                    medDocInfo.DateScan = DateTime.Now;
                    listMedicalOrderDoc.Add(medDocInfo);
                }
            }

            int? intStatus = new Business.MedicalOrder().InsertFileScan(listMedicalOrderDoc);

            foreach (Entity.MedicalOrderDoc medicalOrderDoc in listMedicalOrderDoc)
            {
                //Save File 
                //string    idMaxFile = UtilityBackEnd.GenMaxSeqnoValues("FIL");
                //  //string  strPrefix = idMaxFile.Substring(0, 7);
                //  //double runNo = double.Parse(idMax.Substring(7, 4));
                //  FileInfo fn = new FileInfo(medicalOrderDoc.FilePath);
                //  string KeyFileName = string.Format("{0}_{1}_{2}{3}", idMaxFile, SO, VN, fn.Extension);
                SaveImage(medicalOrderDoc.FileName, medicalOrderDoc.FilePath);
                //if (BrowseFile.MovefileOther(medicalOrderDoc.FilePath, "MEDICALDOC", medicalOrderDoc.FileName))
                //{

                //}
                //else
                //{
                //    MessageBox.Show("Save Image Fail.");
                //}
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static void LaunchCommandLineApp(string pp)
        {
            // For the example.
            const string ex1 = "C:\\";
            const string ex2 = "C:\\Dir";

            // Use ProcessStartInfo class.
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\Program Files\WindowsApps\5E8FC25E.XodoDocs_4.0.2.0_x64__3v3sf0k6w2rec\Xodo_Windows10.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using-statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxAddNew_Click(object sender, EventArgs e)
        {
            try
            {


                //if (txtFilePath.Text != "")
                //{
                //    if (txtFileName.Text == "")
                //    {
                //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุชื่อไฟล์ \"Filename is empty\"");
                //        return;
                //    }
               string NewFileFullPath =CreateNewPDFBoard();
                    object[] myItems = {
                                       NewFileFullPath,
                                       Path.GetFileName(NewFileFullPath),
                                       "NewPaper",
                                       String.Format("{0:g}", DateTime.Now),
                                       imageList1.Images[2],
                                       imageList1.Images[1],
                                       //imageList1.Images[9],
                                       //imageList1.Images[5],
                                       "True"
                                   };
                    dgvFile.Rows.Add(myItems);
                    txtFilePath.Text = "";
                    txtFileName.Text = "";
               // }
                    if (File.Exists(NewFileFullPath))
                    {
                        Process.Start(NewFileFullPath);//.WaitForExit();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      public string CreateNewPDFBoard()
		{
            //string appRootDir = Application.StartupPath;
            string Local_Folder = string.Format(@"{0}\MEDICALDOC\{1}\", Application.StartupPath, CN);
            string FullPath = Local_Folder + "/NewPaper1.pdf";
			try
			{
				// Step 1: Creating System.IO.FileStream object

                if (!Directory.Exists(Local_Folder)) Directory.CreateDirectory(Local_Folder );
                if (File.Exists(FullPath)) File.Delete(FullPath);
              
                using (FileStream fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write, FileShare.None))
				// Step 2: Creating iTextSharp.text.Document object
				using (Document doc = new Document())
				// Step 3: Creating iTextSharp.text.pdf.PdfWriter object
				// It helps to write the Document to the Specified FileStream
				using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
				{
					// Step 4: Openning the Document
					doc.Open();

					// Step 5: Adding a paragraph
					// NOTE: When we want to insert text, then we've to do it through creating paragraph
					doc.Add(new Paragraph("Hello World"));

					// Step 6: Closing the Document
					doc.Close();
				}
			}
			// Catching iTextSharp.text.DocumentException if any
			catch (DocumentException de)
			{
                FullPath = "";
				throw de;
			}
			// Catching System.IO.IOException if any
			catch (IOException ioe)
			{
                FullPath = "";
				throw ioe;
			}
            return FullPath;
		}

      private void popAddFileScan_FormClosing(object sender, FormClosingEventArgs e)
      {
          SaveFileScan();
      }

      private void txtFileName_MouseClick(object sender, MouseEventArgs e)
      {
          DerUtility.GetSetInputKeyBorad("thai");
      }
    }
}
