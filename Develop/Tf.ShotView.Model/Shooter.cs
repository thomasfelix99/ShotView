namespace Tf.ShotView.Models;

public class Shooter
{
    public string? Name { get; set; }
    public Passe? CurrentPasse { get; set; }
    public List<Passe>? Passen { get; set; }
    public List<Shot>? IllegalShots { get; set; }
    public int Lane { get; set; }
    public EShooterState State { get; set; }

    public static Shooter CreateShooter(string name, int lane)
    {
        return new Shooter()
        {
            Name = name,
            Lane = lane,
            Passen = new List<Passe>(),
            IllegalShots = new List<Shot>(),
            State = EShooterState.None
        };
    }

    public void Clear()
    {
        Passen?.Clear();
        CurrentPasse = null;
        State = EShooterState.None;
    }

    public double CurrentPasseTotal()
    {
        double retVal = 0;

        CurrentPasse?.Shots?.ForEach(s => retVal += s.Result);

        return retVal;
    }

    public double LastPasseTotal()
    {
        double retVal = 0;

        if (Passen?.Count > 0)
        {
            Passen.Last().Shots?.ForEach(s => retVal += s.Result);
        }

        return retVal;
    }

    public void SetReadyForNewPasse(int anzShotsInPasse)
    {
        CurrentPasse = new Passe() { ShotCountExpected = anzShotsInPasse };
        IllegalShots?.Clear();
        State = EShooterState.Ready;
    }

    public bool CurrentPasseFinished()
    {
        if (CurrentPasse != null)
        {
            return CurrentPasse.PasseFinished;
        }
        return false;
    }

    public void ShotDetected(Shot shot)
    {
        if (shot.Lane == Lane)
        {
            CurrentPasse ??= new Passe();
            if (!CurrentPasseFinished())
            {
                CurrentPasse?.Shots?.Add(shot);
                if (CurrentPasseFinished())
                {
                    Passen?.Add(CurrentPasse);
                    State = EShooterState.Finished;
                }
                else
                {
                    State = EShooterState.Shooting;
                }
            }
            else
            {
                IllegalShots?.Add(shot);
            }
        }
    }

}
