using IPA.Config.Stores;
using System.Runtime.CompilerServices;
using Libraries.HM.HMLib.VR;
using System.Collections.Generic;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaberHaptics
{
    internal class Configuration
    {
        public static Configuration Instance { get; set; }

        public bool leftControllerRumble { get; set; } = true;
        public bool rightControllerRumble { get; set; } = true;
        public bool ArcRumble { get; set; } = true;
        public HapticPresetSO SliderImpact { get; set; } = DefaultNotePresets.ContinuousRumbleHapticPreset;
        // public bool swapControllerRumble { get; set; } = false;

        public bool CustomNormal = false;
        public HapticPresetSO NormalNoteImpact { get; set; } = DefaultNotePresets.HitNoteHapticPreset;

        public bool CustomBomb = false;
        public HapticPresetSO BombImpact { get; set; } = DefaultNotePresets.HitNoteHapticPreset;

        public bool CustomChainHead = false;
        public HapticPresetSO ChainHeadImpact { get; set; } = DefaultNotePresets.HitBurstSliderHeadHapticPreset;
        public bool CustomChainElement = false;
        public HapticPresetSO ChainElementImpact { get; set; } = DefaultNotePresets.HitBurstSliderElementHapticPreset;
    }
}