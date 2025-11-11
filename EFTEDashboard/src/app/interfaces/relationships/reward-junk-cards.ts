import { CardRecord } from '../card-record';
import { RewardRecord } from '../reward-record';

export interface RewardJunkCards {
	rewardRecordId?: number;
	rewardRecord?: RewardRecord;
	cardRecordId?: number;
	cardRecord?: CardRecord;
}
