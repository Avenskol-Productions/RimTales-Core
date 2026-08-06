using RimWorld;
using Verse;
using System.Collections.Generic;

namespace RimTalesCore
{
    public class Projectile_ManaExplosion_RimTales : Projectile_Explosive
    {
        protected override void Explode()
        {
            Map map = this.Map;
            if (map != null)
            {
                float radius = this.def.projectile.explosionRadius;
                IntVec3 center = this.Position;
                IEnumerable<Thing> targets = GenRadial.RadialDistinctThingsAround(center, map, radius, true);
                foreach (Thing thing in targets)
                {
                    if (thing is Pawn pawn && pawn.RaceProps.IsFlesh)
                    {
                        ApplyManaSickness(pawn);
                    }
                }
            }
            base.Explode();
        }
        private void ApplyManaSickness(Pawn pawn)
        {
            HediffDef sicknessDef = DefDatabase<HediffDef>.GetNamedSilentFail("RTC_ManaBuildup");
            if (sicknessDef != null)
            {
                Hediff existingSickness = pawn.health.hediffSet.GetFirstHediffOfDef(sicknessDef);
                if (existingSickness != null)
                {
                    existingSickness.Severity += 0.20f;
                }
                else
                {
                    Hediff newSickness = HediffMaker.MakeHediff(sicknessDef, pawn, null);
                    newSickness.Severity = 0.20f;
                    pawn.health.AddHediff(newSickness, null, null);
                }
            }
        }
    }
}