using System.Runtime.InteropServices;
using System.Reflection;
using BepInEx.Logging;
using DiscordRPC;
using HarmonyLib;
using BepInEx;
using System;

namespace InscryptionRichPresence
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        internal static ManualLogSource logger;
        internal static Harmony harmony;
        internal static DiscordRpcClient client;
        internal static IntPtr libHandle;

        public static Timestamps startTimestamps = Timestamps.Now;

        private void Awake()
        {
            libHandle = Native.LoadLibrary($"{Paths.PluginPath}\\{PluginInfo.PLUGIN_NAME}\\NativeNamedPipe.dll");
            if (libHandle == IntPtr.Zero) throw new Exception(string.Format("Failed to load nessecary library (ErrorCode: {0})", Marshal.GetLastWin32Error()));
            logger = Logger;
            harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginInfo.PLUGIN_GUID);

            API.PublicRichPresence.SetApplicationID("954242645834735617");
            API.PublicRichPresence.SetPresence(new RichPresence()
            {
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "Inscryption"
                },
                State = EventHandler.getTextFromState(EventHandler.State.UNKNOW),
                Timestamps = Plugin.startTimestamps
            });
        }

        private void Update()
        {
            client.Invoke();
        }

        private void OnDestroy()
        {
            client.Dispose();
            harmony.UnpatchSelf();
            Native.FreeLibrary(libHandle);
        }
    }
}
