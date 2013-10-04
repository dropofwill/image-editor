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
                new float[] { -1,   0,   0,  0,  1},
                new float[] {  0,  -1,   0,  0,  1},
                new float[] {  0,   0,  -1,  0,  1},
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
                mainPictureBox.Image = currentPicture;
                //mainPictureBox.Image = ScaleToFitPicBox(originalPicture);

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


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPicture != null)
            {
                currentPicture = MatrixConvertBitmap(currentPicture, invertConMatrix);
                mainPictureBox.Image = currentPicture;
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPicture != null)
            {
                //mainPictureBox.Image = ConvertToGreyscale(currentPicture, 0.28, 0.59, 0.11); // Got these from the wikipedia page on greyscale
                currentPicture = MatrixConvertBitmap(currentPicture, greyscaleConMatrix);
                mainPictureBox.Image = currentPicture;
            }
        }

        private Bitmap MatrixConvertBitmap(Bitmap original, ColorMatrix cM)
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
        /// The slow way to iterate over and make a greyscale version of the image
        /// </summary>
        /// <param name="aB">the bitmap you're making greyscale</param>
        /// <param name="r">Coefficient of the red value, wikipedia recommends 0.28</param>
        /// <param name="g">Coefficient of the green value, wikipedia recommends 0.59</param>
        /// <param name="b">Coefficient of the blue value, wikipedia recommends 0.11</param>
        /// <returns></returns>
        private Bitmap ConvertToGreyscale(Bitmap aB, double r, double g, double b)
        {
            Bitmap aBitmap = aB;
            int greyColor;

            for (int x = 0; x < aBitmap.Width; x++)
            {
                for (int y = 0; y < aBitmap.Height; y++)
                {
                    Color oriColor = aBitmap.GetPixel(x, y);
                    greyColor = (int)((oriColor.R * r) + (oriColor.G * g) + (oriColor.B * b));
                    Color newColor = Color.FromArgb(greyColor, greyColor, greyColor);
                    aBitmap.SetPixel(x, y, newColor);
                }
            }

            return aB;
        }

        /// <summary>
        /// Made this before I realized it was already built into winforms
        /// </summary>
        /// <param name="aPicture">Takes a Bitmap</param>
        /// <returns>And returns a bitmap resized to fit the picture box</returns>
        private Bitmap ScaleToFitPicBox(Bitmap aPicture)
        {
            int sourceWidth = aPicture.Width;
            int sourceHeight = aPicture.Height;
            int targetWidth;
            int targetHeight;
            int targetTop;
            int targetLeft;
            double ratio;

            Bitmap tempBitmap = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            tempBitmap.SetResolution(aPicture.HorizontalResolution, aPicture.VerticalResolution);
            Graphics bmGraphics = Graphics.FromImage(tempBitmap);
            bmGraphics.Clear(Color.FromArgb(255, 30, 30, 30));
            bmGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;


            if (sourceWidth > sourceHeight)
            {
                targetWidth = mainPictureBox.Width;

                ratio = (double)targetWidth / sourceWidth;

                targetHeight = (int)(ratio * sourceWidth);
            }
            else if (sourceHeight < sourceWidth)
            {
                targetHeight = mainPictureBox.Height;

                ratio = (double)targetHeight / sourceHeight;

                targetWidth = (int)(ratio * sourceWidth);
            }
            else
            {
                targetWidth = mainPictureBox.Width;
                targetHeight = mainPictureBox.Height;
            }

            targetTop = (mainPictureBox.Height - targetHeight) / 2;
            targetLeft = (mainPictureBox.Width - targetWidth) / 2;

            bmGraphics.DrawImage(aPicture,
                                    new Rectangle(targetLeft, targetTop, targetWidth, targetHeight),
                                    new Rectangle(0, 0, sourceWidth, sourceHeight),
                                    GraphicsUnit.Pixel);
            bmGraphics.Dispose();

            return tempBitmap;
        }

        private void discardChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPictureBox.Image = originalPicture;
        }

        private void colorModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
