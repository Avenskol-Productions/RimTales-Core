using System;
using System.Collections.Generic;
using Verse;

namespace RimWorld
{
    public class PlaceWorker_OnSpiceGeyser_RTC : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            Thing thing2 = map.thingGrid.ThingAt(loc, ThingDefOf_RimTales.RTC_SpiceGeyser);
            if (thing2 == null || thing2.Position != loc)
            {
                return "MustPlaceOnSpiceGeyser".Translate();
            }
            return true;
        }
        public override bool ForceAllowPlaceOver(BuildableDef otherDef)
        {
            return otherDef == ThingDefOf_RimTales.RTC_SpiceGeyser;
        }
        public override void DrawMouseAttachments(BuildableDef def)
        {
            List<Thing> list = Find.CurrentMap.listerThings.ThingsOfDef(ThingDefOf_RimTales.RTC_SpiceGeyser);
            for (int i = 0; i < list.Count; i++)
            {
                TargetHighlighter.Highlight(list[i], true, true, false);
            }
        }
    }
}