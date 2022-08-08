using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components.Settings;

namespace SaberHaptics
{
    class SettingsHandler : PersistentSingleton<SettingsHandler>
    {

        [UIValue("ArcRumble")]
        bool ArcRumble
        {
            get => Configuration.Instance.ArcRumble;
            set
            {
                Configuration.Instance.ArcRumble = value;
            }
        }

        [UIValue("leftControllerRumble")]
        bool LeftControllerRumble
        {
            get => Configuration.Instance.leftControllerRumble;
            set
            {
                Configuration.Instance.leftControllerRumble = value;
            }
        }

        [UIValue("rightControllerRumble")]
        bool RightControllerRumble
        {
            get => Configuration.Instance.rightControllerRumble;
            set
            {
                Configuration.Instance.rightControllerRumble = value;
            }
        }


        [UIValue("CustomNormal")]
        bool CustomNormal
        {
            get => Configuration.Instance.CustomNormal;
            set
            {
                Plugin.Log.Info("customnormal = " + value.ToString());
                nDurationS.interactable = /*nFrequencyS.interactable =*/ nStrengthS.interactable = value;
                Configuration.Instance.CustomNormal = value;
            }
        }

        [UIComponent("nDurationS")] // the slider object for duration
        SliderSetting nDurationS;

        [UIValue("nDuration")]
        float nHapticDuration
        {
            get => Configuration.Instance.NormalNoteImpact._duration;
            set
            {
                Configuration.Instance.NormalNoteImpact._duration = value;
            }
        }

        // frequency doesn't seem to do anything noticeable (so slider is hidden in game)

        [UIComponent("nFrequencyS")]
        SliderSetting nFrequencyS;

        [UIValue("nFrequency")]
        float nHapticFrequency
        {
            get => Configuration.Instance.NormalNoteImpact._frequency;
            set
            {
                Configuration.Instance.NormalNoteImpact._frequency = value;
            }
        }

        [UIComponent("nStrengthS")]
        SliderSetting nStrengthS;

        [UIValue("nStrength")]
        float nHapticStrength
        {
            get => Configuration.Instance.NormalNoteImpact._strength;
            set
            {
                Configuration.Instance.NormalNoteImpact._strength = value;
            }
        }

        [UIAction("#apply")]
        public void OnApply()
        {
            Plugin.Log.Info("Normal Notes:  -  " + Configuration.Instance.NormalNoteImpact.name);
        }
    }
}
