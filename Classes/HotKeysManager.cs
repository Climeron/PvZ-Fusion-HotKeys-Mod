using System.Collections.Generic;
using ClimeronToolsForPvZ.Extensions;
using Il2Cpp;
using UnityEngine;

namespace HotKeysMod.Classes
{
    public static class HotKeysManager
    {
        public static List<(KeyCode keyCode, int index)> cardsList = new()
        {
            (KeyCode.Alpha1, 0),
            (KeyCode.Alpha2, 1),
            (KeyCode.Alpha3, 2),
            (KeyCode.Alpha4, 3),
            (KeyCode.Alpha5, 4),
            (KeyCode.Alpha6, 5),
            (KeyCode.Alpha7, 6),
            (KeyCode.Alpha8, 7),
            (KeyCode.Alpha9, 8),
            (KeyCode.Alpha0, 9),
            (KeyCode.Minus, 10),
            (KeyCode.Equals, 11),
            (KeyCode.LeftBracket, 12),
            (KeyCode.RightBracket, 13)
        };
        public static readonly Dictionary<ToolTypesEnum, KeyCode> toolTypesDict = new()
        {
            { ToolTypesEnum.Shovel, KeyCode.Q },
            { ToolTypesEnum.Glove, KeyCode.W },
            { ToolTypesEnum.Hammer, KeyCode.E },
            { ToolTypesEnum.GoldenBean, KeyCode.R }
        };
        public static readonly KeyCode slowTrigger = KeyCode.Tab;
        public static readonly KeyCode plantHPShowing = KeyCode.F1;
        public static readonly KeyCode zombieHPShowing = KeyCode.F2;
        public static readonly List<KeyCode> gardenToolTypesList = new()
        {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8
        };
        public static readonly (KeyCode keyCode, string label) previousGardenPage = (KeyCode.Comma, "<");
        public static readonly (KeyCode keyCode, string label) nextGardenPage = (KeyCode.Period, ">");

        public static void CheckHotKeys()
        {
            CheckToolsHotKeys();
            CheckCardsHotKeys();
            CheckSlowTriggerHotKey();
            CheckPlantHPShowingHotKey();
            CheckZombieHPShowingHotKey();
            CheckGardenToolsHotKeys();
            CheckGardenPageNavigationHotKeys();
        }
        private static void CheckToolsHotKeys() =>
            toolTypesDict.FindAll(pair => Input.GetKeyDown(pair.Value))
                .ForEach(pair => MouseIntegration.PickUpTool(pair.Key));
        private static void CheckCardsHotKeys() =>
            cardsList.FindAll(tuple => Input.GetKeyDown(tuple.keyCode))
                .ForEach(tuple => MouseIntegration.PickUpCard(tuple.index));
        private static void CheckSlowTriggerHotKey()
        {
            if (Input.GetKeyDown(slowTrigger))
                SlowTrigger.Cast();
        }
        private static void CheckPlantHPShowingHotKey()
        {
            if (Board.Instance && Input.GetKeyDown(plantHPShowing))
                Board.Instance.ShowPlantHealth();
        }
        private static void CheckZombieHPShowingHotKey()
        {
            if (Board.Instance && Input.GetKeyDown(zombieHPShowing))
                Board.Instance.ShowZombieHealth();
        }
        private static void CheckGardenToolsHotKeys()
        {
            for (int i = 0; i < gardenToolTypesList.Count; i++)
                if (Input.GetKeyDown(gardenToolTypesList[i]))
                    MouseIntegration.PickUpGardenTool(i);
        }
        private static void CheckGardenPageNavigationHotKeys()
        {
            GardenUI gardenUI = GardenUI.Instance;
            if (!gardenUI)
                return;
            if (Input.GetKeyDown(previousGardenPage.keyCode))
            {
                if (gardenUI.plantOnGlove)
                    gardenUI.RightClick();
                gardenUI.EnterLastPage();
            }
            if (Input.GetKeyDown(nextGardenPage.keyCode))
            {
                if (gardenUI.plantOnGlove)
                    gardenUI.RightClick();
                gardenUI.EnterNextPage();
            }
        }
    }
}
