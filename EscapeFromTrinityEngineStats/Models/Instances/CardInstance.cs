using System.ComponentModel.DataAnnotations;

namespace EscapeFromTrinityEngineStats.Models.Instances
{
    public class CardInstance
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
