using System.Windows;

namespace FwfovchWpf
{
    public partial class MainWindow : Window
    {
        internal const float CURTAIN_MAX_W = 90f;
        DataModel dataModel = new DataModel();

        public MainWindow()
        {
            InitializeComponent();

            Title = App.APP_TITLE;

            minLabel.Content = fovSlider.Minimum = Fov.MIN_VALUE;
            maxLabel.Content = fovSlider.Maximum = Fov.MAX_VALUE;

            bannerimage.Background = App.bannerImage;            
            dataModel.PropertyChanged += DataModel_PropertyChanged;

            dataModel.Initialize();
            DataContext = dataModel;
        }

        private void DataModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            rightCurtain.Width =
                leftCurtain.Width = ScaleToCurtainWidth(dataModel.NewFov);
            leftFovBound.X1 =
                leftFovBound.X2 = ScaleToCurtainWidth(dataModel.CurrentFov);
            rightFovBound.X1 =
                rightFovBound.X2 = CURTAIN_MAX_W - leftFovBound.X1;

            leftFovBound.Visibility =
                rightFovBound.Visibility =
                    dataModel.NewFov != dataModel.CurrentFov ?
                        Visibility.Visible :
                        Visibility.Hidden;
        }

        float ScaleToCurtainWidth(int fov)
        {
            return (1f - (fov - Fov.MIN_VALUE) / (float)Fov.MIN_VALUE) * CURTAIN_MAX_W;
        }

        private void defaultButton_Click(object sender, RoutedEventArgs e)
        {
            dataModel.Default();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            dataModel.Store();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            MessageBox.Show(
@"Baked under the MIT License
Latest version at https://github.com/beatcracker

" + App.HelpText,
            $"About {App.APP_TITLE}"); // MessageBox
        }
    } // class
}
