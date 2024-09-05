namespace Tf.ShotView.Models;

public class Passe
{
    public int ShotCountExpected { get; set; }

    public List<Shot>? Shots { get; set; }

    public bool PasseFinished => Shots?.Count > 0 && Shots.Count >= ShotCountExpected;
}
