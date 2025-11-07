using StatisticsApi.Models;
using StatisticsApi.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    internal class ShopRecordDto
    {
        public int GoldEntered { get; set; }
        public virtual List<string> AffordableCards { get; set; }
        public virtual List<string> PurchasedCards { get; set; }
        public virtual List<string> AffordablePassives { get; set; }
        public virtual List<string> PurchasedPassives { get; set; }
        public int GoldSpent { get; set; }
        public bool UpgradePurchased;
        public CardRecordDto? UpgradedCard;
    }
}
