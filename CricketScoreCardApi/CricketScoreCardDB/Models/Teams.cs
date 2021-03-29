using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CricketScoreCardDB.Models
{
    [Table("Teams")]
    public class Teams
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool status { get; set; }
    }
}
