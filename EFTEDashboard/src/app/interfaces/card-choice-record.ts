import { CardInstance } from "./Instances/card-instance";

export interface CardChoiceRecord {
  id?: number;
  cardChoices?: CardInstance[];
  cardPicked?: CardInstance;
  levelNumber?: number;
  floorNumber?: number;
  rerollCount?: number;
  rerolledCards?: CardInstance[];
  upgradePicked?: boolean;
  duplicatePicked?: boolean;
  teamworkSpent?: number;
}

