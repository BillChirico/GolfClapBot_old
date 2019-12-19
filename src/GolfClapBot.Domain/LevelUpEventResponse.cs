namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class LevelUpEventResponse
    {
        public string type { get; set; }
        public LevelUpEventResponseData data { get; set; }
        public string ChannelId { get; set; }

        public Streamer Stream { get; set; }
    }

    public class LevelUpEventResponseData
    {
        public string message_id { get; set; }
        public string text { get; set; }
        public LevelUpEventResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class LevelUpEventResponseUser
    {
        public object avatar_url { get; set; }
        public string id { get; set; }
        public LevelUpEventResponseChannel_Xp channel_xp { get; set; }
        public string username { get; set; }
    }

    public class LevelUpEventResponseChannel_Xp
    {
        public int level { get; set; }
        public int xp { get; set; }
        public int xp_to_next_level { get; set; }
    }
}