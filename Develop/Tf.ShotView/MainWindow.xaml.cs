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
        if (_viewModel?.Targets != null)
        {
            foreach (TargetViewModel target in _viewModel.Targets)
            {
                target.ManualScale = e.NewValue / 10;
            }
        }
    }
    public void ShotSizeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (_viewModel?.Targets != null)
        {
            foreach (TargetViewModel target in _viewModel.Targets)
            {
                if (target.Shots?.Count > 0)
                {
                    foreach (ShotViewModel shot in target.Shots)
                    {
                        shot.ShotSize = e.NewValue;
                    }
                }
            }
        }
    }
}
