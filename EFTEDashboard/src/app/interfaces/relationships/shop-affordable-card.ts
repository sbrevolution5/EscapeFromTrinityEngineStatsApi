/* Relationship / join entities */

import { CardInstance } from '../Instances/card-instance';
import { ShopRecord } from '../shop-record';

export interface ShopAffordableCard {
	shopRecordId?: number;
	shopRecord?: ShopRecord;
	cardInstanceId?: number;
	cardInstance?: CardInstance;
}
