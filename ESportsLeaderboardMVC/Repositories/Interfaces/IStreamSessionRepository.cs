using ESportsLeaderboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESportsLeaderboardMVC.Repositories.Interfaces
{
    public interface IStreamSessionRepository
    {
        Task<StreamSession> GetStreamSessionByPlayerIdAsync(int playerID);
    }
}
