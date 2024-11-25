using HarmonyLib;
using Il2Cpp;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(HammerMgr))]
    public static class HammerMgrPatches
    {
        [HarmonyPatch(nameof(HammerMgr.Update))]
        [HarmonyPrefix]
        private static bool PreUpdate(HammerMgr __instance)
        {
            __instance.CDUpdate();
            return false;
        }
    }
}
