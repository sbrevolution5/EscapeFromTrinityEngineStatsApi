import { GameVersion } from "./game-version";
import { CardInstance } from "./Instances/card-instance";

export interface CardChoiceRecord {
  id?: number;
  versionId?: number;
  version?: GameVersion;
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

