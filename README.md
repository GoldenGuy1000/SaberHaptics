# SaberHaptics
A Beat Saber mod to change the haptic feedback for your sabers (hitting notes, sticking your sabers in walls, etc.)


## Settings
Arc Rumble: toggles controller rumble from arc notes


## Harmony Patches
(don't worry about this unless you're also making a mod that interacts with these methods)

### prefixes
SliderHapticFeedbackInteractionEffect.Update <- skips update if ArcRumble is disabled
NoteCutCoreEffectsSpawner.HandleNoteWasCut <- completely replaces this method [1]



# build instructions
- Make SaberHaptics.csproj.user & put beat saber directory in there

`<?xml version="1.0" encoding="utf-8"?>
<Project>
	<PropertyGroup>
		<BeatSaberDir>beat/saber/dir</BeatSaberDir>
		
		<!-- Path to your Beat Saber install, only set if different from BeatSaberDir. -->
		<!--<GameDirectory></GameDirectory>-->
	</PropertyGroup>
</Project>`


[1] (other implementations like changing what type the note was in the actual haptics felt weird)