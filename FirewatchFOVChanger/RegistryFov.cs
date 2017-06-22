using Microsoft.Win32;

namespace FirewatchFOVChanger
{
    public sealed class RegistryFov : Property<int>
    {
        const string REG_KEY_PATH = "HKEY_CURRENT_USER\\SOFTWARE\\CampoSanto\\Firewatch";
        const string REG_VALUE_NAME = "fovAdjust_h2041137991";

        public const int DEFAULT = 55;
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

        protected override int GetValue()
        {
            return ((RegValueDirty as int?) ?? 0) / 100 + DEFAULT;
        }

        protected override void SetValue(int value)
        {
            Registry.SetValue(
                REG_KEY_PATH,
                REG_VALUE_NAME,
                (value - DEFAULT) * 100);

            base.SetValue(value);
        }
    }
}
