using StatisticsApi.Models.Instances;

namespace StatisticsApi.Models
{
    public class CharacterRecord
    {
        public int Id { get; set; }
        public virtual CharacterInstance CharacterInstance { get; set; }
        public virtual List<CardRecord> DeckRecord { get; set; }
        public int PartySlot { get; set; }
    }
}
