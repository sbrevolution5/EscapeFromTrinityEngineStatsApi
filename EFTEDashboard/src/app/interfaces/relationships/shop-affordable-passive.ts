import { PassiveInstance } from '../Instances/passive-instance';
import { ShopRecord } from '../shop-record';

export interface ShopAffordablePassive {
	shopRecordId?: number;
	shopRecord?: ShopRecord;
	passiveInstanceId?: number;
	passiveInstance?: PassiveInstance;
}
