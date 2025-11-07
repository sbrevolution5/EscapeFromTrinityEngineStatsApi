using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    public class GameResultDto
    {
        public bool Win;
        public int PlayerId;
        public string GameVersion = "";
        public int RoomsCompleted;
        public int LevelsCompleted;
        public virtual List<PassiveRecordDto> PassiveDtos { get; set; }
        public virtual List<CharacterRecordDto> CharacterDtos { get; set; }
        public virtual List<RoomRecordDto> RoomDtos { get; set; }
        public int RemainingGold;
        public int RemainingTeamwork;
        public int TotalGoldEarned;
        public int TotalTeamworkEarned;
        public string RunPerk;
    }
}
