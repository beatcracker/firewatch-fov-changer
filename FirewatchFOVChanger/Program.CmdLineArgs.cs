using System.Windows.Forms;

namespace FirewatchFOVChanger
{
    static partial class Program
    {
        internal const string APP_TITLE = "Firewatch FOV Changer";
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
                    if (newFov >= RegistryFov.MIN_VALUE &&
                        newFov <= RegistryFov.MAX_VALUE)
                    {
                        new RegistryFov() { Value = newFov };

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
                    MessageBoxButtons.OK,
                    errLevel > ErrorLevel.Done ? MessageBoxIcon.Error : MessageBoxIcon.Information
                ); // MessageBox
            } // if help

            return errLevel;
        } // ProceedCmdLinesArgs()

        public static string HelpText =
$@"FirewatchFOVChanger.exe <new FOV> [-s]

Arguments:
    -s for silence
    FOV could be set between: {RegistryFov.MIN_VALUE} >= FOV <= {RegistryFov.MAX_VALUE}

Returns ERRORLEVEL:
    {(int)ErrorLevel.Done} - DONE
    {(int)ErrorLevel.OutOfRange} - FOV out of range
    {(int)ErrorLevel.Error}... - ERROR

Examples:
    FirewatchFOVChanger.exe 90 -s
    FirewatchFOVChanger.exe 55"; // HelpText string
    } // class
}
