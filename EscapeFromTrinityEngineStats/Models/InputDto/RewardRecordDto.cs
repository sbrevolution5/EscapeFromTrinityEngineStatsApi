using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    public class RewardRecordDto
    {
        public int GoldGained;
        public virtual List<CardChoiceRecordDto> CardChoiceRecordDtos { get; set; }
        public virtual List<PassiveRecordDto> PassiveRecordDtos { get; set; }
        public virtual List<CardRecordDto> UpgradedCards { get; set; }
        public virtual List<CardRecordDto> RemovedCards { get; set; }
        public virtual List<CardRecordDto> GivenTradeCards { get; set; }
        public virtual List<CardRecordDto> RecievedTradeCards { get; set; }
    }
}
