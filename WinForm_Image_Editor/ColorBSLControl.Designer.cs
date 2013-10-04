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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.redGroupBox = new System.Windows.Forms.GroupBox();
            this.highRed = new System.Windows.Forms.RadioButton();
            this.lowRed = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lowBlue = new System.Windows.Forms.RadioButton();
            this.highBlue = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lowGreen = new System.Windows.Forms.RadioButton();
            this.highGreen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.redGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // brightTrackBar
            // 
            this.brightTrackBar.Location = new System.Drawing.Point(19, 46);
            this.brightTrackBar.Maximum = 100;
            this.brightTrackBar.Minimum = -100;
            this.brightTrackBar.Name = "brightTrackBar";
            this.brightTrackBar.Size = new System.Drawing.Size(317, 45);
            this.brightTrackBar.SmallChange = 10;
            this.brightTrackBar.TabIndex = 0;
            this.brightTrackBar.TickFrequency = 10;
            this.brightTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.brightTrackBar.Scroll += new System.EventHandler(this.brightTrackBar_Scroll);
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
            this.satLabel.Location = new System.Drawing.Point(31, 239);
            this.satLabel.Name = "satLabel";
            this.satLabel.Size = new System.Drawing.Size(55, 13);
            this.satLabel.TabIndex = 5;
            this.satLabel.Text = "Saturation";
            // 
            // satTrackBar
            // 
            this.satTrackBar.Location = new System.Drawing.Point(22, 255);
            this.satTrackBar.Maximum = 1000;
            this.satTrackBar.Name = "satTrackBar";
            this.satTrackBar.Size = new System.Drawing.Size(317, 45);
            this.satTrackBar.SmallChange = 10;
            this.satTrackBar.TabIndex = 4;
            this.satTrackBar.TickFrequency = 100;
            this.satTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.satTrackBar.Scroll += new System.EventHandler(this.satTrackBar_Scroll);
            // 
            // conLabel
            // 
            this.conLabel.AutoSize = true;
            this.conLabel.Location = new System.Drawing.Point(28, 135);
            this.conLabel.Name = "conLabel";
            this.conLabel.Size = new System.Drawing.Size(46, 13);
            this.conLabel.TabIndex = 7;
            this.conLabel.Text = "Contrast";
            // 
            // conTrackBar
            // 
            this.conTrackBar.Location = new System.Drawing.Point(19, 151);
            this.conTrackBar.Maximum = 1000;
            this.conTrackBar.Name = "conTrackBar";
            this.conTrackBar.Size = new System.Drawing.Size(317, 45);
            this.conTrackBar.SmallChange = 10;
            this.conTrackBar.TabIndex = 6;
            this.conTrackBar.TickFrequency = 50;
            this.conTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.conTrackBar.Value = 100;
            this.conTrackBar.Scroll += new System.EventHandler(this.conTrackBar_Scroll);
            // 
            // preview_btn
            // 
            this.preview_btn.Location = new System.Drawing.Point(22, 505);
            this.preview_btn.Name = "preview_btn";
            this.preview_btn.Size = new System.Drawing.Size(75, 23);
            this.preview_btn.TabIndex = 8;
            this.preview_btn.Text = "Preview";
            this.preview_btn.UseVisualStyleBackColor = true;
            this.preview_btn.Click += new System.EventHandler(this.preview_btn_Click);
            // 
            // apply_btn
            // 
            this.apply_btn.Location = new System.Drawing.Point(264, 505);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(75, 23);
            this.apply_btn.TabIndex = 9;
            this.apply_btn.Text = "Apply";
            this.apply_btn.UseVisualStyleBackColor = true;
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(183, 505);
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
            this.satValue.Location = new System.Drawing.Point(326, 239);
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
            this.conValue.Location = new System.Drawing.Point(323, 135);
            this.conValue.Name = "conValue";
            this.conValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.conValue.Size = new System.Drawing.Size(13, 13);
            this.conValue.TabIndex = 13;
            this.conValue.Text = "1";
            this.conValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.redGroupBox);
            this.groupBox1.Location = new System.Drawing.Point(19, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 158);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saturation Luminance Settings:";
            // 
            // redGroupBox
            // 
            this.redGroupBox.Controls.Add(this.lowRed);
            this.redGroupBox.Controls.Add(this.highRed);
            this.redGroupBox.Location = new System.Drawing.Point(6, 19);
            this.redGroupBox.Name = "redGroupBox";
            this.redGroupBox.Size = new System.Drawing.Size(314, 38);
            this.redGroupBox.TabIndex = 0;
            this.redGroupBox.TabStop = false;
            // 
            // highRed
            // 
            this.highRed.AutoSize = true;
            this.highRed.Checked = true;
            this.highRed.Location = new System.Drawing.Point(3, 15);
            this.highRed.Name = "highRed";
            this.highRed.Size = new System.Drawing.Size(125, 17);
            this.highRed.TabIndex = 0;
            this.highRed.TabStop = true;
            this.highRed.Text = "High Red Luminance";
            this.highRed.UseVisualStyleBackColor = true;
            // 
            // lowRed
            // 
            this.lowRed.AutoSize = true;
            this.lowRed.Location = new System.Drawing.Point(145, 15);
            this.lowRed.Name = "lowRed";
            this.lowRed.Size = new System.Drawing.Size(123, 17);
            this.lowRed.TabIndex = 1;
            this.lowRed.TabStop = true;
            this.lowRed.Text = "Low Red Luminance";
            this.lowRed.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lowBlue);
            this.groupBox2.Controls.Add(this.highBlue);
            this.groupBox2.Location = new System.Drawing.Point(3, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 38);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lowBlue
            // 
            this.lowBlue.AutoSize = true;
            this.lowBlue.Location = new System.Drawing.Point(145, 15);
            this.lowBlue.Name = "lowBlue";
            this.lowBlue.Size = new System.Drawing.Size(124, 17);
            this.lowBlue.TabIndex = 1;
            this.lowBlue.TabStop = true;
            this.lowBlue.Text = "Low Blue Luminance";
            this.lowBlue.UseVisualStyleBackColor = true;
            // 
            // highBlue
            // 
            this.highBlue.AutoSize = true;
            this.highBlue.Checked = true;
            this.highBlue.Location = new System.Drawing.Point(3, 15);
            this.highBlue.Name = "highBlue";
            this.highBlue.Size = new System.Drawing.Size(126, 17);
            this.highBlue.TabIndex = 0;
            this.highBlue.TabStop = true;
            this.highBlue.Text = "High Blue Luminance";
            this.highBlue.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lowGreen);
            this.groupBox3.Controls.Add(this.highGreen);
            this.groupBox3.Location = new System.Drawing.Point(3, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 38);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lowGreen
            // 
            this.lowGreen.AutoSize = true;
            this.lowGreen.Location = new System.Drawing.Point(145, 15);
            this.lowGreen.Name = "lowGreen";
            this.lowGreen.Size = new System.Drawing.Size(132, 17);
            this.lowGreen.TabIndex = 1;
            this.lowGreen.TabStop = true;
            this.lowGreen.Text = "Low Green Luminance";
            this.lowGreen.UseVisualStyleBackColor = true;
            // 
            // highGreen
            // 
            this.highGreen.AutoSize = true;
            this.highGreen.Checked = true;
            this.highGreen.Location = new System.Drawing.Point(3, 15);
            this.highGreen.Name = "highGreen";
            this.highGreen.Size = new System.Drawing.Size(134, 17);
            this.highGreen.TabIndex = 0;
            this.highGreen.TabStop = true;
            this.highGreen.Text = "High Green Luminance";
            this.highGreen.UseVisualStyleBackColor = true;
            // 
            // ColorBSLControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
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
            this.Size = new System.Drawing.Size(380, 550);
            ((System.ComponentModel.ISupportInitialize)(this.brightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.redGroupBox.ResumeLayout(false);
            this.redGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton lowGreen;
        private System.Windows.Forms.RadioButton highGreen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton lowBlue;
        private System.Windows.Forms.RadioButton highBlue;
        private System.Windows.Forms.GroupBox redGroupBox;
        private System.Windows.Forms.RadioButton lowRed;
        private System.Windows.Forms.RadioButton highRed;
    }
}
