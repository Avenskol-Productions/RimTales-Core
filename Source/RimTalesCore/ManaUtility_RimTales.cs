using System;
using RimWorld;
using UnityEngine;
using RimTalesCore;

namespace Verse
{
    public static class ManaUtility_RimTales
    {
        public static void PawnRTC_ManaTickInterval(Pawn pawn, int delta)
        {
            if (!pawn.IsHashIntervalTick(3451, delta) || !pawn.Spawned)
            {
                return;
            }
            TerrainDef terrain = pawn.Position.GetTerrain(pawn.Map);
            float num = 0f;
            if (terrain.HasModExtension<TerrainDef_RimTalesExtensions>())
            {
                num = terrain.GetModExtension<TerrainDef_RimTalesExtensions>().RTC_manaBuildupFactor;
            }
            if (num > 0f)
            {
                ManaUtility_RimTales.DoPawnToxicDamage(pawn, num);
            }
        }
        public static void DoAirbornePawnToxicDamage(Pawn p, float extraFactor = 1f)
        {
            if (p.Spawned && p.Position.Roofed(p.Map))
            {
                return;
            }
            ManaUtility_RimTales.DoPawnToxicDamage(p, extraFactor);
        }
        public static void DoPawnToxicDamage(Pawn p, float extraFactor = 1f)
        {
            float num = 0.023006668f;
            num *= Mathf.Max(1f - p.GetStatValue(StatDefOf.ToxicResistance, true, -1), 0f);
            num *= Mathf.Max(1f - p.GetStatValue(StatDefOf.ToxicEnvironmentResistance, true, -1), 0f);
            num *= extraFactor;
            if (num != 0f)
            {
                float num2 = Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(p.thingIDNumber ^ 74374237));
                num *= num2;
                HealthUtility.AdjustSeverity(p, HediffDefOf_RimTales.RTC_ManaBuildup, num);
            }
        }
        public const int CheckInterval = 3451;
    }
}