using HarmonyLib;
using Libraries.HM.HMLib.VR;

namespace SaberHaptics
{
    [HarmonyPatch]
    class HarmonyPatches
    {
		static NoteData.GameplayType lastNoteCut;

        [HarmonyPatch(typeof(SliderHapticFeedbackInteractionEffect), nameof(SliderHapticFeedbackInteractionEffect.Update))]
        [HarmonyPrefix]
        static bool SliderHapticPatch()
        {
            return Configuration.Instance.ArcRumble; // (run the method if arcrumble is enabled, don't if it isn't)
        }

		[HarmonyPatch(typeof(NoteCutCoreEffectsSpawner), nameof(NoteCutCoreEffectsSpawner.HandleNoteWasCut))]
		[HarmonyPrefix]
		static void StoreNoteType(NoteController noteController)
        {
			lastNoteCut = noteController.noteData.gameplayType;
			Plugin.Log.Info("Note Type: " + lastNoteCut);
        }

		[HarmonyPatch(typeof(NoteCutHapticEffect), nameof(NoteCutHapticEffect.HitNote))]
		[HarmonyPrefix]
		static bool NoteHapticsPatch(SaberType saberType,
			HapticPresetSO ____normalPreset, HapticPresetSO ____shortNormalPreset, HapticPresetSO ____shortWeakPreset,
			HapticFeedbackController ____hapticFeedbackController)
        {
			HapticPresetSO hapticPreset;
			switch (lastNoteCut)
            {
				case NoteData.GameplayType.Normal:
					hapticPreset = ____normalPreset;
					break;
				case NoteData.GameplayType.Bomb:
					hapticPreset = ____normalPreset;
					break;
				case NoteData.GameplayType.BurstSliderHead:
					hapticPreset = ____shortNormalPreset;
					break;
				case NoteData.GameplayType.BurstSliderElement:
					hapticPreset = ____shortWeakPreset;
					break;
				default:
					hapticPreset = ____normalPreset;
					break;
			}

			____hapticFeedbackController.PlayHapticFeedback(saberType.Node(), hapticPreset);

			return false;
        }




		[System.Obsolete("HapticIntensityPatch is a transpiler for what this was supposed to do")]
        static bool OldHapticIntensityPrefix(NoteController noteController, in NoteCutInfo noteCutInfo,
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
