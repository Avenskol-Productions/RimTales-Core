using System;
using Verse;

namespace RimWorld
{
    // Token: 0x020035AB RID: 13739
    [DefOf]
    public static class TerrainDefOf_RimTales
    {
        // Token: 0x06013485 RID: 78981 RVA: 0x005BA9D2 File Offset: 0x005B8BD2
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