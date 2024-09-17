using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView;

public partial class RingViewModel : ObservableObject
{
    [NotifyPropertyChangedFor(nameof(RingZIndex))]
    [ObservableProperty] public int score;

    [NotifyPropertyChangedFor(nameof(RingFill))]
    [ObservableProperty] public Color backgroundColor;

    [ObservableProperty] public double ringStrokeThickness;
    
    [NotifyPropertyChangedFor(nameof(RingStroke))]
    [ObservableProperty] public Color ringColor;

    [ObservableProperty] public double ringSize;

    [ObservableProperty] public double ringLeft;

    [ObservableProperty] public double ringTop;

    public int RingZIndex => Score;

    public Brush RingFill => new SolidColorBrush(BackgroundColor);

    public Brush RingStroke => new SolidColorBrush(RingColor);
}
