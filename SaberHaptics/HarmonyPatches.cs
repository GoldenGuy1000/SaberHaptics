using HarmonyLib;
using Libraries.HM.HMLib.VR;
using UnityEngine.XR;

namespace SaberHaptics
{
    [HarmonyPatch]
    class HarmonyPatches
    {
		static NoteData.GameplayType lastNoteCut;
		static bool callingHapticFeedbackFromWallCollision = false;

        #region Slider Patch

        [HarmonyPatch(typeof(SliderHapticFeedbackInteractionEffect), nameof(SliderHapticFeedbackInteractionEffect.Update))]
        [HarmonyPrefix]
        static bool SliderHapticPatch()
        {
			return Configuration.Instance.ArcRumble; // (run the method if arcrumble is enabled, don't if it isn't)
        }

		[HarmonyPatch(typeof(SliderHapticFeedbackInteractionEffect), nameof(SliderHapticFeedbackInteractionEffect.Vibrate))]
		[HarmonyPrefix]
		static bool SliderHapticIntensityPatch(HapticFeedbackController ____hapticFeedbackController, SaberType ____saberType)
        {
			if (Configuration.Instance.ArcRumble)
            {
				____hapticFeedbackController.PlayHapticFeedback(____saberType.Node(), Configuration.Instance.ArcImpact);
				return false;
            }
			return true;
        }
		#endregion

		#region Note Haptics Patch

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
					hapticPreset = Configuration.Instance.CustomBomb ? Configuration.Instance.BombImpact : DefaultNotePresets.HitNoteHapticPreset;
					break;
				case NoteData.GameplayType.BurstSliderHead:
					hapticPreset = Configuration.Instance.CustomChainHead ? Configuration.Instance.ChainHeadImpact : DefaultNotePresets.HitBurstSliderHeadHapticPreset;
					break;
				case NoteData.GameplayType.BurstSliderElement:
					hapticPreset = Configuration.Instance.CustomChainElement ? Configuration.Instance.ChainElementImpact : DefaultNotePresets.HitBurstSliderElementHapticPreset;
					break;
				default:
					hapticPreset = DefaultNotePresets.HitNoteHapticPreset;
					break;
			}

			____hapticFeedbackController.PlayHapticFeedback(saberType.Node(), hapticPreset);

			return false;
        }
        #endregion

        #region Wall Patch

        [HarmonyPatch(typeof(ObstacleSaberSparkleEffectManager), nameof(ObstacleSaberSparkleEffectManager.Update))]
		[HarmonyPrefix]
		static void SaberWallHapticBoolSet()
        {
			callingHapticFeedbackFromWallCollision = true;
        }

		[HarmonyPatch(typeof(HapticFeedbackController), nameof(HapticFeedbackController.PlayHapticFeedback))]
		[HarmonyPrefix]
		static bool SaberWallHapticPatch(ref HapticPresetSO hapticPreset)
        {
			if (callingHapticFeedbackFromWallCollision)
			{
				if (Configuration.Instance.WallRumble)
                {
					hapticPreset = Configuration.Instance.WallImpact;
				}
				else
                {
					return false;
                }
			}
			return true;
        }

		[HarmonyPatch(typeof(ObstacleSaberSparkleEffectManager), nameof(ObstacleSaberSparkleEffectManager.Update))]
		[HarmonyPostfix]
		static void SaberWallHapticBoolReset()
        {
			callingHapticFeedbackFromWallCollision = false;
		}
        #endregion


        [HarmonyPatch(typeof(HapticFeedbackController), nameof(HapticFeedbackController.PlayHapticFeedback))]
		[HarmonyPrefix]
		static bool DisableHapticsByHandPatch(XRNode node)
        {
			// if rumble for a certain saber isn't enabled, don't send haptic feedback
			return (Configuration.Instance.LeftControllerRumble && node == XRNode.LeftHand) || (Configuration.Instance.RightControllerRumble && node == XRNode.RightHand);
		}

		#region dev

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
		#endregion
	}
}
