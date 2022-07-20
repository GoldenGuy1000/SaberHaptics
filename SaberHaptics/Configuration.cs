using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaberHaptics
{
    internal class Configuration
    {
        public static Configuration Instance { get; set; }

        public bool ArcRumble { get; set; } = false;
        public NoteCutHapticEffect.Type NormalNoteImpact { get; set; } = NoteCutHapticEffect.Type.Normal;
    }
}
// TODO: defaults for settings should reflect the game without the mod