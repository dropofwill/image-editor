using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace WPF_Image_Editor
{
    /// <summary>
    /// Interaction logic for RGB.xaml
    /// </summary>
    public partial class CustomMatrix : UserControl
    {

        #region fields

        private MainWindow myParentWindow;
        private ColorDialog myColorDialog;
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
                               {   new float[] {0, 0, 1, 0, 0},
                                   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
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
                               {   new float[] {0, 0, 1, 0, 0},
                                   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"Add Contrast", new ColorMatrix(
                               new float[][]
                               {   new float[] {0, 0, 1, 0, 0},
                                   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            },
            {"Remove Contrast", new ColorMatrix(
                               new float[][]
                               {   new float[] {0, 0, 1, 0, 0},
                                   new float[] {1, 0, 0, 0, 0},
                                   new float[] {0, 1, 0, 0, 0},
                                   new float[] {0, 0, 0, 1, 0},
                                   new float[] {0, 0, 0, 0, 1}})
            }
        };

        #endregion

        /// <summary>
        /// RGB Channel modifier control
        /// </summary>
        /// <param name="mPW">A MainWindow</param>
        /// <param name="cD">A ColorDialog that calls the constructor</param>
        public CustomMatrix(MainWindow mPW, ColorDialog cD)
        {
            myParentWindow = mPW;
            myColorDialog = cD;
            InitializeComponent();
            originalBitmapCount = myParentWindow.CurrentBitmap;
            SetComboBox();
        }

        /// <summary>
        /// Loads each matrix's key into the combo box
        /// </summary>
        private void SetComboBox()
        {
            foreach (string key in matrixDict.Keys)
            {
                PresetsComboBox.Items.Add(key);
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

            Console.WriteLine(myParentWindow.CurrentBitmap);
            Console.WriteLine(myParentWindow.BitmapList.Count);

            // Get the current bitmap to edit
            previewBitmap = myParentWindow.BitmapList[myParentWindow.CurrentBitmap];
            
            // Apply the matrix to the bitmap
            previewBitmap = myParentWindow.MatrixConvertBitmap(previewBitmap, cMatrix);

            // Display the bitmap in the main window, add it to BitmapList, and increment the counter
            myParentWindow.addPicture(previewBitmap);
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

            Console.WriteLine(myParentWindow.CurrentBitmap);
            Console.WriteLine(myParentWindow.BitmapList.Count);

            // Get the current bitmap to edit
            previewBitmap = myParentWindow.BitmapList[myParentWindow.CurrentBitmap];

            // Apply the matrix to the bitmap
            previewBitmap = myParentWindow.MatrixConvertBitmap(previewBitmap, cMatrix);
            
            // Display the bitmap temporarily
            myParentWindow.setTempPicture(previewBitmap);
        }

        #region event_handlers

        private void Preview_btn_Click_1(object sender, RoutedEventArgs e)
        {
            setTempBitmap();
        }

        private void Apply_btn_Click_1(object sender, RoutedEventArgs e)
        {
            setMainBitmap();
            myParentWindow.setMainPicture(myParentWindow.CurrentBitmap);
            myColorDialog.Close();
        }

        private void Cancel_btn_Click_1(object sender, RoutedEventArgs e)
        {
            myParentWindow.setMainPicture(originalBitmapCount);
            myColorDialog.Close();
        }

        #endregion

        private void iV00_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v00 = (float)iV00.Value;
        }

        private void iV10_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v10 = (float)iV10.Value;
        }

        private void iV20_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v20 = (float)iV20.Value;
        }

        private void iV30_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v30 = (float)iV30.Value;
        }

        private void iV40_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v40 = (float)iV40.Value;
        }

        private void iV01_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v01 = (float)iV01.Value;
        }

        private void iV11_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v11 = (float)iV11.Value;
        }

        private void iV21_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v21 = (float)iV21.Value;
        }

        private void iV31_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v31 = (float)iV31.Value;
        }

        private void iV41_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v41 = (float)iV41.Value;
        }

        private void iV02_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v02 = (float)iV02.Value;
        }

        private void iV12_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v12 = (float)iV12.Value;
        }

        private void iV22_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v22 = (float)iV22.Value;
        }

        private void iV32_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v32 = (float)iV32.Value;
        }

        private void iV42_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v42 = (float)iV42.Value;
        }

        private void iV03_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v03 = (float)iV03.Value;
        }

        private void iV04_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v04 = (float)iV04.Value;
        }

        private void iV23_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v23 = (float)iV23.Value;
        }

        private void iV33_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v33 = (float)iV33.Value;
        }

        private void iV13_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v13 = (float)iV13.Value;
        }

        private void iV43_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v43 = (float)iV43.Value;
        }

        private void iV14_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v14 = (float)iV14.Value;
        }

        private void iV24_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v24 = (float)iV24.Value;
        }

        private void iV34_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v34 = (float)iV34.Value;
        }

        private void iV44_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            v44 = (float)iV44.Value;
        }
    }
}
