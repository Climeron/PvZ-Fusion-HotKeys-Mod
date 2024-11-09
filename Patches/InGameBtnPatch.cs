using HarmonyLib;
using Il2Cpp;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(InGameBtn))]
    public class InGameBtnPatch
    {
        [HarmonyPatch(nameof(InGameBtn.Update))]
        [HarmonyPrefix]
        private static bool PreUpdate(InGameBtn __instance)
        {
            return false;
        }
    }
}
