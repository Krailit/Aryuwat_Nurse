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

namespace DermasterSystem.Forms
{
    public partial class FrmWebCapture : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        private string en;
        private string imagepath = "";
        public string EN
        {
            get { return en; }
            set { en = value; }

        }
        public FrmWebCapture()
        {
            InitializeComponent();
        }

        public FrmWebCapture(string e)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.en = e;
            imagepath = Application.StartupPath + @"\PersonnelImage\" + en + ".jpg";
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
                timer1.Stop();
                DialogResult=DialogResult.OK;
                this.Close();
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