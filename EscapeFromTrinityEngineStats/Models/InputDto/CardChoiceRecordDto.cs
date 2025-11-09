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
        public int LevelNumber;
        public int FloorNumber;
        public int RerollCount;
        public virtual List<string> RerolledCards { get; set; }
        public bool UpgradePicked;
        public bool DuplicatePicked;
        public int TeamworkSpent;
    }
}
