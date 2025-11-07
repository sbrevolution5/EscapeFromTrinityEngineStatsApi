namespace EscapeFromTrinityEngineStats.Models.Instances
{
    public class EventInstance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<EventChoiceInstance> EventChoices { get; set; }
    }
}
