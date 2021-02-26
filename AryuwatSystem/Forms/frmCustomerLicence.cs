using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Threading;

namespace AryuwatSystem.Forms
{
    public partial class frmCustomerLicence : Form
    {
        public frmCustomerLicence()
        {
            InitializeComponent();
            panel1.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(panel1, new object[] { System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true });
        }
        bool startPaint = false;
        Graphics g;
        //nullable int for storing Null value
        int? initX = null;
        int? initY = null;
        bool drawSquare = false;
        bool drawRectangle = false;
        bool drawCircle = false;
        string ShapeSize = "1";
        string PenSize = "1";
        public string CustomerName { get; set; }
        public string AmountTotal { get; set; }//จำนวนทั้งหมด
        public string AmountUsed { get; set; }//จำนวนที่ใช้
        private double Amounttotal = 0;
        public string AmountBalance { get; set; }//คงเหลือ
        public string CurrentUsed { get; set; }//ใช้ครั้งนี้
        public string SupplieName { get; set; }//ชื่อรายการ
        public string CN { get; set; }
        public string VN { get; set; }
        public string MS_Code { get; set; }
        public string RefMO { get; set; }
        public string ListOrder { get; set; }
        public string TabName { get; set; }
        public string ReMark { get; set; }
        public string MUT { get; set; }
        public string BranchName { get; set; }
        public string DateUsed { get; set; }
        public string LicenceFullPath { get; set; }

        private bool Brush = true;                      //Uses either Brush or Eraser. Default is Brush
        private Shapes DrawingShapes = new Shapes();    //Stores all the drawing data
        private bool IsPainting = false;                //Is the mouse currently down (PAINTING)
        private bool IsEraseing = false;                 //Is the mouse currently down (ERASEING)
        private Point LastPos = new Point(0, 0);        //Last Position, used to cut down on repative data.
        private Color CurrentColour = Color.Black;      //Deafult Colour
        private float CurrentWidth = 2;                //Deafult Pen width
        private int ShapeNum = 0;                       //record the shapes so they can be drawn sepratley.
        private Point MouseLoc = new Point(0, 0);       //Record the mouse position
        private bool IsMouseing = false;      
        string filename = "";
        string path = "";
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        bool draw = false;
        int s = 2;
        Color color = Color.Red;
        Bitmap mainimage;
     
