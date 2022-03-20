using DiskCardGame;
using HarmonyLib;

namespace InscryptionRichPresence
{
    [HarmonyPatch(typeof(GameFlowManager))]
    public class GameFlowManagerPatches
    {

        [HarmonyPostfix, HarmonyPatch(nameof(GameFlowManager.CurrentGameState), MethodType.Setter)]
        public static void CurrentGameState(GameState value)
        {
            EventHandler.onGameStateChanged(value);
        }
    }
}