using Microsoft.Win32;

namespace FirewatchFOVChanger
{
    public sealed class RegistryFov : Property<int>
    {
        const string REG_KEY_PATH = "HKEY_CURRENT_USER\\SOFTWARE\\CampoSanto\\Firewatch";
        const string REG_VALUE_NAME = "fovAdjust_h2041137991";

        public const int DEFAULT = 55;
        public const int MIN_VALUE = DEFAULT;
        public const int MAX_VALUE = 110;

        public static bool IsFireWatched
        {
            get { return RegValueDirty != null; }
        }

        static object RegValueDirty
        {
            get
            {
                return
                    Registry.GetValue(
                        REG_KEY_PATH,
                        REG_VALUE_NAME,
                        0);
            }
        }

        private int WrapFov(int fov)
        {
            if (fov < MIN_VALUE)
                fov = MIN_VALUE;
            if (fov > MAX_VALUE)
                fov = MAX_VALUE;
            return fov;
        }

        public override int Value
        {
            get { return WrapFov(((RegValueDirty as int?) ?? 0) / 100 + MIN_VALUE); }

            set
            {
                int fov = WrapFov(value);

                Registry.SetValue(
                    REG_KEY_PATH,
                    REG_VALUE_NAME,
                    (fov - MIN_VALUE) * 100);

                base.Value = fov;
            }
        } // Value

    } // class
}
