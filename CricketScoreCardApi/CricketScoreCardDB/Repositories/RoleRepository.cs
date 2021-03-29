using System;
using System.Collections.Generic;
using System.Text;
using CricketScoreCardDB.DataAccess;
using System.Linq;
using CricketScoreCardDB.Models;

namespace CricketScoreCardDB.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public DBContext dbContext;
        public RoleRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void AddRole(Roles Role)
        {
            try
            {
                if (!string.IsNullOrEmpty(Role.RoleName))
                {
                    dbContext.Add(Role);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void updateRole(Roles roles)
        {
            try
            {
                var existing = (from rec in dbContext.Set<Roles>()
                                where rec.RoleID == roles.RoleID
                                select rec).SingleOrDefault();

                if (!string.IsNullOrEmpty(roles.RoleName))
                {
                    existing.RoleName = roles.RoleName;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Roles> GetRoles()
        {
            try
            {
                var result = (from val in dbContext.Set<Roles>()
                              select val).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteRole(int id)
        {
            try
            {
                var val = new Roles { RoleID = id };
                dbContext.Role.Remove(val);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
