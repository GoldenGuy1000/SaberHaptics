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
            harmony.PatchAll(typeof(HarmonyPatches));
        }

        [OnEnable]
        public void OnEnable()
        {
            BSMLSettings.instance.AddSettingsMenu("SaberHaptics", "Saberhaptics.Saberhaptics.settings.bsml", SettingsHandler.instance);
            Log.Info("SaberHaptics enabled");
        }

        [OnDisable]
        public void OnDisable()
        {
            BSMLSettings.instance.RemoveSettingsMenu(SettingsHandler.instance);
            Log.Info("SaberHaptics disabled");
        }

    }
}
// TODO: chain head notes, chain slice notes, normal notes, bombs, saber self collision, wall collision