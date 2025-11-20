using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EscapeFromTrinityEngineStats.Models.Instances
{
    public class CardInstance
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rarity { get; set; }
        public int? CharacterInstanceId { get; set; }
        
        [JsonIgnore]
        public virtual CharacterInstance CharacterInstance { get; set; }
    }
}
