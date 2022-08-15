using HarmonyLib;
using Libraries.HM.HMLib.VR;
using UnityEngine.XR;

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
			// Plugin.Log.Info("Note Type: " + lastNoteCut);
        }

		[HarmonyPatch(typeof(NoteCutHapticEffect), nameof(NoteCutHapticEffect.HitNote))]
		[HarmonyPrefix]
		static bool NoteHapticsPatch(SaberType saberType,
			HapticFeedbackController ____hapticFeedbackController)
        {
			HapticPresetSO hapticPreset;
			switch (lastNoteCut)
            {
				case NoteData.GameplayType.Normal:
					hapticPreset = Configuration.Instance.CustomNormal? Configuration.Instance.NormalNoteImpact: DefaultNotePresets.HitNoteHapticPreset;
					break;
				case NoteData.GameplayType.Bomb:
					hapticPreset = DefaultNotePresets.HitNoteHapticPreset;
					break;
				case NoteData.GameplayType.BurstSliderHead:
					hapticPreset = Configuration.Instance.CustomChainHead ? Configuration.Instance.ChainHeadImpact : DefaultNotePresets.HitBurstSliderHeadHapticPreset;
					break;
				case NoteData.GameplayType.BurstSliderElement:
					hapticPreset = DefaultNotePresets.HitBurstSliderElementHapticPreset;
					break;
				default:
					hapticPreset = DefaultNotePresets.HitNoteHapticPreset;
					break;
			}

			____hapticFeedbackController.PlayHapticFeedback(saberType.Node(), hapticPreset);

			return false;
        }

		[HarmonyPatch(typeof(HapticFeedbackController), nameof(HapticFeedbackController.PlayHapticFeedback))]
		[HarmonyPrefix]
		static bool DisableHapticsPatch(XRNode node)
        {
			// if rumble for a certain saber isn't enabled, don't send haptic feedback
			return (Configuration.Instance.leftControllerRumble && node == XRNode.LeftHand) || (Configuration.Instance.rightControllerRumble && node == XRNode.RightHand);
		}


		// log the default presets (put in DefaultNotePresets)
		
		/*[HarmonyPatch(typeof(NoteCutHapticEffect), nameof(NoteCutHapticEffect.HitNote))]
		[HarmonyPrefix]
		static void GetNoteHapticPresets(HapticPresetSO ____normalPreset, HapticPresetSO ____shortNormalPreset, HapticPresetSO ____shortWeakPreset)
        {
			Plugin.Log.Info(____normalPreset.name + ":" +
				"\n\tcontinuous - " + ____normalPreset._continuous +
				"\n\tduration - " + ____normalPreset._duration +
				"\n\tfrequency - " + ____normalPreset._frequency +
				"\n\tstrength - " + ____normalPreset._strength);
			Plugin.Log.Info(____shortNormalPreset.name + ":" +
				"\n\tcontinuous - " + ____shortNormalPreset._continuous +
				"\n\tduration - " + ____shortNormalPreset._duration +
				"\n\tfrequency - " + ____shortNormalPreset._frequency +
				"\n\tstrength - " + ____shortNormalPreset._strength);
			Plugin.Log.Info(____shortWeakPreset.name + ":" +
				"\n\tcontinuous - " + ____shortWeakPreset._continuous +
				"\n\tduration - " + ____shortWeakPreset._duration +
				"\n\tfrequency - " + ____shortWeakPreset._frequency +
				"\n\tstrength - " + ____shortWeakPreset._strength);
		}*/
	}
}
