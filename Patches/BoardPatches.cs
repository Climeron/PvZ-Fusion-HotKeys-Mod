using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(Board))]
    public static class BoardPatches
    {
        [HarmonyPatch(nameof(Board.Update))]
        [HarmonyPostfix]
        private static void PostUpdate(Board __instance)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //Disabling plant hp showing
                __instance.ShowPlantHealth();
            if (Input.GetKeyDown(KeyCode.W)) //Disabling zombie hp showing
                __instance.ShowZombieHealth();
        }
    }
}
