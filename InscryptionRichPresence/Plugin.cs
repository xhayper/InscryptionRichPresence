using RichPresenceAPI.Logging;
using DiscordRPC;
using HarmonyLib;
using BepInEx;

namespace InscryptionRichPresence
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("io.github.xhayper.RichPresenceAPI")]
    public class Plugin : BaseUnityPlugin
    {
        internal static BepInEx.Logging.ManualLogSource logger;
        internal static Harmony harmony;
        internal static DiscordRpcClient client;

        public static Timestamps startTimestamps = Timestamps.Now;

        private void Awake()
        {
            logger = Logger;
            client = RichPresenceAPI.Utility.createClient("954242645834735617", -1, new BepInExLogger(logger));
            Utility.SetStatus(EventHandler.getTextFromState(EventHandler.State.UNKNOW));
        }

        private void Update()
        {
            client.Invoke();
        }

        private void OnDestroy()
        {
            client.Dispose();
            harmony.UnpatchSelf();
        }
    }
}
