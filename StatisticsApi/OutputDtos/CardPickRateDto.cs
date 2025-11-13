using System;

namespace StatisticsApi.OutputDtos
{
    public class CardPickRateDto
    {
        public int VersionId { get; set; }
        public string VersionName { get; set; } = string.Empty;
        public int CardInstanceId { get; set; }
        public string CardName { get; set; } = string.Empty;
        public int AvailableCount { get; set; }
        public int PickedCount { get; set; }
        public double PickRate { get; set; } // 0..1
    }
}