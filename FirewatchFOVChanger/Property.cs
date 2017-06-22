using System.ComponentModel;

namespace FirewatchFOVChanger
{
    public class Property<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            pceh?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        T _value;
        public T Value
        {
            get
            {
                return _value; 
            }

            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
    }
}
