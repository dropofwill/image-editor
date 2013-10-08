using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private List<Bitmap> bitmapList = new List<Bitmap>();
        private int currentBitmap = 0;


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
                addPicture(currentPicture);

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
                    Bitmap exportPicture = bitmapList[currentBitmap];
                    exportPicture.Save(saveFileDialog.FileName);
                    this.Text = saveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
            }
        }


        public void addPicture(Bitmap aBitmap)
        {
            bitmapList.Add(aBitmap);
            mainPictureBox.Image = aBitmap;
            currentBitmap = bitmapList.Count - 1;

            Console.WriteLine(currentBitmap);
            Console.WriteLine(bitmapList.Count);
        }


        /// <summary>
        /// This changes the main image to a bitmap from the array of bitmaps
        /// Bitmap class for manipulation needs to be converted to bitmap source
        /// to be displayed by WPF
        /// </summary>
        /// <param name="currentState"></param>
        public void setMainPicture(int currentState)
        {
            mainPictureBox.Image = bitmapList[currentState];
            currentBitmap = currentState;

            Console.WriteLine(currentBitmap);
            Console.WriteLine(bitmapList.Count);
        }

        /// <summary>
        /// For non permanent changes to the main image and aren't added to the state
        /// </summary>
        /// <param name="aBitmap"></param>
        public void setTempPicture(Bitmap aBitmap)
        {
            mainPictureBox.Image = aBitmap;
        }

        public void undoPicture()
        {
            if (currentBitmap > 0)
            {
                currentBitmap--;
                setMainPicture(currentBitmap);
            }
            Console.WriteLine("undo ran");
        }

        public void redoPicture()
        {
            if (currentBitmap < bitmapList.Count - 1)
            {
                currentBitmap++;
                setMainPicture(currentBitmap);
            }

            Console.WriteLine("redo ran");
        }

         
    //
    //    public void resetState(Bitmap aBitmap=null)
    //    {
    //        previousStatesList.Clear();
    //        currentStateCounter = -1;
    //        previousStatesList.Add(aBitmap);
    //
    //        Console.WriteLine(currentStateCounter);
    //    }
    //
    //    public void addState(Bitmap aBitmap)
    //    {
    //        previousStatesList.Add(aBitmap);
    //        currentStateCounter++;
    //        Console.WriteLine(currentStateCounter);
    //    }
    //
    //    public void previousState()
    //    {
    //        try
    //        {
    //            setMainPicture(previousStatesList[currentStateCounter--]);
    //            currentStateCounter--;
    //        }
    //        catch (Exception except)
    //        {
    //            MessageBox.Show(except.Message);
    //        }
    //        Console.WriteLine(currentStateCounter);
    //    }
    //
    //    public void currentState()
    //    {
    //        try
    //        {
    //            setMainPicture(previousStatesList[currentStateCounter]);
    //        }
    //        catch (Exception except)
    //        {
    //            MessageBox.Show(except.Message);
    //        }
    //        Console.WriteLine(currentStateCounter);
    //    }
    //
    //    public void nextState()
    //    {
    //        try
    //        {
    //            setMainPicture(previousStatesList[currentStateCounter++]);
    //            currentStateCounter++;
    //        }
    //        catch (Exception except)
    //        {
    //            MessageBox.Show(except.Message);
    //        }
    //        Console.WriteLine(currentStateCounter);
    //    }
    //
    //    /// <summary>
    //    /// Set the main picture from outside
    //    /// </summary>
    //    /// <param name="aBitmap">a Bitmap object that will be displayed</param>
    //    public void setMainPicture(Bitmap aBitmap, Boolean keepChange = true)
    //    {
    //        mainPictureBox.Image = aBitmap;
    //
    //        if (keepChange)
    //            addState(aBitmap);
    //    }

        /// <summary>
        /// Applies a color matrix to the pixels of a bitmap
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

        private void discardChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMainPicture(0);  
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmapList.Count > 0)
                {
                    currentPicture = bitmapList[currentBitmap];
                    currentPicture = MatrixConvertBitmap(currentPicture, invertConMatrix);
                    addPicture(currentPicture);
                }
                else
                {
                    MessageBox.Show("No Picture, please open a a picture to edit it");
                }
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmapList.Count > 0)
                {
                    currentPicture = bitmapList[currentBitmap];
                    currentPicture = MatrixConvertBitmap(currentPicture, greyscaleConMatrix);
                    addPicture(currentPicture);
                }
                else
                {
                    MessageBox.Show("No Picture, please open a a picture to edit it");
                }
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void bSLModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorRGBDialog colorRGB = new ColorRGBDialog(this, "ColorBSL");
                colorRGB.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No Picture, please open a a picture to edit it");
            }
        }

        private void recolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorRGBDialog colorRGB = new ColorRGBDialog(this, "ColorRGB");
                colorRGB.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No Picture, please open a a picture to edit it");
            }
        }

        private void customGreyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorRGBDialog colorRGB = new ColorRGBDialog(this, "CustomGrey");
                colorRGB.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No Picture, please open a a picture to edit it");
            }
        }

        private void customMatrixTransformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorRGBDialog colorRGB = new ColorRGBDialog(this, "CustomMatrix");
                colorRGB.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Picture, please open a a picture to edit it" + ex.Message);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoPicture();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoPicture();
        }


        public Bitmap CurrentPicture
        {
            get { return currentPicture; }
            set { currentPicture = value; }
        }
        public int CurrentBitmap
        {
            get { return currentBitmap; }
            set { currentBitmap = value; }
        }
        public List<Bitmap> BitmapList
        {
            get { return bitmapList; }
            set { bitmapList = value; }
        }

    }
}
