using System;

namespace RimWorld
{
    [DefOf]
    public static class StatDefOf_RimTales
    {
        static StatDefOf_RimTales()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StatDefOf));
        }
        public static StatDef RTC_ManaResistance;
        public static StatDef RTC_ManaEnvironmentResistance;
    }
}