using HarmonyLib;

namespace SaberHaptics
{
    [HarmonyPatch]
    public class HarmonyPatches
    {
        [HarmonyPatch(typeof(SliderHapticFeedbackInteractionEffect), nameof(SliderHapticFeedbackInteractionEffect.Update))]
        [HarmonyPrefix]
        public static bool SliderHapticPatch()
        {
            return Configuration.Instance.ArcRumble;
        }
    }
}
