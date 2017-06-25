using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FwfovchWpf
{
    public partial class MainWindow : Window
    {
        internal const float CURTAIN_MAX_W = 90f;
        ViewModel data = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();

            Title = App.APP_TITLE;

            minLabel.Content = fovSlider.Minimum = Fov.MIN_VALUE;
            maxLabel.Content = fovSlider.Maximum = Fov.MAX_VALUE;

            bannerimage.Background = App.bannerImage;            
            data.PropertyChanged += DataModel_PropertyChanged;

            data.Initialize();
            DataContext = data;
        }

        private void DataModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            rightCurtain.Width =
                leftCurtain.Width = ScaleToCurtainWidth(data.NewFov);
            leftFovBound.X1 =
                leftFovBound.X2 = ScaleToCurtainWidth(data.CurrentFov);
            rightFovBound.X1 =
                rightFovBound.X2 = CURTAIN_MAX_W - leftFovBound.X1;

            leftFovBound.Visibility =
                rightFovBound.Visibility =
                    data.NewFov != data.CurrentFov ?
                        Visibility.Visible :
                        Visibility.Hidden;
        }

        float ScaleToCurtainWidth(int fov)
        {
            return (1f - (fov - Fov.MIN_VALUE) / (float)Fov.MIN_VALUE) * CURTAIN_MAX_W;
        }

        private void defaultButton_Click(object sender, RoutedEventArgs e)
        {
            data.Default();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            data.Store();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            MessageBox.Show(
@"Baked under the MIT License
Latest version at https://github.com/beatcracker

" + App.HelpText,
            $"About {App.APP_TITLE}"); // eof MessageBox
        }

        private void fovTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ival = Fov.DEFAULT;
            e.Handled = !int.TryParse(e.Text, out ival);
        }

        private void fovTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                (sender as TextBox)?.
                    GetBindingExpression(TextBox.TextProperty).
                        UpdateSource();
        }
    } // class
}
