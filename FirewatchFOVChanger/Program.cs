using System;
using System.Windows.Forms;

namespace FirewatchFOVChanger
{
    static partial class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            ErrorLevel retVal = DoCmdLinesArgs(args);
            if (retVal != ErrorLevel.NoArgs)
                return (int)retVal;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!RegistryFov.IsFireWatched)
                MessageBox.Show("It is good if you install Firewatch first.", "Can't find Firewatch");

            Application.Run(new MainForm());

            return 0;
        }
    } // class
}
