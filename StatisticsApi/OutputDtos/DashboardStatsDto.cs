using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsApi.OutputDtos
{
    public class DashboardStatsDto
    {
        public int GamesPlayed { get; set; }
        public int TotalChoices { get; set; }
        public int CurrentWinrate { get; set; }
        public int CurrentVersion { get; set; }
    }
}
