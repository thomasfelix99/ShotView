using System.Windows;

namespace Tf.ShotView;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private MainWindowViewModel? _viewModel => DataContext as MainWindowViewModel;

    public void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (_viewModel?.Target1 != null)
        {
            _viewModel.Target1.ManualScale = e.NewValue / 10;
        }
    }
}
