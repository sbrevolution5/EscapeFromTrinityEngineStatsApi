using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    public class GameResultDto
    {
        public bool Win { get; set; }
        public int PlayerId{ get; set; }
        public string GameVersion { get; set; } = "";
        public int RoomsCompleted { get; set; }
        public int LevelsCompleted{ get; set; }
        public virtual List<PassiveRecordDto> PassiveDtos { get; set; } = [];
        public virtual List<CharacterRecordDto> CharacterDtos { get; set; } = [];
        public virtual List<RoomRecordDto> RoomDtos { get; set; } = [];
        public int RemainingGold { get; set; }
        public int RemainingTeamwork{ get; set; }
        public int TotalGoldEarned{ get; set; }
        public int TotalTeamworkEarned{ get; set; }
        public string RunPerk { get; set; } = "";
        public bool Abandoned { get; set; } = false;
    }
}
