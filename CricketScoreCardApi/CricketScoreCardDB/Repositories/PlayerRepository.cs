using CricketScoreCardDB.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CricketScoreCardDB.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.Common;
using CricketScoreCardDB.DBClient;



namespace CricketScoreCardDB.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public DBContext dbContext;
        public IDbClient dbclient;
        public PlayerRepository(DBContext dbContext,IDbClient dbclient)
        {
            this.dbContext = dbContext;
            this.dbclient = dbclient;
        }

        public void AddPlayer(Players Player)
        {
            try
            {
                if (!string.IsNullOrEmpty(Player.PlayerName))
                {
                    dbContext.Add(Player);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void updatePlayer(Players player)
        {
            try
            {
                var existing = (from rec in dbContext.Set<Players>()
                                where rec.PlayerID == player.PlayerID
                                select rec).SingleOrDefault();

                if (!string.IsNullOrEmpty(player.PlayerName))
                {
                    existing.PlayerName = player.PlayerName;
                    existing.UpdatedDate = DateTime.Now;
                    existing.TeamID = player.TeamID;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<PlayerTeamResultSet> GetPlayers()
        {
            try
            {
                var queryResult = new List<PlayerTeamResultSet>();
            
                using (var sqlConnection = new SqlConnection(this.dbclient.GetConnectionString()))
                {

                    using (var cmd = new SqlCommand())
                    {
                        sqlConnection.Open();

                        cmd.CommandText = "GetPlayer";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection;

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            PlayerTeamResultSet PTS = new PlayerTeamResultSet();

                            PTS.PlayerID = reader.GetInt32(0);
                            PTS.TeamID = reader.GetInt32(1);
                            PTS.PlayerName = reader.GetString(2);
                            PTS.TeamName = reader.GetString(3);

                            queryResult.Add(PTS);
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

        public void DeletePlayer(int id)
        {
            try
            {
                var val = new Players { PlayerID = id };
                dbContext.player.Remove(val);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
