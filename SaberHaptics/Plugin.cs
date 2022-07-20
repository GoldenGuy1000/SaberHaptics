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
// TODO: chain head notes, chain slice notes, normal notes, bombs
// TODO: saber self collision, wall collision <- read through tweaks55 to make sure it doesn't buggin
// TODO: funny swap saber haptics
// TODO: disable haptics for one controller