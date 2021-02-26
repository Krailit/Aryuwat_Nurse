using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Cyotek.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Properties;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.ComponentModel;
using AryuwatSystem.Class;
using ImageMagick;

namespace AryuwatSystem.Forms
{
  // Cyotek ImageBox
  // Copyright (c) 2010-2014 Cyotek.
  // http://cyotek.com
  // http://cyotek.com/blog/tag/imagebox

  // Licensed under the MIT License. See imagebox-license.txt for the full text.

  // If you use this control in your applications, attribution, donations or contributions are welcome.

    public partial class SwitchImageDuringZoomDemoForm : DockContent, AryuwatSystem.DerClass.IForm
  {
      #region IForm Members

      void IForm.IsSave()
      {
      }

      void IForm.IsDelete()
      {
         // DeleteData();
      }

      void IForm.IsRefresh()
      {

      }

      void IForm.IsEdit()
      {//
          ///CallForm(CallMode.Update);
      }

      void IForm.IsPrint()
      {
      }

      void IForm.IsNew()
      {
         // NewUserGroup();
      }

      void IForm.IsExit()
      {
          //throw new Exception("The method or operation is not implemented.");
      }

      #endregion
    #region Instance Fields

    private int _virtualZoom;

    #endregion

    #region Public Constructors

    public SwitchImageDuringZoomDemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }

