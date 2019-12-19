namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class SubGiftEventResponseRootobject
    {
        public string type { get; set; }
        public SubGiftEventResponseData data { get; set; }
        public string ChannelId { get; set; }

        public Streamer Stream { get; set; }
    }

    public class SubGiftEventResponseData
    {
        public SubGiftEventResponseSub sub { get; set; }
        public SubGiftEventResponseRecipient recipient { get; set; }
        public string message_id { get; set; }
        public string text { get; set; }
        public SubGiftEventResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class SubGiftEventResponseSub
    {
        public string subscription_status { get; set; }
        public SubGiftEventResponseGifter gifter { get; set; }
        public int count { get; set; }
        public string id { get; set; }
        public long current_period_end { get; set; }
    }

    public class SubGiftEventResponseGifter
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class SubGiftEventResponseRecipient
    {
        public object avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class SubGiftEventResponseUser
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }
}