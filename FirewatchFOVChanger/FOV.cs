using System;
using Microsoft.Win32;

namespace FirewatchFOVChanger
{
    public static class FOV
    {
        const string regPath = "HKEY_CURRENT_USER\\SOFTWARE\\CampoSanto\\Firewatch";
        const string regName = "fovAdjust_h2041137991";
        public const int baseFOV = 55;
        public const int maxFOV = 110;

        public static int Get()
        {
            return Convert.ToInt32(
                Registry.GetValue(regPath, regName, 0)
            ) / 100 + baseFOV;
        }

        public static void Set(int fov)
        {
            Registry.SetValue(regPath, regName, (fov - baseFOV) * 100);
        }
    }

}
