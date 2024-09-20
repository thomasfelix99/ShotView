using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView.ViewModels;

public partial class ShotViewModel : ObservableObject
{
    [NotifyPropertyChangedFor(nameof(ShotZIndex))]
    [ObservableProperty] public int number;

    [NotifyPropertyChangedFor(nameof(ShotFill))]
    [ObservableProperty] public Color shotColor;

    [ObservableProperty] public double shotBoarderThickness;

    [NotifyPropertyChangedFor(nameof(ShotStroke))]
    [ObservableProperty] public Color shotBoarderColor;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotVisibility))]
    public double score;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotVisibility))]
    public bool showShot;

    [ObservableProperty]
    public double shotSize;

    public double X { get; set; }
    public double Y { get; set; }

    [ObservableProperty] public double shotLeft;
    [ObservableProperty] public double shotTop;

    public Visibility ShotVisibility => CalcShotVisibility();

    public Brush ShotFill => new SolidColorBrush(ShotColor);

    public Brush ShotStroke => new SolidColorBrush(ShotBoarderColor);
    
    public int ShotZIndex => Number ;

    private Visibility CalcShotVisibility()
    {
        if (double.IsNaN(Score)) return Visibility.Hidden;

        return ShowShot ? Visibility.Visible : Visibility.Hidden;
    }
}
