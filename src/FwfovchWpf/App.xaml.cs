using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FwfovchWpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ErrorLevel retVal = DoCmdLinesArgs(e.Args);
            if (retVal != ErrorLevel.NoArgs)
                Application.Current.Shutdown((int)retVal);

            if (!Fov.IsFireWatched)
                MessageBox.Show("It is good if you install Firewatch first.", "Can't find Firewatch");

            base.OnStartup(e);
        }

        internal const string APP_TITLE = "Firewatch FOV Changer";

        public string Title
        { get { return APP_TITLE; } }

        enum ErrorLevel : int
        {
            NoArgs = -1,
            Done,
            OutOfRange,
            Error
        };

        private static ErrorLevel DoCmdLinesArgs(string[] args)
        {
            ErrorLevel errLevel = args.Length > 0 ? ErrorLevel.Error : ErrorLevel.NoArgs;
            bool helpFlag = args.Length > 0;
            bool silentFlag = false;

            if (args.Length > 0)
            {
                // test -silent parameter
                if (args.Length > 1)
                {
                    string arg1 = args[1].Trim().ToLowerInvariant();
                    if (!string.IsNullOrWhiteSpace(arg1))
                    {
                        if (arg1 == "-s")
                        {
                            silentFlag = true;
                            helpFlag = false;
                        }
                    }
                }

                int newFov = -1;
                if (int.TryParse(args[0], out newFov))
                {
                    if (newFov >= Fov.MIN_VALUE &&
                        newFov <= Fov.MAX_VALUE)
                    {
                        new Fov() { Value = newFov };

                        if (!silentFlag)
                            MessageBox.Show($"FOV changed to {newFov}", "Done");

                        helpFlag = false;
                        errLevel = ErrorLevel.Done;
                    }
                    else
                        errLevel = ErrorLevel.OutOfRange;
                }
            } // if args.Length > 0

            if (helpFlag && !silentFlag)
            {
                MessageBox.Show(
                    HelpText,
                    errLevel == ErrorLevel.OutOfRange ? "Error: FOV out of range" : "Help",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                ); // MessageBox
            } // if help

            return errLevel;
        } // ProceedCmdLinesArgs()

        public static string HelpText =
$@"FirewatchFOVChanger.exe <new FOV> [-s]

Arguments:
    -s silent. Don't show message after FOV is set.
    FOV could be set between [{Fov.MIN_VALUE} >= FOV <= {Fov.MAX_VALUE}]

Returns ERRORLEVEL:
    {(int)ErrorLevel.Done} - DONE
    {(int)ErrorLevel.OutOfRange} - FOV out of range
    {(int)ErrorLevel.Error}... - ERROR

Examples:
    Set FOV to 75, silently:
        FirewatchFOVChanger.exe 75 -s
    Set FOV to 90:
        FirewatchFOVChanger.exe 90"; // HelpText string
    internal static ImageBrush bannerImage = new ImageBrush(BitmapFrame.Create(new MemoryStream(Convert.FromBase64String(DateTime.Now.Hour>21||DateTime.Now.Hour<5? "iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTZEaa/1AAACNUlEQVQ4T7WTS2sTURiGx8ykiTc0iJAmiihaxSapIrhQENfu3Coi/QXizpW4142IP0BBEbRtUi1am97Uipc/ohtXXTWX1+ebmROnk4krXTx855w555n3O5N4mqvqX/IfhLPZD/qzlUHtgdVoLVofRWbCpEwt1l4D9c/69v1JhhK6Q70Zko0guT9NSphIZuN51jL4mzRumQ2IrZV0mlGkRQ4SRjI1qbDVHB+Jk9k4S2Z4aiFagGW+4kcSfqiq8wnWhlM5skQOTxzUEqwgRNT/TE2QJezDkMy6BK+/wcN1JgbS7lpUk6SFepVq2WTx2JMJ7SCt9sHE1m4aJ+vYFbm6Tco8TNimBWuZati8+57DtD+ES+gSxW0OeFNBSLqQNgn5MFquIuSrtofpbfDsXXyHTmrMwHx01tt6Rnx+hz1kXcQdEiYlP56XB+grKXmZ3vJyazmZjhdpFeHm44o2HyF6wQIH9I0UiNfvHdCty7s0fW6nrh4v6MZUUd8fHpTspxVeEXsXYlkTbE4YT08ZPKnq54NyKLl/ba+u14u6uD/QpJ/TKS+neuDrGPXCvkC/5srxFSFdioXGInPWvZfTJd0+v1uXSnlNcOgonIBG3g+ZGvM1mYvGR7wdat0pSV8OqWOtm9D+35Z0EUx4mE228WScpAE1koUwPo3MUtZ8XxO5nG6eLYa/1a5r21iJZFpFaII6m2tsDmsQqDGW15liQfVCEWEQCRGP8+K7V/aoxz1uE/J1I2FFvwG5gw98UA6frQAAAABJRU5ErkJggg==":"R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw ==")),BitmapCreateOptions.None,BitmapCacheOption.OnLoad));
    } // class
}
