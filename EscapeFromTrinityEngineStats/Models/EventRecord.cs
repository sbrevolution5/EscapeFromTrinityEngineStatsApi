using StatisticsApi.Models.Instances;

namespace StatisticsApi.Models
{
    public class EventRecord
    {
        public int Id {  get; set; }
        public virtual EventInstance EventInstance { get; set; }
        public int TeamworkOnEnter;
        public int ChoiceSelected;
    }
}
