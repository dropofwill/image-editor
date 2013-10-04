namespace WinForm_Image_Editor
{
    partial class CustomGreyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.blueLabel = new System.Windows.Forms.Label();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.preview_btn = new System.Windows.Forms.Button();
            this.apply_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.redValue = new System.Windows.Forms.Label();
            this.greenValue = new System.Windows.Forms.Label();
            this.blueValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // redTrackBar
            // 
            this.redTrackBar.Location = new System.Drawing.Point(19, 46);
            this.redTrackBar.Maximum = 100;
            this.redTrackBar.Minimum = -100;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(317, 45);
            this.redTrackBar.SmallChange = 10;
            this.redTrackBar.TabIndex = 0;
            this.redTrackBar.TickFrequency = 10;
            this.redTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.redTrackBar.Value = 22;
            this.redTrackBar.Scroll += new System.EventHandler(this.redTrackBar_Scroll);
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(28, 30);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(27, 13);
            this.redLabel.TabIndex = 3;
            this.redLabel.Text = "Red";
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(28, 123);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(36, 13);
            this.greenLabel.TabIndex = 5;
            this.greenLabel.Text = "Green";
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Location = new System.Drawing.Point(19, 139);
            this.greenTrackBar.Maximum = 100;
            this.greenTrackBar.Minimum = -100;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(317, 45);
            this.greenTrackBar.SmallChange = 10;
            this.greenTrackBar.TabIndex = 4;
            this.greenTrackBar.TickFrequency = 10;
            this.greenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.greenTrackBar.Value = 59;
            this.greenTrackBar.Scroll += new System.EventHandler(this.greenTrackBar_Scroll);
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(28, 219);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(28, 13);
            this.blueLabel.TabIndex = 7;
            this.blueLabel.Text = "Blue";
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Location = new System.Drawing.Point(19, 235);
            this.blueTrackBar.Maximum = 100;
            this.blueTrackBar.Minimum = -100;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(317, 45);
            this.blueTrackBar.SmallChange = 10;
            this.blueTrackBar.TabIndex = 6;
            this.blueTrackBar.TickFrequency = 10;
            this.blueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.blueTrackBar.Value = 11;
            this.blueTrackBar.Scroll += new System.EventHandler(this.blueTrackBar_Scroll);
            // 
            // preview_btn
            // 
            this.preview_btn.Location = new System.Drawing.Point(19, 319);
            this.preview_btn.Name = "preview_btn";
            this.preview_btn.Size = new System.Drawing.Size(75, 23);
            this.preview_btn.TabIndex = 8;
            this.preview_btn.Text = "Preview";
            this.preview_btn.UseVisualStyleBackColor = true;
            this.preview_btn.Click += new System.EventHandler(this.preview_btn_Click);
            // 
            // apply_btn
            // 
            this.apply_btn.Location = new System.Drawing.Point(261, 319);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(75, 23);
            this.apply_btn.TabIndex = 9;
            this.apply_btn.Text = "Apply";
            this.apply_btn.UseVisualStyleBackColor = true;
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(180, 319);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 10;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // redValue
            // 
            this.redValue.AutoSize = true;
            this.redValue.Location = new System.Drawing.Point(323, 30);
            this.redValue.Name = "redValue";
            this.redValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.redValue.Size = new System.Drawing.Size(28, 13);
            this.redValue.TabIndex = 11;
            this.redValue.Text = "0.22";
            this.redValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // greenValue
            // 
            this.greenValue.AutoSize = true;
            this.greenValue.Location = new System.Drawing.Point(323, 123);
            this.greenValue.Name = "greenValue";
            this.greenValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.greenValue.Size = new System.Drawing.Size(28, 13);
            this.greenValue.TabIndex = 12;
            this.greenValue.Text = "0.59";
            this.greenValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // blueValue
            // 
            this.blueValue.AutoSize = true;
            this.blueValue.Location = new System.Drawing.Point(323, 219);
            this.blueValue.Name = "blueValue";
            this.blueValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.blueValue.Size = new System.Drawing.Size(28, 13);
            this.blueValue.TabIndex = 13;
            this.blueValue.Text = "0.11";
            this.blueValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CustomGreyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.blueValue);
            this.Controls.Add(this.greenValue);
            this.Controls.Add(this.redValue);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.preview_btn);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.blueTrackBar);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.greenTrackBar);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.redTrackBar);
            this.Name = "CustomGreyControl";
            this.Size = new System.Drawing.Size(378, 362);
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.Button preview_btn;
        private System.Windows.Forms.Button apply_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label redValue;
        private System.Windows.Forms.Label greenValue;
        private System.Windows.Forms.Label blueValue;
    }
}