        public static SizeF MeasureString(string s, Font font)
        {
            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font);
                }
            }
            return result;
        }
        private void frmCustomerLicence_Load(object sender, EventArgs e)
        {
            try
            {
                //string sFileData = "Hello World";
                //string sFileName = @"D:\Dermaster\SourceCode\AryuwatSystem\bin\Debug\Screenshot.png";

                //Font oFont = new Font("Arial", 11, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                //var sz = MeasureString(sFileData, oFont);

                //var oBitmap = new Bitmap((int)sz.Width, (int)sz.Height);

                //using (Graphics oGraphics = Graphics.FromImage(oBitmap))
                //{
                //    oGraphics.Clear(Color.White);
                //    oGraphics.DrawString(sFileData, oFont, new SolidBrush(System.Drawing.Color.Black), 0, 0);
                //    oGraphics.Flush();

                //}

                //oBitmap.Save(sFileName, System.Drawing.Imaging.ImageFormat.Bmp);
             
                //using (Graphics gfx = f.CreateGraphics())
                //{
                //    using (Bitmap bmp = new Bitmap(f.Width, f.Height, gfx))
                //    {
                //        f.DrawToBitmap(bmp, new Rectangle(0, 0, f.Width, f.Height));
                //        bmp.Save(sFileName);
                //    }
                //}

             
                //panel1.Visible = false;
             
            }
            catch (Exception)
            {


            }
        }

        /// <summary>
        /// Sharpens the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="strength">strength erwartet werte zwische 0 - 99</param>
        /// <returns></returns>
        public Bitmap Sharpen(Image image, whichMatrix welcheMatrix, double strength)
        {
            double FaktorKorrekturWert = 0;

            //strenght muß für den jeweiligen filter angepasst werden
            switch (welcheMatrix)
            {
                case whichMatrix.Gaussian3x3:
                    //diese Matrix benötigt einen strenght Wert von 0 bis -9.9 default ist -2.5
                    //und einen korekturwert von 16
                    strength = (strength * -1) / 10;
                    FaktorKorrekturWert = 16;
                    break;

                case whichMatrix.Mean3x3:
                    //diese Matrix benötigt einen strenght Wert von 0 bis -9 default ist -2.25
                    //und einen Korrekturwert von 10
                    strength = strength * -9 / 100;
                    FaktorKorrekturWert = 10;
                    break;

                case whichMatrix.Gaussian5x5Type1:
                    //diese Matrix benötigt einen strenght Wert von 0 bis 2.5 default ist 1.25
                    //und einen Korrekturwert von 12
                    strength = strength * 2.5 / 100;
                    FaktorKorrekturWert = 12;
                    break;

                default:
                    break;
            }

            using (var bitmap = image as Bitmap)
            {
                if (bitmap != null)
                {
                    var sharpenImage = bitmap.Clone() as Bitmap;

                    int width = image.Width;
                    int height = image.Height;

                    // Create sharpening filter.
                    var filter = Matrix(welcheMatrix);

                    //const int filterSize = 3; // wenn die Matrix 3 Zeilen und 3 Spalten besitzt dann 3 bei 4 = 4 usw.                    
                    int filterSize = filter.GetLength(0);

                    double bias = 1.0 - strength;
                    double factor = strength / FaktorKorrekturWert;

                    //const int s = filterSize / 2;
                    int s = filterSize / 2; // Filtersize ist keine Constante mehr darum wurde der befehl const entfernt


                    var result = new Color[image.Width, image.Height];

                    // Lock image bits for read/write.
                    if (sharpenImage != null)
                    {
                        BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                        // Declare an array to hold the bytes of the bitmap.
                        int bytes = pbits.Stride * height;
                        var rgbValues = new byte[bytes];

                        // Copy the RGB values into the array.
                        Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

                        int rgb;
                        // Fill the color array with the new sharpened color values.
                        for (int x = s; x < width - s; x++)
                        {
                            for (int y = s; y < height - s; y++)
                            {
                                double red = 0.0, green = 0.0, blue = 0.0;

                                for (int filterX = 0; filterX < filterSize; filterX++)
                                {
                                    for (int filterY = 0; filterY < filterSize; filterY++)
                                    {
                                        int imageX = (x - s + filterX + width) % width;
                                        int imageY = (y - s + filterY + height) % height;

                                        rgb = imageY * pbits.Stride + 3 * imageX;

                                        red += rgbValues[rgb + 2] * filter[filterX, filterY];
                                        green += rgbValues[rgb + 1] * filter[filterX, filterY];
                                        blue += rgbValues[rgb + 0] * filter[filterX, filterY];
                                    }

                                    rgb = y * pbits.Stride + 3 * x;

                                    int r = Math.Min(Math.Max((int)(factor * red + (bias * rgbValues[rgb + 2])), 0), 255);
                                    int g = Math.Min(Math.Max((int)(factor * green + (bias * rgbValues[rgb + 1])), 0), 255);
                                    int b = Math.Min(Math.Max((int)(factor * blue + (bias * rgbValues[rgb + 0])), 0), 255);

                                    result[x, y] = System.Drawing.Color.FromArgb(r, g, b);
                                }
                            }
                        }

                        // Update the image with the sharpened pixels.
                        for (int x = s; x < width - s; x++)
                        {
                            for (int y = s; y < height - s; y++)
                            {
                                rgb = y * pbits.Stride + 3 * x;

                                rgbValues[rgb + 2] = result[x, y].R;
                                rgbValues[rgb + 1] = result[x, y].G;
                                rgbValues[rgb + 0] = result[x, y].B;
                            }
                        }

                        // Copy the RGB values back to the bitmap.
                        Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
                        // Release image bits.
                        sharpenImage.UnlockBits(pbits);
                    }

                    return sharpenImage;
                }
            }
            return null;
        }


        public enum whichMatrix
        {
            Gaussian3x3,
            Mean3x3,
            Gaussian5x5Type1
        }


        private double[,] Matrix(whichMatrix welcheMatrix)
        {
            double[,] selectedMatrix = null;

            switch (welcheMatrix)
            {
                case whichMatrix.Gaussian3x3:
                    selectedMatrix = new double[,]
                { 
                    { 1, 2, 1, }, 
                    { 2, 4, 2, }, 
                    { 1, 2, 1, }, 
                };
                    break;

                case whichMatrix.Gaussian5x5Type1:
                    selectedMatrix = new double[,]
                { 
                    {-1, -1, -1, -1, -1},
                    {-1,  2,  2,  2, -1},
                    {-1,  2,  16, 2, -1},
                    {-1,  2, -1,  2, -1},
                    {-1, -1, -1, -1, -1} 
                };
                    break;

                case whichMatrix.Mean3x3:
                    selectedMatrix = new double[,]
                { 
                    { 1, 1, 1, }, 
                    { 1, 1, 1, }, 
                    { 1, 1, 1, }, 
                };
                    break;
            }

            return selectedMatrix;
        }
        
        // Return a Bitmap holding an image of the control.
        private Bitmap GetControlImage(Control ctl)
        {
            //Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            Bitmap bm = new Bitmap(ctl.Width,ctl.Height,PixelFormat.Format48bppRgb);
            
            //Bitmap bmp = new Bitmap("filename.bmp");

        

            //image.Image = bmp;

            //ctl.DrawToBitmap(bm, new Rectangle(0, 0, ctl.Width, ctl.Height));
            ctl.DrawToBitmap(bm, new Rectangle(0, 0, ctl.Width, ctl.Height));
           

            //g.SmoothingMode = SmoothingMode.HighQuality;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            ////g.DrawString("yourText", new Font("Tahoma", 8), Brushes.Black, rectf);

            //g.Flush();
            return bm;
        }

       
        // Return the form's image without its borders and decorations.
        private Bitmap GetFormImageWithoutBorders(Form frm)
        {
            // Get the form's whole image.
            using (Bitmap whole_form = GetControlImage(frm))
            {
                // See how far the form's upper left corner is
                // from the upper left corner of its client area.
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                // Copy the client area into a new Bitmap.
                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);

                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawImage(whole_form , 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
               
                }
              
                return bm;
            }
        }
        private void NewBitmap()
        {
            if (LicenceFullPath + "" != "")
            {
                FileStream localFileStream = new FileStream(LicenceFullPath, FileMode.Open);
                panel1.BackgroundImage = new Bitmap(localFileStream); 
                localFileStream.Close();
            }
            else
            {
                PopMedicalUsedBeforLicence frm = new PopMedicalUsedBeforLicence();
                frm.CN = CN;
                frm.VN = VN;
                frm.ListOrder = ListOrder;
                frm.MS_Code = MS_Code;
                frm.SupplieName = SupplieName;
                frm.AmountTotal = AmountTotal;
                frm.AmountUsed = AmountUsed;
                frm.AmountBalance = AmountBalance;
                frm.CurrentUsed = CurrentUsed;
                frm.TabName = TabName;
                frm.CustomerName = CustomerName;
                frm.RefMO = RefMO;
                frm.ReMark = ReMark;
                frm.BranchName = BranchName;
                frm.DateUsed = DateUsed;


                frm.Show();
                g = panel1.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //RectangleF rectf = new RectangleF(70, 90, 90, 50);

                
                panel1.BackgroundImage = GetFormImageWithoutBorders(frm); // mainimage;
                frm.Close();
            }
            
            //panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            panel1.Visible = true;
        }
        private void frmCustomerLicence_Shown(object sender, EventArgs e)
        {
            //Bitmap screenshot = new Bitmap(this.Width,
            //                                this.Height,
            //                                PixelFormat.Format24bppRgb);
            //Graphics screenGraph = Graphics.FromImage(screenshot);
            //screenGraph.CopyFromScreen(this.Location.X,
            //                           this.Location.Y,
            //                           0,
            //                           0,
            //                           this.Size,
            //                           CopyPixelOperation.SourceCopy);

           // screenshot.Save("Screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
             //filename=string.Format("{0}_{1}_{2}.jpg",CN,VN.Replace("-","_"),MS_Code,DateTime.Now.ToString("yyyyMMddHHmm"));
             //path = string.Format("{0}/Customers/{1}/",Application.StartupPath,CN);
             //if (!Directory.Exists(path)) Directory.CreateDirectory(path);
             //string savePath = path + filename;
             //FileInfo f = new FileInfo(savePath);
             //mainimage = new Bitmap(f.FullName);//@"D:\Dermaster\SourceCode\AryuwatSystem\bin\Debug\Screenshot.png"
           
            
            NewBitmap();

            //Image bmp = new Bitmap(panel1.Width, panel1.Height);
            //var gg = Graphics.FromImage(bmp);
            //var rect = panel1.RectangleToScreen(panel1.ClientRectangle);
            //gg.CopyFromScreen(rect.Location, Point.Empty, panel1.Size);
            //filename = string.Format("{0}_{1}_{2}_{3}.jpg", CN, VN.Replace("-", "_"), MS_Code, MUT);
            //path = string.Format(@"{0}\Customers\{1}\", Application.StartupPath, CN);
            //string remote_path = string.Format(@"\Customers\{0}\", CN);
            //if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            //string saveFullPath = path + filename;
            //bmp.Save(saveFullPath);
            //DerClass.DerUtility.SaveImage(saveFullPath, remote_path, filename);
            ////Process.Start(saveFullPath);
            ////string MSEdgePath = string.Format("microsoft-edge:{0}", saveFullPath);
            ////Process.Start(MSEdgePath);
            ////Image img = Image.FromFile(saveFullPath);
            ////img.Tag = saveFullPath;
            //System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            //info.FileName = ("mspaint.exe");
            //info.Arguments = saveFullPath;// img.Tag.ToString(); // returns full path and name
            //System.Diagnostics.Process p1 = System.Diagnostics.Process.Start(info);
            //p1.WaitForExit();

            //DerClass.DerUtility.SaveImage(saveFullPath, remote_path, filename);
        }
        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If we're painting...
            if (Brush)
            {
                //set it to mouse down, illatrate the shape being drawn and reset the last position
                IsPainting = true;
                ShapeNum++;
                LastPos = new Point(0, 0);
            }
            //but if we're eraseing...
            else
            {
                IsEraseing = true;
            }
        }

        protected void panel1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseLoc = e.Location;
            //PAINTING
            if (IsPainting)
            {
                //check its not at the same place it was last time, saves on recording more data.
                if (LastPos != e.Location)
                {
                    //set this position as the last positon
                    LastPos = e.Location;
                    //store the position, width, colour and shape relation data
                    DrawingShapes.NewShape(LastPos, CurrentWidth, CurrentColour, ShapeNum);

                   
                   //  drawLinexxx();

                }
            }
            if (IsEraseing)
            {
                //Remove any point within a certain distance of the mouse
                DrawingShapes.RemoveShape(e.Location, 10);
            }
            //refresh the panel so it will be forced to re-draw.
            //panel1.Refresh();
        }
        private void drawLinexxx()
        {
         //Apply a smoothing mode to smooth out the line.
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //DRAW THE LINES
            for (int i = 0; i < DrawingShapes.NumberOfShapes() - 1; i++)
            {
                Shape T = DrawingShapes.GetShape(i);
                Shape T1 = DrawingShapes.GetShape(i + 1);
                //make sure shape the two ajoining shape numbers are part of the same shape
                if (T.ShapeNumber == T1.ShapeNumber)
                {
                    //create a new pen with its width and colour
                    Pen p = new Pen(T.Colour, T.Width);
                    p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    //draw a line between the two ajoining points
                    g.DrawLine(p, T.Location, T1.Location);
                    //get rid of the pen when finished
                    p.Dispose();
                }
            }
            //If mouse is on the panel, draw the mouse
            if (IsMouseing)
            {
                g.DrawEllipse(new Pen(Color.White, 0.5f), MouseLoc.X - (CurrentWidth / 2), MouseLoc.Y - (CurrentWidth / 2), CurrentWidth, CurrentWidth);
            }
    }

        private void panel1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (IsPainting)
            {
                //Finished Painting.
                IsPainting = false;
            }
            if (IsEraseing)
            {
                //Finished Earsing.
                IsEraseing = false;
            }
        }

        //DRAWING FUNCTION
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ////Apply a smoothing mode to smooth out the line.
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ////e.Graphics.SmoothingMode = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            ////e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            ////DRAW THE LINES
            //for (int i = 0; i < DrawingShapes.NumberOfShapes() - 1; i++)
            //{
            //    Shape T = DrawingShapes.GetShape(i);
            //    Shape T1 = DrawingShapes.GetShape(i + 1);
            //    //make sure shape the two ajoining shape numbers are part of the same shape
            //    if (T.ShapeNumber == T1.ShapeNumber)
            //    {
            //        //create a new pen with its width and colour
            //        Pen p = new Pen(T.Colour, T.Width);
            //        p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            //        p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            //        //draw a line between the two ajoining points
            //        e.Graphics.DrawLine(p, T.Location, T1.Location);
            //        //get rid of the pen when finished
            //        p.Dispose();
            //    }
            //}
            ////If mouse is on the panel, draw the mouse
            //if (IsMouseing)
            //{
            //    e.Graphics.DrawEllipse(new Pen(Color.White, 0.5f), MouseLoc.X - (CurrentWidth / 2), MouseLoc.Y - (CurrentWidth / 2), CurrentWidth, CurrentWidth);
            //}
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            //Hide the mouse cursor and tell the re-drawing function to draw the mouse
            //Cursor.Hide();
            IsMouseing = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //show the mouse, tell the re-drawing function to stop drawing it and force the panel to re-draw.
            //Cursor.Show();
            IsMouseing = false;
            panel1.Refresh();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            
                    SaveControlImage(panel1);
            
                //Bitmap bmap = new Bitmap(panel1.Width, panel1.Height);
                //g.DrawImage(bmap, panel1.Width, panel1.Height);
                //bmap.Save(@"D:\Dermaster\SourceCode\AryuwatSystem\bin\Debug\Screenshot2.png");
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
        string saveFullPath = "";
        string remote_path = "";
        private void SaveControlImage(Control ctr)
        {
            try
            {
                //var imagePath = @"D:\Dermaster\SourceCode\AryuwatSystem\bin\Debug\Screenshot2.png";
                //filename = string.Format("{0}_{1}_{3}_{4}.jpg", CN, VN, MS_Code, DateTime.Now.ToString("yyyyMMddHHmmss"));
                //path = string.Format(@"{0}\Customers\{1}\{2}", Application.StartupPath, CN, filename);
                //mainimage = new Bitmap(path);
                //Image bmp = new Bitmap(panel1.Bounds.Width, panel1.Bounds.Height);
                //var gg = Graphics.FromImage(bmp);
                //var rect = ctr.ClientRectangle;// ctr.RectangleToScreen(ctr.ClientRectangle);


                //gg.CopyFromScreen(panel1.PointToScreen(new Point(0,0)), Point.Empty, ctr.Size);
               
                //using (Bitmap bitmap = new Bitmap(panel1.Bounds.Width, panel1.Bounds.Height))
                using (Bitmap bitmap = new Bitmap(panel1.Bounds.Width, panel1.Bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                     
                        filename = string.Format("{0}_{1}_{2}_{3}.jpg", CN, VN.Replace("-", "_"), MS_Code, MUT);
                        path = string.Format(@"{0}\Customers\{1}\", Application.StartupPath, CN);
                        remote_path = string.Format(@"\Customers\{0}\CustomersSign\", CN);
                        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                         saveFullPath = path + filename;
                         if (LicenceFullPath + "" == "")
                         {
                             g.CopyFromScreen(PointToScreen(panel1.Location), Point.Empty, panel1.Bounds.Size);
                             bitmap.Save(saveFullPath);
                             DerClass.DerUtility.SaveImage(saveFullPath, remote_path, filename);
                         }
                    }
                }


             
//                DerClass.DerUtility.SaveImage(saveFullPath, remote_path, filename);

                //Process.Start(saveFullPath);
                //string MSEdgePath = string.Format("microsoft-edge:{0}", saveFullPath);
                //Process.Start(MSEdgePath);
                //Image img = Image.FromFile(saveFullPath);
                //img.Tag = saveFullPath;


                //System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                //info.FileName = ("mspaint.exe");
                //info.Arguments = saveFullPath;// img.Tag.ToString(); // returns full path and name
                //System.Diagnostics.Process p1 = System.Diagnostics.Process.Start(info);
                //p1.WaitForExit();
                ProcessStartInfo info = new ProcessStartInfo();

                
                info.Arguments = saveFullPath;// img.Tag.ToString(); // returns full path and name
                info.FileName = "mspaint.exe";
                Process process = Process.Start(info);
                process.WaitForExit();
                //process.Exited += new EventHandler(process_Exited);
                //process.Kill();
                bool sav = DerClass.DerUtility.SaveImage(saveFullPath, remote_path, filename);
            
                this.Close();

            //bool sav=    DerClass.DerUtility.SaveImage(saveFullPath, remote_path, filename);
            ////MessageBox.Show(sav.ToString());
            //    this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void process_Exited(object sender, EventArgs e)
        {
            try
            {
                 bool sav=    DerClass.DerUtility.SaveImage(saveFullPath, remote_path, filename);
            //MessageBox.Show(sav.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void btnNew_Click(object sender, EventArgs e)
        {
            LicenceFullPath = "";
            NewBitmap();
            DrawingShapes = new Shapes();
        }

      
    }

    public class Shape
    {
        public Point Location;          //position of the point
        public float Width;             //width of the line
        public Color Colour;            //colour of the line
        public int ShapeNumber;         //part of which shape it belongs to

        //CONSTRUCTOR
        public Shape(Point L, float W, Color C, int S)
        {
            Location = L;               //Stores the Location
            Width = W;                  //Stores the width
            Colour = C;                 //Stores the colour
            ShapeNumber = S;            //Stores the shape number
        }
    }
    public class Shapes
    {
        private List<Shape> _Shapes;    //Stores all the shapes

        public Shapes()
        {
            _Shapes = new List<Shape>();
        }
        //Returns the number of shapes being stored.
        public int NumberOfShapes()
        {
            return _Shapes.Count;
        }
        //Add a shape to the database, recording its position, width, colour and shape relation information
        public void NewShape(Point L, float W, Color C, int S)
        {
            _Shapes.Add(new Shape(L, W, C, S));
        }
        //returns a shape of the requested data.
        public Shape GetShape(int Index)
        {
            return _Shapes[Index];
        }
        //Removes any point data within a certain threshold of a point.
        public void RemoveShape(Point L, float threshold)
        {
            for (int i = 0; i < _Shapes.Count; i++)
            {
                //Finds if a point is within a certain distance of the point to remove.
                if ((Math.Abs(L.X - _Shapes[i].Location.X) < threshold) && (Math.Abs(L.Y - _Shapes[i].Location.Y) < threshold))
                {
                    //removes all data for that number
                    _Shapes.RemoveAt(i);

                    //goes through the rest of the data and adds an extra 1 to defined them as a seprate shape and shuffles on the effect.
                    for (int n = i; n < _Shapes.Count; n++)
                    {
                        _Shapes[n].ShapeNumber += 1;
                    }
                    //Go back a step so we dont miss a point.
                    i -= 1;
                }
            }
        }
    }

}
