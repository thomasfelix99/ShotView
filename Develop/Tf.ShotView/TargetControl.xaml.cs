using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tf.ShotView
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

            InitializeRings();

            Target.Background = new SolidColorBrush(Colors.LightYellow);
        }

        private TargetViewModel? _viewModel => DataContext as TargetViewModel;

        private void InitializeRings()
        {
            for (int i = 0; i < 10; i++)
            {
                Target.Children.Add(new Ellipse());
            }
        }
        
        private void SetRing(Ellipse ring, int score)
        {
            double act = ActualHeight > ActualWidth ? ActualWidth : ActualHeight;
            double fact = act / 500;
            double kaliber = 45 * fact;

            double rz = act - (score - 1) * 50 * fact - kaliber;

            ring.Width = rz;
            ring.Height = rz;
            ring.Fill = score is < 4 or 10 ? Brushes.White : Brushes.Black;
            ring.Stroke = score is < 4 or 10 ? Brushes.Black : Brushes.White;
            ring.StrokeThickness = score == 10 ? 0 : fact * 2;

            Canvas.SetLeft(ring, (ActualWidth - rz) / 2);
            Canvas.SetTop(ring, (ActualHeight - rz) / 2);
        }

        private void ScaleRings()
        {

        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            for (int i = 0; i < Target.Children.Count; i++)
            {
                if (Target.Children[i] is Ellipse ring)
                {
                    SetRing(ring, i + 1);
                }
            }
        }
    }
}
