using System;
using System.Collections.Generic;
using System.Text;
using CricketScoreCardDB.Models;

namespace CricketScoreCardDB.Repositories
{
    public interface IMatchRepository
    {
        public void AddMatch(Matches Match);
        public void updateMatch(Matches Match);
        public List<Matches> GetMatches();
        public void DeleteMatch(int id);
    }
}
