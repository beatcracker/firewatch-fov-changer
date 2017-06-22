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

            fovTrackBar.DataBindings.Add(
                new Binding( "Value",
                    fov, FOV.VALUE_PROPERTYNAME,
                    false, DataSourceUpdateMode.OnPropertyChanged));

            fovUpDown.DataBindings.Add(
                new Binding( "Value",
                    fov, FOV.VALUE_PROPERTYNAME,
                    false, DataSourceUpdateMode.OnPropertyChanged));

            Binding b = new Binding( "Text", fov, FOV.REG_PROPERTYNAME);
            b.Format +=
                (s, e) => {
                    e.Value = $"Current FOV: { fov.RegValue }  -->";
                };
            fovLabel.DataBindings.Add(b);

            fov.PropertyChanged +=
                (s, ea) => {
                    defaultButton.Enabled = (fov.Value) != FOV.DEFAULT;
                };

            fov.Value = fov.RegValue;
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            fov.Value = FOV.DEFAULT;
            fov.Store();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            fov.Store();
        }
    }
}