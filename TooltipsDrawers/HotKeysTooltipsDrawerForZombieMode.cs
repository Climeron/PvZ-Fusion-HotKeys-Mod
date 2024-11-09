using System.Collections;
using ClimeronToolsForPvZ.Extensions;
using MelonLoader;
using UnityEngine;

namespace HotKeysMod.TooltipsDrawers
{
    public static class HotKeysTooltipsDrawerForZombieMode
    {
        public static void CreateTooltips()
        {
            MelonCoroutines.Start(DelayedCast());
        }
        private static IEnumerator DelayedCast()
        {
            yield return null;
            CreateTooltipsForCards();
            CreateTooltipForShovelBank();
            DisableInGameTooltips();
        }
        private static void CreateTooltipsForCards()
        {
            GameObject seedGroupObject = GameObject.Find("Canvas/InGameUIIZE/SeedBank/SeedGroup");
            (seedGroupObject ? $"{seedGroupObject.name} found" : "SeedGroup not found").Print();
            Transform seedGroupTransform = seedGroupObject.transform;
            $"at '{seedGroupTransform.GetPath()}'".Print();
            int cardNumber = -1;
            foreach (Transform child in seedGroupTransform.GetComponentsInChildren<Transform>())
            {
                if (child.parent != seedGroupTransform)
                    continue;
                cardNumber++;
                if (cardNumber == HotKeysCheckers.HotKeys.Cards.Count)
                    return;
                $"Card number {cardNumber}: '{child.name}' found".Print();
                Transform packet = child.GetChild(0);
                if (!packet)
                    continue;
                HotKeyTooltipDrawer.CreateTooltip(packet.GetComponent<RectTransform>(), (char)HotKeysCheckers.HotKeys.Cards[cardNumber].keyCode, HotKeyTooltipDrawer.ObjectType.Card);
            }
        }
        private static void CreateTooltipForShovelBank()
        {
            GameObject shovelBankObject = GameObject.Find("Canvas/InGameUIIZE/ShovelBank");
            (shovelBankObject ? $"{shovelBankObject.name} found" : "ShovelBank not found").Print();
            Transform shovelBankTransform = shovelBankObject.transform;
            $"at '{shovelBankTransform.GetPath()}'".Print();
            HotKeyTooltipDrawer.CreateTooltip(shovelBankTransform.GetComponent<RectTransform>(), (char)HotKeysCheckers.HotKeys.shovel, HotKeyTooltipDrawer.ObjectType.Tool);
        }
        private static void DisableInGameTooltips()
        {
            Transform shovelBankTransform = GameObject.Find("Canvas/InGameUIIZE/ShovelBank").transform;
            shovelBankTransform.Find("text")?.gameObject.SetActive(false);
            shovelBankTransform.Find("shadow")?.gameObject.SetActive(false);
        }
    }
}
