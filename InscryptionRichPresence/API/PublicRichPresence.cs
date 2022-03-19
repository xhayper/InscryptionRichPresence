using DiscordRPC.Events;
using DiscordRPC.Unity;
using DiscordRPC;
using System;

namespace InscryptionRichPresence.API
{
    public static class PublicRichPresence
    {
        internal static DiscordRpcClient client
        {
            get { return Plugin.client; }
            set { Plugin.client = value; }
        }

        public static RichPresence CurrentPresence { get { return client.CurrentPresence; } }

        public static bool IsInitialized { get { return client.IsInitialized; } }

        public static event OnReadyEvent OnReady
        {
            add { client.OnReady += value; }
            remove { client.OnReady -= value; }
        }

        public static event OnCloseEvent OnClose
        {
            add { client.OnClose += value; }
            remove { client.OnClose -= value; }
        }

        public static event OnErrorEvent OnError
        {
            add { client.OnError += value; }
            remove { client.OnError -= value; }
        }

        public static event OnPresenceUpdateEvent OnPresenceUpdate
        {
            add { client.OnPresenceUpdate += value; }
            remove { client.OnPresenceUpdate -= value; }
        }

        public static void SetPresence(RichPresence richPresence)
        {
            client.SetPresence(richPresence);
        }

        public static void ClearPresence()
        {
            client.ClearPresence();
        }

        public static void SetApplicationID(string applicationID)
        {
            if (client != null) client.Dispose();
            client = new DiscordRpcClient(applicationID, -1, null, false, new UnityNamedPipe());
            Initialize();
        }

        public static RichPresence UpdateClearTime()
        {
            return client.UpdateClearTime();
        }

        public static RichPresence UpdateDetails(string details)
        {
            return client.UpdateDetails(details);
        }

        public static RichPresence UpdateEndTime(DateTime time)
        {
            return client.UpdateEndTime(time);
        }

        public static RichPresence UpdateEndTime()
        {
            return client.UpdateEndTime();
        }

        public static RichPresence UpdateLargeAsset(string key = null, string tooltip = null)
        {
            return client.UpdateLargeAsset(key, tooltip);
        }

        public static RichPresence UpdateSmallAsset(string key = null, string tooltip = null)
        {
            return client.UpdateSmallAsset(key, tooltip);
        }

        public static RichPresence UpdateStartTime(DateTime time)
        {
            return client.UpdateStartTime(time);
        }

        public static RichPresence UpdateStartTime()
        {
            return client.UpdateStartTime();
        }

        public static RichPresence UpdateState(string state)
        {
            return client.UpdateState(state);
        }

        internal static void Initialize()
        {
            client.SkipIdenticalPresence = true;
            client.Initialize();
            API.PublicRichPresence.SetPresence(new RichPresence()
            {
                State = "Loading...",
            });
            EventHandler.SubscribeEvent();
        }
    }
}