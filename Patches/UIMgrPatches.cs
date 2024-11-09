using System.Collections;
using HarmonyLib;
using HotKeysMod.TooltipsDrawers;
using Il2Cpp;
using MelonLoader;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(UIMgr))]
    public static class UIMgrPatches
    {
        [HarmonyPatch(nameof(UIMgr.EnterIZGame))]
        [HarmonyPostfix]
        private static void PostUpdate(UIMgr __instance)
        {
            MelonCoroutines.Start(CreateTooltipsWithDelay());
        }
        private static IEnumerator CreateTooltipsWithDelay()
        {
            yield return null;
            HotKeysTooltipsDrawerForZombieMode.CreateTooltips();
        }
    }
}
