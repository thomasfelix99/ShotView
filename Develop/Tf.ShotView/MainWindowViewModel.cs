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
    public ObservableCollection<TargetViewModel> targets = new();

    [ObservableProperty] 
    public ObservableCollection<Shooter> shooters = new();


    [RelayCommand]
    public void UpdateTimeText()
    {
        RefreshText();
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

    private void RefreshText()
    {
        TimeText = $"{DateTime.Now:HH:mm:ss.fff}";

        Shooters?.Add(new Shooter() {Name = TimeText});

        for (int i = 0; i < Targets.Count; i++)
        {
            Targets[i].Score += i + 1;
        }
    }

}
