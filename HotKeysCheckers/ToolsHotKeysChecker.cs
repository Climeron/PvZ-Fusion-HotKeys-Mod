using System.Collections;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using Il2CppSystem.Reflection;
using MelonLoader;
using UnityEngine;

namespace HotKeysMod.HotKeysCheckers
{
    public static class ToolsHotKeysChecker
    {
        public enum Tools { Shovel, Glove, Hammer }
        private static GameObject GetToolBank(int boardType, Tools tool) => tool switch
        {
            Tools.Shovel => boardType != 2 ? InGameUIMgr.Instance.ShovelBank : GameObject.Find("Canvas/InGameUIIZE/ShovelBank"),
            Tools.Glove => boardType != 2 ? InGameUIMgr.Instance.GloveBank : null,
            Tools.Hammer => boardType != 2 ? InGameUIMgr.Instance.HammerBank : null,
            _ => null
        };
        private static Transform GetTool(int boardType, Tools tool) => tool switch
        {
            Tools.Shovel => GetToolBank(boardType, tool)?.transform.Find(Tools.Shovel.ToString()),
            Tools.Glove => GetToolBank(boardType, tool)?.transform.Find(Tools.Glove.ToString()),
            Tools.Hammer => GetToolBank(boardType, tool)?.transform.Find(Tools.Hammer.ToString()),
            _ => null
        };
        private static KeyCode GetToolHotKey(Tools tool) => tool switch
        {
            Tools.Shovel => HotKeys.shovel,
            Tools.Glove => HotKeys.glove,
            Tools.Hammer => HotKeys.hammer,
            _ => default
        };
        private static Type GetToolType(Tools tool) => tool switch
        {
            Tools.Shovel => Il2CppType.Of<ShovelMgr>(),
            Tools.Glove => Il2CppType.Of<GloveMgr>(),
            Tools.Hammer => Il2CppType.Of<HammerMgr>(),
            _ => null
        };
        public static IEnumerator CheckForItem(Tools tool)
        {
            if (GameAPP.theBoardType == -1 || !Main.HotKeyIsAvailable || !Input.GetKeyDown(GetToolHotKey(tool)))
                yield break;
            Mouse mouse = Mouse.Instance;
            Main.HotKeyIsAvailable = false;
            Transform itemTransform = GetTool(GameAPP.theBoardType, tool);
            if (!itemTransform || !itemTransform.gameObject.active)
            {
                mouse.PutDownItem();
                MelonCoroutines.Start(CountDownTimeForHotKey());
                yield break;
            }
            mouse.PutDownItem();
            yield return null;
            Type toolType = GetToolType(tool);
            Component itemComponent = itemTransform.GetComponent(toolType);
            FieldInfo isAvailableField = toolType.GetField("avaliable");
            if (isAvailableField != null && !isAvailableField.GetValue(itemComponent).Unbox<bool>())
            {
                MelonCoroutines.Start(CountDownTimeForHotKey());
                yield break;
            }
            MethodInfo pickUpMethod = toolType.GetMethod("PickUp");
            pickUpMethod?.Invoke(itemComponent, null);
            mouse.theItemOnMouse = itemTransform.gameObject;
            PlaySound(toolType);
            MelonCoroutines.Start(CountDownTimeForHotKey());
        }
        private static IEnumerator CountDownTimeForHotKey()
        {
            yield return null;
            Main.HotKeyIsAvailable = true;
        }
        private static void PlaySound(Type toolType)
        {
            if (toolType == Il2CppType.Of<ShovelMgr>())
                GameAPP.PlaySound(21, 0.5f);
            else if (toolType == Il2CppType.Of<GloveMgr>())
                GameAPP.PlaySound(19, 0.5f);
            else if (toolType == Il2CppType.Of<HammerMgr>())
                GameAPP.PlaySound(19, 0.5f);
        }
    }
}
