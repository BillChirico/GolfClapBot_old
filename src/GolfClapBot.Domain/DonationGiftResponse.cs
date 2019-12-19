namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class DonationGiftEventResponse
    {
        public string type { get; set; }
        public DonationGiftEventResponseData data { get; set; }

        public Streamer Stream { get; set; }
    }

    public class DonationGiftEventResponseData
    {
        public DonationGiftEventResponseGift gift { get; set; }
        public DonationGiftEventResponseRecipient recipient { get; set; }
        public string message_id { get; set; }
        public string text { get; set; }
        public DonationGiftEventResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class DonationGiftEventResponseGift
    {
        public string image_url { get; set; }
        public string name { get; set; }
        public int tfuel { get; set; }
        public bool enabled { get; set; }
    }

    public class DonationGiftEventResponseRecipient
    {
        public object avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class DonationGiftEventResponseUser
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }
}