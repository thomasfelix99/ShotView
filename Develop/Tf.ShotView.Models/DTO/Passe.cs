using Tf.ShotView.Models.Db;

namespace Tf.ShotView.Models.DTO;
    public class Passe
    {
        public string Id { get; set; }
        public bool Match { get; set; }
        public double TotalScore { get; set; }

        IList<RawShot> Shots { get; set; }
    }
