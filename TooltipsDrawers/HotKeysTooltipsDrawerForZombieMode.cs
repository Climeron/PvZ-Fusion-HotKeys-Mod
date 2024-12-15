using System.Collections;
using HotKeysMod.Classes;
using Il2Cpp;
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
            CreateTooltipForTools();
            DisableInGameTooltips();
        }
        private static void CreateTooltipForTools()
        {
            HotKeyTooltipDrawer.CreateTooltip(IZEMgr.Instance.shovel.GetComponent<RectTransform>(), (char)HotKeysManager.toolTypesDict[ToolTypesEnum.Shovel], HotKeyTooltipDrawer.ObjectType.Tool);
            HotKeyTooltipDrawer.CreateTooltip(IZEMgr.Instance.glove.GetComponent<RectTransform>(), (char)HotKeysManager.toolTypesDict[ToolTypesEnum.Glove], HotKeyTooltipDrawer.ObjectType.Tool);
        }
        private static void DisableInGameTooltips()
        {
            if (!IZEMgr.Instance)
                return;
            Transform shovelBankTransform = IZEMgr.Instance.shovel.transform;
            shovelBankTransform.Find("text")?.gameObject.SetActive(false);
            shovelBankTransform.Find("shadow")?.gameObject.SetActive(false);
            Transform gloveBankTransform = IZEMgr.Instance.glove.transform;
            gloveBankTransform.Find("text")?.gameObject.SetActive(false);
            gloveBankTransform.Find("shadow")?.gameObject.SetActive(false);
        }
    }
}
