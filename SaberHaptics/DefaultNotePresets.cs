using Libraries.HM.HMLib.VR;

namespace SaberHaptics.SaberHaptics
{
    public class DefaultNotePresets
    {
        public static readonly HapticPresetSO HitNoteHapticPreset = new HapticPresetSO
        {
            _continuous = false,
            _duration = 0.13f,
            _frequency = 0.5f,
            _strength = 1f
        };
        public static readonly HapticPresetSO HitBurstSliderHeadHapticPreset = new HapticPresetSO
        {
            _continuous = false,
            _duration = 0.09f,
            _frequency = 0.5f,
            _strength = 1f
        };
        public static readonly HapticPresetSO HitBurstSliderElementHapticPreset = new HapticPresetSO
        {
            _continuous = false,
            _duration = 0.08f,
            _frequency = 0.5f,
            _strength = 1f
        };
    }
}
