using System.Collections;
using ClimeronToolsForPvZ.Extensions;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace HotKeysMod.HotKeysCheckers
{
    public static class PlantsHotkeysChecker
    {
        public static IEnumerator CheckForHotKeys()
        {
            if (GameAPP.theBoardType != 0 && GameAPP.theBoardType != 1 && GameAPP.theBoardType != 3 || !Main.HotKeyIsAvailable)
                yield break;
            foreach ((KeyCode keyCode, int index) in HotKeys.Cards)
            {
                if (!Input.GetKeyDown(keyCode))
                    continue;
                Main.HotKeyIsAvailable = false;
                Mouse mouse = Mouse.Instance;
                if (mouse.theItemOnMouse)
                {
                    yield return null;
                    mouse.PutDownItem();
                    yield return null;
                }
                Transform seedTransform = InGameUIMgr.Instance.SeedBank.transform.Find($"SeedGroup/seed{index}");
                if (!seedTransform)
                {
                    $"Seed{index} not found".Print();
                    yield break;
                }
                if (seedTransform.transform.childCount > 0)
                {
                    Transform packet = seedTransform.transform.GetChild(0);
                    if (packet)
                    {
                        CardUI cardUI = packet.GetComponent<CardUI>();
                        Transform shadow = packet.Find("Shadow");
                        if (cardUI && cardUI.isAvailable && (!shadow || shadow && !shadow.gameObject.active))
                            mouse.ClickOnCard(cardUI);
                    }
                }
                MelonCoroutines.Start(CountDownTimeForHotKey());
            }
        }
        private static IEnumerator CountDownTimeForHotKey()
        {
            yield return null;
            Main.HotKeyIsAvailable = true;
        }
    }
}
