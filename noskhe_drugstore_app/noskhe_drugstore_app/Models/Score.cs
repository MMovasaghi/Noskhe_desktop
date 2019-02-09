using System;

namespace noskhe_drugstore_app.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int CustomerSatisfaction { get; set; }
        public int RankAmongPharmacies { get; set; }
        public int PackingAverageTimeInSeconds { get; set; }
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}