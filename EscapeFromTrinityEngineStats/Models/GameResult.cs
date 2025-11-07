using StatisticsApi.Models.Instances;
namespace StatisticsApi.Models
{
    public class GameResult
    {
        public bool Win;
        public int PlayerId;
        public string GameVersion = "";
        public int RoomsCompleted;
        public int LevelsCompleted;
        public virtual List<PassiveRecord> Passives { get; set; }
        public virtual List<CharacterInstance> Characters { get; set; }
        public virtual List<DeckRecord> Decks { get; set; }
        public virtual List<RoomRecord> Rooms { get; set; }
        public int RemainingGold;
        public int RemainingTeamwork;
        public string RunPerk;
        public BattleRecord RunEndingBattle;
    }
}
