namespace Tf.ShotView.Models;

public class Shot
{
    public bool Match { get; set; }
    public int Nr { get; set; }
    public int ManualEntryShotNr { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Result { get; set; }
    public double SecondaryResult { get; set; }
    public DateTime Time { get; set; }
    public int Lane { get; set; }
    public string? RawData { get; set; }

    public string DisplayString => $"{Result} - {SecondaryResult:F1}";

    public static Shot? CreateShot(string recData)
    {
        string[] strArray = recData.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if ((strArray.Length >= 0x10) && (StringToInt(strArray[7]) == 3))
        {
            int lane = StringToInt(strArray[2]);
            int nr = StringToInt(strArray[13]);
            DateTime time = StringToDateTime(strArray[6]);
            double result = StringToDouble(strArray[10]);
            double secondaryResult = StringToDouble(strArray[11]) / 10;
            bool match = (StringToInt(strArray[9]) & 0x20) == 0;
            double x = StringToDouble(strArray[14]) * 1000;
            double y = StringToDouble(strArray[15]) * 1000;

            return new Shot()
            {
                RawData = recData,
                Match = match,
                Nr = nr,
                ManualEntryShotNr = 0,
                X = x,
                Y = y,
                Result = result,
                SecondaryResult = secondaryResult,
                Time = time,
                Lane = lane
            };
        }

        return null;
    }


    private static int StringToInt(string str)
    {
        int.TryParse(str, out var num);
        return num;
    }

    private static double StringToDouble(string text)
    {
        text = text.Replace(',', '.');
        double.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var result);
        return result;
    }

    private static DateTime StringToDateTime(string str)
    {
        DateTime.TryParse(str, out var time);
        return time;
    }

}
