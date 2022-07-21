using HarmonyLib;

namespace SaberHaptics
{
    [HarmonyPatch]
    class HarmonyPatches
    {
        [HarmonyPatch(typeof(SliderHapticFeedbackInteractionEffect), nameof(SliderHapticFeedbackInteractionEffect.Update))]
        [HarmonyPrefix]
        static bool SliderHapticPatch()
        {
            return Configuration.Instance.ArcRumble; // (run the method if arcrumble is enabled, don't if it isn't)
        }

        [HarmonyPatch(typeof(NoteCutCoreEffectsSpawner), nameof(NoteCutCoreEffectsSpawner.HandleNoteWasCut))]
        [HarmonyPrefix]
        static bool HapticIntensityPatch(NoteController noteController, in NoteCutInfo noteCutInfo,
			NoteCutCoreEffectsSpawner __instance, NoteCutHapticEffect ____noteCutHapticEffect, AudioTimeSyncController ____audioTimeSyncController)
        {
			if (noteController.noteData.time + 0.5f < ____audioTimeSyncController.songTime)
			{
				return false;
			}
			switch (noteController.noteData.gameplayType)
			{
				case NoteData.GameplayType.Normal:
					__instance.SpawnNoteCutEffect(noteCutInfo, noteController, 150, 50);
					____noteCutHapticEffect.HitNote(noteCutInfo.saberType, NoteCutHapticEffect.Type.Normal);
					return false;
				case NoteData.GameplayType.Bomb:
					__instance.SpawnBombCutEffect(noteCutInfo, noteController);
					____noteCutHapticEffect.HitNote(noteCutInfo.saberType, NoteCutHapticEffect.Type.Normal);
					return false;
				case NoteData.GameplayType.BurstSliderHead:
					__instance.SpawnNoteCutEffect(noteCutInfo, noteController, 150, 50);
					____noteCutHapticEffect.HitNote(noteCutInfo.saberType, NoteCutHapticEffect.Type.ShortNormal);
					return false;
				case NoteData.GameplayType.BurstSliderElement:
					__instance.SpawnNoteCutEffect(noteCutInfo, noteController, 50, 20);
					____noteCutHapticEffect.HitNote(noteCutInfo.saberType, NoteCutHapticEffect.Type.ShortWeak);
					return false;
				default:
					return false;
			}
		}
    }
}
