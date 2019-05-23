using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESportsLeaderboardMVC.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Handle { get; set; }
        public int TotalSubscribers { get; set; }
        public int TotalViewers { get; set; }
        public TimeSpan TotalTimeViewed { get; set; }
        public TimeSpan TotalTimeStreamed { get; set; }
        public int CurrentRank { get; set; }
        public int HighestRank { get; set; }
    }
}
