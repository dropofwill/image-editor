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

namespace WPF_Image_Editor
{
    /// <summary>
    /// Interaction logic for RGB.xaml
    /// </summary>
    public partial class GreyCustom : UserControl
    {
        private MainWindow myParentWindow;
        private ColorDialog myColorDialog;
        private int originalBitmapCount = new int();
        private Bitmap previewBitmap;

        private float redV = 0.22f;
        private float greenV = 0.59f;
        private float blueV = 0.11f;

        /// <summary>
        /// RGB Channel modifier control
        /// </summary>
        /// <param name="mPW">A MainWindow</param>
        /// <param name="cD">A ColorDialog that calls the constructor</param>
        public GreyCustom(MainWindow mPW, ColorDialog cD)
        {
            myParentWindow = mPW;
            myColorDialog = cD;
            InitializeComponent();
            originalBitmapCount = myParentWindow.CurrentBitmap;
        }

        /// <summary>
        /// Creates a color matrix offset by the parameters for each channel
        /// </summary>
        /// <param name="rV">Red float, generally from -1 to 1</param>
        /// <param name="gV">Green float, generally from -1 to 1</param>
        /// <param name="bV">Blue float, generally from -1 to 1</param>
        /// <returns>A color matrix with the channels offset by the parameter values</returns>
        private ColorMatrix createColorMatrix(float rV, float gV, float bV)
        {
            ColorMatrix cMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {rV, rV, rV, 0, 0},
                    new float[] {gV, gV, gV, 0, 0},
                    new float[] {bV, bV, bV, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
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
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);

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
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);

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


        private void RedSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                RedValue.Content = redV;
            }
            catch
            {
            }
            //redV = ((float)RedSlider.Value / (float)100);
            //RedValue.Content = "" + redV;
        }

        private void BlueSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                BlueValue.Content = blueV;
            }
            catch
            { 
            }
            //blueV = ((float)BlueSlider.Value / (float)100);
            //BlueValue.Content = "" + blueV;
        }

        private void GreenSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                GreenValue.Content = greenV;
            }
            catch
            {
            }
            //greenV = ((float)GreenSlider.Value / (float)100);
            //GreenValue.Content = greenV;
        }

        #endregion
    }
}
