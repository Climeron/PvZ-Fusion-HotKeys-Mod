using ClimeronToolsForPvZ.Classes.UI;
using ClimeronToolsForPvZ.Components;
using Il2CppTMPro;
using UnityEngine;

namespace HotKeysMod
{
    public static class HotKeyTooltipDrawer
    {
        public enum ObjectType { Card, Tool, Button }
        private static Vector3 _cardTooltipOffset = new(45, -50, 0);
        private static Vector3 _toolTooltipOffset = new(36, -21, 0);
        private static Vector3 _buttonTooltipOffset = new(93.5f, 0, 0);
        public static void CreateTooltip(RectTransform parentRectTransform, char hotKeyChar, ObjectType objectType)
        {
            if (!parentRectTransform)
                return;
            ShadowedTextSupporter textSupporter = ShadowedTextCreator.CreateText("HotKeyTooltip", parentRectTransform);
            textSupporter.Text = $"[<b>{hotKeyChar}</b>]";
            textSupporter.Color = Color.green;
            textSupporter.OutlineWidth = 0.3f;
            textSupporter.Size = 26;
            textSupporter.ShadowOffsetX = 1;
            textSupporter.ShadowOffsetY = -1;
            textSupporter.Alignment = TextAlignmentOptions.Right;
            textSupporter.FontStyle = FontStyles.SmallCaps;
            textSupporter.WordWrapping = false;
            textSupporter.DrawAlwaysOnTop = true;
            RectTransform rectTransform = textSupporter.GetComponent<RectTransform>();
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localScale = new(1, 1, 1);
            rectTransform.localPosition = objectType switch
            {
                ObjectType.Card => _cardTooltipOffset,
                ObjectType.Tool => _toolTooltipOffset,
                ObjectType.Button => _buttonTooltipOffset,
                _ => new()
            };
        }
    }
}
