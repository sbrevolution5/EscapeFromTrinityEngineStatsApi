using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.Relationships
{
    public class RewardGivenTradeCards
    {
        public int RewardRecordId { get; set; }
        public int CardRecordId { get; set; }
        public CardRecord CardRecord { get; set; }
    }
}
