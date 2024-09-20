using CommunityToolkit.Mvvm.ComponentModel;

namespace Tf.ShotView.ViewModels;

public partial class ShooterViewModel : ObservableObject
{
    [ObservableProperty] private string? name;
}
