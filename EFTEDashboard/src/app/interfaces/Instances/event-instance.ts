import { EventChoiceInstance } from "./event-choice-instance";

export interface EventInstance {
  id?: number;
  name?: string;
  eventChoices?: EventChoiceInstance[];
}

