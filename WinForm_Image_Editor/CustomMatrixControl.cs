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

        #region Fields

        private Image_Editor_Main mainParentForm;
        private ColorRGBDialog parentForm;

        private int originalBitmapCount = new int();
        private Bitmap previewBitmap;

        //individual values for the custom matrix, start with the identity matrix
        private float   v00=1, v01=0, v02=0, v03=0, v04=0,
                        v10=0, v11=1, v12=0, v13=0, v14=0,
                        v20=0, v21=0, v22=1, v23=0, v24=0,
                        v30=0, v31=0, v32=0, v33=1, v34=0,
                        v40=0, v41=0, v42=0, v43=0, v44=1;

        /// <summary>
        /// A dictionary storing all the matricies with a name for their key
        /// </summary>
        private static Dictionary<String, ColorMatrix> matrixDict = new Dictionary<string, ColorMatrix>
        {
            {"Greyscale", new ColorMatrix(
                               new float[][]
                               {    new float[] {.22f,.22f,.22f, 0, 0},
                                    new float[] {.59f,.59f,.59f, 0, 0},
                                    new float[] {.11f,.11f,.11f, 0, 0},
                                    new float[] {  0,   0,   0,  1, 0},
                                    new float[] {  0,   0,   0,  0, 1}})
            },
            {"Black and White", new ColorMatrix(
                               new float[][]
                               {   new float[] {1.5f, 1.5f, 1.5f, 0, 0},
                                   new float[] {1.5f, 1.5f, 1.5f, 0, 0},
                                   new float[] {1.5f, 1.5f, 1.5f, 0, 0},
                                   new float[] { 0,    0,    0,  1, 0},
                                   new float[] {-1,  -1,  -1, 0, 1}})
            },
            {"Invert", new ColorMatrix(
                               new float[][]
                               {   new float[] {-1f, 0, 0, 0, 0},
                                   new float[] {0, -1f, 0, 0, 0},
                                   new float[] {0,  0, -1f, 0, 0},
                                   new float[] {0,  0,  0, 1f, 0},
                                   new float[] {1f, 1f, 1f, 0, 1f}})
            },
            {"Sepia", new ColorMatrix(
                               new float[][]
                               {   new float[] {0.393f, 0.349f, 0.272f, 0, 0},
                                   new float[] {0.769f, 0.686f, 0.534f, 0, 0},
                                   new float[] {0.189f, 0.168f, 0.131f, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"Polaroid", new ColorMatrix(
                               new float[][]
                               {   new float[] {1.438f, -0.062f, -0.062f, 0, 0},
                                   new float[] {-0.122f, 1.378f, -0.122f, 0, 0},
                                   new float[] {-0.016f, -0.016f, 1.483f, 0, 0},
                                   new float[] {   0,      0,      0,     1, 0},
                                   new float[] {-.03f,   0.05f,   -0.02f, 0, 1}})
            },
            {"RGB Mapped to BGR", new ColorMatrix(
                               new float[][]
                               {   new float[] {0, 0, 1, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
                                   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"RGB Mapped to GBR", new ColorMatrix(
                               new float[][]
                               {   new float[] {0, 0, 1, 0, 0},
                                   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"RGB Mapped to BRG", new ColorMatrix(
                               new float[][]
                               {   new float[] {0, 1, 0, 0, 0},
                                   new float[] {0, 0, 1, 0, 0},
                                   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"Brighten", new ColorMatrix(
                               new float[][]
                               {   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
                                   new float[] {0, 0, 1, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0.5f, 0.5f, 0.5f, 0, 1}})
            },
            {"Darken", new ColorMatrix(
                               new float[][]
                               {   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
                                   new float[] {0, 0, 1, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {-0.5f, -0.5f, -0.5f, 0, 1}})
            },
            {"Saturate", new ColorMatrix(
                               new float[][]
                               {   new float[] {1.346f, -0.154f, -0.154f, 0, 0},
                                   new float[] {-0.305f, 1.1953f, -0.305f, 0, 0},
                                   new float[] {-0.041f, -0.041f, 1.459f, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"Desaturate", new ColorMatrix(
                               new float[][]
                               {   new float[] {-.37f,.463f,.463f, 0, 0},
                                   new float[] {.914f,.414f, .914f, 0, 0},
                                   new float[] {.123f, .123f, -.377f, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"Add Contrast", new ColorMatrix(
                               new float[][]
                               {   new float[] {1.5f, 0, 0, 0, 0},
                                   new float[] {0, 1.5f, 0, 0, 0},
                                   new float[] {0, 0, 1.5f, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {-0.25f, -0.25f, -0.25f, 0, 1}})
            },
            {"Remove Contrast", new ColorMatrix(
                               new float[][]
                               {   new float[] {.5f, 0, 0, 0, 0},
                                   new float[] {0, .5f, 0, 0, 0},
                                   new float[] {0, 0, .5f, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {.25f, .25f, .25f, 0, 1}})
            }
        };

        #endregion

        /// <summary>
        /// User interface for changing the red/green/blue channels individually for an image
        /// </summary>
        /// <param name="mPF">The Image_Editor_Main that spawned the dialog</param>
        /// <param name="pF">The ColorRGBDialog that spawned this control</param>
        public CustomMatrixControl(Image_Editor_Main mPF, ColorRGBDialog pF)
        {
            mainParentForm = mPF;
            parentForm = pF;

            InitializeComponent();
            originalBitmapCount = mainParentForm.CurrentBitmap;
            SetComboBox();
        }

        /// <summary>
        /// Loads each matrix's key into the combo box
        /// </summary>
        private void SetComboBox()
        {
            foreach (string key in matrixDict.Keys)
            {
                presetsComboBox.Items.Add(key);
            }
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


        /// <summary>
        /// Sets the main Bitmap permanently with the current user settings
        /// Use only for changes that will be saved into state, i.e. the Apply
        /// Button.
        /// </summary>
        private void setMainBitmap()
        {
            // Create the appropriate matrix
            ColorMatrix cMatrix = createColorMatrix();

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
            ColorMatrix cMatrix = createColorMatrix();

            // Get the current bitmap to edit
            previewBitmap = mainParentForm.BitmapList[mainParentForm.CurrentBitmap];

            // Apply the matrix to the bitmap
            previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

            // Display the bitmap temporarily
            mainParentForm.setTempPicture(previewBitmap);
        }

        #region event_handlers

        /// <summary>
        /// Sets the main form's bitmap without closing the current dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preview_btn_Click(object sender, EventArgs e)
        {
            setMainBitmap();
        }

        /// <summary>
        /// Sets the main form's bitmap and closes the current dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apply_btn_Click(object sender, EventArgs e)
        {
            setMainBitmap();
            mainParentForm.setMainPicture(mainParentForm.CurrentBitmap);
            parentForm.Dispose();
        }

        /// <summary>
        /// Resets the main form's bitmap to the original and closes the current dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            mainParentForm.setMainPicture(originalBitmapCount);
            parentForm.Dispose();
        }

        private void presetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String selected = presetsComboBox.SelectedItem.ToString();
                ColorMatrix cMatrix = matrixDict[selected];

                // Get the current bitmap to edit
                previewBitmap = mainParentForm.BitmapList[mainParentForm.CurrentBitmap];
                previewBitmap = mainParentForm.MatrixConvertBitmap(previewBitmap, cMatrix);

                mainParentForm.setTempPicture(previewBitmap);

                iV00.Value = (decimal)cMatrix.Matrix00;
                iV01.Value = (decimal)cMatrix.Matrix01;
                iV02.Value = (decimal)cMatrix.Matrix02;
                iV03.Value = (decimal)cMatrix.Matrix03;
                iV04.Value = (decimal)cMatrix.Matrix04;
                iV10.Value = (decimal)cMatrix.Matrix10;
                iV11.Value = (decimal)cMatrix.Matrix11;
                iV12.Value = (decimal)cMatrix.Matrix12;
                iV13.Value = (decimal)cMatrix.Matrix13;
                iV14.Value = (decimal)cMatrix.Matrix14;
                iV20.Value = (decimal)cMatrix.Matrix20;
                iV21.Value = (decimal)cMatrix.Matrix21;
                iV22.Value = (decimal)cMatrix.Matrix22;
                iV23.Value = (decimal)cMatrix.Matrix23;
                iV24.Value = (decimal)cMatrix.Matrix24;
                iV30.Value = (decimal)cMatrix.Matrix30;
                iV31.Value = (decimal)cMatrix.Matrix31;
                iV32.Value = (decimal)cMatrix.Matrix32;
                iV33.Value = (decimal)cMatrix.Matrix33;
                iV34.Value = (decimal)cMatrix.Matrix34;
                iV40.Value = (decimal)cMatrix.Matrix40;
                iV41.Value = (decimal)cMatrix.Matrix41;
                iV42.Value = (decimal)cMatrix.Matrix42;
                iV43.Value = (decimal)cMatrix.Matrix43;
                iV44.Value = (decimal)cMatrix.Matrix44;
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }   
        }


        /// <summary>
        /// Changing matricies variables whenever a number box's value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion
    }
}
