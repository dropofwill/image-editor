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
    public partial class CustomMatrixControl : UserControl
    {
        private Image_Editor_Main mainParentForm;
        private ColorRGBDialog parentForm;
        private Bitmap controlBitmap;
        private Bitmap previewBitmap;
        private Image anImage;

        //individual values for the custom matrix, start with the identity matrix
        private float   v00=1, v01=0, v02=0, v03=0, v04=0,
                        v10=0, v11=1, v12=0, v13=0, v14=0,
                        v20=0, v21=0, v22=1, v23=0, v24=0,
                        v30=0, v31=0, v32=0, v33=1, v34=0,
                        v40=0, v41=0, v42=0, v43=0, v44=1;

        /// <summary>
        /// User interface for changing the red/green/blue channels individually for an image
        /// </summary>
        /// <param name="mPF">The Image_Editor_Main that spawned the dialog</param>
        /// <param name="pF">The ColorRGBDialog that spawned this control</param>
        public CustomMatrixControl(Image_Editor_Main mPF, ColorRGBDialog pF)
        {
            mainParentForm = mPF;
            parentForm = pF;
            anImage = mainParentForm.CurrentPicture;
            controlBitmap = new Bitmap(anImage);
            InitializeComponent();
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
            parentForm.Dispose();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            mainParentForm.setMainPicture(controlBitmap);
            parentForm.Dispose();
        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            setMainBitmap();
         }

        private void setMainBitmap()
        {
            //ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);
            //previewBitmap = deepCopyBitmap(controlBitmap);
            //previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            //mainParentForm.setMainPicture(previewBitmap);
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
