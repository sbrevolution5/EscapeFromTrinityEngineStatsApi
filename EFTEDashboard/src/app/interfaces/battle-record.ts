import { BattleInstance } from "./Instances/battle-instance";

export interface BattleRecord {
  id?: number;
  battleInstance?: BattleInstance;
  floorEncountered?: number;
  levelEncountered?: number;
  character1HpStart?: number;
  character2HpStart?: number;
  character3HpStart?: number;
  characterResting?: number;
  character1HpEnd?: number;
  character2HpEnd?: number;
  character3HpEnd?: number;
  character1DamageDealt?: number;
  character2DamageDealt?: number;
  character3DamageDealt?: number;
  character1CardsPlayed?: number;
  character2CardsPlayed?: number;
  character3CardsPlayed?: number;
  teamworkStart?: number;
  teamworkEnd?: number;
  character1Downed?: boolean;
  character2Downed?: boolean;
  character3Downed?: boolean;
  goldGained?: number;
  roundsElapsed?: number;
}

