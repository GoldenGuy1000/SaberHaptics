using BeatSaberMarkupLanguage.Attributes;
using Libraries.HM.HMLib.VR;
using System.Collections.Generic;
using System.Linq;

namespace SaberHaptics
{
    class SettingsHandler : PersistentSingleton<SettingsHandler>
    {
        Dictionary<string, HapticPresetSO> hapticOptionToPreset = new Dictionary<string, HapticPresetSO>
        {
            { (string)hapticOptions[0], DefaultNotePresets.HitNoteHapticPreset },
            { (string)hapticOptions[1], DefaultNotePresets.HitBurstSliderHeadHapticPreset },
            { (string)hapticOptions[2], DefaultNotePresets.HitBurstSliderElementHapticPreset },
            { (string)hapticOptions[3], DefaultNotePresets.None }
        };

        [UIValue("ArcRumble")]
        bool ArcRumble
        {
            get => Configuration.Instance.ArcRumble;
            set
            {
                Configuration.Instance.ArcRumble = value;
            }
        }

        [UIValue("NormalNoteHaptic")]
        string normalNoteHaptic {
            get => Configuration.Instance.NormalNoteImpact.name;
            set
            {
                Configuration.Instance.NormalNoteImpact = hapticOptionToPreset.ContainsKey(value)
                    ? hapticOptionToPreset[value]
                    : DefaultNotePresets.HitNoteHapticPreset;
            }
        }

        [UIValue("HapticOptions")]
        static List<object> hapticOptions = new object[] { 
            DefaultNotePresets.HitNoteHapticPreset.name,
            DefaultNotePresets.HitBurstSliderHeadHapticPreset.name,
            DefaultNotePresets.HitBurstSliderElementHapticPreset.name,
            DefaultNotePresets.None.name
        }.ToList();

        [UIAction("#apply")]
        public void OnApply()
        {
            Plugin.Log.Info("Normal Notes:  -  " + Configuration.Instance.NormalNoteImpact.name);
        }
    }
}
