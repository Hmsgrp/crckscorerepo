using CricketScoreCardDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CricketScoreCardDB.Repositories
{
    public interface ITeamRepository
    {
        public void AddTeam(Teams Team);
        public void updateTeam(Teams Team);
        public List<Teams> GetTeams(); 
        public void DeleteTeam(int id);
    }
}
