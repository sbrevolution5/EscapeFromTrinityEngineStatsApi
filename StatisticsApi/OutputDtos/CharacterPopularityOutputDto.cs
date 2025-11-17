namespace StatisticsApi.OutputDtos
{
    public class CharacterPopularityOutputDto
    {
        public List<CharacterInstancePopularityOutputDto> Characters { get; set; }= new List<CharacterInstancePopularityOutputDto>();
        public int TotalGames { get; set; }
        public bool SpecificVersion = false;
        public int? VersionId { get; set; } = 0;    
    }
    public class CharacterInstancePopularityOutputDto
    {
        public string Name;
        public int Plays;
        public int Wins;
    }
}
