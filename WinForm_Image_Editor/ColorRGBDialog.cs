using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Image_Editor
{
    public partial class ColorRGBDialog : Form
    {
        private Image_Editor_Main parentForm;
        private String typeOfControl;
        private ColorRGBControl myColorRGBControl;
        private ColorBSLControl myColorBSLControl;
        private CustomGreyControl myCustomGreyControl;
        private CustomMatrixControl myCustomMatrixControl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pf">Current Form</param>
        /// <param name="tOC">Accepted Values "ColorRGB", "ColorBSL", "CustomGrey", "CustomMatrix"</param>
        public ColorRGBDialog(Image_Editor_Main pf, String tOC)
        {
            parentForm = pf;
            typeOfControl = tOC;
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            if (typeOfControl == "ColorRGB")
            {
                CreateColorRGB();
                this.ClientSize = new Size(myColorRGBControl.Width + 26, myColorRGBControl.Height + 26);
                this.Text = "Red, Green, and Blue Channel Modifier";
            }
            else if (typeOfControl == "ColorBSL")
            {
                CreateColorBSL();
                this.ClientSize = new Size(myColorBSLControl.Width + 26, myColorBSLControl.Height + 26);
                this.Text = "Brightness, Saturation, and Contrast Modifier";
            }
            else if (typeOfControl == "CustomGrey")
            {
                CreateCustomGrey();
                this.ClientSize = new Size(myCustomGreyControl.Width + 26, myCustomGreyControl.Height + 26);
                this.Text = "Custom Grayscale Filter";
            }
            else if (typeOfControl == "CustomMatrix")
            {
                CreateCustomMatrix();
                this.ClientSize = new Size(myCustomMatrixControl.Width + 26, myCustomMatrixControl.Height + 26);
                this.Text = "Custom Color Matrix Transform";
            }
        }

        private void CreateColorBSL()
        {
            this.myColorBSLControl = new WinForm_Image_Editor.ColorBSLControl(parentForm, this);
            this.myColorBSLControl.Location = new System.Drawing.Point(13, 13);
            this.myColorBSLControl.Name = "Custom BSL Control";
            this.myColorBSLControl.Size = new System.Drawing.Size(380, 550);
            this.myColorBSLControl.TabIndex = 0;
            this.Controls.Add(this.myColorBSLControl);
        }

        private void CreateColorRGB()
        {
            this.myColorRGBControl = new WinForm_Image_Editor.ColorRGBControl(parentForm, this);
            this.myColorRGBControl.Location = new System.Drawing.Point(13, 13);
            this.myColorRGBControl.Name = "Custom RGBControl";
            this.myColorRGBControl.Size = new System.Drawing.Size(378, 362);
            this.myColorRGBControl.TabIndex = 0;
            this.Controls.Add(this.myColorRGBControl);
        }

        private void CreateCustomGrey()
        {
            this.myCustomGreyControl = new WinForm_Image_Editor.CustomGreyControl(parentForm, this);
            this.myCustomGreyControl.Location = new System.Drawing.Point(13, 13);
            this.myCustomGreyControl.Name = "Custom Grey Control";
            this.myCustomGreyControl.Size = new System.Drawing.Size(378, 362);
            this.myCustomGreyControl.TabIndex = 0;
            this.Controls.Add(this.myCustomGreyControl);
        }

        private void CreateCustomMatrix()
        {
            this.myCustomMatrixControl = new WinForm_Image_Editor.CustomMatrixControl(parentForm, this);
            this.myCustomMatrixControl.Location = new System.Drawing.Point(13, 13);
            this.myCustomMatrixControl.Name = "Custom Matrix Control";
            this.myCustomMatrixControl.Size = new System.Drawing.Size(378, 362);
            this.myCustomMatrixControl.TabIndex = 0;
            this.Controls.Add(this.myCustomMatrixControl);
        }
    }
}
