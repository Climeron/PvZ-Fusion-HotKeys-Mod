using System.Linq;
using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.HotKeysCheckers
{
    public static class SlowTrigger
    {
        public static void Cast()
        {
            if (GameAPP.theGameStatus != (int)GameStatus.InGame)
                return;
            Object.FindObjectsOfType<InGameBtn>()
                .FirstOrDefault(btn => btn.buttonNumber == 3)?
                .SpeedTrigger();
        }
    }
}
