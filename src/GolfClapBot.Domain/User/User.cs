using System;
using System.Collections.Generic;
using GolfClapBot.Domain.Channel;

namespace GolfClapBot.Domain.User
{
    public class User
    {
        public List<string> AuthTypes { get; set; }
        public Uri AvatarUrl { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public ChannelXp ChannelXp { get; set; }
        public string Username { get; set; }
        public string Unw { get; set; }
    }
}