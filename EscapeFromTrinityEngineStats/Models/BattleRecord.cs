using EscapeFromTrinityEngineStats.Models.Instances;

namespace EscapeFromTrinityEngineStats.Models
{
    public class BattleRecord
    {
        public int Id { get; set; }
        public virtual BattleInstance BattleInstance { get; set; }
        public int FloorEncountered;
        public int LevelEncountered;
        public int Character1HpStart;
        public int Character2HpStart;
        public int Character3HpStart;
        public int CharacterResting;
        public int Character1HpEnd;
        public int Character2HpEnd;
        public int Character3HpEnd;
        public int Character1DamageDealt;
        public int Character2DamageDealt;
        public int Character3DamageDealt;
        public int Character1CardsPlayed;
        public int Character2CardsPlayed;
        public int Character3CardsPlayed;
        public int TeamworkStart;
        public int TeamworkEnd;
        public bool Character1Downed;
        public bool Character2Downed;
        public bool Character3Downed;
        public int GoldGained;
        public int RoundsElapsed;
    }
}
