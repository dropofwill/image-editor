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
        private Bitmap controlBitmap;
        private Bitmap previewBitmap;
        private Image anImage;
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
            anImage = mainParentForm.CurrentPicture;
            controlBitmap = new Bitmap(anImage);
            InitializeComponent();
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
                    new float[] {0, 1, 0, 0, gV},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {rV, gV, bV, 0, 1}
                });
            return cMatrix;
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            setMainBitmap();
            parentForm.Dispose();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            mainParentForm.setMainPicture(controlBitmap);
            parentForm.Dispose();
        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);
            previewBitmap = deepCopyBitmap(controlBitmap);
            previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            mainParentForm.setMainPicture(previewBitmap);
         }

        private void setMainBitmap()
        {
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);
            previewBitmap = deepCopyBitmap(controlBitmap);
            previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            mainParentForm.setMainPicture(previewBitmap);
        }

        private Bitmap deepCopyBitmap(Bitmap aBitmap)
        {
            Bitmap copy = new Bitmap(aBitmap.Width, aBitmap.Height);

            using (Graphics graphics = Graphics.FromImage(copy))
            {
                Rectangle imageRectangle = new Rectangle(0, 0, copy.Width, copy.Height);
                graphics.DrawImage(aBitmap, imageRectangle, imageRectangle, GraphicsUnit.Pixel);
            }

            return copy;
        }

    }
}
