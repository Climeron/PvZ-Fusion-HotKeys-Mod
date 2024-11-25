using ClimeronToolsForPvZ.Extensions;
using HotKeysMod.Classes;
using HotKeysMod.HotKeysCheckers;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace HotKeysMod
{
    public class Main : MelonMod
    {
        public static Main Instance { get; private set; }

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            Instance = this;
        }
        public override void OnUpdate()
        {
            HotKeysManager.CheckHotKeys();
        }
    }
}
