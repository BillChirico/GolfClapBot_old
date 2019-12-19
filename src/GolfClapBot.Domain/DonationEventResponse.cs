namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class DonationEventResponse
    {
        public string type { get; set; }
        public DonationEventResponseData data { get; set; }
        public Streamer Stream { get; set; }
    }

    public class DonationEventResponseData
    {
        public string note { get; set; }
        public DonationEventResponseSender sender { get; set; }
        public DonationEventResponseRecipient recipient { get; set; }
        public string tfuel { get; set; }
        public string message_id { get; set; }
        public DonationEventResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class DonationEventResponseSender
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class DonationEventResponseRecipient
    {
        public object avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class DonationEventResponseUser
    {
    }
}