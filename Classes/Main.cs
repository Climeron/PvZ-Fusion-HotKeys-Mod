using HotKeysMod.HotKeysCheckers;
using MelonLoader;

namespace HotKeysMod
{
    public class Main : MelonMod
    {
        private static bool _hotKeyIsAvailable = true;
        public static bool HotKeyIsAvailable
        {
            get => _hotKeyIsAvailable;
            internal set => _hotKeyIsAvailable = value;
        }

        public override void OnUpdate()
        {
            CastCheckers();
        }
        private void CastCheckers()
        {
            MelonCoroutines.Start(ToolsHotKeysChecker.CheckForItem(ToolsHotKeysChecker.Tools.Shovel));
            MelonCoroutines.Start(ToolsHotKeysChecker.CheckForItem(ToolsHotKeysChecker.Tools.Glove));
            MelonCoroutines.Start(ToolsHotKeysChecker.CheckForItem(ToolsHotKeysChecker.Tools.Hammer));
            MelonCoroutines.Start(PlantsHotkeysChecker.CheckForHotKeys());
            MelonCoroutines.Start(ZombiesHotkeysChecker.CheckForHotKeys());
            SlowTriggerChecker.CheckForHotKeys();
        }
    }
}
