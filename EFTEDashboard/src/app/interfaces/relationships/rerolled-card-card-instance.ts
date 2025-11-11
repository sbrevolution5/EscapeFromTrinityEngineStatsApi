import { CardChoiceRecord } from "../card-choice-record";
import { CardInstance } from "../Instances/card-instance";

export interface RerolledCardCardInstance {
  cardChoiceRecordId?: number;
  cardChoiceRecord?: CardChoiceRecord;
  cardInstanceId?: number;
  cardInstance?: CardInstance;
}
