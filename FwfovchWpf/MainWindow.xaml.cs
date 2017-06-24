using System.Windows;

namespace FwfovchWpf
{
    public partial class MainWindow : Window
    {
        DataModel dataModel = new DataModel();
        const float CURTAIN_MAX_W = 90f;

        public MainWindow()
        {
            InitializeComponent();

            Title = App.APP_TITLE;

            minLabel.Content = fovSlider.Minimum = Fov.MIN_VALUE;
            maxLabel.Content = fovSlider.Maximum = Fov.MAX_VALUE;

            dataModel.PropertyChanged +=
                (s, ee) => {
                    rightCurtain.Width = leftCurtain.Width =
                            (1f - (dataModel.NewFov - Fov.MIN_VALUE) / (float)Fov.MIN_VALUE) * CURTAIN_MAX_W;
                };

            dataModel.Initialize();
            DataContext = dataModel;
        }

        private void defaultButton_Click(object sender, RoutedEventArgs e)
        {
            dataModel.Default();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            dataModel.Store();
        }

    } // class
}
