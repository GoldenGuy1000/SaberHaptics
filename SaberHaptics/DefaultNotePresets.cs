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

        public static readonly HapticPresetSO ContinuousRumbleHapticPreset = new HapticPresetSO
        {
            name = "Slider",
            _continuous = true,
            _duration = 0.01f,
            _frequency = 0.5f,
            _strength = 0.75f
        };
    }
}
