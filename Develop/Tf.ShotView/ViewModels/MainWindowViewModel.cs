using System.Collections.ObjectModel;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Tf.ShotView.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        InitializeTargets();
    }

    [ObservableProperty] public string? timeText;
    [ObservableProperty] public ObservableCollection<TargetViewModel>? targets = new();

    [RelayCommand]
    public void UpdateTimeText()
    {
        Targets[0].IsEnabled = !Targets[0].IsEnabled;
        //await UpdateText();
    }

    [RelayCommand]
    public async Task AddShot()
    {
        await AddTestShot();
    }

    [RelayCommand]
    public void ClearShots()
    {
        if (Targets != null)
        {
            foreach (TargetViewModel target in Targets)
            {
                target.Shots?.Clear();
            }
        }
    }

    private void InitializeTargets()
    {
        for (int i = 1; i <= 6; i++)
        {
            Targets?.Add(new TargetViewModel()
            {
                LaneNumber = i
            });
        }
    }

    private async Task AddTestShot()
    {
        TestData.TestShot shot = TestData.NextShot();
        TargetViewModel? target = Targets?.FirstOrDefault(t => t.LaneNumber == shot.TargetNr);
        await target!.AddShot(shot.Score, shot.X, shot.Y);
    }
}
