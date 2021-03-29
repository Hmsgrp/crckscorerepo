using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricketScoreCardDB.Models
{
    [Table("Matches")]
    public class Matches
    {
        [Key]
        public int MatchID { get; set; }
        public string MatchName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
