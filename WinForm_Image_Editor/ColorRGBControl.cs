using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WinForm_Image_Editor
{
    public partial class ColorRGBControl : UserControl
    {
        private Image_Editor_Main mainParentForm;
        private ColorRGBDialog parentForm;
        private int originalBitmapCount = new int();

        private Bitmap previewBitmap;
        private float redV;
        private float greenV;
        private float blueV;

        /// <summary>
        /// User interface for changing the red/green/blue channels individually for an image
        /// </summary>
        /// <param name="mPF">The Image_Editor_Main that spawned the dialog</param>
        /// <param name="pF">The ColorRGBDialog that spawned this control</param>
        public ColorRGBControl(Image_Editor_Main mPF, ColorRGBDialog pF)
        {
            mainParentForm = mPF;
            parentForm = pF;
            InitializeComponent();
            originalBitmapCount = mainParentForm.CurrentBitmap;
        }

        private void redTrackBar_Scroll(object sender, EventArgs e)
        {
            redV = ((float)redTrackBar.Value / (float)100);
            redValue.Text = "" + redV;
        }

        private void greenTrackBar_Scroll(object sender, EventArgs e)
        {
            greenV = ((float)greenTrackBar.Value / (float)100);
            greenValue.Text = "" + greenV;
        }

        private void blueTrackBar_Scroll(object sender, EventArgs e)
        {
            blueV = ((float)blueTrackBar.Value / (float)100);
            blueValue.Text = "" + blueV;
        }

        private ColorMatrix createColorMatrix(float rV, float gV, float bV)
        {
            ColorMatrix cMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {rV, gV, bV, 0, 1}
                });
            return cMatrix;
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            setMainBitmap();
            mainParentForm.setMainPicture(mainParentForm.CurrentBitmap);
            parentForm.Dispose();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            mainParentForm.setMainPicture(originalBitmapCount);
            parentForm.Dispose();
        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            setTempBitmap();
         }

        /// <summary>
        /// Sets the main Bitmap permanently with the current user settings
        /// Use only for changes that will be saved into state, i.e. the Apply
        /// Button.
        /// </summary>
        private void setMainBitmap()
        {
            // Create the appropriate matrix
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);

            // Get the current bitmap to edit
            previewBitmap = mainParentForm.BitmapList[mainParentForm.CurrentBitmap];

            // Apply the matrix to the bitmap
            previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            // Display the bitmap in the main window, add it to BitmapList, and increment the counter
            mainParentForm.addPicture(previewBitmap);
        }

        /// <summary>
        /// Sets the main Bitmap temporarily with the current user settings
        /// Use only for previews of effects, as it isn't added to the BitmapList,
        /// and goes away when this window is closed.
        /// </summary>
        private void setTempBitmap()
        {
            // Create the appropriate matrix
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);

            // Get the current bitmap to edit
            previewBitmap = mainParentForm.BitmapList[mainParentForm.CurrentBitmap];

            // Apply the matrix to the bitmap
            previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            // Display the bitmap temporarily
            mainParentForm.setTempPicture(previewBitmap);
        }
    }
}
