import { CardRecord } from "./card-record";
import { GameVersion } from "./game-version";
import { ShopAffordableCard } from "./relationships/shop-affordable-card";
import { ShopAffordablePassive } from "./relationships/shop-affordable-passive";
import { ShopPurchasedCard } from "./relationships/shop-purchased-card";
import { ShopPurchasedPassive } from "./relationships/shop-purchased-passive";

export interface ShopRecord {
  id?: number;
  goldEntered?: number;
  versionId?: number;
    version?: GameVersion;
  affordableCards?: ShopAffordableCard[];
  purchasedCards?: ShopPurchasedCard[];
  affordablePassives?: ShopAffordablePassive[];
  purchasedPassives?: ShopPurchasedPassive[];
  goldSpent?: number;
  upgradePurchased?: boolean;
  upgradedCard?: CardRecord | null;
}

