using ClimeronToolsForPvZ.Classes.UI;
using ClimeronToolsForPvZ.Components;
using ClimeronToolsForPvZ.Extensions;
using HotKeysMod.Classes;
using System.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;

namespace HotKeysMod
{
    public static class HotKeyTooltipDrawer
    {
        public enum ObjectType { None, Card, Tool, GardenTool, GardenPageButton, Button, GoldenBean }
        private static readonly Dictionary<ObjectType, Vector3> _tooltipPositionsDict = new()
        {
            { ObjectType.None, new(0, 0, 0) },
            { ObjectType.Card, new(45, -50, 0) },
            { ObjectType.Tool, new(36, -21, 0) },
            { ObjectType.GardenTool, new(63, 17, 0) },
            { ObjectType.GardenPageButton, new(-8, 3, 0) },
            { ObjectType.Button, new(59, 0, 0) },
            { ObjectType.GoldenBean, new(40, 5.5f, 0) }
        };
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
            rectTransform.localPosition = _tooltipPositionsDict[objectType];
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
                if (cardNumber == HotKeysManager.cardsList.Count)
                    return;
                $"Card number {cardNumber}: '{child.name}' found".Print();
                if (child.childCount == 0)
                    continue;
                CreateTooltip(child.GetChild(0).GetComponent<RectTransform>(), (char)HotKeysManager.cardsList[cardNumber].keyCode, HotKeyTooltipDrawer.ObjectType.Card);
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
