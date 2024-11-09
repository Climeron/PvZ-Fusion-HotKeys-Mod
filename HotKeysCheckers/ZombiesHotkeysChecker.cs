using System.Collections;
using ClimeronToolsForPvZ.Extensions;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace HotKeysMod.HotKeysCheckers
{
    public static class ZombiesHotkeysChecker
    {
        public static IEnumerator CheckForHotKeys()
        {
            if (GameAPP.theBoardType != 2 || !Main.HotKeyIsAvailable)
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
                GameObject seedGroupObject = GameObject.Find("Canvas/InGameUIIZE/SeedBank/SeedGroup");
                if (!seedGroupObject)
                {
                    $"SeedGroup not found".Print();
                    yield break;
                }
                Transform seedGroupTransform = seedGroupObject.transform;
                int cardNumber = -1;
                foreach (Transform child in seedGroupTransform.GetComponentsInChildren<Transform>())
                {
                    if (child.parent != seedGroupTransform)
                        continue;
                    cardNumber++;
                    if (cardNumber != index)
                        continue;
                    Transform packet = child.GetChild(0);
                    if (!packet)
                        continue;
                    if (packet.TryGetComponent(out IZECard izeCard))
                        mouse.ClickOnIZECard(izeCard);
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
