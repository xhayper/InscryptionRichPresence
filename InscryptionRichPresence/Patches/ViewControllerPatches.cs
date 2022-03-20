using DiskCardGame;
using HarmonyLib;

namespace InscryptionRichPresence
{
    [HarmonyPatch(typeof(ViewController))]
    public class ViewControllerPatches
    {

        [HarmonyPostfix, HarmonyPatch(nameof(ViewController.SwitchToControlMode))]
        public static void SwitchToControlMode(ViewController.ControlMode mode)
        {
            EventHandler.onViewControlModeSwitch(mode);
        }
    }
}