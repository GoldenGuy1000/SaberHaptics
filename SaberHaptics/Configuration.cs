using IPA.Config.Stores;
using System.Runtime.CompilerServices;
using Libraries.HM.HMLib.VR;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaberHaptics
{
    internal class Configuration
    {
        public static Configuration Instance { get; set; }

        public bool ArcRumble { get; set; } = false;
        public HapticPresetSO NormalNoteImpact { get; set; } = DefaultNotePresets.HitNoteHapticPreset;
    }
}
// TODO: defaults for settings should reflect the game without the mod