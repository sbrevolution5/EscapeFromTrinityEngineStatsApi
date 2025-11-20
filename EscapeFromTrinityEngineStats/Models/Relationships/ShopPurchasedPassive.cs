using EscapeFromTrinityEngineStats.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.Relationships
{
    public class ShopPurchasedPassive
    {
        public int ShopRecordId { get; set; }
        public int PassiveInstanceId { get; set; }
        public virtual PassiveInstance PassiveInstance { get; set; }
    }
}
