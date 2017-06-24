using System.ComponentModel;

namespace FwfovchWpf
{
    public class DataModel : INotifyPropertyChanged
    {
        int newFov;
        public int NewFov
        {
            get { return newFov; }
            set {
                newFov = value;
                OnPropertyChanged("NewFov");
            }
        }

        Fov fovInRegistry = new Fov();
        public int CurrentFov
        {
            get { return fovInRegistry.Value; }

            set {
                fovInRegistry.Value = value;
                OnPropertyChanged("CurrentFov");
            }
        }

        public void Store()
        {
            CurrentFov = newFov;
        }

        public void Default()
        {
            NewFov =
                CurrentFov = Fov.DEFAULT;
        }

        public void Initialize()
        {
            NewFov = CurrentFov;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            pceh?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } // class
}
