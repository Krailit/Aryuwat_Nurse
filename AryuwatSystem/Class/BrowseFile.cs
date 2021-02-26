using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.DerClass
{
    public static class BrowseFile
    {
        public static string BrowFileType(string fileTyp)
        {
            string path = "";
            switch (fileTyp)
            {
                case "DOC":
                    //path = SelectDocFile();
                    break;
                case "IMAGE":
                    path= SelectImageFile();
                    break;
            }
            return path;
        }

        //private static string SelectDocFile()
        //{
        //    // Configure open file dialog box 
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.Filter = "";

        //    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        //    string sep = string.Empty;

        //    //foreach (var c in codecs)
        //    //{
        //    //    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
        //    //    dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
        //    //    sep = "|";
        //    //}

        //    dlg.Filter = "JPG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|PNG|*.png|TIFF|*.tif;*.tiff|" +
        //                 "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

        //    //dlg.DefaultExt = "*.JPG"; // Default file extension 
        //    //dlg.DefaultExt = "JPG";
        //    // Show open file dialog box 


        //    // Process open file dialog box results 
        //    if (dlg.ShowDialog() == DialogResult.OK && dlg.FileName != "")
        //    {
        //        // Open document 
        //        string fileName = dlg.FileName;
        //        // Do something with fileName  
        //        return fileName;
        //    }
        //    return "";
        //}
        private static string SelectImageFile()
        {
            // Configure open file dialog box 
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "";

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            //foreach (var c in codecs)
            //{
            //    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
            //    dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
            //    sep = "|";
            //}

            dlg.Filter = "JPG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|PNG|*.png|TIFF|*.tif;*.tiff|" +
                         "All Graphics Types|*.PDF;*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            //dlg.DefaultExt = "*.JPG"; // Default file extension 
            //dlg.DefaultExt = "JPG";
            // Show open file dialog box 
            

            // Process open file dialog box results 
            if (dlg.ShowDialog()==DialogResult.OK && dlg.FileName!="")
            {
                // Open document 
                string fileName = dlg.FileName;
                // Do something with fileName  
                return fileName;
            }
            return "";
        }

        public static bool Movefile(string sourcePath, string targetType, string filename)
        {
            bool succ = false;
            if (!string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(targetType))
            {
                
                string sourceDirec = Path.GetDirectoryName(sourcePath);
                string targetPath = Properties.Settings.Default.ImagePathServer + "\\" + targetType.ToUpper();

                 // Use Path class to manipulate file and directory paths. 
                string sourceFile = System.IO.Path.Combine(sourceDirec, path2: Path.GetFileName(sourcePath));
                string destFile = System.IO.Path.Combine(targetPath, filename+@".jpg");

             // To copy a folder's contents to a new location: 
       
                // Create a new target folder, if necessary. 
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                // To copy a file to another location and  
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);
                succ = true;
            }
            return succ;
        }

        /// <summary>
        /// Create By tu
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetType"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool CopyfileOther(string sourcePath, string targetFolder, string targetfilename)
        {
            bool succ = false;
            if (!string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(targetFolder))
            {

                string sourceDirec = Path.GetDirectoryName(sourcePath);
               // string targetPath = Properties.Settings.Default.ImagePathServer + "\\";

                // Use Path class to manipulate file and directory paths. 
                string sourceFile = System.IO.Path.Combine(sourceDirec, path2: Path.GetFileName(sourcePath));
                string destFile = System.IO.Path.Combine(targetFolder, targetfilename);

                // To copy a folder's contents to a new location: 

                // Create a new target folder, if necessary. 
                if (!System.IO.Directory.Exists(targetFolder))
                {
                    System.IO.Directory.CreateDirectory(targetFolder);
                }

                // To copy a file to another location and  
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);
                succ = true;
            }
            return succ;
        }
        public static bool MovefileOther(string sourcePath, string targetType, string filename)
        {
            bool succ = false;
            if (!string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(targetType))
            {

                string sourceDirec = Path.GetDirectoryName(sourcePath);
                string targetPath = Properties.Settings.Default.ImagePathServer + "\\" + targetType.ToUpper();

                // Use Path class to manipulate file and directory paths. 
                string sourceFile = System.IO.Path.Combine(sourceDirec, path2: Path.GetFileName(sourcePath));
                string destFile = System.IO.Path.Combine(targetPath, filename);

                // To copy a folder's contents to a new location: 

                // Create a new target folder, if necessary. 
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                // To copy a file to another location and  
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);
                succ = true;
            }
            return succ;
        }
        public static bool Deletefile(string targetType, string filename)
        {
            bool succ = false;
            if (!string.IsNullOrEmpty(targetType) && !string.IsNullOrEmpty(filename))
            {
                string delPath = Properties.Settings.Default.ImagePathServer + "\\" + targetType.ToUpper();

                // Use Path class to manipulate file and directory paths. 
                string delFile = System.IO.Path.Combine(delPath, filename + @".jpg");

                if (File.Exists(delFile))
                {
                    File.Delete(delFile);
                }
                succ = true;
            }
            return succ;
        }
        public static bool Deletefile(string fileFullPath)
        {
            bool succ = false;
            if (!string.IsNullOrEmpty(fileFullPath))
            {

                if (File.Exists(fileFullPath))
                {
                    File.Delete(fileFullPath);
                }
                succ = true;
            }
            return succ;
        }
    }
}
