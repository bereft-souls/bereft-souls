using CalamityMod;
using PackBuilder.Common.JsonBuilding.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace PackBuilder.Common.JsonBuilding.NPCs.Changes
{
    internal class CalamityNPCChange : INPCChange
    {
        public ValueModifier DamageReduction { get; set; }

        [JITWhenModsEnabled("CalamityMod")]
        public void ApplyTo(NPC npc)
        {
            var calNpc = npc.Calamity();
            calNpc.DR = this.DamageReduction.Apply(calNpc.DR);
        }
    }
}
