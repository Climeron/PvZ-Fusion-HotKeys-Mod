using ClimeronToolsForPvZ.Components;
using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.Components
{
    public class BeansAmountDrawer : MonoBehaviour
    {
        public ShadowedTextSupporter beansAmountTextSupporter;

        private void Update()
        {
            beansAmountTextSupporter.Text = $"x{Money.Instance?.board.theMoney / 1000}";
        }
    }
}
