using PackBuilder.Common.JsonBuilding.Data;
using Terraria;

namespace PackBuilder.Common.JsonBuilding.NPCs.Changes
{
    internal class VanillaNpcChange : INPCChange
    {
        public ValueModifier Damage { get; set; }
        public ValueModifier Defense { get; set; }
        public ValueModifier Health { get; set; }
        public ValueModifier KnockbackScaling { get; set; }
        public ValueModifier NPCSlots { get; set; }

        public void ApplyTo(NPC npc) {
            this.Damage.ApplyTo(ref npc.damage);
            this.Defense.ApplyTo(ref npc.defense);
            this.Health.ApplyTo(ref npc.lifeMax);
            this.KnockbackScaling.ApplyTo(ref npc.knockBackResist);
            this.NPCSlots.ApplyTo(ref npc.npcSlots);
            
            // Are those necessary?
            npc.life = npc.lifeMax;
            npc.defDamage = npc.damage;
            npc.defDefense = npc.defense;
        }
    }
}
