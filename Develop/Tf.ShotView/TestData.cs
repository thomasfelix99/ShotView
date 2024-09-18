namespace Tf.ShotView;

internal static class TestData
{
    public class TestShot
    {
        public int TargetNr { get; set; }
        public double Score { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    private static int idx = -1;
    public static TestShot NextShot()
    {
        idx += 1;
        if (idx > Shots.Count - 1)
        {
            idx = 0;
        }
        return Shots[idx];
    }

    private static readonly List<TestShot> Shots = new List<TestShot>()
    {
        new() { TargetNr = 1, Score = 10.9, X = 0, Y = 0 },
        new() { TargetNr = 1, Score = 9.1, X = 2.64371, Y = -3.79727 },
        new() { TargetNr = 2, Score = 5.9, X = 10.51955, Y = 7.00189 },
        new() { TargetNr = 3, Score = 9.4, X = 3.05522, Y = -2.44362 },
        new() { TargetNr = 4, Score = 8.3, X = 5.19471, Y = -4.02973 },
        new() { TargetNr = 5, Score = 5.3, X = 2.77162, Y = 13.74946 },
        new() { TargetNr = 6, Score = 6.5, X = 10.60858, Y = 3.29231 },
        new() { TargetNr = 1, Score = 6, X = 9.67583, Y = 7.77909 },
        new() { TargetNr = 2, Score = 4.6, X = 3.45563, Y = 15.46212 },
        new() { TargetNr = 3, Score = 9.4, X = 3.77978, Y = 0.00171 },
        new() { TargetNr = 4, Score = 7, X = 1.37325, Y = 9.70313 },
        new() { TargetNr = 5, Score = 3, X = 19.9608, Y = -0.77755 },
        new() { TargetNr = 6, Score = 5.7, X = 11.74952, Y = -5.96822 },
        new() { TargetNr = 1, Score = 5.7, X = 13.06337, Y = -2.11839 },
        new() { TargetNr = 2, Score = 7.5, X = 2.50716, Y = 8.2082 },
        new() { TargetNr = 3, Score = 6.2, X = -9.06073, Y = 7.60117 },
        new() { TargetNr = 4, Score = 7.2, X = 5.3055, Y = 7.76126 },
        new() { TargetNr = 5, Score = 4.2, X = -16.07418, Y = 4.85168 },
        new() { TargetNr = 6, Score = 2.6, X = 20.62155, Y = 2.93121 },
        new() { TargetNr = 1, Score = 6.4, X = -3.22838, Y = -10.91962 },
        new() { TargetNr = 2, Score = 7.4, X = 8.7431, Y = 1.01071 },
        new() { TargetNr = 3, Score = 7.8, X = 7.92637, Y = 0.9578 },
        new() { TargetNr = 4, Score = 7.7, X = -7.70937, Y = 2.31179 },
        new() { TargetNr = 5, Score = 9.1, X = 3.10495, Y = -3.57266 },
        new() { TargetNr = 6, Score = 8.3, X = -3.09172, Y = 5.94921 },
        new() { TargetNr = 1, Score = 8.1, X = -6.59302, Y = 2.40565 },
        new() { TargetNr = 2, Score = 10, X = 0.1752, Y = 2.39115 },
        new() { TargetNr = 3, Score = 8.8, X = 5.20679, Y = 1.1702 },
        new() { TargetNr = 4, Score = 5.1, X = 14.46792, Y = 2.16128 },
        new() { TargetNr = 5, Score = 10.8, X = -0.25032, Y = -0.25575 },
        new() { TargetNr = 6, Score = 8.5, X = 3.66517, Y = -5.02927 },
        new() { TargetNr = 1, Score = 6.5, X = 9.19012, Y = -6.30674 },
        new() { TargetNr = 2, Score = 7.4, X = 8.55756, Y = -2.22099 },
        new() { TargetNr = 3, Score = 7.8, X = 0.27996, Y = 7.89165 },
        new() { TargetNr = 4, Score = 8.1, X = 4.57947, Y = -5.3412 },
        new() { TargetNr = 5, Score = 7.7, X = -2.83387, Y = 7.64543 },
        new() { TargetNr = 6, Score = 9.7, X = -1.98499, Y = -2.38394 },
        new() { TargetNr = 1, Score = 7.3, X = 6.14145, Y = -6.86396 },
        new() { TargetNr = 2, Score = 4.8, X = -14.42303, Y = 5.4251 },
        new() { TargetNr = 3, Score = 8, X = -6.61224, Y = 3.43441 },
        new() { TargetNr = 4, Score = 5.2, X = 13.91585, Y = 3.30021 },
        new() { TargetNr = 5, Score = 4.4, X = -16.3885, Y = -1.66595 },
        new() { TargetNr = 6, Score = 9.3, X = 3.30145, Y = -2.44723 },
        new() { TargetNr = 1, Score = 5.4, X = -11.99652, Y = 6.75337 },
        new() { TargetNr = 2, Score = 8.9, X = 2.58744, Y = 4.34245 },
        new() { TargetNr = 3, Score = 6.5, X = -6.10347, Y = 9.28637 },
        new() { TargetNr = 4, Score = 8.6, X = 4.57943, Y = -3.55907 },
        new() { TargetNr = 5, Score = 8, X = 7.17005, Y = 1.91862 },
        new() { TargetNr = 6, Score = 10.1, X = 1.82124, Y = 1.23155 },
        new() { TargetNr = 1, Score = 6.8, X = -9.90234, Y = 3.41422 },
        new() { TargetNr = 2, Score = 8.1, X = 2.19465, Y = 6.76166 },
        new() { TargetNr = 3, Score = 8.1, X = 1.88463, Y = 6.90532 },
        new() { TargetNr = 4, Score = 8.6, X = -3.55559, Y = 4.68583 },
        new() { TargetNr = 5, Score = 6.1, X = -12.01423, Y = 0.38851 },
    };

}
