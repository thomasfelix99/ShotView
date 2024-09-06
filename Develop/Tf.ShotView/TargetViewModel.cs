using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView;

[INotifyPropertyChanged]
public partial class TargetViewModel
{
    [ObservableProperty] public int number;
    [ObservableProperty] public double score;
}
