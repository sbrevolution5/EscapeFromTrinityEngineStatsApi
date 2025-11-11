import { CardInstance } from "../Instances/card-instance";
import { ShopRecord } from "../shop-record";

export interface ShopPurchasedCard {
  shopRecordId?: number;
  shopRecord?: ShopRecord;
  cardInstanceId?: number;
  cardInstance?: CardInstance;
}

