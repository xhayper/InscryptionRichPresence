# !! ALPHA !!
# InscryptionRichPresence

Add an API for Discord RPC as well as adding it own Rich Presence

## Installation (game, automated)

This is the recommended way to install this plugin on the game.

1. Download and install [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager) or [r2modman](https://inscryption.thunderstore.io/package/ebkr/r2modman/)
2. Click **Install with Mod Manager** button on top of the page
3. Run the game via the mod manager

## Installation (manual)

If you are installing this manually, do the following

1. Extract the archive into a folder. Do not extract into the game folder.
2. Move the _InscryptionRichPresence.dll_ file and the _InscryptionRichPresence_ folder into the _BepInEx/plugins_ folder.
3. Run the game.

## Example API Usage

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
                Timestamps = Timestamps.Now
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
