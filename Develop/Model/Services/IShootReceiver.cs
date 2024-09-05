namespace Tf.ShotView.Models.Services;

public interface IShootReceiver : IDisposable
{
    event EventHandler NewShot;

    bool IsRunning { get; }
    int TcpPort { get; set; }
    string TcpAddress { get; set; }
    string LogLocation { get; set; }

    void Start();
    void Stop();
}
