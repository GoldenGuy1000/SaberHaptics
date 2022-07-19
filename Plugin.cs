using IPA;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using System.Reflection;

namespace NormaliseNoteRumble
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        /// <summary>
        /// Use to send log messages through BSIPA.
        /// </summary>
        internal static IPALogger Log { get; private set; }

        internal readonly Harmony harmony;


        [Init]
        public Plugin(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            harmony = new Harmony("NormaliseNoteRumble.GoldenGuy1000");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Plugin.Log.Info("OnApplicationStart");
        }

        [OnExit]
        public void OnApplicationQuit()
        {

        }

    }

    [HarmonyPatch]
    public class HarmonyPatches
    {
        [HarmonyPatch(typeof(SliderHapticFeedbackInteractionEffect), nameof(SliderHapticFeedbackInteractionEffect.Update))]
        [HarmonyPrefix]
        public static bool SliderHapticPatch()
        {
            bool noRumble = true;
            // Plugin.Log.Info("the SliderHapticFeedbackInteractionEffect class is existing");
            if (noRumble)
            {
                return false;
            }
            return true;
        }
    }
}
