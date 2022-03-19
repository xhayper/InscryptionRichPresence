# InscryptionRichPresence

Add an API for Discord RPC as well as adding it own Rich Presence

## API Docs

To set the application id, Call `InscryptionRichPresence.API.PublicRichPresence.SetApplicationID("1234567890")`;

By default, This mod will handle everything by itself, You can turn it off by calling `InscryptionRichPresence.EventHandler.UnsubscribeEvent()`,

The main API is provied in `InscryptionRichPresence.API`, We have `InscryptionRichPresence.API.PublicRichPresence` and `InscryptionRichPresence.API.PublicUser`.

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