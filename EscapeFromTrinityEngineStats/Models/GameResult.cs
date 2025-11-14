using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.Instances;
namespace EscapeFromTrinityEngineStats.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public bool Win { get; set; }
        public int PlayerId { get; set; }
        public int GameVersionId { get; set; }
        public virtual GameVersion GameVersion { get; set; }
        public int RoomsCompleted { get; set; }
        public int LevelsCompleted { get; set; }
        public virtual List<PassiveRecord> Passives { get; set; } = [];
        public virtual List<CharacterRecord> Characters { get; set; } = [];
        public virtual List<RoomRecord> Rooms { get; set; } = [];
        public int RemainingGold { get; set; }
        public int RemainingTeamwork { get; set; }
        public int TotalGoldEarned { get; set; }
        public int TotalTeamworkEarned { get; set; }
        public string RunPerk { get; set; }
        public bool Abandoned { get; set; } = false;
    }
}
