using HarmonyLib;
using Il2Cpp;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(GloveMgr))]
    public static class GloveMgrPatches
    {
        [HarmonyPatch(nameof(GloveMgr.Update))]
        [HarmonyPrefix]
        private static bool PreUpdate(GloveMgr __instance)
        {
            __instance.CDUpdate();
            return false;
        }
    }
}
