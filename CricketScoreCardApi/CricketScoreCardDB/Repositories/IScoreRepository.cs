using System;
using System.Collections.Generic;
using System.Text;
using CricketScoreCardDB.Models;

namespace CricketScoreCardDB.Repositories
{
    public interface IScoreRepository
    {
        public void AddScore(Scores score);
        public void updateScore(Scores score);
        public List<ScoreResult> GetScores();
        public void DeleteScore(int id);
    }
}
