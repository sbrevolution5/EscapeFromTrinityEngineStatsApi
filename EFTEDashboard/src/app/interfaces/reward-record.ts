import { CardChoiceRecord } from './card-choice-record';
import { GameVersion } from './game-version';
import { PassiveRecord } from './passive-record';
import { RewardGivenTradeCards } from './relationships/reward-given-trade-cards';
import { RewardJunkCards } from './relationships/reward-junk-cards';
import { RewardRecievedTradeCards } from './relationships/reward-recieved-trade-cards';
import { RewardRemovedCards } from './relationships/reward-removed-cards';
import { RewardUpgradedCards } from './relationships/reward-upgraded-cards';

export interface RewardRecord {
	id?: number;
	versionId?: number;
	version?: GameVersion;
	passiveRecords?: PassiveRecord[];
	cardChoiceRecords?: CardChoiceRecord[];
	upgradedCards?: RewardUpgradedCards[];
	removedCards?: RewardRemovedCards[];
	givenTradeCards?: RewardGivenTradeCards[];
	recievedTradeCards?: RewardRecievedTradeCards[];
	junkRewards?: RewardJunkCards[];
}
