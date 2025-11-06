using StatisticsApi.Models.Instances;

namespace StatisticsApi.Models
{
    public class CardRecord
    {
        public int Id { get; set; }
        public virtual CardInstance CardInstance { get; set; }
        public int PartySlot = -1;
    }
}
