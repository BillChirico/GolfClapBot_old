namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class SubEventResponse
    {
        public string type { get; set; }
        public SubEventResponseData data { get; set; }
        public string ChannelId { get; set; }

        public Streamer Stream { get; set; }
    }

    public class SubEventResponseData
    {
        public SubEventResponseSub sub { get; set; }
        public SubEventResponseRecipient recipient { get; set; }
        public string message_id { get; set; }
        public string text { get; set; }
        public SubEventResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class SubEventResponseSub
    {
        public string subscription_status { get; set; }
        public SubEventResponseGifter gifter { get; set; }
        public int count { get; set; }
        public string id { get; set; }
        public long current_period_end { get; set; }
    }

    public class SubEventResponseGifter
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class SubEventResponseRecipient
    {
        public object avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class SubEventResponseUser
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }
}