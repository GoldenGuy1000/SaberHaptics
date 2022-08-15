﻿using BeatSaberMarkupLanguage.Attributes;
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

        [UIValue("ArcRumble")]
        bool ArcRumble
        {
            get => Configuration.Instance.ArcRumble;
            set
            {
                Configuration.Instance.ArcRumble = value;
            }
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



        [UIAction("#apply")]
        public void OnApply()
        {
            Plugin.Log.Info("Normal Notes:  -  " + Configuration.Instance.NormalNoteImpact.name);
        }
    }
}
