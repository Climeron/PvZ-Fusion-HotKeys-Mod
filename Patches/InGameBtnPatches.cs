using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(InGameBtn))]
    public static class InGameBtnPatches
    {
        [HarmonyPatch(nameof(InGameBtn.Update))]
        [HarmonyPrefix]
        private static bool PreUpdate(InGameBtn __instance)
        {
            return false; //Disabling slow trigger hotkey
        }
        [HarmonyPatch(nameof(InGameBtn.OnMouseUpAsButton))]
        [HarmonyPostfix]
        private static void PostOnMouseUp(InGameBtn __instance)
        {
            if (!InGameUIMgr.Instance || !InGameUIMgr.Instance.transform.Find("Bottom"))
                return;
            Transform seedGroupTransform = InGameUIMgr.Instance.SeedBank.transform.Find("SeedGroup");
            if (InGameUIMgr.Instance.transform.Find("Bottom").gameObject.activeInHierarchy)
                HotKeyTooltipDrawer.DeleteCardsTooltips(seedGroupTransform);
            else
                HotKeyTooltipDrawer.CreateCardsTooltips(seedGroupTransform);
        }
    }
}
