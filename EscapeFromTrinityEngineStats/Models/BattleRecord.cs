using EscapeFromTrinityEngineStats.Models.Instances;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscapeFromTrinityEngineStats.Models
{
    public class BattleRecord
    {
        public int Id { get; set; }
        public int VersionId { get; set; }

        public virtual GameVersion Version { get; set; }
        public virtual BattleInstance BattleInstance { get; set; }
        public int FloorEncountered { get; set; }
        public int LevelEncountered { get; set; }
        public int Character1HpStart { get; set; }
        public int Character2HpStart { get; set; }
        public int Character3HpStart { get; set; }
        public int CharacterResting { get; set; }
        public int Character1HpEnd { get; set; }
        public int Character2HpEnd { get; set; }
        public int Character3HpEnd { get; set; }
        public int Character1DamageDealt { get; set; }
        public int Character2DamageDealt { get; set; }
        public int Character3DamageDealt { get; set; }
        public int Character1CardsPlayed { get; set; }
        public int Character2CardsPlayed { get; set; }
        public int Character3CardsPlayed { get; set; }
        public int TeamworkStart { get; set; }
        public int TeamworkEnd { get; set; }
        public bool Character1Downed { get; set; }
        public bool Character2Downed { get; set; }
        public bool Character3Downed { get; set; }
        public int GoldGained { get; set; }
        public int RoundsElapsed { get; set; }
    }
}
