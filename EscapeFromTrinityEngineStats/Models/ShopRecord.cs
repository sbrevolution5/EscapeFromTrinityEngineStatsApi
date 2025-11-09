using EscapeFromTrinityEngineStats.Models.Instances;
using EscapeFromTrinityEngineStats.Models.Relationships;

namespace EscapeFromTrinityEngineStats.Models
{
    public class ShopRecord
    {
        public int Id { get; set; }
        public int GoldEntered { get; set; }
        public virtual List<ShopAffordableCard> AffordableCards { get; set; }
        public virtual List<ShopPurchasedCard> PurchasedCards { get; set; }
        public virtual List<ShopAffordablePassive> AffordablePassives { get; set; }
        public virtual List<ShopPurchasedPassive> PurchasedPassives { get; set; }
        public int GoldSpent { get; set; }
        public bool UpgradePurchased { get; set; }
        public CardRecord? UpgradedCard { get; set; }
    }
}
