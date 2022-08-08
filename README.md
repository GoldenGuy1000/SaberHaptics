# SaberHaptics
A Beat Saber mod to change the haptic feedback for your sabers (hitting notes, sticking your sabers in walls, etc.)

^ menu haptics are unaffected


## Settings
Arc Rumble: toggles controller rumble from arc notes


## Harmony Patches
(don't worry about this unless you're also making a mod that also interacts with these methods)

### Prefixes
`SliderHapticFeedbackInteractionEffect.Update` <- skips update if ArcRumble is disabled  
`NoteCutCoreEffectsSpawner.HandleNoteWasCut` <- will not skip (just gets the note type)
`NoteCutHapticEffect.HitNote` <- replaced
`HapticFeedbackController` <- skips if haptic feedback is disabled



# Build Instructions
- Install beatsaber, bsipa, & bsml
- Make SaberHaptics.csproj.user & put beat saber directory in there
- build with VS

```xml
<Project>
	<PropertyGroup>
		<BeatSaberDir>beat/saber/dir</BeatSaberDir>
		
		<!-- Path to your Beat Saber install, only set if different from BeatSaberDir. -->
		<!--<GameDirectory></GameDirectory>-->
	</PropertyGroup>
</Project>
```