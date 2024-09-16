using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView;

public partial class TargetViewModel : ObservableObject
{
    public TargetViewModel()
    {
        Shots = new ObservableCollection<ShotViewModel>();

        Shots.CollectionChanged += ShotsOnCollectionChanged;
    }

    private static void RunInDispacher(Action action)
    {
        if (Application.Current.Dispatcher.CheckAccess())
        {
            action.Invoke();
        }
        else
        {
            Application.Current.Dispatcher.Invoke(action.Invoke);
        }
    }

    private void ShotsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (ShotViewModel newItem in e.NewItems)
            {
                newItem.ShotChanged += OnShotChanged;
            }
        }

        if (e.OldItems != null)
        {
            foreach (ShotViewModel oldItem in e.OldItems)
            {
                oldItem.ShotChanged -= OnShotChanged;
            }
        }
    }

    protected void OnShotChanged(object? sender, EventArgs e)
    {
        if (sender is ShotViewModel shot)
        {
            shot.Scale = Scale;
        }
        
        OnPropertyChanged(nameof(Scale));
    }

    [ObservableProperty]
    public int targetNumber;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Scale))]
    public ObservableCollection<ShotViewModel>? shots;

    public int Scale => CalcScale();

    private int CalcScale()
    {
        if (Shots == null)
            return 500;

        if (Shots.Count == 0)
            return 500;

        if (Shots.Min(s => s.Score) >= 9) return 1800;

        if (Shots.Min(s => s.Score) >= 7) return 1300;

        if (Shots.Min(s => s.Score) >= 5) return 800;

        return 500;
    }

    private ShotViewModel InitialShot(int number)
    {
        return new ShotViewModel()
        {
            Number = number,
            Score = double.NaN,
            ShotColor = Colors.White,
            ShotBoarderColor = Colors.Black,
            ShotBoarder = 1.0
        };
    }

    public void AddShot(double score, double x, double y)
    {
        RunInDispacher(() =>
        {
            var shot = InitialShot(Shots!.Count + 1);
            shot.Score = score;
            shot.X = x;
            shot.Y = y;
            Shots.Add(shot);
        });
    }

}
