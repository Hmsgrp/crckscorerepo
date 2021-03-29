using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace CricketScoreCardDB.DBClient
{
    public class DbClient : IDbClient
    {
        IConfiguration _iconfiguration;
        public DbClient(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public string GetConnectionString()
        {
            string cnstring = _iconfiguration.GetSection("ConnectionStrings").GetSection("Localdbconnection").Value;
            return cnstring;
        }
    }
}
