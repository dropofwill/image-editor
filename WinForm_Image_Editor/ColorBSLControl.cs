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
    public partial class ColorBSLControl : UserControl
    {
        private Image_Editor_Main mainParentForm;
        private ColorRGBDialog parentForm;
        private Bitmap controlBitmap;
        private Bitmap previewBitmap;
        private Image anImage;
        private float brightV;
        private float satV;
        private float conV;

        /// <summary>
        /// User interface for changing the red/green/blue channels individually for an image
        /// </summary>
        /// <param name="mPF">The Image_Editor_Main that spawned the dialog</param>
        /// <param name="pF">The ColorRGBDialog that spawned this control</param>
        public ColorBSLControl(Image_Editor_Main mPF, ColorRGBDialog pF)
        {
            mainParentForm = mPF;
            parentForm = pF;
            anImage = mainParentForm.CurrentPicture;
            controlBitmap = new Bitmap(anImage);
            InitializeComponent();
        }

        private void redTrackBar_Scroll(object sender, EventArgs e)
        {
            brightV = ((float)brightTrackBar.Value / (float)100);
            brightValue.Text = "" + brightV;
        }

        private void greenTrackBar_Scroll(object sender, EventArgs e)
        {
            satV = ((float)satTrackBar.Value / (float)100);
            satValue.Text = "" + satV;
        }

        private void blueTrackBar_Scroll(object sender, EventArgs e)
        {
            conV = ((float)conTrackBar.Value / (float)100);
            conValue.Text = "" + conV;
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

        private ColorMatrix createBrightnessMatrix(float bV)
        {
            ColorMatrix cMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {bV, bV, bV, 0, 1}
                });
            return cMatrix;
        }

        private ColorMatrix createContrastMatrix(float rV, float gV, float bV)
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

        private ColorMatrix createSaturationMatrix(float rV, float gV, float bV)
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
            ColorMatrix cMatrix = createColorMatrix(brightV, satV, conV);
            previewBitmap = deepCopyBitmap(controlBitmap);
            previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            mainParentForm.setMainPicture(previewBitmap);
         }

        private void setMainBitmap()
        {
            ColorMatrix cMatrix = createColorMatrix(brightV, satV, conV);
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
