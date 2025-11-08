using EscapeFromTrinityEngineStats.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.Relationships
{
    public class ShopPurchasedCard
    {
        public int ShopRecordId { get; set; }
        public ShopRecord ShopRecord { get; set; }

        public int CardInstanceId { get; set; }
        public CardInstance CardInstance { get; set; }
    }
}
