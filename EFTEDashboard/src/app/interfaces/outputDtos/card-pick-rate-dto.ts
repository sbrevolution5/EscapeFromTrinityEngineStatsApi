export interface CardPickRateDto {
    versionId: number;
    versionName: string;
    cardInstanceId: number;
    cardName: string;
    availableCount: number;
    pickedCount: number;
    pickRate: number; // 0..1
}
