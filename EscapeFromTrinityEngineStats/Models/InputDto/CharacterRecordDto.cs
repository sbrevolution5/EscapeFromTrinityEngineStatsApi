using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    public class CharacterRecordDto
    {
        public string Name { get; set; }
        public virtual List<CardRecordDto> DeckRecord { get; set; } = [];
        public int PartySlot { get; set; }
    }
}
