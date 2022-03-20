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
            Plugin.client.SetPresence(new RichPresence()
            {
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "Inscryption"
                },
                Buttons = (new List<DiscordRPC.Button> { new DiscordRPC.Button() {
                    Label = "Buy Inscryption",
                    Url = "https://store.steampowered.com/app/1092790/Inscryption/"
                },
                new DiscordRPC.Button {
                    Label = "Play Inscryption",
                    Url = "steam://rungameid/1092790"
                }}).ToArray(),
                State = state,
                Timestamps = timestamp
            });
        }

    }
}