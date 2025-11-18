export interface BattleStatsOutputDto {
    battleObjects: BattleInstanceOutputDto[];
    versionId: number;
    versionName: string;
}
export interface BattleInstanceOutputDto {
    name: string;
    numberOfBattles: number;
    wins: number;
    winrate:number;
    tier: number;
    averageTurnsElapsed: number;
    averageDamageTaken: number;
    averageDamageTakenWhenInactive: number;
    averageDamageDealt: number;
    averageFloor: number;
    restingRatio: number;
    averageTeamworkGained: number;
    averageCardsPlayed: number;
    characterDownedRatio: number;
    averageNumberOfDowns: number;
}
