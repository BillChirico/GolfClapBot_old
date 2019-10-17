namespace GolfClapBot.Domain.Message
{
    public class MessageData
    {
        public string MessageId { get; set; }
        public string Text { get; set; }
        public User.User User { get; set; }
        public long Timestamp { get; set; }
    }
}