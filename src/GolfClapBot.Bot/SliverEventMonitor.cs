using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PotatoSquad.Lib.Sliver.MessageObjects;
using PubnubApi;

namespace GolfClapBot.Bot
{
    public class SliverEventMonitor : IDisposable
    {
        private const string Chat_Message = "chat_message";
        private const string Chat_SystemMessage = "system_chat_message";
        private const string Chat_Donation = "donation";
        private const string Chat_DonationGift = "donation_gift";
        private const string Chat_Follow = "follow";
        private const string Chat_Subscribe = "subscribe";
        private const string Chat_HelloMessage = "hello_message";
        private const string Chat_Raffle = "raffle";
        private const string Chat_RaffleWinner = "raffle_winner";
        private const string Chat_Quiz = "quiz";
        private const string Chat_GrantItem = "gift_item";
        private const string Chat_LevelUp = "level_up";

        private static readonly Regex messageTypeReg =
            new Regex("\\\"type\\\":\\\"([a-z_0-9]+)\\\"", RegexOptions.Compiled);

        private readonly ILogger log;

        private SubscribeCallbackExt callbackHandler;
        private PNConfiguration pnConfiguration;
        private Pubnub pubnub;

        public SliverEventMonitor(ILogger<SliverEventMonitor> logger)
        {
            log = logger;

            pnConfiguration = new PNConfiguration
            {
                SubscribeKey = "sub-c-0d05b2d2-6fa7-11e6-8a59-0619f8945a4f",
                PublishKey = string.Empty,
                LogVerbosity = PNLogVerbosity.BODY
            };

            pubnub = new Pubnub(pnConfiguration);
            callbackHandler = GetPubnubCallbackHandler();
            pubnub.AddListener(callbackHandler);
        }

        public Func<string, bool> OnRawEvent { get; set; }

        public Func<ChatEventResponse, bool> OnChat_HelloMessage { get; set; }
        public Func<ChatEventResponse, bool> OnChat_Message { get; set; }
        public Func<DonationEventResponse, bool> OnChat_Donation { get; set; }
        public Func<DonationGiftEventResponse, bool> OnChat_DonationGift { get; set; }
        public Func<FollowEventResponse, bool> OnChat_Follow { get; set; }
        public Func<SubGiftEventResponseRootobject, bool> OnChat_Subscribe { get; set; }
        public Func<SubGiftEventResponseRootobject, bool> OnChat_SubscribeGift { get; set; }
        public Func<string, bool> OnChat_Raffle { get; set; }
        public Func<string, bool> OnChat_RaffleWinner { get; set; }
        public Func<string, bool> OnChat_Quiz { get; set; }
        public Func<GiveItemEventResponse, bool> OnChat_GrantItem { get; set; }
        public Func<LevelUpEventResponse, bool> OnChat_LevelUp { get; set; }
        private List<Streamer> Channels { get; set; } = new List<Streamer>();

        private SubscribeCallbackExt GetPubnubCallbackHandler()
        {
            return callbackHandler = new SubscribeCallbackExt(
                (pubnubObj, messageResult) =>
                {
                    if (messageResult?.Message == null) return;

                    var jsonString = messageResult.Message.ToString();
                    var streamerId = messageResult.Channel.Split(".".ToCharArray())[1];

                    TranslatePubNubResponseToSliverObjects(Channels.Find(a => a.Id == streamerId), jsonString);
                },
                (pubnubObj, presencResult) =>
                {
                    if (presencResult != null)
                    {
                        //todo hook up channel presence
                    }
                },
                (pubnubObj, statusResult) =>
                {
                    if (statusResult.Category == PNStatusCategory.PNConnectedCategory)
                    {
                    }
                }
            );
        }

