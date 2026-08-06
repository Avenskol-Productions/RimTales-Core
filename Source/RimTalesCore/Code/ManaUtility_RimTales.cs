using System;
using RimWorld;
using UnityEngine;
using RimTalesCore;

namespace Verse
{
    public static class ManaUtility_RimTales
    {
        public static void RTC_PawnRTC_ManaTickInterval(Pawn pawn)
        {
            if (!pawn.IsHashIntervalTick(CheckInterval) || !pawn.Spawned || pawn.Dead)
            {
                return;
            }
            TerrainDef terrain = pawn.Position.GetTerrain(pawn.Map);
            float num = 0f;
            if (terrain != null && terrain.HasModExtension<TerrainDef_RimTalesExtensions>())
            {
                num = terrain.GetModExtension<TerrainDef_RimTalesExtensions>().RTC_manaBuildupFactor;
            }
            if (num > 0f)
            {
                ManaUtility_RimTales.RTC_DoPawnManaDamage(pawn, num);
            }
        }
        public static void RTC_DoAirbornePawnManaDamage(Pawn p, float extraFactor = 1f)
        {
            if (p.Spawned && p.Position.Roofed(p.Map))
            {
                return;
            }
            ManaUtility_RimTales.RTC_DoPawnManaDamage(p, extraFactor);
        }
        public static void RTC_DoPawnManaDamage(Pawn p, float extraFactor = 1f)
        {
            float num = 0.023006668f;
            num *= Mathf.Max(1f - p.GetStatValue(StatDefOf_RimTales.RTC_ManaResistance, true, -1), 0f);
            num *= Mathf.Max(1f - p.GetStatValue(StatDefOf_RimTales.RTC_ManaEnvironmentResistance, true, -1), 0f);
            num *= extraFactor;
            if (num != 0f)
            {
                float num2 = Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(p.thingIDNumber ^ 74374237));
                num *= num2;
                HealthUtility.AdjustSeverity(p, HediffDefOf_RimTales.RTC_ManaBuildup, num);
            }
        }
        public const int CheckInterval = 3451;
        private const float ManaPerDay = 0.4f;
    }
}