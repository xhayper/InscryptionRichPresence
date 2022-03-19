using DiscordRPC;

namespace InscryptionRichPresence.API
{
    public static class PublicUser
    {
        internal static User user { get { return Plugin.client.CurrentUser; } }

        public static ulong ID { get { return user.ID; } }

        public static string Username { get { return user.Username; } }

        public static int Discriminator { get { return user.Discriminator; } }

        public static string Avatar { get { return user.Avatar; } }

        public static string CdnEndpoint { get { return user.CdnEndpoint; } }

        public static string GetAvatarExtension(User.AvatarFormat format) { return user.GetAvatarExtension(format); }

        public static string GetAvatarURL(User.AvatarFormat format, User.AvatarSize size = User.AvatarSize.x128) { return user.GetAvatarURL(format, size); }
    }
}