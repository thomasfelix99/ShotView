using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView.ViewModels;

public partial class TargetViewModel : ObservableObject
{
    [NotifyPropertyChangedFor(nameof(TargetBackground))]
    [ObservableProperty] public Color backgroundColor;

    [ObservableProperty] public int targetNumber;

    [ObservableProperty] public ObservableCollection<ShotViewModel>? shots;

    [ObservableProperty] public ObservableCollection<RingViewModel>? rings;

    [NotifyPropertyChangedFor(nameof(CenterX))]
    [ObservableProperty] public double targetActualWidth;

    [NotifyPropertyChangedFor(nameof(CenterY))]
    [ObservableProperty] public double targetActualHeight;

    [NotifyPropertyChangedFor(nameof(CenterX))]
    [NotifyPropertyChangedFor(nameof(CenterY))]
    [NotifyPropertyChangedFor(nameof(Scale))]
    [ObservableProperty] public double manualScale;

    [NotifyPropertyChangedFor(nameof(Scale))]
    [ObservableProperty] public bool autoScale;

    [ObservableProperty] public double lastScore;

    public double CenterX => TargetActualWidth / 2;
    public double CenterY => TargetActualHeight / 2;
    public double Scale => AutoScale ? ScaleFromShots() : ManualScale;

    private const double KaliberG10 = 4.5;

    public TargetViewModel()
    {
        InitializeTarget();
        InitializeRings();
        InitializeShots();
    }

    public Brush TargetBackground => new SolidColorBrush(BackgroundColor);
    
    private void InitializeTarget()
    {
        BackgroundColor = Colors.LightYellow;
        TargetNumber = 0;
        ManualScale = 1;
        AutoScale = false;
    }

    private void InitializeRings()
    {
        Rings = new ObservableCollection<RingViewModel>();
        
        for (int score = 1; score <= 10; score++)
        {
            Rings.Add(new RingViewModel()
            {
                Score = score
            });
        }
    }

    private void InitializeShots()
    {
        Shots = new ObservableCollection<ShotViewModel>();
        Shots.CollectionChanged += ShotsOnCollectionChanged;
    }

    private double Factor => 500 / double.Min(TargetActualHeight, TargetActualWidth);
    
    private void SetRingG10(RingViewModel ring)
    {
        double ringDiameter = 45.5 - 5 * (ring.Score - 1);

        ring.BackgroundColor = ring.Score is < 4 or 10 ? Colors.White : Colors.Black;
        ring.RingColor = ring.Score is < 4 or 10 ? Colors.Black : Colors.White;

        ring.RingSize = ringDiameter * 10 / Factor;
        ring.RingStrokeThickness = ring.Score < 10 ? 0.2 * 10 / Factor : 0;

        ring.RingLeft = (TargetActualWidth - ring.RingSize) / 2;
        ring.RingTop = (TargetActualHeight - ring.RingSize) / 2;
    }

    private void SetShotG10(ShotViewModel shot)
    {
        shot.ShotBoarderThickness = 1 / Factor;
        shot.ShotSize = KaliberG10 * 10 / Factor;
        shot.ShotLeft = TargetActualWidth / 2 + shot.X * 10 / Factor - shot.ShotSize / 2;
        shot.ShotTop = TargetActualHeight / 2 + shot.Y * 10 / Factor - shot.ShotSize / 2;
    }

    private static async Task RunInDispacher(Action action)
    {
        if (Application.Current.Dispatcher.CheckAccess())
        {
            action.Invoke();
        }
        else
        {
            await Application.Current.Dispatcher.BeginInvoke(action.Invoke);
        }
    }

    private void UpdateLatestShot()
    {
        LastScore = Shots?.Count > 0 ? Shots.Last().Score : double.NaN;
    }

    private void ShotsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Scale));
        UpdateLatestShot();
    }

    private double ScaleFromShots()
    {
        if (Shots?.Count > 0)
        {
            if (Shots?.Min(s => s.Score) >= 9)
            {
                return 2;
            }

            if (Shots?.Min(s => s.Score) >= 7)
            {
                return 1.5;
            }

            if (Shots?.Min(s => s.Score) >= 5)
            {
                return 1.2;
            }

        }
        return 1;
    }
    public void TargetSizeChanged(double actualWidth, double actualHeight)
    {
        TargetActualWidth = actualWidth;
        TargetActualHeight = actualHeight;

        if (Rings != null)
        {
            foreach (RingViewModel ring in Rings)
            {
                SetRingG10(ring);
            }
        }

        if (Shots != null)
        {
            foreach (ShotViewModel shot in Shots)
            {
                SetShotG10(shot);
            }
        }
    }
    
    public async Task AddShot(double score, double x, double y)
    {
        await RunInDispacher(() =>
        {
            ShotViewModel shot = new ShotViewModel()
            {
                Number = Shots!.Count + 1,
                ShotColor = Colors.White,
                ShotBoarderColor = Colors.Black,
                Score = score,
                X = x,
                Y = y,
                ShowShot = true
            };
            SetShotG10(shot);
            Shots.Add(shot);
        });
    }

}
