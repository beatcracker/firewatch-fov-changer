using System;
using System.Windows.Forms;

namespace FirewatchFOVChanger
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Set value first, then apply min/max.
            // Otherwise ValueChanged event wouldn't fire
            tbFOV.Value = FOV.Get();

            lbMin.Text = FOV.baseFOV.ToString();
            lbMax.Text= FOV.maxFOV.ToString();

            tbFOV.Minimum = FOV.baseFOV;
            tbFOV.Maximum = FOV.maxFOV;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            tbFOV.Value = FOV.baseFOV;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            FOV.Set(tbFOV.Value);
        }

        private void tbFOV_ValueChanged(object sender, EventArgs e)
        {
            lbFOV.Text = "FOV: " + tbFOV.Value.ToString();
        }
    }
}