using System;
using System.Collections.Generic;
using System.Text;
using CricketScoreCardDB.Models;

namespace CricketScoreCardDB.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(Users user);
        public List<Users> GetUsers();
        public void DeleteUser(int id);
        public Users GetUsersLoginAuth(string Username, string Password);
        public List<SummaryInfo> GetSumaryInfo();
        public List<Summary> GetSumary();
    }
}
