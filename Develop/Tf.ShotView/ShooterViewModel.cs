using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView;

[INotifyPropertyChanged]
public partial class ShooterViewModel
{
    [ObservableProperty] private string? name;
}
