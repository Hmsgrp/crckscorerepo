using System;
using System.Collections.Generic;
using System.Text;
using CricketScoreCardDB.Models;

namespace CricketScoreCardDB.Repositories
{
    public interface IPlayerRepository
    {
        public void AddPlayer(Players player);
        public void updatePlayer(Players player);
        public List<PlayerTeamResultSet> GetPlayers();
        public void DeletePlayer(int id);
    }
}
