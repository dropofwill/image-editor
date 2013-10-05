﻿using System;
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


        private ColorMatrix createColorMatrix()
        {
            ColorMatrix cMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {v00, v01, v02, v03, v04},
                    new float[] {v10, v11, v12, v13, v14},
                    new float[] {v20, v21, v22, v23, v24},
                    new float[] {v30, v31, v32, v33, v34},
                    new float[] {v40, v41, v42, v43, v44}
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
            ColorMatrix cMatrix = createColorMatrix();
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

        private void iV00_ValueChanged(object sender, EventArgs e)
        {
            v00 = (float)iV00.Value;
        }

        private void iV01_ValueChanged(object sender, EventArgs e)
        {
            v01 = (float)iV01.Value;
        }

        private void iV02_ValueChanged(object sender, EventArgs e)
        {
            v02 = (float)iV02.Value;
        }

        private void iV03_ValueChanged(object sender, EventArgs e)
        {
            v03 = (float)iV03.Value;
        }

        private void iV04_ValueChanged(object sender, EventArgs e)
        {
            v04 = (float)iV04.Value;
        }

        private void iV10_ValueChanged(object sender, EventArgs e)
        {
            v10 = (float)iV10.Value;
        }

        private void iV11_ValueChanged(object sender, EventArgs e)
        {
            v11 = (float)iV11.Value;
        }

        private void iV12_ValueChanged(object sender, EventArgs e)
        {
            v12 = (float)iV12.Value;
        }

        private void iV13_ValueChanged(object sender, EventArgs e)
        {
            v13 = (float)iV13.Value;
        }

        private void iV14_ValueChanged(object sender, EventArgs e)
        {
            v14 = (float)iV14.Value;
        }

        private void iV20_ValueChanged(object sender, EventArgs e)
        {
            v20 = (float)iV20.Value;
        }

        private void iV21_ValueChanged(object sender, EventArgs e)
        {
            v21 = (float)iV21.Value;
        }

        private void iV22_ValueChanged(object sender, EventArgs e)
        {
            v22 = (float)iV22.Value;
        }

        private void iV23_ValueChanged(object sender, EventArgs e)
        {
            v23 = (float)iV23.Value;
        }

        private void iV24_ValueChanged(object sender, EventArgs e)
        {
            v24 = (float)iV24.Value;
        }

        private void iV30_ValueChanged(object sender, EventArgs e)
        {
            v30 = (float)iV30.Value;
        }

        private void iV31_ValueChanged(object sender, EventArgs e)
        {
            v31 = (float)iV31.Value;
        }

        private void iV32_ValueChanged(object sender, EventArgs e)
        {
            v32 = (float)iV32.Value;
        }

        private void iV33_ValueChanged(object sender, EventArgs e)
        {
            v33 = (float)iV33.Value;
        }

        private void iV34_ValueChanged(object sender, EventArgs e)
        {
            v34 = (float)iV34.Value;
        }

        private void iV40_ValueChanged(object sender, EventArgs e)
        {
            v40 = (float)iV40.Value;
        }

        private void iV41_ValueChanged(object sender, EventArgs e)
        {
            v41 = (float)iV41.Value;
        }

        private void iV42_ValueChanged(object sender, EventArgs e)
        {
            v42 = (float)iV42.Value;
        }

        private void iV43_ValueChanged(object sender, EventArgs e)
        {
            v43 = (float)iV43.Value;
        }

        private void iV44_ValueChanged(object sender, EventArgs e)
        {
            v44 = (float)iV44.Value;
        }
    }
}