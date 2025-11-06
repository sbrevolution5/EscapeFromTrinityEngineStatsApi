namespace StatisticsApi.Models
{
    public class DeckRecord
    {
        public int Id { get; set; }
        public int PartySlot = -1;
        public List<CardRecord> Contents = new List<CardRecord>();
    }
}
