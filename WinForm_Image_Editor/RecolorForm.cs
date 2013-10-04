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
    public partial class RecolorForm : Form
    {
        private Image_Editor_Main parentForm;

        public RecolorForm(Image_Editor_Main pF)
        {
            parentForm = pF;
            InitializeComponent();
        }
    }
}
