using HarmonyLib;

namespace NormaliseNoteRumble
{
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
