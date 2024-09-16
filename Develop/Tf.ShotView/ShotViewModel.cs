using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView;

public partial class ShotViewModel : ObservableObject
{
    public EventHandler? ShotChanged;

    [ObservableProperty] public double shotSize = 45;
    
    [ObservableProperty] public int number;

    [NotifyPropertyChangedFor(nameof(ShotFill))]
    [ObservableProperty] public Color shotColor = Colors.White;

    [NotifyPropertyChangedFor(nameof(ShotStrokeThickness))]
    [ObservableProperty] public double shotBoarder = 1;

    [NotifyPropertyChangedFor(nameof(ShotStroke))]
    [ObservableProperty] public Color shotBoarderColor = Colors.Black;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotVisibility))]
    public double score = double.NaN;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotVisibility))]
    public bool showShot = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotLeft))]
    public double x;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShotTop))]
    public double y;

    [ObservableProperty]
    public double scale;
    
    public double ShotLeft => X + 250 - ShotSize / 2;
    public double ShotTop => Y + 250 - ShotSize / 2;
    public Visibility ShotVisibility => CalcShotVisibility();

    public Brush ShotFill => new SolidColorBrush(ShotColor);

    public Brush ShotStroke => new SolidColorBrush(ShotBoarderColor);
    
    public Thickness ShotStrokeThickness => CalcStrokeThikness();

    private Visibility CalcShotVisibility()
    {
        if (double.IsNaN(Score)) return Visibility.Hidden;

        return ShowShot ? Visibility.Visible : Visibility.Hidden;
    }

    private Thickness CalcStrokeThikness()
    {
        if (!double.IsNaN(ShotBoarder))
        {
            return new Thickness(0);
        }

        return new Thickness(ShotBoarder);
    }

    partial void OnScoreChanged(double oldValue, double newValue)
    {
        ShotChanged?.Invoke(this, EventArgs.Empty);
    }
}
