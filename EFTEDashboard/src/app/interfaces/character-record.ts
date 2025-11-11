import { CardRecord } from "./card-record";
import { GameVersion } from "./game-version";
import { CharacterInstance } from "./Instances/character-instance";

export interface CharacterRecord {
  id?: number;
  versionId?: number;
    version?: GameVersion;
  characterInstance?: CharacterInstance;
  deckRecord?: CardRecord[];
  partySlot?: number;
}

