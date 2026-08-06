using HarmonyLib;
using Verse;

namespace RimTalesCore
{
    [HarmonyPatch(typeof(Pawn), "Tick")]
    public static class Patch_Pawn_Tick
    {
        [HarmonyPostfix]
        public static void Postfix(Pawn __instance)
        {
            if (__instance == null || !__instance.Spawned) return;
            if (__instance.RaceProps.IsMechanoid) return;
            ManaUtility_RimTales.RTC_PawnRTC_ManaTickInterval(__instance);
        }
    }
    [StaticConstructorOnStartup]
    public static class ModBootstrapper
    {
        static ModBootstrapper()
        {
            var harmony = new Harmony("AvenskolProductions.RimTales.Core");
            harmony.PatchAll();
            Log.Message("[RimTalesCore] Patches successfully injected.");
        }
    }
}