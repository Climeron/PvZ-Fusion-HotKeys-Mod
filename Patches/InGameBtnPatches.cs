using HarmonyLib;
using Il2Cpp;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(InGameBtn))]
    public static class InGameBtnPatches
    {
        [HarmonyPatch(nameof(InGameBtn.Update))]
        [HarmonyPrefix]
        private static bool PreUpdate(InGameBtn __instance)
        {
            return false;
        }
    }
}
