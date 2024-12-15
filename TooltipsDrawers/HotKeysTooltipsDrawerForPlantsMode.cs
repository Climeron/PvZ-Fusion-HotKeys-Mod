using ClimeronToolsForPvZ.Components;
using ClimeronToolsForPvZ.Extensions;
using HotKeysMod.Classes;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppTMPro;
using UnityEngine;

namespace HotKeysMod.TooltipsDrawers
{
    using ObjectType = HotKeyTooltipDrawer.ObjectType;
    public static class HotKeysTooltipsDrawerForPlantsMode
    {
        public static void CreateTooltips()
        {
            PrintPaths();
            DisableInGameTooltips();
            HotKeyTooltipDrawer.CreateCardsTooltips(InGameUIMgr.Instance.SeedBank.transform.Find("SeedGroup"));
            CreateTooltipsForTools();
            CreateTooltipForSlowTrigger();
        }
        private static void PrintPaths()
        {
            "Searching CardUI".Print();
            foreach (Object obj in Object.FindObjectsOfType(Il2CppType.Of<CardUI>()))
                obj.TryCast<CardUI>().transform.GetPath().Print();
            "Searching ShovelMgr".Print();
            foreach (Object obj in Object.FindObjectsOfType(Il2CppType.Of<ShovelMgr>(), true))
                obj.TryCast<ShovelMgr>().transform.GetPath().Print();
            "Searching GloveMgr".Print();
            foreach (Object obj in Object.FindObjectsOfType(Il2CppType.Of<GloveMgr>(), true))
                obj.TryCast<GloveMgr>().transform.GetPath().Print();
            "Searching HammerMgr".Print();
            foreach (Object obj in Object.FindObjectsOfType(Il2CppType.Of<HammerMgr>(), true))
                obj.TryCast<HammerMgr>().transform.GetPath().Print();
        }
        private static void CreateTooltipsForTools()
        {
            CreateTooltipForTool(InGameUIMgr.Instance.ShovelBank, (char)HotKeysManager.toolTypesDict[ToolTypesEnum.Shovel]);
            CreateTooltipForTool(InGameUIMgr.Instance.GloveBank, (char)HotKeysManager.toolTypesDict[ToolTypesEnum.Glove]);
            CreateTooltipForTool(InGameUIMgr.Instance.HammerBank, (char)HotKeysManager.toolTypesDict[ToolTypesEnum.Hammer]);
        }
        private static void CreateTooltipForTool(GameObject bank, char hotkey)
        {
            if (bank == null)
                return;
            RectTransform bankRectTransform = bank.GetComponent<RectTransform>();
            HotKeyTooltipDrawer.CreateTooltip(bankRectTransform, hotkey, ObjectType.Tool);
        }
        private static void CreateTooltipForSlowTrigger()
        {
            GameObject slowTriggerObject = InGameUIMgr.Instance.SlowTrigger;
            ShadowedTextSupporter tooltip = HotKeyTooltipDrawer.CreateTooltip(slowTriggerObject.GetComponent<RectTransform>(), "Tab", ObjectType.Button);
            tooltip.Alignment = TextAlignmentOptions.Left;
        }
        private static void DisableInGameTooltips()
        {
            InGameUIMgr.Instance.ShovelBank.transform.Find("text")?.gameObject.SetActive(false);
            InGameUIMgr.Instance.ShovelBank.transform.Find("shadow")?.gameObject.SetActive(false);
            InGameUIMgr.Instance.GloveBank.transform.Find("text")?.gameObject.SetActive(false);
            InGameUIMgr.Instance.GloveBank.transform.Find("shadow")?.gameObject.SetActive(false);
            InGameUIMgr.Instance.HammerBank.transform.Find("text")?.gameObject.SetActive(false);
            InGameUIMgr.Instance.HammerBank.transform.Find("shadow")?.gameObject.SetActive(false);
            GameObject slowTriggerObject = InGameUIMgr.Instance.SlowTrigger;
            foreach (Transform child in slowTriggerObject.GetComponentsInChildren<Transform>(true))
                if (child.parent == slowTriggerObject.transform && child.localPosition.y < -20)
                    child.gameObject.SetActive(false);
        }
    }
}
