using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Tf.ShotView;

public partial class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        InitializeTargets();
    }

    [ObservableProperty] public string? timeText;
    [ObservableProperty] public ObservableCollection<TargetViewModel>? targets = new();

    [RelayCommand]
    public async Task UpdateTimeText()
    {
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
                TargetNumber = i
            });
        }
    }

    private async Task AddTestShot()
    {
        TestData.TestShot shot = TestData.NextShot();
        TargetViewModel? target = Targets?.FirstOrDefault(t => t.TargetNumber == shot.TargetNr);
        await target!.AddShot(shot.Score, shot.X, shot.Y);
    }
}
