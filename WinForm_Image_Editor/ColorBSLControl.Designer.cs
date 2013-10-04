namespace WinForm_Image_Editor
{
    partial class ColorBSLControl
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
            this.brightTrackBar = new System.Windows.Forms.TrackBar();
            this.brightLabel = new System.Windows.Forms.Label();
            this.satLabel = new System.Windows.Forms.Label();
            this.satTrackBar = new System.Windows.Forms.TrackBar();
            this.conLabel = new System.Windows.Forms.Label();
            this.conTrackBar = new System.Windows.Forms.TrackBar();
            this.preview_btn = new System.Windows.Forms.Button();
            this.apply_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.brightValue = new System.Windows.Forms.Label();
            this.satValue = new System.Windows.Forms.Label();
            this.conValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // brightTrackBar
            // 
            this.brightTrackBar.Location = new System.Drawing.Point(19, 46);
            this.brightTrackBar.Maximum = 100;
            this.brightTrackBar.Name = "brightTrackBar";
            this.brightTrackBar.Size = new System.Drawing.Size(317, 45);
            this.brightTrackBar.SmallChange = 10;
            this.brightTrackBar.TabIndex = 0;
            this.brightTrackBar.TickFrequency = 10;
            this.brightTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.brightTrackBar.Scroll += new System.EventHandler(this.redTrackBar_Scroll);
            // 
            // brightLabel
            // 
            this.brightLabel.AutoSize = true;
            this.brightLabel.Location = new System.Drawing.Point(28, 30);
            this.brightLabel.Name = "brightLabel";
            this.brightLabel.Size = new System.Drawing.Size(56, 13);
            this.brightLabel.TabIndex = 3;
            this.brightLabel.Text = "Brightness";
            // 
            // satLabel
            // 
            this.satLabel.AutoSize = true;
            this.satLabel.Location = new System.Drawing.Point(28, 123);
            this.satLabel.Name = "satLabel";
            this.satLabel.Size = new System.Drawing.Size(55, 13);
            this.satLabel.TabIndex = 5;
            this.satLabel.Text = "Saturation";
            // 
            // satTrackBar
            // 
            this.satTrackBar.Location = new System.Drawing.Point(19, 139);
            this.satTrackBar.Maximum = 100;
            this.satTrackBar.Name = "satTrackBar";
            this.satTrackBar.Size = new System.Drawing.Size(317, 45);
            this.satTrackBar.SmallChange = 10;
            this.satTrackBar.TabIndex = 4;
            this.satTrackBar.TickFrequency = 10;
            this.satTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.satTrackBar.Scroll += new System.EventHandler(this.greenTrackBar_Scroll);
            // 
            // conLabel
            // 
            this.conLabel.AutoSize = true;
            this.conLabel.Location = new System.Drawing.Point(28, 219);
            this.conLabel.Name = "conLabel";
            this.conLabel.Size = new System.Drawing.Size(46, 13);
            this.conLabel.TabIndex = 7;
            this.conLabel.Text = "Contrast";
            // 
            // conTrackBar
            // 
            this.conTrackBar.Location = new System.Drawing.Point(19, 235);
            this.conTrackBar.Maximum = 100;
            this.conTrackBar.Name = "conTrackBar";
            this.conTrackBar.Size = new System.Drawing.Size(317, 45);
            this.conTrackBar.SmallChange = 10;
            this.conTrackBar.TabIndex = 6;
            this.conTrackBar.TickFrequency = 10;
            this.conTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.conTrackBar.Scroll += new System.EventHandler(this.blueTrackBar_Scroll);
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
            // brightValue
            // 
            this.brightValue.AutoSize = true;
            this.brightValue.Location = new System.Drawing.Point(323, 30);
            this.brightValue.Name = "brightValue";
            this.brightValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.brightValue.Size = new System.Drawing.Size(13, 13);
            this.brightValue.TabIndex = 11;
            this.brightValue.Text = "0";
            this.brightValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // satValue
            // 
            this.satValue.AutoSize = true;
            this.satValue.Location = new System.Drawing.Point(323, 123);
            this.satValue.Name = "satValue";
            this.satValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.satValue.Size = new System.Drawing.Size(13, 13);
            this.satValue.TabIndex = 12;
            this.satValue.Text = "0";
            this.satValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // conValue
            // 
            this.conValue.AutoSize = true;
            this.conValue.Location = new System.Drawing.Point(323, 219);
            this.conValue.Name = "conValue";
            this.conValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.conValue.Size = new System.Drawing.Size(13, 13);
            this.conValue.TabIndex = 13;
            this.conValue.Text = "0";
            this.conValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ColorBSLControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.conValue);
            this.Controls.Add(this.satValue);
            this.Controls.Add(this.brightValue);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.preview_btn);
            this.Controls.Add(this.conLabel);
            this.Controls.Add(this.conTrackBar);
            this.Controls.Add(this.satLabel);
            this.Controls.Add(this.satTrackBar);
            this.Controls.Add(this.brightLabel);
            this.Controls.Add(this.brightTrackBar);
            this.Name = "ColorBSLControl";
            this.Size = new System.Drawing.Size(378, 362);
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar brightTrackBar;
        private System.Windows.Forms.Label brightLabel;
        private System.Windows.Forms.Label satLabel;
        private System.Windows.Forms.TrackBar satTrackBar;
        private System.Windows.Forms.Label conLabel;
        private System.Windows.Forms.TrackBar conTrackBar;
        private System.Windows.Forms.Button preview_btn;
        private System.Windows.Forms.Button apply_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label brightValue;
        private System.Windows.Forms.Label satValue;
        private System.Windows.Forms.Label conValue;
    }
}
