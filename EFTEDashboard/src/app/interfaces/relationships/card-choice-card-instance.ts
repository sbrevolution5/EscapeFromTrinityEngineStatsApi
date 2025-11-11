import { CardChoiceRecord } from '../card-choice-record';
import { CardInstance } from '../Instances/card-instance';

export interface CardChoiceCardInstance {
	cardChoiceRecordId?: number;
	cardChoiceRecord?: CardChoiceRecord;
	cardInstanceId?: number;
	cardInstance?: CardInstance;
}
