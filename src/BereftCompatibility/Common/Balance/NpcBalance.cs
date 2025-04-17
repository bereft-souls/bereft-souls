using System;

using CalamityMod;

using JetBrains.Annotations;

using SOTS.NPCs;
using SOTS.NPCs.Boss;
using SOTS.NPCs.Boss.Advisor;
using SOTS.NPCs.Boss.Curse;
using SOTS.NPCs.Boss.Glowmoth;
using SOTS.NPCs.Boss.Lux;
using SOTS.NPCs.Boss.Polaris;
using SOTS.NPCs.Boss.Polaris.NewPolaris;

using Terraria;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

// ReSharper disable InconsistentNaming

namespace BereftCompatibility.Common.Balance;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
public sealed class NpcBalance : GlobalNPC
{
    // public override bool InstancePerEntity => true;

    public override void SetDefaults(NPC npc)
    {
        var calNpc = npc.Calamity();

        // Glowmoth
        {
            if (npc.type == NPCType<Glowmoth>())
            {
                npc.lifeMax = 4200;

                calNpc.VulnerableToSickness = true;
            }

            if (npc.type == NPCType<Glowmoth>() || npc.type == NPCType<GlowmothMinion>())
            {
                // One projectile, spawned from Glowmoth minion, has
                // explicitly-typed damage.  This applies to the rest of the
                // fight's projectiles.
                npc.damage = 45;
            }
        }

        // Putrid Pinky
        {
            if (npc.type == NPCType<PutridPinkyPhase2>())
            {
                npc.lifeMax = 6875; // base is 5000
            }

            if (npc.type == NPCType<PutridHook>())
            {
                npc.lifeMax = 500; // base is 400
            }

            if (npc.type == NPCType<PutridPinky1>() || npc.type == NPCType<PutridPinkyPhase2>() || npc.type == NPCType<PutridHook>())
            {
                npc.damage = 50;

                calNpc.VulnerableToSickness = false;
                calNpc.VulnerableToHeat     = true;
            }
        }

        // Pharaoh
        {
            if (npc.type == NPCType<PharaohsCurse>())
            {
                npc.lifeMax = 4200; // base is 4000
                npc.damage  = 50;

                ModCalls.SetDefenseDamageNPC(npc, true);

                calNpc.VulnerableToCold     = true;
                calNpc.VulnerableToHeat     = false;
                calNpc.VulnerableToSickness = false;
            }
        }

        // The Advisor
        {
            if (npc.type == NPCType<TheAdvisorHead>())
            {
                // Stats also need to be scaled in a detour because of how the
                // boss works.

                npc.lifeMax = 17000; // base is 12500
                npc.damage  = 62;    // base is 54

                calNpc.VulnerableToElectricity = true;
                calNpc.VulnerableToSickness    = false;
            }

            if (npc.type == NPCType<PhaseEye>())
            {
                npc.lifeMax = 68;
                npc.damage  = 58;

                calNpc.VulnerableToElectricity = true;
                calNpc.VulnerableToSickness    = false;
            }
        }

        // Polaris
        if (npc.type == NPCType<Polaris>() || npc.type == NPCType<NewPolaris>())
        {
            npc.lifeMax = 80000;
            npc.damage  = 85;

            ModCalls.SetDefenseDamageNPC(npc, true);

            calNpc.VulnerableToElectricity = true;
            calNpc.VulnerableToHeat        = true;
            calNpc.VulnerableToCold        = false;
            calNpc.VulnerableToSickness    = false;
        }

        // Lux
        {
            if (npc.type == NPCType<Lux>())
            {
                npc.lifeMax = 68000;
                npc.damage  = 112;
            }

            if (npc.type == NPCType<FakeLux>())
            {
                npc.damage = 100;
            }
        }

        // Calamity boss health boost config compatibility.
        if (!Main.gameMenu && npc.boss && npc.ModNPC?.Mod == ModCompatibility.Sots.Mod)
        {
            BoostHealth(ref npc.lifeMax);
        }
    }

    public override void Load()
    {
        MonoModHooks.Add(
            typeof(TheAdvisorHead).GetMethod(nameof(TheAdvisorHead.ScaleExpertStats), GENERIC_FLAGS),
            Advisor_ScaleExpertStats_Detour
        );
    }

    private static void Advisor_ScaleExpertStats_Detour(Action<TheAdvisorHead> orig, TheAdvisorHead self)
    {
        orig(self);

        self.NPC.life = self.NPC.lifeMax = 17000; // base is 12500

        BoostHealth(ref self.NPC.lifeMax);

        self.NPC.damage = 62; // base is 54
        self.NPC.ScaleStats(null, Main.GameModeInfo, null);
    }

    private static void BoostHealth(ref int lifeMax)
    {
        if (CalamityConfig.Instance is null)
        {
            return;
        }

        var hpBoost = CalamityConfig.Instance.BossHealthBoost * 0.01f;

        lifeMax += (int)(lifeMax * hpBoost);
    }
}