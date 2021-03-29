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
    public class UserRepository: IUserRepository
    {
        public IDbClient dbclient;
        public DBContext dbContext;
        public UserRepository(DBContext dbContext, IDbClient dbclient)
        {
            this.dbContext = dbContext;
            this.dbclient = dbclient;
        }


        public void AddUser(Users user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Users> GetUsers()
        {
            try
            {
                var result = (from val in dbContext.Set<Users>()
                              where val.Status == true
                              orderby val.CreatedDate ascending
                              select val).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Users GetUsersLoginAuth(string Username,string Password)
        {
            try
            {
                var result = (from val in dbContext.Set<Users>()
                              where val.Status == true && val.UserName == Username && val.Password == Password
                              orderby val.CreatedDate ascending
                              select val).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteUser(int id)
        {
            try
            {
                var val = new Users { UserID = id };
                dbContext.User.Remove(val);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<SummaryInfo> GetSumaryInfo()
        {
            try
            {
                var queryResult = new List<SummaryInfo>();

                using (var sqlConnection = new SqlConnection(this.dbclient.GetConnectionString()))
                {

                    using (var cmd = new SqlCommand())
                    {
                        sqlConnection.Open();

                        cmd.CommandText = "GetSummaryInfo";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection;

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            SummaryInfo SR = new SummaryInfo();

                            SR.Players = reader.GetInt32(0);
                            SR.Teams = reader.GetInt32(1);
                            SR.Matches = reader.GetInt32(2);

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
    }
}
