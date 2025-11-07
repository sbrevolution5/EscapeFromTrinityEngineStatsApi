using EscapeFromTrinityEngineStats.Models.Instances;

namespace EscapeFromTrinityEngineStats.Models
{
    public class PassiveRecord
    {
        public int Id;
        public virtual PassiveInstance PassiveInstance { get; set; }
        public int PartySlot = -1;
    }
}
