namespace FirewatchFOVChanger
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tbFOV = new System.Windows.Forms.TrackBar();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.lbFOV = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbFOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFOV
            // 
            this.tbFOV.Location = new System.Drawing.Point(45, 126);
            this.tbFOV.Maximum = 666;
            this.tbFOV.Minimum = 1;
            this.tbFOV.Name = "tbFOV";
            this.tbFOV.Size = new System.Drawing.Size(277, 45);
            this.tbFOV.TabIndex = 0;
            this.tbFOV.Value = 1;
            this.tbFOV.ValueChanged += new System.EventHandler(this.tbFOV_ValueChanged);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.Location = new System.Drawing.Point(267, 167);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 30);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDefault.Location = new System.Drawing.Point(17, 167);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(100, 30);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // lbFOV
            // 
            this.lbFOV.AutoSize = true;
            this.lbFOV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFOV.Location = new System.Drawing.Point(162, 172);
            this.lbFOV.Name = "lbFOV";
            this.lbFOV.Size = new System.Drawing.Size(58, 21);
            this.lbFOV.TabIndex = 3;
            this.lbFOV.Text = "FOV: 0";
            this.lbFOV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMin.Location = new System.Drawing.Point(12, 126);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(37, 21);
            this.lbMin.TabIndex = 5;
            this.lbMin.Text = "Min";
            this.lbMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMax.Location = new System.Drawing.Point(328, 126);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(39, 21);
            this.lbMax.TabIndex = 6;
            this.lbMax.Text = "Max";
            this.lbMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbLogo.Image = global::FirewatchFOVChanger.Properties.Resources.Banner;
            this.pbLogo.Location = new System.Drawing.Point(17, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(350, 98);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.lbFOV);
            this.Controls.Add(this.tbFOV);
            this.Controls.Add(this.lbMax);
            this.Controls.Add(this.lbMin);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firewatch FOV Changer";
            ((System.ComponentModel.ISupportInitialize)(this.tbFOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbFOV;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Label lbFOV;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbMax;
    }
}

