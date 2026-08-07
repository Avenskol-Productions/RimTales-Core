using System;
using Verse;

namespace RimWorld
{
    public class StatPart_ManaFog_RimTales : StatPart
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (this.ActiveFor(req.Thing))
            {
                val *= this.multiplier;
            }
        }
        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && this.ActiveFor(req.Thing))
            {
                return "StatsReport_MultiplierFor".Translate(GameConditionDefOf_RimTales.ManaFog_RimTales.label) + (": x" + this.multiplier.ToStringPercent());
            }
            return null;
        }
        private bool ActiveFor(Thing t)
        {
            return t != null && t.def.deteriorateFromEnvironmentalEffects && t.MapHeld != null && t.MapHeld.gameConditionManager.ConditionIsActive(GameConditionDefOf_RimTales.ManaFog_RimTales) && t.PositionHeld.IsValid && !t.PositionHeld.Roofed(t.MapHeld);
        }
        private float multiplier = 1f;
    }
}