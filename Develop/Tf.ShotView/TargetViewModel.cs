using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView;

[INotifyPropertyChanged]
public partial class TargetViewModel
{
    [ObservableProperty] public int number;
    [ObservableProperty] public double score;
    [ObservableProperty] public double shotSize = 45;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotVisibility))]
    public bool showShot = true;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotLeft))]
    public double x;

    [NotifyPropertyChangedFor(nameof(ShotTop))]
    [ObservableProperty] public double y;

    public double ShotLeft => X + 250 - ShotSize / 2;
    public double ShotTop => Y + 250 - ShotSize / 2;

    public System.Windows.Visibility ShotVisibility => ShowShot ? Visibility.Visible : Visibility.Hidden;
}
