using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Image_Editor
{
    public partial class Image_Editor_Main : Form
    {

        private Bitmap originalPicture;
        private Bitmap currentPicture;

        private ColorMatrix greyscaleConMatrix = new ColorMatrix(
            new float[][]
            {
                new float[] {.22f,.22f,.22f, 0, 0},
                new float[] {.59f,.59f,.59f, 0, 0},
                new float[] {.11f,.11f,.11f, 0, 0},
                new float[] {  0,   0,   0,  1, 0},
                new float[] {  0,   0,   0,  0, 1}
            });

        private ColorMatrix invertConMatrix = new ColorMatrix(
           new float[][]
            {
                new float[] { -1,   0,   0,  0,  255},
                new float[] {  0,  -1,   0,  0,  255},
                new float[] {  0,   0,  -1,  0,  255},
                new float[] {  0,   0,   0,  1,  0},
                new float[] {  1,   1,   1,  0,  1}
            });

        public Image_Editor_Main()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "JPEG Compressed Image (*.jpg)|*.jpg|GIF Image(*.gif)|*.gif|Bitmap Image(*.bmp)|*.bmp|PNG Image (*.png)|*.png";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalPicture = new Bitmap(openFileDialog.FileName);
                currentPicture = new Bitmap(openFileDialog.FileName);
                setMainPicture(currentPicture);

                this.Text = openFileDialog.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPEG Compressed Image (*.jpg)|*.jpg|GIF Image(*.gif)|*.gif|Bitmap Image(*.bmp)|*.bmp|PNG Image (*.png)|*.png";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mainPictureBox.Image.Save(saveFileDialog.FileName);
                    this.Text = saveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
            }
        }



        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPicture != null)
            {
                currentPicture = MatrixConvertBitmap(currentPicture, invertConMatrix);
                setMainPicture(currentPicture);
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPicture != null)
            {
                currentPicture = MatrixConvertBitmap(currentPicture, greyscaleConMatrix);
                setMainPicture(currentPicture);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original">Bitmap to be converted</param>
        /// <param name="cM">ColorMatrix which does the changing</param>
        /// <returns>Converted Bitmap</returns>
        public Bitmap MatrixConvertBitmap(Bitmap original, ColorMatrix cM)
        {
            Bitmap aBitmap = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(aBitmap);

            ColorMatrix colorMatrix = cM;

            // Set an image attribute to our color matrix so that we can apply it to a bitmap
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(colorMatrix);

            //Uses graphics class to redraw the bitmap with our Color matrix applied
            g.DrawImage(    original,                                               // Bitmap
                            new Rectangle(0, 0, original.Width, original.Height),   // Contains the image
                            0,                                                      // x, y, width, and height
                            0,
                            original.Width,
                            original.Height,
                            GraphicsUnit.Pixel,                                     // Unit of measure
                            attr);                                                  // Our ColorMatrix being applied
            g.Dispose();

            return aBitmap;
        }

        /// <summary>
        /// Set the main picture from outside
        /// </summary>
        /// <param name="aBitmap">a Bitmap object that will be displayed</param>
        public void setMainPicture(Bitmap aBitmap)
        {
            mainPictureBox.Image = aBitmap;
        }




        private void discardChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMainPicture(originalPicture);
            currentPicture = originalPicture;
            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void recolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainPictureBox.Image != null)
            {
                RecolorForm recolorF = new RecolorForm(this);
                recolorF.Show();
            }
        }

        public Bitmap CurrentPicture
        {
            get { return currentPicture; }
            set { currentPicture = value; }
        }
    }
}
