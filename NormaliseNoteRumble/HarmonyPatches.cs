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
            return Config.Instance.ArcRumble;
        }
    }
}
