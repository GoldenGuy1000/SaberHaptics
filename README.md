# SaberHaptics
A Beat Saber mod to change the haptic feedback for your sabers (hitting notes, sticking your sabers in walls, etc.)

Look in Options/Mod Settings for the saberhaptics menu

## Settings
Left Controller Rumble: disabling stops **any** haptic feedback from being sent to your left controller
Right Controller Rumble: ^

Arc Rumble: toggles controller rumble from arcs on and off
Arc Rumble Strength: the strength of rumble to give your controller during an arc note (default 75%)

Wall Rumble: toggles controller rumble from your saber intersecting a wall
Wall Rumble Strength: the strength of rumble that putting your saber in a wall triggers (default 75%)

### Specific Note Customization
Duration: the length (in seconds) of haptic feedback from that note
Strength: the intensity of that feedback

|Note Type      | Default Duration | Default Strength |
|---------------|------------------|------------------|
|Normal Notes   |              0.13|              100%|
|Bombs          |              0.13|              100%|
|Chain Heads    |              0.09|              100%|
|Chain Elements |              0.08|              100%|


## Harmony Patches That Skip
(don't worry about this unless you're also making a mod that also interacts with these methods)

`SliderHapticFeedbackInteractionEffect.Update` <- skips update if ArcRumble is disabled  
`NoteCutHapticEffect.HitNote` <- replaced
`HapticFeedbackController.PlayHapticFeedback` <- skips on walls if WallRumble is disabled
`HapticFeedbackController.PlayHapticFeedback` <- skips if Left/RightControllerRumble is disabled for the targeted hand


# Build Instructions
- Install beatsaber, bsipa, & bsml
- Make SaberHaptics.csproj.user & put beat saber directory in there
- build with VS

`SaberHaptics.csproj.user` V
```xml
<Project>
	<PropertyGroup>
		<BeatSaberDir>beat/saber/dir</BeatSaberDir>
		
		<!-- Path to your Beat Saber install, only set if different from BeatSaberDir. -->
		<!--<GameDirectory></GameDirectory>-->
	</PropertyGroup>
</Project>
```