        if (this.ImageCache != null)
        {
          foreach (Image image in this.ImageCache.Values)
          {
            image.Dispose();
          }
          this.ImageCache = null;
        }
      }
      base.Dispose(disposing);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      //pictureBoxNextB.BackColor = Color.Transparent;
      //pictureBoxPreviosB.BackColor = Color.Transparent;
      //// Change parent for overlay PictureBox...
      //pictureBoxNextB.Parent = imageBox;
      //pictureBoxPreviosB.Parent = imageBox;

      //pictureBoxPreviosB.Location = new Point(0, 0);
      ////pictureBoxNextB.Location = new Point(imageBox1.Image.Width - pictureBoxNextB.Width, imageBox.Image.Height / 2);

      //// Change overlay PictureBox position in new parent...
      

      LayerData = new List<MapLayerData>();

      // add some map layers for the different zoom levels
      this.AddLayer("map10", int.MinValue, 0);
      this.AddLayer("map20", 0, 2);
      this.AddLayer("map30", 2, 4);
      this.AddLayer("map40", 4, 6);
      this.AddLayer("map50", 6, 8);
      this.AddLayer("map60", 8, 9);
      this.AddLayer("map70", 9, 10);
      this.AddLayer("map80", 10, 11);
      this.AddLayer("map90", 11, 12);
      this.AddLayer("map100", 12, int.MaxValue);

      // load the lowest detail map
      imageBox.Image = this.GetMapImage("map10");

      // now zoom in a bit
      this.VirtualZoom = 5;
      this.UpdateMap();
      imageBox.Zoom = 100;
      //imageBox.CenterAt(3350, 800);
      imageBox.CenterAt(imageBox.Image.Width / 2, imageBox.Image.Height / 2);

      // load the lowest detail map
      imageBox1.Image = this.GetMapImage("map10");

      // now zoom in a bit
      this.VirtualZoom = 5;
      this.UpdateMap();
      imageBox1.Zoom = 100;
      //imageBox1.CenterAt(3350, 800);
      imageBox1.CenterAt(imageBox1.Image.Width / 2, imageBox1.Image.Height / 2);

      if (CN + "" == "") return;
      CN = CN.ToUpper().Replace("-", "");
      StartLoadBefore();
      StartLoadAfter();
    }

    #endregion

    #region Private Properties

    private IDictionary<string, Image> ImageCache { get; set; }

    private bool IsUpdatingMap { get; set; }

    private int Layer { get; set; }

    private List<MapLayerData> LayerData { get; set; }

    private bool ResetZoomOnUpdate { get; set; }
    public string CN { get; set; }
    private int BCurentIndex =0;
    private int ACurentIndex = 0;
    private int VirtualZoom
    {
      get { return _virtualZoom; }
      set
      {
        _virtualZoom = value;

        this.UpdateZoomLabel();
      }
    }

    #endregion

    #region Private Members

    private void AddLayer(string FullFilename, int lowerZoom, int upperZoom)
    {
      // The larger map sizes (>map50) are 80MB, so I'm not including them in the GitHub repository.
      // Therefore, just silently skip any missing maps without raising an error

        if (File.Exists(this.GetMapFileName(FullFilename)))
      {
        MapLayerData data;

        data = new MapLayerData();
        data.Name = FullFilename;
        data.UpperZoom = upperZoom;
        data.LowerZoom = lowerZoom;

        this.LayerData.Add(data);
      }
    }

    private int FindNearestLayer(int zoom)
    {
      int result;

      result = -1;

      for (int i = 0; i < this.LayerData.Count; i++)
      {
        MapLayerData data;

        data = this.LayerData[i];

        if (zoom >= data.LowerZoom && zoom < data.UpperZoom)
        {
          result = i;
          break;
        }
      }

      return result;
    }

    private string GetMapFileName(string name)
    {
        //return Path.GetFullPath(Path.Combine(Path.Combine(Application.StartupPath), Path.ChangeExtension("test", ".jpg")));
            
        return name.Length>20 ?name:Path.GetFullPath(Path.Combine(Path.Combine(Application.StartupPath), Path.ChangeExtension("test", ".jpg")));
    }

    private Image GetMapImage(string name)
    {
      Image result;

      if (this.ImageCache == null)
      {
        this.ImageCache = new Dictionary<string, Image>();
      }

      if (!this.ImageCache.TryGetValue(name, out result))
      {
        this.SetStatus("Loading image...");

        result = Image.FromFile(this.GetMapFileName(name));
        //result = Image.FromFile(FullPath);

        this.ImageCache.Add(name, result);

        this.SetStatus(string.Empty);
      }

      this.SetMessage(string.Format("Switching to image {0}.jpg", name));

      return result;
    }

    private void SetMessage(string message)
    {
      //messageLabel.Text = message;
      resetMessageTimer.Stop();
      resetMessageTimer.Start();
    }

    private void SetStatus(string message)
    {
      Cursor.Current = string.IsNullOrEmpty(message) ? Cursors.Default : Cursors.WaitCursor;

      statusToolStripStatusLabel.Text = message;
      statusToolStripStatusLabel.Owner.Refresh();
    }

    private void UpdateCursorPosition(Point location)
    {
      if (imageBox.IsPointInImage(location))
      {
        Point point;
        point = imageBox.PointToImage(location);
        //cursorToolStripStatusLabel.Text = this.FormatPoint(point);
      }
      else
      {
        cursorToolStripStatusLabel.Text = string.Empty;
      }
    }

    private void UpdateMap()
    {
      if (!this.IsUpdatingMap)
      {
        int mapLayer;

        this.IsUpdatingMap = true;

        mapLayer = this.FindNearestLayer(this.VirtualZoom);

        if (mapLayer != -1 && mapLayer != this.Layer)
        {
          MapLayerData data;
          Image newImage;
          RectangleF currentViewport;
          RectangleF newViewport;
          Size currentSize;
          float vAspectRatio;
          float hAspectRatio;

          this.Layer = mapLayer;
          data = this.LayerData[mapLayer];
          mapNameToolStripStatusLabel.Text = data.Name;

          newImage = this.GetMapImage(data.Name);
          currentViewport = imageBox.GetSourceImageRegion();
          currentSize = imageBox.Image.Size;

          hAspectRatio = newImage.Width / (float)currentSize.Width;
          vAspectRatio = newImage.Height / (float)currentSize.Height;

          imageBox.BeginUpdate();
          imageBox.Image = newImage;
          newViewport = new RectangleF(currentViewport.X * hAspectRatio, currentViewport.Y * vAspectRatio, currentViewport.Width * hAspectRatio, currentViewport.Height * vAspectRatio);
          imageBox.ZoomToRegion(newViewport);

          if (this.ResetZoomOnUpdate)
          {
            this.ResetZoomOnUpdate = false;
            imageBox.Zoom = 100;
            imageBox.CenterToImage();
          }

          imageBox.EndUpdate();
        }

        this.IsUpdatingMap = false;
      }
    }

    private void UpdateZoomLabel()
    {
      zoomToolStripStatusLabel.Text = string.Format("{0}% [{1}]", imageBox.Zoom, this.VirtualZoom);
    }

    #endregion

    #region Event Handlers

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //AboutDialog.ShowAboutDialog();
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void imageBox_MouseLeave(object sender, EventArgs e)
    {
      cursorToolStripStatusLabel.Text = string.Empty;
    }

    private void imageBox_MouseMove(object sender, MouseEventArgs e)
    {
      this.UpdateCursorPosition(e.Location);
    }

    private void imageBox_ZoomChanged(object sender, EventArgs e)
    {
      this.UpdateZoomLabel();
    }

    private void imageBox_Zoomed(object sender, ImageBoxZoomEventArgs e)
    {
      if ((e.Source & ImageBoxActionSources.User) == ImageBoxActionSources.User)
      {
        if ((e.Actions & ImageBoxZoomActions.ActualSize) == ImageBoxZoomActions.ActualSize)
        {
          this.VirtualZoom = 0;
          this.ResetZoomOnUpdate = true;
        }
        else if ((e.Actions & ImageBoxZoomActions.ZoomIn) == ImageBoxZoomActions.ZoomIn)
        {
          this.VirtualZoom++;
        }
        else if ((e.Actions & ImageBoxZoomActions.ZoomOut) == ImageBoxZoomActions.ZoomOut)
        {
          this.VirtualZoom--;
        }

        // TODO: Currently the ZoomChanged and Zoomed events are raised after the zoom level has changed, but before any
        // actions such as modifying scrollbars occur. This means methods such as GetSourceImageRegion will return the
        // wrong X and Y values. Until this is fixed, using a timer to trigger the change.
        // However, if you had lots of map changes to make then using a timer would be a good idea regardless; for example
        // if the user rapdily zooms through the available levels, they'll have a smoother experiance if you only load
        // the data once they've stopped zooming
        refreshMapTimer.Stop();
        refreshMapTimer.Start();
      }
    }

    private void refreshMapTimer_Tick(object sender, EventArgs e)
    {
      refreshMapTimer.Stop();

      this.UpdateMap();
    }

    private void resetMessageTimer_Tick(object sender, EventArgs e)
    {
      resetMessageTimer.Stop();
      //messageLabel.Text = string.Empty;
    }

    #endregion

    #region Nested Types

    private struct MapLayerData
    {
      #region Public Properties

      public int LowerZoom { get; set; }

      public string Name { get; set; }

      public int UpperZoom { get; set; }

      #endregion
    }

    #endregion
    private Dictionary<int, string> dicBefor = new Dictionary<int, string>();
    private Dictionary<int, string> dicAfter = new Dictionary<int, string>();
    private void imageBox1_MouseLeave(object sender, EventArgs e)
    {
        cursorToolStripStatusLabel.Text = string.Empty;
    }

    private void imageBox1_MouseMove(object sender, MouseEventArgs e)
    {
        this.UpdateCursorPosition(e.Location);
    }

    private void imageBox1_ZoomChanged(object sender, EventArgs e)
    {
        this.UpdateZoomLabel();
    }

    private void imageBox1_Zoomed(object sender, ImageBoxZoomEventArgs e)
    {
        if ((e.Source & ImageBoxActionSources.User) == ImageBoxActionSources.User)
        {
            if ((e.Actions & ImageBoxZoomActions.ActualSize) == ImageBoxZoomActions.ActualSize)
            {
                this.VirtualZoom = 0;
                this.ResetZoomOnUpdate = true;
            }
            else if ((e.Actions & ImageBoxZoomActions.ZoomIn) == ImageBoxZoomActions.ZoomIn)
            {
                this.VirtualZoom++;
            }
            else if ((e.Actions & ImageBoxZoomActions.ZoomOut) == ImageBoxZoomActions.ZoomOut)
            {
                this.VirtualZoom--;
            }

            // TODO: Currently the ZoomChanged and Zoomed events are raised after the zoom level has changed, but before any
            // actions such as modifying scrollbars occur. This means methods such as GetSourceImageRegion will return the
            // wrong X and Y values. Until this is fixed, using a timer to trigger the change.
            // However, if you had lots of map changes to make then using a timer would be a good idea regardless; for example
            // if the user rapdily zooms through the available levels, they'll have a smoother experiance if you only load
            // the data once they've stopped zooming
            refreshMapTimer.Stop();
            refreshMapTimer.Start();
        }
    }

  
