using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using BepInEx.Logging;
using DiscordRPC;
using HarmonyLib;
using System.IO;
using BepInEx;
using System;

namespace InscryptionRichPresence
{
    [BepInPlugin(PluginGuid, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal const string PluginGuid = "io.github.xhayper.inscryprionrichpresence";
        internal static string AssemblyDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        internal static ManualLogSource logger;
        internal static Harmony harmony;
        internal static DiscordRpcClient client;
        internal static IntPtr libHandle;

        public static Timestamps startTimestamps = Timestamps.Now;

        private void Awake()
        {
            string pathToDLL = $"{AssemblyDirectory}\\{PluginInfo.PLUGIN_NAME}\\NativeNamedPipe.dll";
            if (!File.Exists(pathToDLL))
            {
                pathToDLL = $"{AssemblyDirectory}\\NativeNamedPipe.dll";
                if (!File.Exists(pathToDLL))
                    throw new Exception("Can't find the library file");
            }
            libHandle = Native.LoadLibrary(pathToDLL);
            if (libHandle == IntPtr.Zero) throw new Exception(string.Format("Failed to load nessecary library (ErrorCode: {0})", Marshal.GetLastWin32Error()));
            logger = Logger;
            harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginGuid);

            API.PublicRichPresence.SetApplicationID("954242645834735617");
            API.PublicRichPresence.SetPresence(new RichPresence()
            {
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "Inscryption"
                },
                Buttons = (new List<DiscordRPC.Button> { new DiscordRPC.Button() {
                    Label = "Play Inscryption",
                    Url = "https://store.steampowered.com/app/1092790/Inscryption/"
                }}).ToArray(),
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
