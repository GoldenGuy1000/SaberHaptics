using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using System.Reflection;
using BeatSaberMarkupLanguage.Settings;
using NormaliseNoteRumble.NormaliseNoteRumble;

namespace NormaliseNoteRumble
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
            Config.Instance = conf.Generated<Config>();
            harmony = new Harmony("NormaliseNoteRumble.GoldenGuy1000");
            harmony.PatchAll(typeof(HarmonyPatches));
        }

        [OnEnable]
        public void OnEnable()
        {
            BSMLSettings.instance.AddSettingsMenu("NormaliseNoteRumble", "NormaliseNoteRumble.NormaliseNoteRumble.settings.bsml", SettingsHandler.instance);
        }

        [OnDisable]
        public void OnDisable()
        {
            BSMLSettings.instance.RemoveSettingsMenu(SettingsHandler.instance);
        }

    }
}
