using System.Collections.Generic;
using UnityEngine;

namespace HotKeysMod.HotKeysCheckers
{
    public static class HotKeys
    {
        public static readonly (KeyCode keyCode, int index) card0 = (KeyCode.Alpha1, 0);
        public static readonly (KeyCode keyCode, int index) card1 = (KeyCode.Alpha2, 1);
        public static readonly (KeyCode keyCode, int index) card2 = (KeyCode.Alpha3, 2);
        public static readonly (KeyCode keyCode, int index) card3 = (KeyCode.Alpha4, 3);
        public static readonly (KeyCode keyCode, int index) card4 = (KeyCode.Alpha5, 4);
        public static readonly (KeyCode keyCode, int index) card5 = (KeyCode.Alpha6, 5);
        public static readonly (KeyCode keyCode, int index) card6 = (KeyCode.Alpha7, 6);
        public static readonly (KeyCode keyCode, int index) card7 = (KeyCode.Alpha8, 7);
        public static readonly (KeyCode keyCode, int index) card8 = (KeyCode.Alpha9, 8);
        public static readonly (KeyCode keyCode, int index) card9 = (KeyCode.Alpha0, 9);
        public static readonly (KeyCode keyCode, int index) card10 = (KeyCode.Minus, 10);
        public static readonly (KeyCode keyCode, int index) card11 = (KeyCode.Equals, 11);
        public static readonly (KeyCode keyCode, int index) card12 = (KeyCode.LeftBracket, 12);
        public static readonly (KeyCode keyCode, int index) card13 = (KeyCode.RightBracket, 13);
        public static readonly KeyCode shovel = KeyCode.Q;
        public static readonly KeyCode glove = KeyCode.W;
        public static readonly KeyCode hammer = KeyCode.E;
        public static readonly KeyCode slowTrigger = KeyCode.R;

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
    }
}
