using ClimeronToolsForPvZ.Classes.UI;
using ClimeronToolsForPvZ.Components;
using ClimeronToolsForPvZ.Extensions;
using HotKeysMod.Classes;
using Il2Cpp;
using Il2CppTMPro;
using UnityEngine;

namespace HotKeysMod
{
    public static class HotKeyTooltipDrawer
    {
        public enum ObjectType { Card, Tool, Button, GoldenBean }
        private static Vector3 _cardTooltipOffset = new(45, -50, 0);
        private static Vector3 _toolTooltipOffset = new(36, -21, 0);
        private static Vector3 _buttonTooltipOffset = new(59, 0, 0);
        private static Vector3 _goldenBeanTooltipOffset = new(40f, 5.5f, 0);
        public static ShadowedTextSupporter CreateTooltip(RectTransform parentRectTransform, char hotKeyChar, ObjectType objectType) =>
            CreateTooltip(parentRectTransform, hotKeyChar.ToString(), objectType);
        public static ShadowedTextSupporter CreateTooltip(RectTransform parentRectTransform, string hotKeyText, ObjectType objectType)
        {
            if (!parentRectTransform)
                return null;
            ShadowedTextSupporter textSupporter = ShadowedTextCreator.CreateText("HotKeyTooltip", parentRectTransform);
            textSupporter.Text = $"[<b>{hotKeyText}</b>]";
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
                ObjectType.GoldenBean => _goldenBeanTooltipOffset,
                _ => new()
            };
            return textSupporter;
        }
        public static void CreateCardsTooltips(Transform seedGroupTransform)
        {
            (seedGroupTransform ? $"{seedGroupTransform.name} found" : "SeedGroup not found").Print();
            $"at '{seedGroupTransform.transform.GetPath()}'".Print();
            int cardNumber = -1;
            foreach (Transform child in seedGroupTransform.GetComponentsInChildren<Transform>())
            {
                if (child.parent != seedGroupTransform)
                    continue;
                cardNumber++;
                if (cardNumber == HotKeysManager.Cards.Count)
                    return;
                $"Card number {cardNumber}: '{child.name}' found".Print();
                if (child.childCount == 0)
                    continue;
                CreateTooltip(child.GetChild(0).GetComponent<RectTransform>(), (char)HotKeysManager.Cards[cardNumber].keyCode, HotKeyTooltipDrawer.ObjectType.Card);
            }
        }
        public static void DeleteCardsTooltips(Transform seedGroupTransform)
        {
            (seedGroupTransform ? $"{seedGroupTransform.name} found" : "SeedGroup not found").Print();
            $"at '{seedGroupTransform.GetPath()}'".Print();
            foreach (ShadowedTextSupporter supporter in seedGroupTransform.GetComponentsInChildren<ShadowedTextSupporter>())
                Object.Destroy(supporter.gameObject);
        }
    }
}
