using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stegary
{
    public class OpenFileArgs : EventArgs
    {
        public Bitmap image { get; set; }
        public string path { get; set; }
        public byte[] file { get; set; }
        public string fileExt { get; set; }
    }
    class FileOperations
    {
        Bitmap newImage=null;
        private byte[] newFile;

        public event EventHandler<OpenFileArgs> FileOpened;

        protected virtual void OnFileOpened(Bitmap image, String path, byte[] file, string fileExtention)
        {
            if (FileOpened != null)
            {
                FileOpened(this, new OpenFileArgs() { image = image, path = path, file = file, fileExt = fileExtention });
            }

        }

        public void OpenFileA()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "jpg files|*.jpg|png files|*.png|bmp files | *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                newImage = new Bitmap(Image.FromFile(ofd.FileName));
            }

            if (newImage != null)
            {
                OnFileOpened(newImage, ofd.FileName, null, null);
            }
           

        }

        public void OpenFileB()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            FileInfo fi = null;
            ofd.Filter = "All files(*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                newFile = File.ReadAllBytes(ofd.FileName);
                fi = new FileInfo(ofd.FileName);
                Console.WriteLine("{0} and its size {1} ", fi.Extension, fi.Extension.Length);

            }

            if (fi != null)
            {
                OnFileOpened(null, ofd.FileName, newFile, fi.Extension);
            }
        }


        public void SaveFileA(Bitmap bmap)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "jpg files|*.jpg|png files|*.png|bmp files | *.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bmap.Save(sfd.FileName);
            }
        }

        public void SaveFileB(byte[] fileBytes)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "File(*.*)|(*.*)"; // h na li tbdl extension wdir switch filterIndex

            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(save_dialog.FileName, fileBytes);
            }
        }

        public void SaveTxt(string message)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Text(*.txt)|*.txt";

            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save_dialog.FileName, message);

            }
        }
    }
}
