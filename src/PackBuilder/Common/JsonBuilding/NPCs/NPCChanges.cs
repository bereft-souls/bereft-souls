﻿using PackBuilder.Common.JsonBuilding.NPCs.Changes;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace PackBuilder.Common.JsonBuilding.NPCs
{
    internal class NPCChanges
    {
        public List<INPCChange> Changes = [];

        public VanillaNpcChange Terraria { set => Changes.Add(value); }

        [JITWhenModsEnabled("CalamityMod")] public CalamityNPCChange CalamityMod { set => Changes.Add(value); }

        public void ApplyTo(NPC npc)
        {
            foreach (var change in Changes)
                change.ApplyTo(npc);
        }
    }
}
