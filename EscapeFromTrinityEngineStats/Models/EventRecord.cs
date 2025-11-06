namespace StatisticsApi.Models
{
    public class EventRecord
    {
        public int Id {  get; set; }
        public int TeamworkOnEnter;
        public int ChoiceSelected;
        public List<int> AvailableChoices;
    }
}
