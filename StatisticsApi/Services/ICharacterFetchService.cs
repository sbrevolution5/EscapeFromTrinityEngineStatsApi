using StatisticsApi.OutputDtos;

namespace StatisticsApi.Services
{
    public interface ICharacterFetchService
    {
        Task<CharacterPopularityOutputDto> GetCharacterPopularityAsync(int versionId = 0);
    }
}