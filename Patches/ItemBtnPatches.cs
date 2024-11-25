using HarmonyLib;
using Il2Cpp;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(ItemBtn))]
    public static class ItemBtnPatches
    {
        [HarmonyPatch(nameof(ItemBtn.Update))]
        [HarmonyPrefix]
        private static bool PreUpdate(ItemBtn __instance)
        {
            return false;
        }
    }
}
