using ClimeronToolsForPvZ.Components;
using ClimeronToolsForPvZ.Extensions;
using HarmonyLib;
using HotKeysMod.Classes;
using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(EveBtn))]
    public static class EveBtnPatches
    {
        [HarmonyPatch(nameof(EveBtn.OnMouseUp))]
        [HarmonyPostfix]
        private static void PostOnMouseUp(EveBtn __instance)
        {
            if (!IZEMgr.Instance || !IZEMgr.Instance.zombieLibary || !IZEMgr.Instance.plantLibrary
                || (__instance.buttonNumber != 6 && __instance.buttonNumber != 9))
                return;
            Transform seedGroupTransform = IZEMgr.Instance.transform.Find("SeedBank/SeedGroup");
            if (IZEMgr.Instance.zombieLibary.activeInHierarchy || IZEMgr.Instance.plantLibrary.activeInHierarchy)
                HotKeyTooltipDrawer.DeleteCardsTooltips(seedGroupTransform);
            else
                HotKeyTooltipDrawer.CreateCardsTooltips(seedGroupTransform);
        }
    }
}
