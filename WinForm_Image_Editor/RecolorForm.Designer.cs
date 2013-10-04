namespace WinForm_Image_Editor
{
    partial class RecolorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recolor1 = new WinForm_Image_Editor.Recolor(parentForm);
            this.SuspendLayout();
            // 
            // recolor1
            // 
            this.recolor1.Location = new System.Drawing.Point(13, 13);
            this.recolor1.Name = "recolor1";
            this.recolor1.Size = new System.Drawing.Size(378, 362);
            this.recolor1.TabIndex = 0;
            // 
            // RecolorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 384);
            this.Controls.Add(this.recolor1);
            this.Name = "RecolorForm";
            this.Text = "Recolor Image";
            this.ResumeLayout(false);

        }

        #endregion

        private Recolor recolor1;
    }
}