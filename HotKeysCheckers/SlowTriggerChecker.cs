using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.HotKeysCheckers
{
    public static class SlowTriggerChecker
    {
        public static void CheckForHotKeys()
        {
            if (GameAPP.theBoardType == -1 || !Input.GetKeyDown(HotKeys.slowTrigger))
                return;
            var btns = Object.FindObjectsOfType<InGameBtn>();
            foreach (InGameBtn btn in btns)
            {
                if (btn.buttonNumber == 3)
                {
                    btn.SpeedTrigger();
                    return;
                }
            }
        }
    }
}
