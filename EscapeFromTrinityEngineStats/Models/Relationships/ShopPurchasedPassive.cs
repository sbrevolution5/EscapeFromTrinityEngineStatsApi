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
        public ShopRecord ShopRecord { get; set; }

        public int PassiveRecordId { get; set; }
        public PassiveRecord PassiveRecord { get; set; }
    }
}
