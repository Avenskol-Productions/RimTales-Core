using System;
using Verse;

namespace RimWorld
{
    public class TileMutatorWorker_RTC_AcidManaLake : TileMutatorWorker_Lake
    {
        public TileMutatorWorker_RTC_AcidManaLake(TileMutatorDef def) : base(def)
        {
        }
        protected override void ProcessCell(IntVec3 cell, Map map)
        {
            float valAt = this.GetValAt(cell, map);
            if (this.GenerateDeepWater && valAt > 0.75f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf_RimTales.RTC_AcidManaChestDeep);
                return;
            }
            if (valAt > 0.5f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf_RimTales.RTC_AcidManaShallow);
                return;
            }
            if (valAt > 0.45f && MapGenUtility.ShouldGenerateBeachSand(cell, map))
            {
                map.terrainGrid.SetTerrain(cell, MapGenUtility.LakeshoreTerrainAt(cell, map));
            }
        }
    }
}
