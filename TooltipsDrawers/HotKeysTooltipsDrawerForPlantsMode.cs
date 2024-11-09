using System.Collections.Generic;
using System.Linq;
using ClimeronToolsForPvZ.Extensions;
using HotKeysMod.HotKeysCheckers;
using Il2Cpp;
using Il2CppInterop.Runtime;
using UnityEngine;

namespace HotKeysMod.TooltipsDrawers
{
    using ObjectType = HotKeyTooltipDrawer.ObjectType;
    public static class HotKeysTooltipsDrawerForPlantsMode
    {
        public static void CreateTooltips()
        {
            PrintPaths();
            CreateTooltipsForCards();
            CreateTooltipsForTools();
            CreateTooltipForSlowTrigger();
            DisableInGameTooltips();
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
        private static void CreateTooltipsForCards()
        {
            List<(KeyCode keyCode, int index)> cardsHotkeys = HotKeys.Cards;
            for (int i = 0; i < 14; i++)
            {
                (KeyCode keyCode, int index) tuple = cardsHotkeys.FirstOrDefault(tuple => tuple.index == i);
                if (tuple.Equals(default))
                    continue;
                Transform seed = InGameUIMgr.Instance.SeedBank.transform.Find($"SeedGroup/seed{i}");
                if (!seed || seed.childCount == 0)
                    return;
                RectTransform packet = seed.transform.GetChild(0).GetComponent<RectTransform>();
                HotKeyTooltipDrawer.CreateTooltip(packet, (char)tuple.keyCode, ObjectType.Card);
            }
        }
        private static void CreateTooltipsForTools()
        {
            CreateTooltipForTool(InGameUIMgr.Instance.ShovelBank, (char)HotKeys.shovel);
            CreateTooltipForTool(InGameUIMgr.Instance.GloveBank, (char)HotKeys.glove);
            CreateTooltipForTool(InGameUIMgr.Instance.HammerBank, (char)HotKeys.hammer);
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
            HotKeyTooltipDrawer.CreateTooltip(slowTriggerObject.GetComponent<RectTransform>(), (char)HotKeys.slowTrigger, ObjectType.Button);
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
