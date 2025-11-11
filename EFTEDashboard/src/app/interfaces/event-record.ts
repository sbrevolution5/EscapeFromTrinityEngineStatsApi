import { EventInstance } from "./Instances/event-instance";

export interface EventRecord {
  id?: number;
  eventInstance?: EventInstance;
  teamworkOnEnter?: number;
  choiceSelected?: number;
}

