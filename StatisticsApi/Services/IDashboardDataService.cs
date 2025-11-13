using StatisticsApi.OutputDtos;

namespace StatisticsApi.Services
{
    public interface IDashboardDataService
    {
        public Task<DashboardStatsDto> GetDashboardStatsAsync();
    }
}
