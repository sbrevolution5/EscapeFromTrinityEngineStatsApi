import { PassiveInstance } from '../Instances/passive-instance';
import { ShopRecord } from '../shop-record';

export interface ShopPurchasedPassive {
	shopRecordId?: number;
	shopRecord?: ShopRecord;
	passiveInstanceId?: number;
	passiveInstance?: PassiveInstance;
}
