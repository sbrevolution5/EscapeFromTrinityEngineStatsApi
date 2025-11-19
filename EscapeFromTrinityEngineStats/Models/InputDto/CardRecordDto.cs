using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    public class CardRecordDto
    {
        public string Name { get; set; }
        public int PartySlot { get; set; } = -1;
        public int Rarity { get; set; }
        public string CharacterName { get; set; }
    }
}
