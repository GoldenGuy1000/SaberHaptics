using Libraries.HM.HMLib.VR;

namespace SaberHaptics
{
    public class DefaultNotePresets
    {
        public static readonly HapticPresetSO HitNoteHapticPreset = new HapticPresetSO
        {
            name = "Normal",
            _continuous = false,
            _duration = 0.13f,
            _frequency = 0.5f,
            _strength = 1f
        };
        public static readonly HapticPresetSO HitBurstSliderHeadHapticPreset = new HapticPresetSO
        {
            name = "ShortNormal",
            _continuous = false,
            _duration = 0.09f,
            _frequency = 0.5f,
            _strength = 1f
        };
        public static readonly HapticPresetSO HitBurstSliderElementHapticPreset = new HapticPresetSO
        {
            name = "ShortWeak",
            _continuous = false,
            _duration = 0.08f,
            _frequency = 0.5f,
            _strength = 1f
        };

        // Not from the base game

        public static readonly HapticPresetSO None = new HapticPresetSO {
            name = "None",
            _continuous = false,
            _duration = 0f,
            _frequency = 0f,
            _strength = 0f,
        };
    }
}
