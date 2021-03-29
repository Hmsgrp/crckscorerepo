using System;
using System.Collections.Generic;
using System.Text;

namespace CricketScoreCardDB.Models
{
    public class Summary
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public string TeamName { get; set; }
        public string MatchName { get; set; }
    }
}
