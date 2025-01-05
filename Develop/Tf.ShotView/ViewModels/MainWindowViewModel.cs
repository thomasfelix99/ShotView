﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tf.ShotView.Models.Services;

namespace Tf.ShotView.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IDbService _db;

    public MainWindowViewModel(IDbService dbService)
    {
        InitializeTargets();
        _db = dbService;
    }

    [ObservableProperty] public string? timeText;
    [ObservableProperty] public ObservableCollection<TargetViewModel>? targets = null;

    [RelayCommand]
    public void UpdateTimeText()
    {
        Targets![0].IsEnabled = !Targets[0].IsEnabled;
        //await UpdateText();
    }

    private string CreatePasseId(int day, int lane, int passeNr)
    {
        return $"{day}-{lane:D3}-{passeNr:D3}";
    }

    [RelayCommand]
    public async Task AddShot()
    {
        //TestData.InsertFromSiusData(_db, @"C:\tmp\20241218_0.csv");

        //foreach (int day in await _db.SelectDays())
        //{
        //    foreach (int lane in await _db.SelectLanes(day))
        //    {
        //        int passeNr = 1;
        //        string passeId = CreatePasseId(day, lane, passeNr);

        //        IList<RawShot> shots = await _db.GetRawShotsByLaneAndDay(day, lane);

        //        foreach (RawShot shot in shots.OrderBy(s => s.TimeStamp))
        //        {
        //            shot.PasseId = passeId;
        //            if (shot.TotalArt != 0)
        //            {
        //                passeNr += 1;
        //                passeId = CreatePasseId(day, lane, passeNr);
        //            }
        //        }

        //        await _db.UpdateRawShots(shots);
        //    }
        //}

        for (int i = 0; i < 6; i++)
        {
            Targets![i].UseShotColors = true;
            Targets![i].Shots?.Clear();
            foreach (var item in await _db.GetRawShotsByPasseId($"20241226-001-{(i+1):D3}"))
            {
                await Targets![i].AddShot(item.PrimaryScore, item.X, item.Y);
            }
        }
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
        Targets = new ObservableCollection<TargetViewModel>();

        for (int i = 1; i <= 6; i++)
        {
            Targets?.Add(new TargetViewModel()
            {
                LaneNumber = i
            });
        }
    }
}
