using DiskCardGame;
using HarmonyLib;

namespace InscryptionRichPresence
{
    [HarmonyPatch(typeof(VideoCameraRig))]
    public class VideoCameraRigPatches
    {

        [HarmonyPostfix, HarmonyPatch(nameof(VideoCameraRig.SwitchToState))]
        public static void DisplayMenuCardTitle(VideoCameraRig.State newState)
        {
            if (!EventHandler.isActive) return;
            EventHandler.onCameraChangeState(newState);
        }
    }
}