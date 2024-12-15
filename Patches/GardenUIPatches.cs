using ClimeronToolsForPvZ.Components;
using ClimeronToolsForPvZ.Extensions;
using HarmonyLib;
using HotKeysMod.Classes;
using Il2Cpp;
using System;
using UnityEngine;
using static Il2Cpp.AlmanacCard;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(GardenUI))]
    public static class GardenUIPatches
    {
        [HarmonyPatch(nameof(GardenUI.Awake))]
        [HarmonyPostfix]
        private static void PostUpdate(GardenUI __instance) => CreateTooltips();
        private static void CreateTooltips()
        {
            if (!GameAPP.canvas)
            {
                $"Tried to find canvas but it was null.".PrintError<NullReferenceException>();
                return;
            }
            CreateToolsTooltips();
            CreateArrowsTooltips();
        }
        private static void CreateToolsTooltips()
        {
            Transform toolBanks = GameAPP.canvas.transform.Find("GardenUI/Tools");
            if (!toolBanks)
            {
                $"Tried to find {nameof(toolBanks)} but it was null.".PrintError<NullReferenceException>();
                return;
            }
            int cardNumber = -1;
            foreach (Il2CppSystem.Object bank in toolBanks)
            {
                cardNumber++;
                ShadowedTextSupporter tooltip = HotKeyTooltipDrawer.CreateTooltip(bank.Cast<RectTransform>(), (char)HotKeysManager.cardsList[cardNumber].keyCode, HotKeyTooltipDrawer.ObjectType.GardenTool);
                tooltip.Alignment = Il2CppTMPro.TextAlignmentOptions.Center;
            }
        }
        private static void CreateArrowsTooltips()
        {
            CreateLeftArrowTooltip();
            CreateRightArrowTooltip();
        }
        private static void CreateLeftArrowTooltip()
        {
            Transform previousPageButton = GameAPP.canvas.transform.Find("GardenUI/LastGarden");
            if (!previousPageButton)
            {
                $"Tried to find {nameof(previousPageButton)} but it was null.".PrintError<NullReferenceException>();
                return;
            }
            ShadowedTextSupporter tooltip = HotKeyTooltipDrawer.CreateTooltip(previousPageButton.GetComponent<RectTransform>(), HotKeysManager.previousGardenPage.label, HotKeyTooltipDrawer.ObjectType.GardenPageButton);
            tooltip.Alignment = Il2CppTMPro.TextAlignmentOptions.Midline;
            tooltip.Size = 20;
            tooltip.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180, 0);
        }
        private static void CreateRightArrowTooltip()
        {
            Transform nextPageButton = GameAPP.canvas.transform.Find("GardenUI/NextGarden");
            if (!nextPageButton)
            {
                $"Tried to find {nameof(nextPageButton)} but it was null.".PrintError<NullReferenceException>();
                return;
            }
            ShadowedTextSupporter tooltip = HotKeyTooltipDrawer.CreateTooltip(nextPageButton.GetComponent<RectTransform>(), HotKeysManager.nextGardenPage.label, HotKeyTooltipDrawer.ObjectType.GardenPageButton);
            tooltip.Alignment = Il2CppTMPro.TextAlignmentOptions.Midline;
            tooltip.Size = 20;
        }
    }
}
