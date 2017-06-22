namespace FirewatchFOVChanger
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fovLabel = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.defaultButton = new System.Windows.Forms.Button();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.fovUpDown = new System.Windows.Forms.NumericUpDown();
            this.fovTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // fovLabel
            // 
            this.fovLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fovLabel.Location = new System.Drawing.Point(93, 172);
            this.fovLabel.Name = "fovLabel";
            this.fovLabel.Size = new System.Drawing.Size(133, 13);
            this.fovLabel.TabIndex = 7;
            this.fovLabel.Text = "Current FOV: ?? -->";
            this.fovLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbLogo.Image = global::FirewatchFOVChanger.Properties.Resources.Banner;
            this.pbLogo.Location = new System.Drawing.Point(12, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(350, 98);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // defaultButton
            // 
            this.defaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.defaultButton.Location = new System.Drawing.Point(12, 167);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(75, 23);
            this.defaultButton.TabIndex = 8;
            this.defaultButton.Text = "Default";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(12, 148);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(23, 13);
            this.minLabel.TabIndex = 9;
            this.minLabel.Text = "min";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(336, 148);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(26, 13);
            this.maxLabel.TabIndex = 9;
            this.maxLabel.Text = "max";
            this.maxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(287, 167);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 10;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // fovUpDown
            // 
            this.fovUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fovUpDown.Location = new System.Drawing.Point(232, 170);
            this.fovUpDown.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.fovUpDown.Minimum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.fovUpDown.Name = "fovUpDown";
            this.fovUpDown.Size = new System.Drawing.Size(49, 20);
            this.fovUpDown.TabIndex = 11;
            this.fovUpDown.Value = new decimal(new int[] {
            55,
            0,
            0,
            0});
            // 
            // fovTrackBar
            // 
            this.fovTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fovTrackBar.Location = new System.Drawing.Point(12, 116);
            this.fovTrackBar.Maximum = 110;
            this.fovTrackBar.Minimum = 55;
            this.fovTrackBar.Name = "fovTrackBar";
            this.fovTrackBar.Size = new System.Drawing.Size(350, 45);
            this.fovTrackBar.TabIndex = 12;
            this.fovTrackBar.Value = 55;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 202);
            this.Controls.Add(this.fovUpDown);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.defaultButton);
            this.Controls.Add(this.fovLabel);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.fovTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Firewatch FOV Changer";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.NumericUpDown fovUpDown;
        private System.Windows.Forms.TrackBar fovTrackBar;
        private System.Windows.Forms.Label fovLabel;
    }
}

