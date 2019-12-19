namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class GiveItemEventResponse
    {
        public string type { get; set; }
        public DonationGiftResponseData data { get; set; }
        public Streamer Stream { get; set; }
    }

    public class DonationGiftResponseData
    {
        public object note { get; set; }
        public DonationGiftResponseItem item { get; set; }
        public DonationGiftResponseRecipient recipient { get; set; }
        public string message_id { get; set; }
        public string text { get; set; }
        public DonationGiftResponseUser user { get; set; }
        public long timestamp { get; set; }
    }

    public class DonationGiftResponseItem
    {
        public string name { get; set; }
        public string id { get; set; }
        public string thumbnail_url { get; set; }
    }

    public class DonationGiftResponseRecipient
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }

    public class DonationGiftResponseUser
    {
        public string avatar_url { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }
}