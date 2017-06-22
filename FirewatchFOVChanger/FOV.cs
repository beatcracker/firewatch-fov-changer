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

        public static bool IsFireWatched
        {
            get
            {
                return RegValue != null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            pceh?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static object RegValue
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

        public int Value
        {
            get
            {
                return
                    ((RegValue as int?) ?? 0) / 100 + DEFAULT;
            }

            set
            {
                Registry.SetValue(
                    REG_KEY_PATH,
                    REG_VALUE_NAME,
                    (value - DEFAULT) * 100);

                OnPropertyChanged("Value");
            }
        } // Value get/set
    }
}
