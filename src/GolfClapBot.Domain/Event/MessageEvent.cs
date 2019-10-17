namespace GolfClapBot.Domain.Event
{
    public class MessageEvent
    {
        public Message.Message Message { get; set; }
        public double Timetoken { get; set; }
        public string Publisher { get; set; }
        public string Channel { get; set; }
        public object Subscription { get; set; }
        public object UserMetadata { get; set; }
    }
}