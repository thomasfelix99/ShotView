using System.Windows;
using System.Windows.Controls;

namespace Tf.ShotView.Controls
{
    /// <summary>
    /// Interaktionslogik für Target.xaml
    /// </summary>
    public partial class TargetControl : UserControl
    {
        public TargetControl()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }

        private ViewModels.TargetViewModel? _viewModel => DataContext as ViewModels.TargetViewModel;

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is TargetControl t)
            {
                _viewModel?.TargetSizeChanged(t.ActualWidth, t.ActualHeight);
            }
        }
    }
}
