using System.Collections.Generic;
using ClimeronToolsForPvZ.Extensions;
using HotKeysMod.Classes;
using UnityEngine;

namespace HotKeysMod.HotKeysCheckers
{
    public static class HotKeysManager
    {
        public static readonly (KeyCode keyCode, int index) card0 = (Main.key0.Value, 0);
        public static readonly (KeyCode keyCode, int index) card1 = (Main.key1.Value, 1);
        public static readonly (KeyCode keyCode, int index) card2 = (Main.key2.Value, 2);
        public static readonly (KeyCode keyCode, int index) card3 = (Main.key3.Value, 3);
        public static readonly (KeyCode keyCode, int index) card4 = (Main.key4.Value, 4);
        public static readonly (KeyCode keyCode, int index) card5 = (Main.key5.Value, 5);
        public static readonly (KeyCode keyCode, int index) card6 = (Main.key6.Value, 6);
        public static readonly (KeyCode keyCode, int index) card7 = (Main.key7.Value, 7);
        public static readonly (KeyCode keyCode, int index) card8 = (Main.key8.Value, 8);
        public static readonly (KeyCode keyCode, int index) card9 = (Main.key9.Value, 9);
        public static readonly (KeyCode keyCode, int index) card10 = (Main.key10.Value, 10);
        public static readonly (KeyCode keyCode, int index) card11 = (Main.key11.Value, 11);
        public static readonly (KeyCode keyCode, int index) card12 = (Main.key12.Value, 12);
        public static readonly (KeyCode keyCode, int index) card13 = (Main.key13.Value, 13);
        public static readonly KeyCode shovel = Main.keyShovel.Value;
        public static readonly KeyCode glove = Main.keyGlove.Value;
        public static readonly KeyCode hammer = Main.keyHammer.Value;
        public static readonly KeyCode goldenBean = Main.keyGoldenBean.Value;
        public static readonly KeyCode slowTrigger = Main.keySlowTrigger.Value;
        public static Dictionary<ToolTypesEnum, KeyCode> ToolTypes
        {
            get
            {
                Dictionary<ToolTypesEnum, KeyCode> resultDict = new();
                resultDict[ToolTypesEnum.Shovel] = shovel;
                resultDict[ToolTypesEnum.Glove] = glove;
                resultDict[ToolTypesEnum.Hammer] = hammer;
                resultDict[ToolTypesEnum.GoldenBean] = goldenBean;
                return resultDict;
            }
        }
        public static List<(KeyCode keyCode, int index)> Cards
        {
            get
            {
                List<(KeyCode keyCode, int arg0)> resultList = new();
                resultList.Add(card0);
                resultList.Add(card1);
                resultList.Add(card2);
                resultList.Add(card3);
                resultList.Add(card4);
                resultList.Add(card5);
                resultList.Add(card6);
                resultList.Add(card7);
                resultList.Add(card8);
                resultList.Add(card9);
                resultList.Add(card10);
                resultList.Add(card11);
                resultList.Add(card12);
                resultList.Add(card13);
                return resultList;
            }
        }

        public static void CheckHotKeys()
        {
            CheckToolsHotKeys();
            CheckCardsHotKeys();
            CheckSlowTriggerHotKey();
        }
        private static void CheckToolsHotKeys() =>
            ToolTypes.FindAll(pair => Input.GetKeyDown(pair.Value))
                .ForEach(pair => MouseIntegration.PickUpTool(pair.Key));
        private static void CheckCardsHotKeys() =>
            Cards.FindAll(tuple => Input.GetKeyDown(tuple.keyCode))
                .ForEach(tuple => MouseIntegration.PickUpCard(tuple.index));
        private static void CheckSlowTriggerHotKey()
        {
            if (Input.GetKeyDown(slowTrigger))
                SlowTrigger.Cast();
        }
    }
}
