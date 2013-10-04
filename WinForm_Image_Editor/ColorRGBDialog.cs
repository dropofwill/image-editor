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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pf">Current Form</param>
        /// <param name="tOC">Accepted Values "ColorRGB", "ColorBSL"</param>
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
            }
            else if (typeOfControl == "ColorBSL")
            {
                CreateColorBSL();
            }
        }

        private void CreateColorBSL()
        {
            this.myColorBSLControl = new WinForm_Image_Editor.ColorBSLControl(parentForm, this);
            this.myColorBSLControl.Location = new System.Drawing.Point(5, 5);
            this.myColorBSLControl.Name = "recolor1";
            this.myColorBSLControl.Size = new System.Drawing.Size(380, 550);
            this.myColorBSLControl.TabIndex = 0;
            this.Controls.Add(this.myColorBSLControl);
        }

        private void CreateColorRGB()
        {
            this.myColorRGBControl = new WinForm_Image_Editor.ColorRGBControl(parentForm, this);
            this.myColorRGBControl.Location = new System.Drawing.Point(13, 13);
            this.myColorRGBControl.Name = "recolor1";
            this.myColorRGBControl.Size = new System.Drawing.Size(378, 362);
            this.myColorRGBControl.TabIndex = 0;
            this.Controls.Add(this.myColorRGBControl);
        }
    }
}
