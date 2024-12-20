﻿using System.Collections.Generic;
using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.Classes
{
    public static class MouseIntegration
    {
        public static object PickUpCard(int index)
        {
            Mouse mouse = Mouse.Instance;
            if (!mouse || GameAPP.theGameStatus != (int)GameStatus.InGame)
                return null;
            DestroyPlantPreview();
            mouse.PutDownItem();
            object card = GetCard(index);
            if (card == null)
                return null;
            switch (card)
            {
                case IZECard izeCard:
                    if (!izeCard.gameObject.activeInHierarchy)
                        return null;
                    mouse.ClickOnIZECard(izeCard);
                    return izeCard;
                case CardUI cardUI:
                    if (!cardUI.gameObject.activeInHierarchy || !cardUI.isAvailable)
                        return null;
                    mouse.ClickOnCard(cardUI);
                    return cardUI;
            }
            return card;
        }
        public static void DestroyPlantPreview()
        {
            Mouse mouse = Mouse.Instance;
            if (mouse.preview)
            {
                Object.Destroy(mouse.preview);
                mouse.preview = null;
            }
        }
        public static object GetCard(int index)
        {
            Transform seedGroup = GetCardsGroup();
            if (!seedGroup || seedGroup.childCount <= index)
                return null;
            Transform cardContainer = seedGroup.GetChild(index);
            if (cardContainer.childCount == 0)
                return null;
            Transform card = cardContainer.GetChild(0);
            if (card.TryGetComponent(out IZECard izeCard))
                return izeCard;
            else if (card.TryGetComponent(out CardUI cardUI))
                return cardUI;
            return null;
        }
        public static Transform GetCardsGroup() =>
            GameAPP.canvas.transform.Find("InGameUIFHD/SeedBank/SeedGroup")
                ?? GameAPP.canvas.transform.Find("InGameUIIZE/SeedBank/SeedGroup");
        public static object PickUpTool(ToolTypesEnum toolType)
        {
            Mouse mouse = Mouse.Instance;
            if (!mouse || GameAPP.theGameStatus != (int)GameStatus.InGame)
                return null;
            object toolObject = GetTool(toolType);
            GameObject itemOnMouse = mouse.theItemOnMouse;
            mouse.PutDownItem();
            if (toolObject == null || MouseObjectCorrespondsToolType(itemOnMouse, toolType))
                return null;
            switch (toolObject)
            {
                case ShovelMgr shovel:
                    if (!shovel.gameObject.activeInHierarchy)
                        return null;
                    shovel.PickUp();
                    mouse.theItemOnMouse = shovel.gameObject;
                    return shovel;
                case GloveMgr glove:
                    if (!glove.gameObject.activeInHierarchy || !glove.avaliable)
                        return null;
                    glove.PickUp();
                    mouse.theItemOnMouse = glove.gameObject;
                    return glove;
                case HammerMgr hammer:
                    if (!hammer.gameObject.activeInHierarchy || !hammer.avaliable)
                        return null;
                    hammer.PickUp();
                    mouse.theItemOnMouse = hammer.gameObject;
                    return hammer;
                case ItemBtn bean:
                    if (!bean.gameObject.activeInHierarchy || Money.Instance?.board.theMoney <= 1000)
                        return null;
                    mouse.theItemOnMouse = bean.Clicked();
                    return bean;
            }
            return toolObject;
        }
        public static bool MouseObjectCorrespondsToolType(GameObject item, ToolTypesEnum toolType)
        {
            if (!item)
                return false;
            else if (item.GetComponent<ShovelMgr>() && toolType == ToolTypesEnum.Shovel)
                return true;
            else if (item.GetComponent<GloveMgr>() && toolType == ToolTypesEnum.Glove)
                return true;
            else if (item.GetComponent<HammerMgr>() && toolType == ToolTypesEnum.Hammer)
                return true;
            else if (item.name == "bean" && toolType == ToolTypesEnum.GoldenBean)
                return true;
            return false;
        }
        public static object GetTool(ToolTypesEnum toolType)
        {
            switch (toolType)
            {
                case ToolTypesEnum.Shovel:
                    Transform shovelTransform = GameAPP.canvas.transform.Find("InGameUIFHD/ShovelBank/Shovel")
                        ?? GameAPP.canvas.transform.Find("InGameUIIZE/ShovelBank/Shovel");
                    return shovelTransform?.GetComponent<ShovelMgr>();
                case ToolTypesEnum.Glove:
                    Transform gloveTransform = GameAPP.canvas.transform.Find("InGameUIFHD/GloveBank/Glove")
                        ?? GameAPP.canvas.transform.Find("InGameUIIZE/GloveBank/Glove");
                    return gloveTransform?.GetComponent<GloveMgr>();
                case ToolTypesEnum.Hammer:
                    Transform hammerTransform = GameAPP.canvas.transform.Find("InGameUIFHD/HammerBank/Hammer")
                        ?? GameAPP.canvas.transform.Find("InGameUIIZE/HammerBank/Hammer");
                    return hammerTransform?.GetComponent<HammerMgr>();
                case ToolTypesEnum.GoldenBean:
                    Transform beenBankTransform = GameAPP.canvasUp.transform.Find("MoneyBank/BeanBank");
                    return beenBankTransform?.GetComponent<ItemBtn>();
            }
            return null;
        }
        public static GardenTool PickUpGardenTool(int index)
        {
            GardenUI gardenUI = GardenUI.Instance;
            if (!gardenUI)
                return null;
            GardenTool tool = GetGardenTool(index);
            if (gardenUI.toolOnMouse)
            {
                gardenUI.RightClick();
                if (!tool)
                    return null;
            }
            tool.PickUp();
            gardenUI.toolOnMouse = tool;
            return tool;
        }
        public static GardenTool GetGardenTool(int index) => GetGardenTools()[index];
        public static GardenTool[] GetGardenTools()
        {
            List<GardenTool> gardenToolsList = new();
            foreach (RectTransform bank in GetGardenBanks())
                gardenToolsList.Add(bank.GetComponentInChildren<GardenTool>());
            return gardenToolsList.ToArray();
        }
        public static RectTransform[] GetGardenBanks()
        {
            Transform toolsGroup = GameAPP.canvas.transform.Find("GardenUI/Tools");
            if (!toolsGroup)
                return null;
            List<RectTransform> banksList = new();
            foreach (Il2CppSystem.Object bank in toolsGroup)
                banksList.Add(bank.Cast<RectTransform>());
            return banksList.ToArray();
        }
    }
}
