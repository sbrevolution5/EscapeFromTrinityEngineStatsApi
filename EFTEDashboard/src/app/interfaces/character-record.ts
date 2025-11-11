import { CardRecord } from "./card-record";
import { CharacterInstance } from "./Instances/character-instance";

export interface CharacterRecord {
  id?: number;
  characterInstance?: CharacterInstance;
  deckRecord?: CardRecord[];
  partySlot?: number;
}

