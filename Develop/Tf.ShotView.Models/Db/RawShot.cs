using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tf.ShotView.Models.Db;

public class RawShot
{
    [Key]
    [Description("ID")]
    public string ShootId { get; set; } = string.Empty;

    [Description("ID der Passe")]
    public string PasseId { get; set; } = string.Empty;

    [Description("Anlage (SVMG10 / SVMG50 / SVMG300 ...)")]
    public string? Anlage { get; set; }

    [Description("StartTag im Format YYYYMMDD als Zahl")]
    public int Day { get; set; }

    [Description("Mit der Startnummer ist der Schütze eindeutig identifiziert")]
    public int StartNr { get; set; }

    [Description("99.99 Primärwertung(1.0 bis 10.9 oder 1 bis 10)")]
    public double PrimaryScore { get; set; }

    [Description("0=Probeschuss, 1=Matchschuss, 8=Finalschuss")]
    public int Schussart { get; set; }

    [Description("Bahnnummer des Schützen(1-9999)")]
    public int BahnNr { get; set; }

    [Description("Ringzahl(1.0 bis 10.9 oder 1 bis 10)")]
    public double SecondaryScore { get; set; }

    [Description("Anz. 100stel mm vom Zentrum entfernt")]
    public int Teiler { get; set; }

    [Description("Zeit des Schusses(HH:MM:SS)")]
    public DateTime Zeit { get; set; }

    [Description("1=Mouche, 0=keine Mouche")]
    public int Mouche { get; set; }

    [Description("X-Koordinate in mm(allenfalls mit neg.Vorzeichen)")]
    public double X { get; set; }

    [Description("Y-Koordinate in mm(allenfalls mit neg.Vorzeichen)")]
    public double Y { get; set; }

    [Description("1=innerhalb des gültigen Zeitrahmens, 0=ausserhalb")]
    public int InTime { get; set; }

    [Description("Zeit seit Beginn der Rot-/Grün-Phase, in 0.01s")]
    public double TimeSinceChange { get; set; }

    [Description("0=aus/links, 1=rechts, Richtung nur für Running target")]
    public int SweepDirection { get; set; }

    [Description("Demo-Modus(0=aus, 1=ein)")]
    public int Demonstration { get; set; }

    [Description("auf 0 basierender Index des Programms")]
    public int Match { get; set; }

    [Description("auf 0 basierender Index des Stichs")]
    public int Stich { get; set; }

    [Description("Datensatz manuell eingefügt=1; Datensatz ignorieren = 2")]
    public int InsDel { get; set; }

    [Description("Passentotal=1, Subtotal=2, Gesamttotal=4")]
    public int TotalArt { get; set; }

    [Description("0 oder 1 basierte Aufzählung der Schussgruppe.")]
    public int Gruppe { get; set; }

    [Description("Probeschüsse= 0, Einzelfeuer= 1, Seriefeuer= 2")]
    public int Feuerart { get; set; }

    [Description("Aufsteigende LogEvent-Nummer (ohne Header/Footer)")]
    public int LogEvent { get; set; }

    [Description("Schussart(3: Eigener Schuss, 10: Fremd-Schuss, 12: Illegaler Schuss")]
    public int LogTyp { get; set; }

    [Description("99999999 Zeit seit Anfangs Jahr in Hundertstel-Sekunden")]
    public long TimeStamp { get; set; }

    [Description("Aktuelle Ablösung")]
    public int Ablösung { get; set; }

    [Description("0:Waffentyp aus, 1-21:verschiedene Waffentypen")]
    public int Waffe { get; set; } //

    [Description("0:Position aus, 1:liegend, 2:stehend, 3:knieend, 4 liegend aufgelegt")]
    public int Position { get; set; }

    [Description("FF:undefiniert, alle anderen Nummern ensprechen der Definition in der Datei \"target.ini\"")]
    public string? TargetID { get; set; }

    [Description("Externe Nummer, mit welcher ein Benutzerstich identifiziert werden kann")]
    public string? ExterneNummer { get; set; }
}
