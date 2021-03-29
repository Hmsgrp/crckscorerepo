using CricketScoreCardDB.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CricketScoreCardDB.Models;

namespace CricketScoreCardDB.Repositories
{
    public class MatchRepository: IMatchRepository
    {
        public DBContext dbContext;
        public MatchRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddMatch(Matches Match)
        {
            try
            {
                if (!string.IsNullOrEmpty(Match.MatchName))
                {
                    dbContext.Add(Match);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void updateMatch(Matches match)
        {
            try
            {
                var existing = (from rec in dbContext.Set<Matches>()
                                where rec.MatchID == match.MatchID
                                select rec).SingleOrDefault();

                if (!string.IsNullOrEmpty(match.MatchName))
                {
                    existing.MatchName = match.MatchName;
                    existing.UpdatedDate = DateTime.Now;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Matches> GetMatches()
        {
            try
            {
                var result = (from val in dbContext.Set<Matches>()
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

        public void DeleteMatch(int id)
        {
            try
            {
                var val = new Matches { MatchID = id };
                dbContext.Match.Remove(val);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
