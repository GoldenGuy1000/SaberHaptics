using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

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
		[HarmonyTranspiler]
		static IEnumerable<CodeInstruction> HapticIntensityPatch(IEnumerable<CodeInstruction> instructions) // those for loops neet to get refactored or something sheesh
        {
			var codes = new List<CodeInstruction>(instructions);

			List<int> switchBranchStarts = new List<int>();

			for (int i = 0; i < codes.Count; i++)
            {
				if (codes[i].opcode == OpCodes.Switch)
				{
					//  Plugin.Log.Info("found the switch @ " + i);
					Label[] switchCases = ((Label[])codes[i].operand);
					for (int noteType = 0; noteType < switchCases.Length; noteType++) // loop through the arms
                    {
						for (int instructionIndex = i; instructionIndex < codes.Count; instructionIndex++) // loop through instructions until you find the arms
                        {
							if (codes[instructionIndex].labels.Contains(switchCases[noteType])) {
								//  Plugin.Log.Info("start of " + noteType + ": " + instructionIndex);
								switchBranchStarts.Append(instructionIndex);
                            }
                        }
						// switchCases[noteType]
                    }
				}

				if (codes[i].Calls(typeof(NoteCutHapticEffect).GetMethod("HitNote")))
                {
					Plugin.Log.Info("hittin the note @ " + i);
                }
			}

			return codes.AsEnumerable();
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
