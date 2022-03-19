using DiscordRPC;

namespace InscryptionRichPresence.API
{
    public static class PublicRichPresence
    {
        internal static DiscordRpcClient client { get { return Plugin.client; } }

        public static void SetPresence(RichPresence richPresence)
        {
            client.SetPresence(richPresence);
        }

        public static void ClearPresence()
        {
            client.ClearPresence();
        }
    }
}