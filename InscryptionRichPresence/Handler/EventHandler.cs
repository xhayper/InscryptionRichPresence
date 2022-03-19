using DiskCardGame;

namespace InscryptionRichPresence
{
    public static class EventHandler
    {

        internal static bool isActive = false;

        public static void SubscribeEvent()
        {
            isActive = true;
        }

        public static void UnsubscribeEvent()
        {
            isActive = false;
        }

        internal static void onCameraChangeState(VideoCameraRig.State newState) {
            Plugin.logger.LogInfo(newState);
        }

    }
}