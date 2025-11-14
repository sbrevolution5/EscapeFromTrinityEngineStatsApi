import { CharacterRecord } from './character-record';
import { GameVersion } from './game-version';
import { PassiveRecord } from './passive-record';
import { RoomRecord } from './room-record';

export interface GameResult {
	id?: number;
	win?: boolean;
	playerId?: number;
	gameVersionId?: number;
	gameVersion?: GameVersion;
	roomsCompleted?: number;
	levelsCompleted?: number;
	passives?: PassiveRecord[];
	characters?: CharacterRecord[];
	rooms?: RoomRecord[];
	remainingGold?: number;
	remainingTeamwork?: number;
	totalGoldEarned?: number;
	totalTeamworkEarned?: number;
	runPerk?: string;
	abandon: boolean;
}
