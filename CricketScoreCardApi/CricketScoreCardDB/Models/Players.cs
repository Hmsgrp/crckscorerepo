using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricketScoreCardDB.Models
{
    [Table("Players")]
    public class Players
    {
        [Key]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int TeamID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
