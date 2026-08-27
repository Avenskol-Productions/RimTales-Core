using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorld
{
    public class GenStep_SpiceGeyser_RTC : GenStep_ScatterThings
    {
        public override int SeedPart
        {
            get
            {
                return 4281792;
            }
        }
        public override void Generate(Map map, GenStepParams parms)
        {
            if (!ModsConfig.OdysseyActive)
            {
                return;
            }
            base.Generate(map, parms);
            float x = this.densityByDistance.MaxBy((CurvePoint p) => p.x).x;
            ThingGrid thingGrid = map.thingGrid;
            foreach (IntVec3 intVec in this.RTC_SpiceGeyser)
            {
                foreach (IntVec3 intVec2 in GenRadial.RadialCellsAround(intVec, x, false))
                {
                    if (thingGrid.ThingAt(intVec2, ThingDefOf_RimTales.RTC_SpiceGeyser) == null)
                    {
                        float lengthHorizontal = (intVec2 - intVec).LengthHorizontal;
                        if (Rand.Chance(this.densityByDistance.Evaluate(lengthHorizontal)))
                        {
                            this.DoPlaceRandomFloraAt(intVec2, map);
                        }
                    }
                }
            }
            this.RTC_SpiceGeyser.Clear();
        }
        protected override void ScatterAt(IntVec3 loc, Map map, GenStepParams parms, int stackCount = 1)
        {
            this.RTC_SpiceGeyser.Add(loc);
            base.ScatterAt(loc, map, parms, stackCount);
        }
        private void DoPlaceRandomFloraAt(IntVec3 pos, Map map)
        {
            ThingDef plant = this.floraToScatter.RandomElementByWeight((BiomePlantRecord f) => f.commonality).plant;
            Thing thing;
            if (!plant.CanEverPlantAt(pos, map, out thing, false, true, true))
            {
                return;
            }
            Plant plant2 = (Plant)ThingMaker.MakeThing(plant, null);
            plant2.Growth = Mathf.Clamp01(WildPlantSpawner.InitialGrowthRandomRange.RandomInRange);
            if (plant2.def.plant.LimitedLifespan)
            {
                plant2.Age = Rand.Range(0, Mathf.Max(plant2.def.plant.LifespanTicks - 50, 0));
            }
            GenSpawn.Spawn(plant2, pos, map, WipeMode.Vanish);
        }
        public List<BiomePlantRecord> floraToScatter;
        public SimpleCurve densityByDistance;
        [Unsaved(false)]
        private List<IntVec3> RTC_SpiceGeyser = new List<IntVec3>();
    }
}