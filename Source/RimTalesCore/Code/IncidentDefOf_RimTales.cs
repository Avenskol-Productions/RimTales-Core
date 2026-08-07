using System;

namespace RimWorld
{
    [DefOf]
    public static class IncidentDefOf_RimTales
    {
        static IncidentDefOf_RimTales()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(IncidentDefOf));
        }
        public static IncidentDef ManaFog_RimTales;
    }
}