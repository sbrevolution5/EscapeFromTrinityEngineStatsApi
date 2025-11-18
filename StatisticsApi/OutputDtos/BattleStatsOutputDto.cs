namespace StatisticsApi.OutputDtos
{
    public class BattleStatsOutputDto
    {
        public List<BattleInstanceOutputDto> BattleObjects = new();
        public int VersionId = 0;
        public string VersionName = "";
    }
    public class BattleInstanceOutputDto
    {
        public string Name { get; set; } = "";
        public int NumberOfBattles { get; set; }
        public int Wins { get; set; }
        public double Winrate { get; set; }
        public int Tier {  get; set; }
        public double AverageTurnsElapsed { get; set; }
        public double AverageDamageTaken { get; set; }
        public double AverageDamageTakenWhenInactive { get; set; }
        public double AverageDamageDealt { get; set; }
        public double AverageFloor { get; set; }
        public double RestingRatio { get; set; }
        public double AverageTeamworkGained { get; set; }
        public double AverageCardsPlayed { get; set; }
        public double CharacterDownedRatio { get; set; }
        public double AverageNumberOfDowns { get; set; }
    }
}
