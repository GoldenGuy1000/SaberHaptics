using IPA;
using IPA.Config.Stores;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using BeatSaberMarkupLanguage.Settings;

namespace SaberHaptics
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }

        internal static IPALogger Log { get; private set; }

        internal readonly Harmony harmony;


        [Init]
        public Plugin(IPALogger logger, IPA.Config.Config conf)
        {
            Instance = this;
            Log = logger;
            Configuration.Instance = conf.Generated<Configuration>();
            harmony = new Harmony("SaberHaptics.GoldenGuy1000");
        }

        [OnEnable]
        public void OnEnable()
        {
            BSMLSettings.instance.AddSettingsMenu("SaberHaptics", "SaberHaptics.SaberHaptics.settings.bsml", SettingsHandler.instance);
            harmony.PatchAll(typeof(HarmonyPatches));
            Log.Info("SaberHaptics enabled");
        }

        [OnDisable]
        public void OnDisable()
        {
            BSMLSettings.instance.RemoveSettingsMenu(SettingsHandler.instance);
            harmony.UnpatchSelf();
            Log.Info("SaberHaptics disabled");
        }

    }
}
// for 1.0:
// TODO: saber self collision, wall collision
// TODO: reset button for all settings & each note type
// TODO: license
// TODO: % setting for sliders

// TODO: extend setting slider length
// TODO: funny swap saber haptics

// tweaks55 -- https://github.com/kinsi55/BeatSaber_Tweaks55
// gameplaycore sabertype (used by) <- interesting classes
// bsml docs -> https://monkeymanboy.github.io/BSML-Docs/Tags/slidersettingtag/
// beatmods -> https://beatmods.com -- https://docs.google.com/document/d/15RBVesZdS-U94AvesJ2DJqcnAtgh9E2PZOcbjrQle5Y/
// harmony docs -> https://harmony.pardeike.net/articles/patching.html
// don't ask to ask!!! -> https://dontasktoask.com/
// beattogether usage stats -> https://bssb.app/stats

// webgpu is cool -> https://hacks.mozilla.org/2020/04/experimental-webgpu-in-firefox/
//        -- https://austin-eng.com/webgpu-samples/samples/helloTriangle -- https://github.com/gpuweb/gpuweb/wiki/Implementation-Status
// maintained dnspy -> https://github.com/dnSpyEx/dnSpy