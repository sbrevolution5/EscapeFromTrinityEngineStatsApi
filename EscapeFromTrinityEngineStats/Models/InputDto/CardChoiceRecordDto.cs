using EscapeFromTrinityEngineStats.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    public class CardChoiceRecordDto
    {
        public virtual List<string> CardChoices { get; set; }
        public virtual string CardPicked { get; set; }
        public int LevelNumber { get; set; }
        public int FloorNumber{ get; set; }
        public int RerollCount{ get; set; }
        public virtual List<string> RerolledCards { get; set; }
        public bool UpgradePicked { get; set; }
        public bool DuplicatePicked{ get; set; }
        public int TeamworkSpent{ get; set; }
    }
}
