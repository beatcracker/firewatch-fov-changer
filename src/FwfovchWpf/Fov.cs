using Microsoft.Win32;

namespace FwfovchWpf
{
    public sealed class Fov
    {
        const string REG_KEY_PATH = "HKEY_CURRENT_USER\\SOFTWARE\\CampoSanto\\Firewatch";
        const string REG_VALUE_NAME = "fovAdjust_h2041137991";

        public const int DEFAULT = 55;
        public const int MIN_VALUE = DEFAULT;
        public const int MAX_VALUE = 110;

        public static bool IsFireWatched { get { return RegValueDirty != null; }}

        static object RegValueDirty
        {
            get { return
                    Registry.GetValue(
                        REG_KEY_PATH,
                        REG_VALUE_NAME,
                        0); }
        }

        public static int Wrap(int fov)
        {
            if (fov < MIN_VALUE)
                fov = MIN_VALUE;
            if (fov > MAX_VALUE)
                fov = MAX_VALUE;

            return fov;
        }

        public int Value
        {
            get { return
                    Wrap(
                        ((RegValueDirty as int?) ?? 0) / 100 + MIN_VALUE); }

            set {
                Registry.SetValue(
                    REG_KEY_PATH,
                    REG_VALUE_NAME,
                    (Wrap(value) - MIN_VALUE) * 100); }
        } // Value

    } // class
}
