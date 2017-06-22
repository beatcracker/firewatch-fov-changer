using System;
using System.Windows.Forms;

namespace FirewatchFOVChanger
{
    public partial class MainForm : Form
    {
        FOV fov = new FOV();

        public MainForm()
        {
            InitializeComponent();

            fovUpDown.Minimum =
                fovTrackBar.Minimum = FOV.DEFAULT;
            fovUpDown.Maximum =
                fovTrackBar.Maximum = FOV.MAX_VALUE;

            minLabel.Text = FOV.DEFAULT.ToString();
            maxLabel.Text = FOV.MAX_VALUE.ToString();

            fov.PropertyChanged +=
                (s, ea) =>
                {
                    if (ea.PropertyName == "Value")
                    {
                        int foval = ((s as FOV)?.Value) ?? FOV.DEFAULT;

                        fovLabel.Text = $"Current FOV: {foval}  -->";
                        fovTrackBar.Value = foval;
                        defaultButton.Enabled = fovTrackBar.Value != FOV.DEFAULT;
                    }
                };

            fov.OnPropertyChanged("Value");
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            fov.Value = FOV.DEFAULT;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            fov.Value = fovTrackBar.Value;
        }

        private void fovTrackBar_ValueChanged(object sender, EventArgs e)
        {
            fovUpDown.Value = fovTrackBar.Value;
            defaultButton.Enabled = fovTrackBar.Value != FOV.DEFAULT;
        }

        private void fovUpDown_ValueChanged(object sender, EventArgs e)
        {
            fovTrackBar.Value = (int)fovUpDown.Value;
        }
    }
}