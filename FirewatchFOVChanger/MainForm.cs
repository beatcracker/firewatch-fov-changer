using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FirewatchFOVChanger
{
    public partial class MainForm : Form
    {
        const float CURTAIN_MAX_W = 90; // px
        const float CURTAIN_MAX_H = 8;  // px
        const int CURTAIN_MAX_A = 150;  // 0 = transparent, 255 = solid
        readonly Color CURTAIN_TOP_COLOR = Color.Orange;
        readonly Color CURTAIN_BOT_COLOR = Color.Black;
        readonly LinearGradientBrush CURTAIN_BRUSH;
        readonly Pen REGFOV_BOUNDS_PEN = new Pen(Color.Black) { DashStyle = DashStyle.Dot};

        Property<int> fov = new Property<int>();
        RegistryFov regFov = new RegistryFov();
        int cachedRegFov = -1;

        public MainForm()
        {
            InitializeComponent();

            fovUpDown.Minimum =
                fovTrackBar.Minimum = RegistryFov.MIN_VALUE;
            fovUpDown.Maximum =
                fovTrackBar.Maximum = RegistryFov.MAX_VALUE;

            minLabel.Text = RegistryFov.MIN_VALUE.ToString();
            maxLabel.Text = RegistryFov.MAX_VALUE.ToString();

            #region Model-View Bindings
            fovTrackBar.DataBindings.Add(
                new Binding( "Value",
                    fov, Property<int>.VALUE_NAME,
                    false, DataSourceUpdateMode.OnPropertyChanged));

            fovUpDown.DataBindings.Add(
                new Binding( "Value",
                    fov, Property<int>.VALUE_NAME,
                    false, DataSourceUpdateMode.OnPropertyChanged));

            Binding b = new Binding( "Text", regFov, RegistryFov.VALUE_NAME);
            b.Format +=
                (s, e) => {
                    e.Value = $"FOV: { regFov.Value }";
                };
            fovLabel.DataBindings.Add(b);

            fov.PropertyChanged +=
                (s, ea) => {
                    defaultButton.Enabled = (fov.Value) != RegistryFov.DEFAULT;
                    pbLogo.Invalidate();
                };

            regFov.PropertyChanged +=
                (s, ea) => {
                    cachedRegFov = regFov.Value;
                };
            #endregion

            cachedRegFov =
                fov.Value = regFov.Value;

            CURTAIN_BRUSH = new LinearGradientBrush(
                new RectangleF(
                    0, 0,
                    CURTAIN_MAX_W, pbLogo.Height),
                Color.FromArgb(CURTAIN_MAX_A, CURTAIN_TOP_COLOR),
                Color.FromArgb(CURTAIN_MAX_A, CURTAIN_BOT_COLOR),
                LinearGradientMode.Vertical)
                { GammaCorrection = true };
        } // ctor

        private void defaultButton_Click(object sender, EventArgs e)
        {
            regFov.Value = 
                fov.Value = RegistryFov.DEFAULT;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            regFov.Value = fov.Value;
            pbLogo.Invalidate();
        }

        private void pbLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            float wx = ScaleToCurtainWidth(fov.Value);

            RectangleF rect =
                new RectangleF(
                    0, 0,
                    wx, pbLogo.Height);

            // Left curtain
            g.FillRectangle(CURTAIN_BRUSH, rect);

            // Right curtain
            rect.X = pbLogo.Width - wx;
            g.FillRectangle(CURTAIN_BRUSH, rect);

            // Current FOV bounds
            if (fov.Value != cachedRegFov)
            {
                wx = ScaleToCurtainWidth(cachedRegFov);

                g.DrawLine(
                    REGFOV_BOUNDS_PEN,
                    wx, 0,
                    wx, pbLogo.Height);
                g.DrawLine(
                    REGFOV_BOUNDS_PEN,
                    pbLogo.Width - wx, 0,
                    pbLogo.Width - wx, pbLogo.Height);
            }
        } // pbLogo_Paint()

        float ScaleToCurtainWidth(int currentFov)
        {
            return (1f - (currentFov - RegistryFov.MIN_VALUE) / (float)RegistryFov.MIN_VALUE) * CURTAIN_MAX_W;
            //float kx = 1f - (currentFov - RegistryFov.MIN_VALUE) / (float)RegistryFov.MIN_VALUE;
            //float wx = CURTAIN_MAX_W * kx;
        }
    } // class
}