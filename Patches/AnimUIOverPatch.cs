using HarmonyLib;
using HotKeysMod.TooltipsDrawers;
using Il2Cpp;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(AnimUIOver))]
    public static class AnimUIOverPatch
    {
        [HarmonyPatch(nameof(AnimUIOver.Die))]
        [HarmonyPostfix]
        private static void PostUpdate(AnimUIOver __instance)
        {
            HotKeysTooltipsDrawerForPlantsMode.CreateTooltips();
        }
    }
}
