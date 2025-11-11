using EscapeFromTrinityEngineStats.Models.Instances;

namespace EscapeFromTrinityEngineStats.Models
{
    public class EventRecord
    {
        public int Id { get; set; }
        public int VersionId { get; set; }

        public virtual GameVersion Version { get; set; }

        public virtual EventInstance EventInstance { get; set; } 
        public int TeamworkOnEnter { get; set; }
        public int ChoiceSelected { get; set; }
    }
}
