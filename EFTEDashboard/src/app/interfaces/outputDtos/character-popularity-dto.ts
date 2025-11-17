export interface CharacterPopularityDto {
	characters: CharacterInstancePopularityOutputDto[];
	totalGames: number;
	specificVersion: boolean;
	versionId: number;
}
export interface CharacterInstancePopularityOutputDto {
	name: string;
	plays: number;
	wins: number;
}
