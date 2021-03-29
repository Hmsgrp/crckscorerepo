using System;
using System.Collections.Generic;
using System.Text;

namespace CricketScoreCardDB.DBClient
{
    public interface IDbClient
    {
        public string GetConnectionString();
    }
}
