using System;
using System.Windows.Forms;

namespace FirewatchFOVChanger
{
    public partial class MainForm : Form
    {
        Property<int> fov = new Property<int>();
        RegistryFov regFov = new RegistryFov();

        public MainForm()
        {
            InitializeComponent();

            fovUpDown.Minimum =
                fovTrackBar.Minimum = RegistryFov.DEFAULT;
            fovUpDown.Maximum =
                fovTrackBar.Maximum = RegistryFov.MAX_VALUE;

            minLabel.Text = RegistryFov.DEFAULT.ToString();
            maxLabel.Text = RegistryFov.MAX_VALUE.ToString();

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
                    e.Value = $"Current FOV: { regFov.Value }.  New FOV:";
                };
            fovLabel.DataBindings.Add(b);

            fov.PropertyChanged +=
                (s, ea) => {
                    defaultButton.Enabled = (fov.Value) != RegistryFov.DEFAULT;
                };

            fov.Value = regFov.Value;
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            regFov.Value = 
                fov.Value = RegistryFov.DEFAULT;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            regFov.Value = fov.Value;
        }
    }
}