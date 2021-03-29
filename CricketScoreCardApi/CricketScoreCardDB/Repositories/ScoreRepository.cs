using System;
using System.Collections.Generic;
using System.Text;
using CricketScoreCardDB.DataAccess;
using System.Linq;
using CricketScoreCardDB.Models;
using Microsoft.Data.SqlClient;
using CricketScoreCardDB.DBClient;

namespace CricketScoreCardDB.Repositories
{
    public class ScoreRepository: IScoreRepository
    {
        public DBContext dbContext;
        public IDbClient dbclient;
        public ScoreRepository(DBContext dbContext, IDbClient dbclient)
        {
            this.dbContext = dbContext;
            this.dbclient = dbclient;
        }


        public void AddScore(Scores Score)
        {
            try
            {
                var existing = (from rec in dbContext.Set<Scores>()
                                where rec.MatchID == Score.MatchID && rec.PlayerID == Score.PlayerID
                                select rec).SingleOrDefault();

                if(existing == null)
                {
                    if (Score.Score > 0)
                    {
                        dbContext.Add(Score);
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("User is already added in this Match");
                }        
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void updateScore(Scores score)
        {
            try
            {
                var existing = (from rec in dbContext.Set<Scores>()
                                where rec.ID == score.ID
                                select rec).SingleOrDefault();

                if (score.Score > 0)
                {
                    existing.Score = score.Score;
                    existing.Balls = score.Balls;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<ScoreResult> GetScores()
        {
            try
            {
                var queryResult = new List<ScoreResult>();

                using (var sqlConnection = new SqlConnection(this.dbclient.GetConnectionString()))
                {

                    using (var cmd = new SqlCommand())
                    {
                        sqlConnection.Open();

                        cmd.CommandText = "GetScores";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection;

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ScoreResult SR = new ScoreResult();

                           SR.PlayerID = reader.GetInt32(0);
                           SR.TeamID = reader.GetInt32(1);
                           SR.MatchID = reader.GetInt32(2);
                           SR.ScoreID = reader.GetInt32(3);
                           SR.PlayerName = reader.GetString(4);
                           SR.TeamName = reader.GetString(5);
                           SR.MatchName = reader.GetString(6);
                           SR.Balls = reader.GetInt32(7);
                           SR.Score = reader.GetInt32(8);

                           queryResult.Add(SR);
                        }
                    }
                }
                return queryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteScore(int id)
        {
            try
            {
                var val = new Scores { ID = id };
                dbContext.Score.Remove(val);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
