using StatisticsApi.OutputDtos;

namespace StatisticsApi.Services
{
    public interface ICardPickRateService
    {
        Task<List<CardPickRateDto>> GetCardPickRatesAsync(int? versionId = null);
    }
}