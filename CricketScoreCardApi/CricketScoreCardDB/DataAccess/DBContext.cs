using CricketScoreCardDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CricketScoreCardDB.DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        { }

        public DbSet<Teams> Team { get; set; }
        public DbSet<Matches> Match { get; set; }
        public DbSet<Players> player { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Scores> Score { get; set; }
        public DbSet<Users> User { get; set; }
    }
}
