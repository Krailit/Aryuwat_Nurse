using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class FrmWebCapture : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        private string en;
        public string imagepath = "";
        //public bool FolderTypeCustomer = true;
        public string PicID;
        bool _FolderTypeCustomer = false;
        public FrmWebCapture()
        {
            InitializeComponent();
        }

        public FrmWebCapture(string e, bool FolderTypeCustomer)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.PicID = e;
          //  imagepath = Application.StartupPath + @"\PersonnelImage\" + en + ".jpg";
            //if(FolderTypeCustomer)
            //    imagepath = Entity.Userinfo.ImagePath + @"\Customers\" + PicID + ".jpg";
            //else imagepath = Entity.Userinfo.ImagePath + @"\Personnels\" + PicID + ".jpg";
            _FolderTypeCustomer = FolderTypeCustomer;
            if(FolderTypeCustomer)
                imagepath =string.Format(@"{0}\Customers\{1}\{2}.jpg",Application.StartupPath,PicID ,PicID);
            else imagepath = string.Format(@"{0}\Personnels\{1}\{2}.jpg", Application.StartupPath, PicID, PicID);
             
        }

        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                comboBox1.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                comboBox1.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                comboBox1.Items.Add("No capture device on your system");
            }
        }

        private void rfsh_Click(object sender, EventArgs e)
        {
            try
            {
                    getCamList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void StartCamera()
        {

            try
            {
                if (start.Text == "&Start")
                {
                    if (DeviceExist)
                    {
                        videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString) { DesiredFrameSize = new Size(160, 120) };
                        videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                        CloseVideoSource();
                        //videoSource.DesiredFrameRate = 10;
                        videoSource.Start();
                        label2.Text = "Device running...";
                        start.Text = "&Stop";
                        timer1.Enabled = true;
                    }
                    else
                    {
                        label2.Text = "Error: No Device selected.";
                    }
                }
                else
                {
                    if (videoSource.IsRunning)
                    {
                        timer1.Enabled = false;
                        CloseVideoSource();
                        label2.Text = "Device stopped.";
                        start.Text = "&Start";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void start_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                    Bitmap img = (Bitmap)eventArgs.Frame.Clone();
                        pictureBox1.Image = img;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void CloseVideoSource()
        {
            try
            {
                if (videoSource != null)
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "Device running... " + videoSource.FramesReceived.ToString() + " FPS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CloseVideoSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(path: Path.GetDirectoryName(imagepath)))
                    Directory.CreateDirectory(path: Path.GetDirectoryName(imagepath));
                pictureBox1.Image.Save(imagepath);
                SaveImage();
                timer1.Stop();
                DialogResult=DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void SaveImage()
        {
            try 
	        {
                string Remote_imagetPath = "";
                string remoteMainFolder = "";
                if (_FolderTypeCustomer)
                {
                    //Remote_imagetPath =string.Format("\Customers\" + PicID+"\" + PicID + ".jpg";
                    remoteMainFolder = "Customers";
                }
                else
                {
                    //Remote_imagetPath = @"\Personnels\" + PicID + ".jpg";
                    remoteMainFolder = "Personnels";
                }
                Remote_imagetPath=string.Format(@"\{0}\{1}\{2}.jpg",remoteMainFolder,PicID,PicID);
                remoteMainFolder = string.Format(@"{0}\{1}\",remoteMainFolder,PicID);
                //DermasterFtp ftp = new DermasterFtp("61.91.14.121", "AryuwatSystem", "Dermaster1234567890");
        
               // ftp.upload(Remote_imagetPath,imagepath);
                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                if (ftpClient.directoryListSimple(remoteMainFolder).Length <= 1)
                    ftpClient.createDirectory(remoteMainFolder);
                /* Upload a File */
                ftpClient.upload(Remote_imagetPath,imagepath);
                FileInfo f=new FileInfo(imagepath);
                if(!f.Exists)
                /* Download a File */
                ftpClient.download(Remote_imagetPath, imagepath);

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
        private void FrmWebCapture_Load(object sender, EventArgs e)
        {
            getCamList();
            if(comboBox1.SelectedIndex!=-1)
            StartCamera();
        }

        private void FrmWebCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}