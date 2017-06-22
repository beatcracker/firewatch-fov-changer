using Microsoft.Win32;
using System.ComponentModel;

namespace FirewatchFOVChanger
{
    public class FOV : INotifyPropertyChanged
    {
        const string REG_KEY_PATH = "HKEY_CURRENT_USER\\SOFTWARE\\CampoSanto\\Firewatch";
        const string REG_VALUE_NAME = "fovAdjust_h2041137991";

        public const int DEFAULT = 55;
        public const int MAX_VALUE = 110;
        public const string REG_PROPERTYNAME = "RegValue";
        public const string VALUE_PROPERTYNAME = "Value";

        public static bool IsFireWatched
        {
            get { return RegValueDirty != null; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            pceh?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public int RegValue
        {
            get { return ((RegValueDirty as int?) ?? 0) / 100 + DEFAULT; }
        }


        int preValue = -1;
        public int Value
        {
            get { return preValue; }

            set
            {
                preValue = value;
                OnPropertyChanged(VALUE_PROPERTYNAME);
            }
        }

        public void Store()
        {
            Registry.SetValue(
                REG_KEY_PATH,
                REG_VALUE_NAME,
                (preValue - DEFAULT) * 100);

            OnPropertyChanged(REG_PROPERTYNAME);
        }
    }
}
