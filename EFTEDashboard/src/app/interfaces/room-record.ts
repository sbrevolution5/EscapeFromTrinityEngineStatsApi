import { BattleRecord } from "./battle-record";
import { EventRecord } from "./event-record";
import { RewardRecord } from "./reward-record";
import { ShopRecord } from "./shop-record";

export interface RoomRecord {
  id?: number;
  floorNumber?: number;
  levelNumber?: number;
  battleRecord?: BattleRecord | null;
  eventRecord?: EventRecord | null;
  shopRecord?: ShopRecord | null;
  rewardRecord?: RewardRecord | null;
}

