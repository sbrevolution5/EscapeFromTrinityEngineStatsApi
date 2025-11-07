namespace EscapeFromTrinityEngineStats.Models.Instances
{
    public class EventChoiceInstance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual EventInstance Event { get; set; }
    }
}
