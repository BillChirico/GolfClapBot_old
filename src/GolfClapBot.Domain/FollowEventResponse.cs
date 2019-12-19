namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class FollowEventResponse
    {
        public Streamer Stream { get; set; }
        public string type { get; set; }
        public FollowEventResponseData data { get; set; }
    }

    public class FollowEventResponseData
    {
        public string message_id { get; set; }
        public string text { get; set; }
        public FollowEventResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class FollowEventResponseUser
    {
        public string id { get; set; }
        public string username { get; set; }
    }
}