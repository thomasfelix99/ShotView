using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tf.ShotView.Models;

namespace Tf.ShotView;

[INotifyPropertyChanged]
public partial class MainWindowViewModel
{
    public MainWindowViewModel()
    {
        InitializeTargets();
    }

    [ObservableProperty]
    public string? timeText;

    [ObservableProperty]
    public TargetViewModel target1 = new();

    [ObservableProperty]
    public ObservableCollection<TargetViewModel> targets = new();

    [ObservableProperty]
    public ObservableCollection<ShooterViewModel> shooters = new();


    [RelayCommand]
    public void UpdateTimeText()
    {
        UpdateText();
    }

    [RelayCommand]
    public void AddTimeText()
    {
        AddText();
    }

    private void InitializeTargets()
    {
        Targets.Add(new TargetViewModel()
        {
            Number = 1,
            Score = 10.1
        });
        Targets.Add(new TargetViewModel()
        {
            Number = 2,
            Score = 10.2
        });
        Targets.Add(new TargetViewModel()
        {
            Number = 3,
            Score = 10.3
        });
        Targets.Add(new TargetViewModel()
        {
            Number = 4,
            Score = 10.4
        });
        Targets.Add(new TargetViewModel()
        {
            Number = 5,
            Score = 10.5
        });
        Targets.Add(new TargetViewModel()
        {
            Number = 6,
            Score = 10.6
        });

    }

    private void AddText()
    {
        Target1.ShowShot = !Target1.ShowShot;
        //Shooters.Add(new ShooterViewModel() { Name = $"{DateTime.Now:fff}" });
    }


    class TestShot
    {
        public double Score { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }


    List<TestShot> shots = new List<TestShot>()
    {
        new() { Score = 9.1, X = 2.64371, Y = -3.79727 },
        new() { Score = 5.9, X = 10.51955, Y = 7.00189 },
        new() { Score = 9.4, X = 3.05522, Y = -2.44362 },
        new() { Score = 8.3, X = 5.19471, Y = -4.02973 },
        new() { Score = 5.3, X = 2.77162, Y = 13.74946 },
        new() { Score = 6.5, X = 10.60858, Y = 3.29231 },
        new() { Score = 6, X = 9.67583, Y = 7.77909 },
        new() { Score = 4.6, X = 3.45563, Y = 15.46212 },
        new() { Score = 9.4, X = 3.77978, Y = 0.00171 },
        new() { Score = 7, X = 1.37325, Y = 9.70313 },
        new() { Score = 3, X = 19.9608, Y = -0.77755 },
        new() { Score = 5.7, X = 11.74952, Y = -5.96822 },
        new() { Score = 5.7, X = 13.06337, Y = -2.11839 },
        new() { Score = 7.5, X = 2.50716, Y = 8.2082 },
        new() { Score = 6.2, X = -9.06073, Y = 7.60117 },
        new() { Score = 7.2, X = 5.3055, Y = 7.76126 },
        new() { Score = 4.2, X = -16.07418, Y = 4.85168 },
        new() { Score = 2.6, X = 20.62155, Y = 2.93121 },
        new() { Score = 6.4, X = -3.22838, Y = -10.91962 },
        new() { Score = 7.4, X = 8.7431, Y = 1.01071 },
        new() { Score = 7.8, X = 7.92637, Y = 0.9578 },
        new() { Score = 7.7, X = -7.70937, Y = 2.31179 },
        new() { Score = 9.1, X = 3.10495, Y = -3.57266 },
        new() { Score = 8.3, X = -3.09172, Y = 5.94921 },
        new() { Score = 8.1, X = -6.59302, Y = 2.40565 },
        new() { Score = 10, X = 0.1752, Y = 2.39115 },
        new() { Score = 8.8, X = 5.20679, Y = 1.1702 },
        new() { Score = 5.1, X = 14.46792, Y = 2.16128 },
        new() { Score = 10.8, X = -0.25032, Y = -0.25575 },
        new() { Score = 8.5, X = 3.66517, Y = -5.02927 },
        new() { Score = 6.5, X = 9.19012, Y = -6.30674 },
        new() { Score = 7.4, X = 8.55756, Y = -2.22099 },
        new() { Score = 7.8, X = 0.27996, Y = 7.89165 },
        new() { Score = 8.1, X = 4.57947, Y = -5.3412 },
        new() { Score = 7.7, X = -2.83387, Y = 7.64543 },
        new() { Score = 9.7, X = -1.98499, Y = -2.38394 },
        new() { Score = 7.3, X = 6.14145, Y = -6.86396 },
        new() { Score = 4.8, X = -14.42303, Y = 5.4251 },
        new() { Score = 8, X = -6.61224, Y = 3.43441 },
        new() { Score = 5.2, X = 13.91585, Y = 3.30021 },
        new() { Score = 4.4, X = -16.3885, Y = -1.66595 },
        new() { Score = 9.3, X = 3.30145, Y = -2.44723 },
        new() { Score = 5.4, X = -11.99652, Y = 6.75337 },
        new() { Score = 8.9, X = 2.58744, Y = 4.34245 },
        new() { Score = 6.5, X = -6.10347, Y = 9.28637 },
        new() { Score = 8.6, X = 4.57943, Y = -3.55907 },
        new() { Score = 8, X = 7.17005, Y = 1.91862 },
        new() { Score = 10.1, X = 1.82124, Y = 1.23155 },
        new() { Score = 6.8, X = -9.90234, Y = 3.41422 },
        new() { Score = 8.1, X = 2.19465, Y = 6.76166 },
        new() { Score = 8.1, X = 1.88463, Y = 6.90532 },
        new() { Score = 8.6, X = -3.55559, Y = 4.68583 },
        new() { Score = 6.1, X = -12.01423, Y = 0.38851 },
    };

    private int idx = 0;
    private void UpdateText()
    {
        idx += 1;
        if (idx > shots.Count - 1)
        {
            idx = 0;
        }

        Target1.Score = shots[idx].Score;
        Target1.X = shots[idx].X * 10;
        Target1.Y = shots[idx].Y * 10;
        
        //foreach (var t in Targets)
        //{
        //    t.Score += 1;
        //}


        //if (Shooters.Count > 0)
        //{
        //    Shooters[0].Name = $"- {Shooters[0].Name}";
        //}
    }

}
