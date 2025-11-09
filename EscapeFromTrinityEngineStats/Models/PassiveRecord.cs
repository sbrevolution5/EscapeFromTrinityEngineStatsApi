using EscapeFromTrinityEngineStats.Models.Instances;

namespace EscapeFromTrinityEngineStats.Models
{
    public class PassiveRecord
    {
        public int Id { get; set; }
        public virtual PassiveInstance PassiveInstance { get; set; }
        public int PartySlot { get; set; } = -1;
    }
}