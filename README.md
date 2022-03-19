# InscryptionRichPresence

Add an API for Discord RPC as well as adding it own Rich Presence

## Example Usage

```cs
using InscryptionRichPresence;
using DiscordRPC;
using BepInEx;

namespace ExamplePlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        private void Awake()
        {

            API.PublicRichPresence.SetApplicationID("954242645834735617");
            API.PublicRichPresence.SetPresence(new RichPresence()
            {
                State = "Hello, World!",
                Timestamps = Plugin.startTimestamps
            });
        }
    }
}
```