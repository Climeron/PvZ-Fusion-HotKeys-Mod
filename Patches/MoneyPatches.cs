using ClimeronToolsForPvZ.Classes.UI;
using ClimeronToolsForPvZ.Components;
using HarmonyLib;
using HotKeysMod.Classes;
using HotKeysMod.Components;
using Il2Cpp;
using Il2CppTMPro;
using UnityEngine;
using static HotKeysMod.HotKeyTooltipDrawer;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(Money))]
    public static class MoneyPatches
    {
        [HarmonyPatch(nameof(Money.Awake))]
        [HarmonyPostfix]
        private static void PostAwake(Money __instance)
        {
            DisableInGameTooltip(__instance);
            CreateTextsForGoldenBean(__instance);
        }
        private static void DisableInGameTooltip(Money __instance) => __instance.beanCount2.gameObject.SetActive(false);
        private static void CreateTextsForGoldenBean(Money __instance)
        {
            Transform beanObject = __instance.transform.Find("BeanBank");
            ShadowedTextSupporter tooltip = CreateTooltip(beanObject.GetComponent<RectTransform>(), (char)HotKeysManager.toolTypesDict[ToolTypesEnum.GoldenBean], ObjectType.GoldenBean);
            tooltip.Alignment = TextAlignmentOptions.Left;
            tooltip.Size = 70;
            ShadowedTextSupporter beansAmount = ShadowedTextCreator.CreateText("BeansAmount", beanObject);
            beansAmount.Alignment = TextAlignmentOptions.Right;
            beansAmount.Color = new(0.9f, 0.9f, 0, 1);
            beansAmount.FontStyle = FontStyles.Bold;
            beansAmount.OutlineWidth = 0.3f;
            beansAmount.ShadowOffsetX = 0.03f;
            beansAmount.ShadowOffsetY = 0.02f;
            beansAmount.Size = 30;
            beansAmount.WordWrapping = false;
            RectTransform beanAmountRectTransform = beansAmount.GetComponent<RectTransform>();
            beanAmountRectTransform.localScale = Vector3.one;
            beanAmountRectTransform.localPosition = new(33, -22.5f, 0);
            BeansAmountDrawer beansAmountDrawer = beansAmount.gameObject.AddComponent<BeansAmountDrawer>();
            beansAmountDrawer.beansAmountTextSupporter = beansAmount;
        }
    }
}
