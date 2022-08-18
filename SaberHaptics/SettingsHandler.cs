using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components.Settings;

namespace SaberHaptics
{
    class SettingsHandler : PersistentSingleton<SettingsHandler>
    {

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


        [UIAction("%")]
        string PercentFormat(float value)
        {
            return $"{(int)(value * 100)}%";
        }


        [UIValue("ArcRumble")]
        bool ArcRumble
        {
            get => Configuration.Instance.ArcRumble;
            set
            {
                Configuration.Instance.ArcRumble = value;
                ArcStrengthS.interactable = value;
            }
        }

        [UIComponent("ArcStrengthS")]
        SliderSetting ArcStrengthS;

        [UIValue("ArcStrength")]
        float ArcHapticStrength
        {
            get => Configuration.Instance.SliderImpact._strength;
            set
            {
                Configuration.Instance.SliderImpact._strength = value;
            }
        }

        [UIAction("ArcReset")]
        void ArcReset()
        {
            ArcStrengthS.Value = DefaultNotePresets.ContinuousRumbleHapticPreset._strength;
        }

        [UIAction("ResetAll")]
        void ResetAll()
        {
            nReset(); bReset(); chReset(); ceReset();
        }

        #region Custom Normal

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

        [UIAction("nReset")]
        void nReset()
        {
            Plugin.Log.Info("reset normal");
            nDurationS.Value = DefaultNotePresets.HitNoteHapticPreset._duration;
            /* nFrequencyS.Value = DefaultNotePresets.HitNoteHapticPreset._frequency; */
            nStrengthS.Value = DefaultNotePresets.HitNoteHapticPreset._strength;
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
        #endregion


        #region Custom Bomb

        [UIValue("CustomBomb")]
        bool CustomBomb
        {
            get => Configuration.Instance.CustomBomb;
            set
            {
                Plugin.Log.Info("custombomb = " + value.ToString());
                bDurationS.interactable = /*bFrequencyS.interactable =*/ bStrengthS.interactable = value;
                Configuration.Instance.CustomBomb = value;
            }
        }

        [UIAction("bReset")]
        void bReset()
        {
            Plugin.Log.Info("reset bomb");
            bDurationS.Value = DefaultNotePresets.HitNoteHapticPreset._duration;
            /* bFrequencyS.Value = DefaultNotePresets.HitNoteHapticPreset._frequency; */
            bStrengthS.Value = DefaultNotePresets.HitNoteHapticPreset._strength;
        }

        [UIComponent("bDurationS")] // the slider object for duration
        SliderSetting bDurationS;

        [UIValue("bDuration")]
        float bHapticDuration
        {
            get => Configuration.Instance.BombImpact._duration;
            set
            {
                Configuration.Instance.BombImpact._duration = value;
            }
        }

        // frequency doesn't seem to do anything noticeable (so slider is hidden in game)

        [UIComponent("bFrequencyS")]
        SliderSetting bFrequencyS;

        [UIValue("bFrequency")]
        float bHapticFrequency
        {
            get => Configuration.Instance.BombImpact._frequency;
            set
            {
                Configuration.Instance.BombImpact._frequency = value;
            }
        }

        [UIComponent("bStrengthS")]
        SliderSetting bStrengthS;

        [UIValue("bStrength")]
        float bHapticStrength
        {
            get => Configuration.Instance.BombImpact._strength;
            set
            {
                Configuration.Instance.BombImpact._strength = value;
            }
        }
        #endregion


        #region Custom Chain Head

        [UIValue("CustomChainHead")]
        bool CustomChainHead
        {
            get => Configuration.Instance.CustomChainHead;
            set
            {
                Plugin.Log.Info("customchainhead = " + value.ToString());
                chDurationS.interactable = /*chFrequencyS.interactable =*/ chStrengthS.interactable = value;
                Configuration.Instance.CustomChainHead = value;
            }
        }

        [UIAction("chReset")]
        void chReset()
        {
            Plugin.Log.Info("reset chain head");
            chDurationS.Value = DefaultNotePresets.HitBurstSliderHeadHapticPreset._duration;
            /* chFrequencyS.Value = DefaultNotePresets.HitBurstSliderHeadHapticPreset._frequency; */
            chStrengthS.Value = DefaultNotePresets.HitBurstSliderHeadHapticPreset._strength;
        }

        [UIComponent("chDurationS")] // the slider object for duration
        SliderSetting chDurationS;

        [UIValue("chDuration")]
        float chHapticDuration
        {
            get => Configuration.Instance.ChainHeadImpact._duration;
            set
            {
                Configuration.Instance.ChainHeadImpact._duration = value;
            }
        }

        // frequency doesn't seem to do anything noticeable (so slider is hidden in game)

        [UIComponent("chFrequencyS")]
        SliderSetting chFrequencyS;

        [UIValue("chFrequency")]
        float chHapticFrequency
        {
            get => Configuration.Instance.ChainHeadImpact._frequency;
            set
            {
                Configuration.Instance.ChainHeadImpact._frequency = value;
            }
        }

        [UIComponent("chStrengthS")]
        SliderSetting chStrengthS;

        [UIValue("chStrength")]
        float chHapticStrength
        {
            get => Configuration.Instance.ChainHeadImpact._strength;
            set
            {
                Configuration.Instance.ChainHeadImpact._strength = value;
            }
        }
        #endregion


        #region Custom Chain Element

        [UIValue("CustomChainElement")]
        bool CustomChainElement
        {
            get => Configuration.Instance.CustomChainElement;
            set
            {
                Plugin.Log.Info("customchainelement = " + value.ToString());
                ceDurationS.interactable = /*ceFrequencyS.interactable =*/ ceStrengthS.interactable = value;
                Configuration.Instance.CustomChainElement = value;
            }
        }

        [UIAction("ceReset")]
        void ceReset()
        {
            Plugin.Log.Info("reset chain element");
            ceDurationS.Value = DefaultNotePresets.HitBurstSliderElementHapticPreset._duration;
            /* ceFrequencyS.Value = DefaultNotePresets.HitBurstSliderElementHapticPreset._frequency; */
            ceStrengthS.Value = DefaultNotePresets.HitBurstSliderElementHapticPreset._strength;
        }

        [UIComponent("ceDurationS")] // the slider object for duration
        SliderSetting ceDurationS;

        [UIValue("ceDuration")]
        float ceHapticDuration
        {
            get => Configuration.Instance.ChainElementImpact._duration;
            set
            {
                Configuration.Instance.ChainElementImpact._duration = value;
            }
        }

        // frequency doesn't seem to do anything noticeable (so slider is hidden in game)

        [UIComponent("ceFrequencyS")]
        SliderSetting ceFrequencyS;

        [UIValue("ceFrequency")]
        float ceHapticFrequency
        {
            get => Configuration.Instance.ChainElementImpact._frequency;
            set
            {
                Configuration.Instance.ChainElementImpact._frequency = value;
            }
        }

        [UIComponent("ceStrengthS")]
        SliderSetting ceStrengthS;

        [UIValue("ceStrength")]
        float ceHapticStrength
        {
            get => Configuration.Instance.ChainElementImpact._strength;
            set
            {
                Configuration.Instance.ChainElementImpact._strength = value;
            }
        }
        #endregion
    }
}
