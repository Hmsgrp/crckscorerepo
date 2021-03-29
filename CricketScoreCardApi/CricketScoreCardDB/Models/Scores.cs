using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricketScoreCardDB.Models
{
    [Table("Scores")]
    public class Scores
    {
        [Key]
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int MatchID { get; set; }
        public int Balls { get; set; }
        public int Score { get; set; }
    }
}
