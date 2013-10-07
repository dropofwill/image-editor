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
    public partial class RGB : UserControl
    {
        private MainWindow myParentWindow;
        private ColorDialog myColorDialog;
        private int originalBitmapCount;
        private float redV;
        private float greenV;
        private float blueV;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mPW">A MainWindow</param>
        /// <param name="cD">A ColorDialog that calls the constructor</param>
        public RGB(MainWindow mPW, ColorDialog cD)
        {
            originalBitmapCount = myParentWindow.CurrentBitmap;
            myParentWindow = mPW;
            myColorDialog = cD;
            InitializeComponent();
        }

        private void RedSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            redV = ((float)RedSlider.Value / (float)100);
            RedValue.Content = "" + redV;
        }

        private void BlueSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blueV = ((float)BlueSlider.Value / (float)100);
            BlueValue.Content = "" + blueV;
        }

        private void GreenSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            greenV = ((float)GreenSlider.Value / (float)100);
            GreenValue.Content = "" + greenV;
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


        private void setMainBitmap()
        {
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);;
            previewBitmap = myParentWindow.MatrixConvertBitmap(previewBitmap, cMatrix);

            mainParentForm.setMainPicture(previewBitmap);
        }


        private void Preview_btn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Apply_btn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_btn_Click_1(object sender, RoutedEventArgs e)
        {

        }


    }
}
