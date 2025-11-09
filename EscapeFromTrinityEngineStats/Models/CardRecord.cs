using EscapeFromTrinityEngineStats.Models.Instances;

namespace EscapeFromTrinityEngineStats.Models
{
    public class CardRecord
    {
        public int Id { get; set; }
        public virtual CardInstance CardInstance { get; set; }
        public int PartySlot { get; set; } = -1;
    }
}
