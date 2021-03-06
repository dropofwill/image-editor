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
    public partial class ColorBSLControl : UserControl
    {
        private Image_Editor_Main mainParentForm;
        private ColorRGBDialog parentForm;
        private Bitmap previewBitmap;

        private int originalBitmapCount = new int();
        private float brightV = 0f;
        private float satV = 1f;
        private float conV = 1f;

        /// <summary>
        /// User interface for changing the brightness/contrast/saturation of an image.
        /// Actual values and formulas actually came from (oddly enough) the rainmeter 
        /// documentation, which explains the matrix formulas pretty well:
        /// docs.rainmeter.net/tips/colormatrix-guide
        /// </summary>
        /// <param name="mPF">The Image_Editor_Main that spawned the dialog</param>
        /// <param name="pF">The ColorRGBDialog that spawned this control</param>
        public ColorBSLControl(Image_Editor_Main mPF, ColorRGBDialog pF)
        {
            mainParentForm = mPF;
            parentForm = pF;
            InitializeComponent();
            originalBitmapCount = mainParentForm.CurrentBitmap;
        }

        private void brightTrackBar_Scroll(object sender, EventArgs e)
        {
            brightV = ((float)brightTrackBar.Value / (float)100);
            brightValue.Text = "" + brightV;
        }

        private void satTrackBar_Scroll(object sender, EventArgs e)
        {
            satV = ((float)satTrackBar.Value / (float)100);
            satValue.Text = "" + satV;
        }

        private void conTrackBar_Scroll(object sender, EventArgs e)
        {
            conV = ((float)conTrackBar.Value / (float)100);
            conValue.Text = "" + conV;
        }

        /// <summary>
        /// It's faster to take the cross product of the three matricies together
        /// than to apply each separately. I've left the other three functions 
        /// below to help with understanding.
        /// </summary>
        /// <param name="bV"></param>
        /// <param name="sV"></param>
        /// <param name="cV"></param>
        /// <returns>Returns a ColorMatrix that change Brightness, Contrast, and Saturation</returns>
        private ColorMatrix createTransformMatrix(float bV, float sV, float cV)
        {
            float lumR, lumG, lumB, sR, sG, sB, tV;

            if (highRed.Checked == true)
            {
                lumR = 0.3086f;
            }
            else
            {
                lumR = 0.2125f;
            }

            if (highGreen.Checked == true)
            {
                lumG = 0.7154f;
            }
            else
            {
                lumG = 0.6094f;
            }

            if (highBlue.Checked == true)
            {
                lumB = 0.0820f;
            }
            else
            {
                lumB = 0.0721f;
            }

            sR = (1 - sV) * lumR;
            sG = (1 - sV) * lumG;
            sB = (1 - sV) * lumB;
            tV = (float)((1.0 - cV) / 2.0);

            ColorMatrix sMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] { cV*(sR+sV),  cV*(sR),    cV*(sR),    0, 0},
                    new float[] {  cV*(sG),   cV*(sG+sV),  cV*(sG),    0, 0},
                    new float[] {  cV*(sB),     cV*(sB),  cV*(sB+sV),  0, 0},
                    new float[] {      0,          0,          0,      1, 0},
                    new float[] {    bV+tV,      bV+tV,      bV+tV,    0, 1}
                });
            return sMatrix;
        }

        /// <summary>
        /// Creates a Color Matrix that adjusts brightness by whatever value passed in
        /// </summary>
        /// <param name="bV"></param>
        /// <returns>A ColorMatrix that adjusts brightness</returns>
        private ColorMatrix createBrightnessMatrix(float bV)
        {
            ColorMatrix cMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] { 1,  0,  0, 0, 0},
                    new float[] { 0,  1,  0, 0, 0},
                    new float[] { 0,  0,  1, 0, 0},
                    new float[] { 0,  0,  0, 1, 0},
                    new float[] {bV, bV, bV, 0, 1}
                });
            return cMatrix;
        }

        /// <summary>
        /// Creates a Color Matrix that adjusts the contrast by whatever value is passed in
        /// </summary>
        /// <param name="cV"></param>
        /// <returns>A ColorMatrix adjusts brightness</returns>
        private ColorMatrix createContrastMatrix(float cV)
        {
            float tV = (float)((1.0 - cV) / 2.0);

            ColorMatrix cMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {cV, 0,  0,  0, 0},
                    new float[] {0,  cV, 0,  0, 0},
                    new float[] {0,  0,  cV, 0, 0},
                    new float[] {0,  0,  0,  1, 0},
                    new float[] {tV, tV, tV, 0, 1}
                });
            return cMatrix;
        }

        /// <summary>
        /// Creates a Color Matrix that adjusts the saturation by whatever value is passed in
        /// </summary>
        /// <param name="sV"></param>
        /// <returns>A ColorMatrix adjusts saturation</returns>
        private ColorMatrix createSaturationMatrix(float sV)
        {
            float lumR, lumG, lumB, sR, sG, sB;

            if (highRed.Checked == true)
            {
                lumR = 0.3086f;
            }
            else
            {
                lumR = 0.2125f;
            }

            if (highGreen.Checked == true)
            {
                lumG = 0.7154f;
            }
            else
            {
                lumG = 0.6094f;
            }

            if (highBlue.Checked == true)
            {
                lumB = 0.0820f;
            }
            else
            {
                lumB = 0.0721f;
            }

            sR = (1 - sV) * lumR;
            sG = (1 - sV) * lumG;
            sB = (1 - sV) * lumB;

            ColorMatrix sMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {sR+sV, sR, sR, 0, 0},
                    new float[] {sG, sG+sV, sG, 0, 0},
                    new float[] {sB, sB, sB+sV, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            return sMatrix;
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
            ColorMatrix cMatrix = createTransformMatrix(brightV, satV, conV);

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
            ColorMatrix cMatrix = createTransformMatrix(brightV, satV, conV);

            // Get the current bitmap to edit
            previewBitmap = mainParentForm.BitmapList[mainParentForm.CurrentBitmap];

            // Apply the matrix to the bitmap
            previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            // Display the bitmap temporarily
            mainParentForm.setTempPicture(previewBitmap);
        }

    }
}
