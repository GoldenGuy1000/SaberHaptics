using BeatSaberMarkupLanguage.Attributes;

namespace NormaliseNoteRumble.NormaliseNoteRumble
{
    class SettingsHandler: PersistentSingleton<SettingsHandler>
    {
        [UIValue("ArcRumble")]
        public bool ArcRumble
        {
            get => Config.Instance.ArcRumble;
            set
            {
                Config.Instance.ArcRumble = value;
            }
        }
    }
}
