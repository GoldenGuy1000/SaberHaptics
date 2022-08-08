﻿using IPA.Config.Stores;
using System.Runtime.CompilerServices;
using Libraries.HM.HMLib.VR;
using System.Collections.Generic;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaberHaptics
{
    internal class Configuration
    {
        public static Configuration Instance { get; set; }

        public bool ArcRumble { get; set; } = true;
        public bool CustomNormal = false;
        public HapticPresetSO NormalNoteImpact { get; set; } = DefaultNotePresets.HitNoteHapticPreset;
    }
}