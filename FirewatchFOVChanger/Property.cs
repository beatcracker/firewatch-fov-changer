using System.ComponentModel;

namespace FirewatchFOVChanger
{
    public class Property<T> : INotifyPropertyChanged
    {
        public const string VALUE_NAME = "Value";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            pceh?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected T _value;
        public T Value
        {
            get
            {
                return GetValue(); 
            }

            set
            {
                SetValue(value);
                OnPropertyChanged(VALUE_NAME);
            }
        }

        protected virtual void SetValue(T value)
        {
            _value = value;
        }

        protected virtual T GetValue()
        {
            return _value;
        }
    }
}
