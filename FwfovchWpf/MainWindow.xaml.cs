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

            dataModel.PropertyChanged +=
                (s, ee) => {
                    rightCurtain.Width =
                        leftCurtain.Width = ScaleToCurtainWidth(dataModel.NewFov);
                    leftFovBound.X1 =
                        leftFovBound.X2 = ScaleToCurtainWidth(dataModel.CurrentFov);
                    rightFovBound.X1 =
                        rightFovBound.X2 = CURTAIN_MAX_W - leftFovBound.X1;
                };

            dataModel.Initialize();
            DataContext = dataModel;
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
    } // class
}
