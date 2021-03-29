using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CricketScoreCardDB.Models
{
    public class ScoreResult
    {
        [Key]
        public int PlayerID { get; set; }
        public int TeamID { get; set; }
        public int MatchID { get; set; }
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
        public string MatchName { get; set; }
        public int ScoreID { get; set; }
        public int Balls { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
