using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace NormaliseNoteRumble
{
    internal class Config
    {
        public static Config Instance { get; set; }

        public bool ArcRumble { get; set; } = false;
    }
}
// TODO: defaults for settings should reflect the game without the mod