using System.ComponentModel.DataAnnotations;

namespace EscapeFromTrinityEngineStats.Models.Instances
{
    public class CardInstance
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rarity { get; set; }
        public bool Junk { get; set; }
        public int? CharacterId { get; set; }
        public virtual CharacterInstance Character { get; set; }
    }
}
