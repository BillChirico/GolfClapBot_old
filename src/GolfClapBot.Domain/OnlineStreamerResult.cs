namespace PotatoSquad.Lib.Sliver.MessageObjects
{
    public class OnlineStreamerResult
    {
        public string status { get; set; }
        public Body[] body { get; set; }
    }

    public class Body
    {
        public string user_id { get; set; }
        public string live_stream_id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public long score { get; set; }
        public long timestamp { get; set; }
        public Live_Stream live_stream { get; set; }
        public object programs { get; set; }
        public bool has_auto_trivia { get; set; }
        public object trivia_game_id { get; set; }
        public bool visible { get; set; }
        public string status { get; set; }
        public bool subscribed_twitch { get; set; }
        public User1 user { get; set; }
        public int follows { get; set; }
        public string source { get; set; }
        public string streamer_id { get; set; }
        public StreamerObj streamer { get; set; }
    }

    public class Live_Stream
    {
        public string id { get; set; }
        public string game_id { get; set; }
        public Game game { get; set; }
        public string title { get; set; }
        public int score { get; set; }
        public int duration { get; set; }
        public object description { get; set; }
        public int view_count { get; set; }
        public int like_count { get; set; }
        public int live_count { get; set; }
        public int comment_count { get; set; }
        public long timestamp { get; set; }
        public object[] tags { get; set; }
        public object[] rich_tags { get; set; }
        public Video_Urls[] video_urls { get; set; }
        public Video_Url_Map video_url_map { get; set; }
        public string thumbnail_url { get; set; }
        public User user { get; set; }
        public object _event { get; set; }
        public int status { get; set; }
        public Stats stats { get; set; }
        public bool featured { get; set; }
        public bool visible { get; set; }
        public bool rewarding { get; set; }
        public int base_reward_amount { get; set; }
        public object reward_amount { get; set; }
        public object milliseconds_to_next_reward { get; set; }
        public object raffle { get; set; }
        public object quizzes { get; set; }
        public bool use_theta { get; set; }
    }

    public class Game
    {
        public string id { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int score { get; set; }
        public string thumbnail_url { get; set; }
        public string banner_url { get; set; }
        public string category_url { get; set; }
        public string logo_url { get; set; }
        public string twitch_id { get; set; }
        public object featured_videos { get; set; }
    }

    public class Video_Url_Map
    {
        public _2D _2d { get; set; }
    }

    public class _2D
    {
        public string _360p { get; set; }
        public string master { get; set; }
        public string source720p60 { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public object username { get; set; }
        public string avatar_url { get; set; }
        public object type { get; set; }
        public object subscriber_count { get; set; }
        public object subscription_count { get; set; }
        public object upload_count { get; set; }
    }

    public class Stats
    {
    }

    public class Video_Urls
    {
        public string name { get; set; }
        public string icon_url { get; set; }
        public string type { get; set; }
        public string resolution { get; set; }
        public string url { get; set; }
    }

    public class User1
    {
        public string id { get; set; }
        public string username { get; set; }
        public string avatar_url { get; set; }
        public string type { get; set; }
        public object subscriber_count { get; set; }
        public object subscription_count { get; set; }
        public object upload_count { get; set; }
    }

    public class StreamerObj
    {
        public string id { get; set; }
        public string username { get; set; }
        public string avatar_url { get; set; }
        public string type { get; set; }
        public object subscriber_count { get; set; }
        public object subscription_count { get; set; }
        public object upload_count { get; set; }
    }
}