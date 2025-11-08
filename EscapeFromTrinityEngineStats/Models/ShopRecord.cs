using EscapeFromTrinityEngineStats.Models.Instances;
using EscapeFromTrinityEngineStats.Models.Relationships;

namespace EscapeFromTrinityEngineStats.Models
{
    public class ShopRecord
    {
        public int Id { get; set; }
        public int GoldEntered { get; set; }
        public virtual List<ShopAffordableCard> AffordableCards { get; set; }
        public virtual List<CardInstance> PurchasedCards { get; set; }
        public virtual List<PassiveInstance> AffordablePassives { get; set; }
        public virtual List<PassiveInstance> PurchasedPassives { get; set; }
        public virtual RoomRecord RoomRecord { get; set; }
        public int GoldSpent { get; set; }
        public bool UpgradePurchased;
        public CardRecord? UpgradedCard;
    }
}
