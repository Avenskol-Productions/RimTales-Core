using System;
using Verse;

namespace RimWorld
{
    [DefOf]
    public static class TerrainDefOf_RimTales
    {
        static TerrainDefOf_RimTales()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TerrainDefOf));
        }
        public static TerrainDef RTC_AcidManaChestDeep;
        public static TerrainDef RTC_AcidManaShallow;
        public static TerrainDef RTC_FireManaChestDeep;
        public static TerrainDef RTC_FireManaShallow;
        public static TerrainDef RTC_IceManaChestDeep;
        public static TerrainDef RTC_IceManaShallow;
    }
}