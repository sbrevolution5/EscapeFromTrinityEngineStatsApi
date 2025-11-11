import { CardInstance } from "./Instances/card-instance";

export interface CardRecord {
  id?: number;
  cardInstance?: CardInstance;
  partySlot?: number;
}

