using BeatSaberMarkupLanguage.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace SaberHaptics
{
    class SettingsHandler: PersistentSingleton<SettingsHandler>
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

        [UIValue("NormalNoteHaptic")]
        string normalNoteHaptic = "Normal";

        [UIValue("HapticOptions")]
        List<object> hapticOptions = new object[] { "Normal", "ShortNormal", "ShortWeak", "None" }.ToList();
    }
}
