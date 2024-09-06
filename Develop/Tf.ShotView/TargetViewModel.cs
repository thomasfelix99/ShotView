using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView;

[INotifyPropertyChanged]
public partial class TargetViewModel
{
    [ObservableProperty] public int number;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Scale))]
    [NotifyPropertyChangedFor(nameof(ShotVisibility))]
    public double score = double.NaN;
    
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

    public Visibility ShotVisibility => CalcShotVisibility();

    public int Scale => CalcScale();

    private Visibility CalcShotVisibility()
    {
        if (double.IsNaN(Score)) return Visibility.Hidden;

        return ShowShot ? Visibility.Visible : Visibility.Hidden;
    }

    private int CalcScale()
    {
        if (double.IsNaN(Score)) return 500;

        if (Score >= 9) return 1800;

        if (Score >= 7) return 1000;

        if (Score >= 5) return 800;

        return 500;
    }
}
