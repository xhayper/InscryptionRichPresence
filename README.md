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

            API.PublicRichPresence.SetApplicationID("1234567890"); // Setting this to your own application ID
            API.PublicRichPresence.SetPresence(new RichPresence() // Set the Presence
            {
                State = "Hello, World!",
                Timestamps = Plugin.startTimestamps
            });
        }

    }
}
```

## FAQ

- Q: How to disable default behaviour?
- A: Calling `InscryptionRichPresence.EventHandler.UnsubscribeEvent()`

- Q: What dependencies i need to include?
- A: [Newtonsoft.Json](https://www.newtonsoft.com/json) and [DiscordRichPresence](https://github.com/Lachee/discord-rpc-csharp)

- Q: What's `NativeNamedPipe` / How do i get it?
- A: It's used as alternative to C#'s vanilla named pipe, Since Unity broke it, You can get it [here](https://github.com/Lachee/unity-named-pipes/tree/master/UnityNamedPipe.Native)