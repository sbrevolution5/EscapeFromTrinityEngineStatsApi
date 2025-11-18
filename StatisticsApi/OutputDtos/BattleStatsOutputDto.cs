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
        public int Wins { get; set; } = 0;
        public double Winrate { get; set; } = 0.0;
        public int Tier { get; set; } = 0;
        public double AverageTurnsElapsed { get; set; } = 0.0;
        public double AverageDamageTaken { get; set; } = 0.0;
        public double AverageDamageTakenWhenInactive { get; set; } = 0.0;
        public double AverageDamageDealt { get; set; } = 0.0;
        public double AverageFloor { get; set; } = 0.0;
        public double RestingRatio { get; set; } = 0.0;
        public double AverageTeamworkGained { get; set; } = 0.0;
        public double AverageCardsPlayed { get; set; } = 0.0;
        public double CharacterDownedRatio { get; set; } = 0.0;
        public double AverageNumberOfDowns { get; set; } = 0.0;
    }
}
