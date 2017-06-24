using System.ComponentModel;

namespace FwfovchWpf
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
        public virtual T Value
        {
            get { return _value; }

            set
            {
                _value = value;
                OnPropertyChanged(VALUE_NAME);
            }
        }
    }
}
