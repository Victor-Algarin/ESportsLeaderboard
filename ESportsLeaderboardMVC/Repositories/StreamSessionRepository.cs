using Dapper;
using ESportsLeaderboardMVC.Models;
using ESportsLeaderboardMVC.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ESportsLeaderboardMVC.Repositories
{
    public class StreamSessionRepository : IStreamSessionRepository
    {
        private readonly IConfiguration _config;

        public StreamSessionRepository(IConfiguration config)
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
        public async Task<StreamSession> GetStreamSessionByPlayerIdAsync(int playerID)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT SessionID,  CurrentViewerCount, TotalSessionViews FROM StreamSession WHERE PlayerID = @PlayerID";
                conn.Open();
                var result = await conn.QueryAsync<StreamSession>(sQuery, new { PlayerID = playerID });
                return result.FirstOrDefault();
            }
        }
    }
}
