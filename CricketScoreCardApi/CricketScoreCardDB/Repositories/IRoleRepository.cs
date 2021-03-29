using System;
using System.Collections.Generic;
using System.Text;
using CricketScoreCardDB.Models;

namespace CricketScoreCardDB.Repositories
{
    public interface IRoleRepository
    {
        public void AddRole(Roles Role);
        public void updateRole(Roles Role);
        public List<Roles> GetRoles();
        public void DeleteRole(int id);
    }
}
