import { PassiveInstance } from "./Instances/passive-instance";

export interface PassiveRecord {
  id?: number;
  passiveInstance?: PassiveInstance;
  partySlot?: number;
}

