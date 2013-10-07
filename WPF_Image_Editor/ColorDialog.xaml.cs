using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPF_Image_Editor
{
    /// <summary>
    /// Interaction logic for ColorDialog.xaml
    /// </summary>
    public partial class ColorDialog : Window
    {
        private MainWindow myParentWindow;
        private String controlType;
        private RGB rgbControl;

        public ColorDialog(MainWindow parentWindow, String cT)
        {
            myParentWindow = parentWindow;
            controlType = cT;

            InitializeComponent();
            InitControl();
            //this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void InitControl()
        {
            if (controlType == "RGB")
            {
                CreateRGB();
                this.Title = "Red, Green, and Blue Channel Modifier";
            }
            else if (controlType == "BSC")
            {
                //CreateColorBSL();
                //this.ClientSize = new Size(myColorBSLControl.Width + 26, myColorBSLControl.Height + 26);
                this.Title = "Brightness, Saturation, and Contrast Modifier";
            }
            else if (controlType == "Grey")
            {
                //CreateCustomGrey();
                //this.ClientSize = new Size(myCustomGreyControl.Width + 26, myCustomGreyControl.Height + 26);
                this.Title = "Custom Grayscale Filter";
            }
            else if (controlType == "Matrix")
            {
                //CreateCustomMatrix();
                //this.ClientSize = new Size(myCustomMatrixControl.Width + 26, myCustomMatrixControl.Height + 26);
                this.Title = "Custom Color Matrix Transform";
            }
        }

        private void CreateRGB()
        {
            rgbControl = new WPF_Image_Editor.RGB();
            this.Content = rgbControl;
        }
    }
}
