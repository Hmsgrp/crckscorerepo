using System;
using System.Collections.Generic;
using System.Text;

namespace CricketScoreCardDB.Models
{
    public class PlayerTeamResultSet
    {
        public int PlayerID { get; set; }
        public int TeamID { get; set; }
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
    }
}
