namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class ChatEventResponse
    {
        public string type { get; set; }
        public ChatEventResponseData data { get; set; }
        public Streamer Stream { get; set; }
    }

    public class ChatEventResponseData
    {
        public string message_id { get; set; }
        public string text { get; set; }
        public ChatEventResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class ChatEventResponseUser
    {
        public string[] auth_types { get; set; }
        public ChatEventResponseSub sub { get; set; }
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public Channel_Xp channel_xp { get; set; }
        public string username { get; set; }
        public string unw { get; set; }
    }

    public class ChatEventResponseSub
    {
        public string subscription_status { get; set; }
        public int count { get; set; }
        public string id { get; set; }
        public long current_period_end { get; set; }
    }

    public class Channel_Xp
    {
        public int level { get; set; }
        public int xp { get; set; }
        public int xp_to_next_level { get; set; }
    }
}