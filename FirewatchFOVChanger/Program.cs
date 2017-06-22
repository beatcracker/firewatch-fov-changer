using System;
using System.Windows.Forms;

namespace FirewatchFOVChanger
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!FOV.IsFireWatched)
                MessageBox.Show("It is good if you install Firewatch first.", "Can't find Firewatch");

            Application.Run(new MainForm());
        }
    }
}
