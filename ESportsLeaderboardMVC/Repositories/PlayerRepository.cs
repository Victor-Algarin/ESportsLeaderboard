using ESportsLeaderboardMVC.Models;
using ESportsLeaderboardMVC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ESportsLeaderboardMVC.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IConfiguration _config;

        public PlayerRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public async Task<List<Player>> GetListOfPLayersAsync()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Player";
                conn.Open();
                var result = await conn.QueryAsync<Player>(sQuery);
                return result.ToList();
            }
        }
    }
}
