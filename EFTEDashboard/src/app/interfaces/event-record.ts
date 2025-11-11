import { GameVersion } from "./game-version";
import { EventInstance } from "./Instances/event-instance";

export interface EventRecord {
  id?: number;
  versionId?: number;
    version?: GameVersion;
  eventInstance?: EventInstance;
  teamworkOnEnter?: number;
  choiceSelected?: number;
}