//        Private Function OrientedImageFromFile(ByVal photoFileName As String) As Image
//   Dim img As Image = Image.FromFile(photoFileName) 'get the image
//   Dim pi As Imaging.PropertyItem = Array.Find(img.PropertyItems, _
//        Function(T As Imaging.PropertyItem) T.Id = &H112) '&H112 = PropertyTagOrientation
//   Select Case pi.Value(0) 'value is array of Int16
//       Case 3 : img.RotateFlip(RotateFlipType.Rotate180FlipNone) 'upside-down
//       Case 6 : img.RotateFlip(RotateFlipType.Rotate90FlipNone) 'rotated right
//       Case 8 : img.RotateFlip(RotateFlipType.Rotate270FlipNone) 'rotated left
//   End Select
//   Return img
//End Function
    private Image OrientedImageFromFile(string photoFileName)
    {
        Image img = Image.FromFile(photoFileName);
        //Imaging.PropertyItem pi
        return img;
    }
    private void StartLoadBefore()
    {
        try
        {
            string foldername = Properties.Settings.Default.BeforAfterPath;// Settings.Default;//this.folderBrowserDialog1.SelectedPath;
                int i = 0;
                //foreach (string f in Directory.GetFiles(foldername))
                CN = Regex.Replace(CN, @"\s+", "").Replace("-", "").Replace("(", "").Replace(")", "").ToUpper();
                //string[] folders = System.IO.Directory.GetDirectories(foldername, "*", System.IO.SearchOption.AllDirectories);
            List<string> lsDirectory=new List<string>() ;
            lsDirectory=CustomSearcherFolder.ListDirec(foldername,1,2);

                foreach (string f in lsDirectory)
                {
                    if (Regex.Replace(f, @"\s+", "").Replace("-", "").Replace("(", "").Replace(")", "").ToUpper().Contains(CN))
                    {
                        //foreach (string file in Directory.GetFiles(f))
                        if (!Directory.Exists(f + @"\Before")) return;

                        string[] fileArray = Directory.GetFiles(f + @"\Before", "*.jpg", SearchOption.AllDirectories);
                        foreach (string item in fileArray)
                        {
                            dicBefor.Add(i, item);
                            i++;
                        }
                        break;
                    }
                }
                if (dicBefor.Count > 0)
                {
                    RepoadImageBefor(dicBefor[0]);
                    BCurentIndex = 0;
                }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    private void RepoadImageBefor(string FullPath)
    {
        try
        {
            
            LayerData = new List<MapLayerData>();
            // add some map layers for the different zoom levels
            this.AddLayer(FullPath, int.MinValue, 0);
            this.AddLayer(FullPath, 0, 2);
            this.AddLayer(FullPath, 2, 4);
            this.AddLayer(FullPath, 4, 6);
            this.AddLayer(FullPath, 6, 8);
            this.AddLayer(FullPath, 8, 9);
            this.AddLayer(FullPath, 9, 10);
            this.AddLayer(FullPath, 10, 11);
            this.AddLayer(FullPath, 11, 12);
            this.AddLayer(FullPath, 12, int.MaxValue);
                     // load the lowest detail map
            //System.IO.FileStream fs = new FileStream(FullPath,FileMode.Open,FileAccess.Read);
            
           // imageBox.Image =System.Drawing.Image.FromStream(fs);// this.GetMapImage(FullPath);
                  //Bitmap theImage = pbxImage.Image as Bitmap;
                  
   //theImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
   //pbxImage.Image = theImage;
            //Image img = System.Drawing.Image.FromStream(fs);
            //img.RotateFlip(ImageHelper.RotateImageByExifOrientationData(img,false));//  RotateFlipType.Rotate90FlipNone
            //Bitmap bmp = new Bitmap(pictureBox1.Image);
            //bmp.MakeTransparent(bmp.GetPixel(1, 1));
            imageBox.Image = getImage(FullPath); //bmp;
            

//            Dim fs As System.IO.FileStream' Specify a valid picture file path on your computer.
//fs = New System.IO.FileStream("C:\WINNT\Web\Wallpaper\Fly Away.jpg", 
//     IO.FileMode.Open, IO.FileAccess.Read)
//PictureBox1.Image = System.Drawing.Image.FromStream(fs)
            //fs.Close();


            labelBFileName.Text = Path.GetFileName(FullPath);
              // now zoom in a bit
            this.VirtualZoom = 5;
            //this.UpdateMap();
              imageBox.Zoom = 20;
              //imageBox.CenterAt(3350, 800);
              imageBox.CenterAt(imageBox.Image.Width / 2, imageBox.Image.Height / 2);
            

              // load the lowest detail map

              // now zoom in a bit
              this.VirtualZoom = 5;
              //this.UpdateMap();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void StartLoadAfter()
    {
        try
        {
            string foldername = Properties.Settings.Default.BeforAfterPath;// Settings.Default;//this.folderBrowserDialog1.SelectedPath;
            int i = 0;
            //foreach (string f in Directory.GetFiles(foldername))
            List<string> lsDirectory = new List<string>();
            lsDirectory = CustomSearcherFolder.ListDirec(foldername, 1, 2);
            foreach (string f in lsDirectory)
            {
                if (Regex.Replace(f, @"\s+", "").Replace("-", "").Replace("(", "").Replace(")", "").ToUpper().Contains(CN))
                {
                    //foreach (string file in Directory.GetFiles(f))
                    if (!Directory.Exists(f + @"\After")) return;

                    string[] fileArray = Directory.GetFiles(f + @"\After", "*.jpg", SearchOption.AllDirectories);
                    foreach (string item in fileArray)
                    {
                        dicAfter.Add(i, item);
                        i++;
                    }
                    break;
                }
            }

            if (dicAfter.Count > 0)
            {
                RepoadImageAfter(dicAfter[0]);
                ACurentIndex = 0;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void RepoadImageAfter(string FullPath)
    {
        try
        {
            LayerData = new List<MapLayerData>();
            // add some map layers for the different zoom levels
            this.AddLayer(FullPath, int.MinValue, 0);
            this.AddLayer(FullPath, 0, 2);
            this.AddLayer(FullPath, 2, 4);
            this.AddLayer(FullPath, 4, 6);
            this.AddLayer(FullPath, 6, 8);
            this.AddLayer(FullPath, 8, 9);
            this.AddLayer(FullPath, 9, 10);
            this.AddLayer(FullPath, 10, 11);
            this.AddLayer(FullPath, 11, 12);
            this.AddLayer(FullPath, 12, int.MaxValue);
            // now zoom in a bit
            this.VirtualZoom = 5;
            //this.UpdateMap();
         
            //// load the lowest detail map
            ////imageBox1.Image = this.GetMapImage(FullPath);
            //System.IO.FileStream fs = new FileStream(FullPath, FileMode.Open, FileAccess.Read);
            //imageBox.Image = System.Drawing.Image.FromStream(fs);// this.GetMapImage(FullPath);
            //fs.Close();
            imageBox1.Image = getImage(FullPath); //bmp;

            labelAFilename.Text = Path.GetFileName(FullPath);
            // now zoom in a bit
            this.VirtualZoom = 5;
            //this.UpdateMap();
            imageBox1.Zoom = 20;
            //imageBox1.CenterAt(3350, 800);
            imageBox1.CenterAt(imageBox1.Image.Width / 2, imageBox1.Image.Height / 2);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private Bitmap getImage(string path, int @width = 0, int @height = 0)
    {
        var ext = Path.GetExtension(path).ToLower();
        Bitmap bmp = null;
        var settings = new MagickReadSettings();

        if (ext.CompareTo(".svg") == 0)
        {
            settings.BackgroundColor = MagickColors.Transparent;
        }

        if (width > 0 && height > 0)
        {
            settings.Width = width;
            settings.Height = height;
        }


        using (var magicImg = new MagickImage(path, settings))
        {
            //Get Exif information
            var profile = magicImg.GetExifProfile();
            if (profile != null)
            {
                //Get Orieantation Flag
                var exifTag = profile.GetValue(ExifTag.Orientation);

                if (exifTag != null)
                {
                    int orientationFlag = int.Parse(profile.GetValue(ExifTag.Orientation).Value.ToString());

                    var orientationDegree = GetOrientationDegree(orientationFlag);
                    if (orientationDegree != 0)
                    {
                        //Rotate image accordingly
                        magicImg.Rotate(orientationDegree);
                    }
                }

            }

            //corect the image color
            magicImg.AddProfile(ColorProfile.SRGB);

            return bmp = magicImg.ToBitmap();
        }
    }
    /// <summary>
    /// Returns Exif rotation in degrees. Returns 0 if the metadata 
    /// does not exist or could not be read. A negative value means
    /// the image needs to be mirrored about the vertical axis.
    /// </summary>
    /// <param name="orientationFlag">Orientation Flag</param>
    /// <returns></returns>
    public static double GetOrientationDegree(int orientationFlag)
    {
        if (orientationFlag == 1)
            return 0;
        else if (orientationFlag == 2)
            return -360;
        else if (orientationFlag == 3)
            return 180;
        else if (orientationFlag == 4)
            return -180;
        else if (orientationFlag == 5)
            return -90;
        else if (orientationFlag == 6)
            return 90;
        else if (orientationFlag == 7)
            return -270;
        else if (orientationFlag == 8)
            return 270;

        return 0;
    }
    
    private void btnPreviosB_Click(object sender, EventArgs e)
    {
        try
        {
            if (BCurentIndex == 0)
                BCurentIndex = dicBefor.Count - 1;
            else
                BCurentIndex -= 1;

            if (dicBefor.ContainsKey(BCurentIndex))
                RepoadImageBefor(dicBefor[BCurentIndex]);
        }
        catch (Exception)
        {

        }
    }

    private void btnNextB_Click(object sender, EventArgs e)
    {
        try
        {
            if (dicBefor.Count - 1 == BCurentIndex)
                BCurentIndex = 0;
            else
                BCurentIndex += 1;

            if (dicBefor.ContainsKey(BCurentIndex))
                RepoadImageBefor(dicBefor[BCurentIndex]);
        }
        catch (Exception)
        {

        }
    }

    private void btnPreviosA_Click(object sender, EventArgs e)
    {
        try
        {
            if (ACurentIndex == 0)
                ACurentIndex = dicAfter.Count - 1;
            else
                ACurentIndex -= 1;

            if (dicAfter.ContainsKey(ACurentIndex))
                RepoadImageAfter(dicAfter[ACurentIndex]);
        }
        catch (Exception)
        {

        }
    }

    private void btnNextA_Click(object sender, EventArgs e)
    {
        try
        {
            if (dicAfter.Count - 1 == ACurentIndex)
                ACurentIndex = 0;
            else
                ACurentIndex += 1;

            if (dicAfter.ContainsKey(ACurentIndex))
                RepoadImageAfter(dicAfter[ACurentIndex]);
        }
        catch (Exception)
        {

        }
    }

   

  }
}
