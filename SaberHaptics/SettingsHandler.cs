using BeatSaberMarkupLanguage.Attributes;

namespace SaberHaptics
{
    class SettingsHandler: PersistentSingleton<SettingsHandler>
    {
        [UIValue("ArcRumble")]
        public bool ArcRumble
        {
            get => Configuration.Instance.ArcRumble;
            set
            {
                Configuration.Instance.ArcRumble = value;
            }
        }
    }
}
