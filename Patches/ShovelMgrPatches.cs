﻿using HarmonyLib;
using Il2Cpp;

namespace HotKeysMod.Patches
{
    [HarmonyPatch(typeof(ShovelMgr))]
    public static class ShovelMgrPatches
    {
        [HarmonyPatch(nameof(ShovelMgr.Update))]
        [HarmonyPrefix]
        private static bool PreUpdate(ShovelMgr __instance)
        {
            return false;
        }
    }
}