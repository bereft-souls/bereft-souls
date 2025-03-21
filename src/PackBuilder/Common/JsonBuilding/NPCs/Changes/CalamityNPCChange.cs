using CalamityMod;
using PackBuilder.Common.JsonBuilding.Data;
using Terraria;
using Terraria.ModLoader;

namespace PackBuilder.Common.JsonBuilding.NPCs.Changes
{
    [JITWhenModsEnabled("CalamityMod")]
    internal class CalamityNPCChange : INPCChange
    {
        public ValueModifier DamageReduction { get; set; }

        public void ApplyTo(NPC npc)
        {
            var calNpc = npc.Calamity();
            calNpc.DR = this.DamageReduction.Apply(calNpc.DR);
        }
    }
}
