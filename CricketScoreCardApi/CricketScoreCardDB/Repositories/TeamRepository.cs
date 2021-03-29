using CricketScoreCardDB.DataAccess;
using CricketScoreCardDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CricketScoreCardDB.Repositories
{
    public class TeamRepository: ITeamRepository
    {
        public DBContext dbContext;
        public TeamRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddTeam(Teams Team)
        {
            try
            {
                if (!string.IsNullOrEmpty(Team.TeamName))
                {
                    dbContext.Add(Team);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void updateTeam(Teams Team)
        {
            try
            {
                var existing = (from rec in dbContext.Set<Teams>()
                                where rec.TeamID == Team.TeamID
                                select rec).SingleOrDefault();

                if (!string.IsNullOrEmpty(Team.TeamName))
                {
                    existing.TeamName = Team.TeamName;
                    existing.UpdatedDate = DateTime.Now;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Teams> GetTeams()
        {
            try
            {
                var result = (from Teamval in dbContext.Set<Teams>()
                              where Teamval.status == true
                              orderby Teamval.CreatedDate ascending
                              select Teamval).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteTeam(int id)
        {
            try
            {
                var tm = new Teams { TeamID = id };
                dbContext.Team.Remove(tm);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
