using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaberHaptics
{
    internal class Configuration
    {
        public static Configuration Instance { get; set; }

        public bool ArcRumble { get; set; } = false;
    }
}
// TODO: defaults for settings should reflect the game without the mod