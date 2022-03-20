using System.Collections.Generic;
using DiscordRPC;

namespace InscryptionRichPresence
{
    internal static class Utility
    {
        internal static void SetStatus(string state, Timestamps timestamp = null)
        {
            if (Plugin.client == null) return;
            if (timestamp == null) timestamp = Plugin.startTimestamps;
            API.PublicRichPresence.SetPresence(new RichPresence()
            {
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "Inscryption"
                },
                Buttons = (new List<DiscordRPC.Button> { new DiscordRPC.Button() {
                    Label = "Buy Inscryption",
                    Url = "https://store.steampowered.com/app/1092790/Inscryption/"
                }}).ToArray(),
                State = state,
                Timestamps = timestamp
            });
        }

    }
}