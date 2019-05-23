using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESportsLeaderboardMVC.Models
{
    public class StreamSession
    {
        public int SessionID { get; set; }
        public int PlayerID { get; set; }
        public DateTime SessionDate { get; set; }
        public int CurrentViewerCount { get; set; }
        public int TotalSessionViews { get; set; }
        public TimeSpan SessionTime { get; set; }
        public TimeSpan SessionTotalTimeViewed { get; set; }

    }
}