        private void TranslatePubNubResponseToSliverObjects(Streamer stream, string jsonString)
        {
            // grab the type via a regex so we don't need to deserialize twice

            var messageType = messageTypeReg.Match(jsonString).Groups[1].Value;

            if (messageType.Contains("chat_message")) messageType = "chat_message";

            Task.Run(() => { FireRawEvent(jsonString); });

            switch (messageType)
            {
                case Chat_HelloMessage:

                    Task.Run(() =>
                    {
                        var helloResponse =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<ChatEventResponse>(jsonString);

                        helloResponse.Stream = stream;

                        OnChat_HelloMessage?.Invoke(helloResponse);
                    });
                    break;
                case Chat_Message:
                    Task.Run(() =>
                    {
                        var chatResponse =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<ChatEventResponse>(jsonString);
                        chatResponse.Stream = stream;
                        OnChat_Message?.Invoke(chatResponse);
                    });
                    break;
                case Chat_Donation:
                    Task.Run(() =>
                    {
                        var donoResponse =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<DonationEventResponse>(jsonString);
                        donoResponse.Stream = stream;

                        OnChat_Donation?.Invoke(donoResponse);
                    });
                    break;
                case Chat_DonationGift:
                    Task.Run(() =>
                    {
                        var donoGiftResponse =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<DonationGiftEventResponse>(jsonString);
                        donoGiftResponse.Stream = stream;

                        OnChat_DonationGift?.Invoke(donoGiftResponse);
                    });
                    break;
                case Chat_Follow:
                    Task.Run(() =>
                    {
                        var followResponse =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<FollowEventResponse>(jsonString);
                        followResponse.Stream = stream;

                        OnChat_Follow?.Invoke(followResponse);
                    });
                    break;
                case Chat_Subscribe:
                    Task.Run(() =>
                    {
                        var SubEventResponseobj =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<SubGiftEventResponseRootobject>(jsonString);
                        SubEventResponseobj.Stream = stream;

                        OnChat_Subscribe?.Invoke(SubEventResponseobj);
                    });

                    break;
                    //case Chat_SubscribeGift:
                    //    Task.Run(() =>
                    //    {
                    //        var SubGiftEventResponseobj = pubnub.JsonPluggableLibrary.DeserializeToObject<SubGiftEventResponseRootobject>(jsonString);
                    //        SubGiftEventResponseobj.Stream = stream;

                    //        if (OnChat_Subscribe != null)
                    //            OnChat_SubscribeGift.Invoke(SubGiftEventResponseobj);
                    //    });

                    break;
                case Chat_Raffle:

                    Task.Run(() => { OnChat_Raffle?.Invoke(jsonString); });

                    break;
                case Chat_RaffleWinner:
                    Task.Run(() => { OnChat_RaffleWinner?.Invoke(jsonString); });

                    break;
                case Chat_Quiz:
                    Task.Run(() => { OnChat_Quiz?.Invoke(jsonString); });

                    break;
                case Chat_GrantItem:
                    Task.Run(() =>
                    {
                        var grantItemResponse =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<GiveItemEventResponse>(jsonString);
                        grantItemResponse.Stream = stream;

                        OnChat_GrantItem?.Invoke(grantItemResponse);
                    });

                    break;
                case Chat_LevelUp:
                    Task.Run(() =>
                    {
                        var lvlUpResponse =
                            pubnub.JsonPluggableLibrary.DeserializeToObject<LevelUpEventResponse>(jsonString);
                        lvlUpResponse.Stream = stream;

                        OnChat_LevelUp?.Invoke(lvlUpResponse);
                    });
                    break;
            }
        }

        private void FireRawEvent(string jsonString)
        {
            OnRawEvent?.Invoke(jsonString);
        }

        public void AddChannel(Streamer streamer)
        {
            log.LogDebug($"SliverEventMonitor - AddChannel - chat.{streamer.Id}");
            if (streamer == null) throw new ArgumentNullException(nameof(streamer));

            var chatChannel = $"chat.{streamer.Id}";
            if (Channels.Find(a => a.Id == streamer.Id) == null)
            {
                Channels.Add(streamer);
                if (Channels.Count > 0)
                    pubnub.Subscribe<string>()
                        .Channels(Channels.Select(a => "chat." + a.Id).ToArray()).Execute();
            }
        }

        public void RemoveChannel(Streamer streamer)
        {
            if (streamer == null) throw new ArgumentNullException(nameof(streamer));

            var chatChannel = $"chat.{streamer.Id}";
            if (Channels.Contains(streamer))
            {
                Channels.Remove(streamer);
                if (Channels.Count > 0)
                    //pubnub.UnsubscribeAll<string>();
                    pubnub.Subscribe<string>()
                        .Channels(Channels.Select(a => "chat." + a.Id).ToArray()).Execute();
            }
        }

        public void Start()
        {
            log.LogDebug($"SliverEventMonitor - Start - {string.Join(",", Channels)}");
            pubnub.Subscribe<string>()
                .Channels(Channels.Select(a => "chat." + a.Id).ToArray()).Execute();
        }

        public void Stop()
        {
            pubnub.UnsubscribeAll<string>();
        }

        #region IDisposable Support

        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) return;
            if (disposing)
            {
                Stop();
                pubnub.Disconnect<string>();
                pubnub = null;
                pnConfiguration = null;
                Channels = null;
                OnRawEvent = null;
                OnChat_HelloMessage = null;
                OnChat_Message = null;
                OnChat_Donation = null;
                OnChat_DonationGift = null;
                OnChat_Follow = null;
                OnChat_Subscribe = null;
                OnChat_Raffle = null;
                OnChat_RaffleWinner = null;
                OnChat_Quiz = null;
                OnChat_GrantItem = null;
                OnChat_LevelUp = null;
            }

            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }

    public class PlatformPubnubLog : IPubnubLog
    {
        private readonly string logFilePath = "";

        public PlatformPubnubLog()
        {
            // Get folder path may vary based on environment
            var folder = Directory.GetCurrentDirectory(); //For console
            //string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // For iOS
            Debug.WriteLine(folder);
            logFilePath = Path.Combine(folder, "pubnubmessaging.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
        }

        public void WriteToLog(string log)
        {
            //Save to text file or DB or any storage
            Trace.WriteLine(log);
            Trace.Flush();
        }
    }
}