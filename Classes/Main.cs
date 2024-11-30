using HotKeysMod.Components;
using HotKeysMod.HotKeysCheckers;
using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using UnityEngine;

namespace HotKeysMod
{
	public class Main : MelonMod
	{
		public static Main Instance { get; private set; }

        public static MelonPreferences_Entry<KeyCode> key0;
        public static MelonPreferences_Entry<KeyCode> key1;
        public static MelonPreferences_Entry<KeyCode> key2;
        public static MelonPreferences_Entry<KeyCode> key3;
        public static MelonPreferences_Entry<KeyCode> key4;
        public static MelonPreferences_Entry<KeyCode> key5;
        public static MelonPreferences_Entry<KeyCode> key6;
        public static MelonPreferences_Entry<KeyCode> key7;
        public static MelonPreferences_Entry<KeyCode> key8;
        public static MelonPreferences_Entry<KeyCode> key9;
        public static MelonPreferences_Entry<KeyCode> key10;
        public static MelonPreferences_Entry<KeyCode> key11;
        public static MelonPreferences_Entry<KeyCode> key12;
        public static MelonPreferences_Entry<KeyCode> key13;
        public static MelonPreferences_Entry<KeyCode> keyShovel;
        public static MelonPreferences_Entry<KeyCode> keyGlove;
        public static MelonPreferences_Entry<KeyCode> keyHammer;
        public static MelonPreferences_Entry<KeyCode> keyGoldenBean;
        public static MelonPreferences_Entry<KeyCode> keySlowTrigger;

		public override void OnInitializeMelon()
		{
			RegisterComponents();
			base.OnInitializeMelon();
			Instance = this;

			var category = MelonPreferences.CreateCategory("Hotkeys Mod", "");
            key0 = category.CreateEntry("Card 1", KeyCode.Alpha1, "Hotkey for Card 1");
            key1 = category.CreateEntry("Card 2", KeyCode.Alpha2, "Hotkey for Card 2");
            key2 = category.CreateEntry("Card 3", KeyCode.Alpha3, "Hotkey for Card 3");
            key3 = category.CreateEntry("Card 4", KeyCode.Alpha4, "Hotkey for Card 4");
            key4 = category.CreateEntry("Card 5", KeyCode.Alpha5, "Hotkey for Card 5");
            key5 = category.CreateEntry("Card 6", KeyCode.Alpha6, "Hotkey for Card 6");
            key6 = category.CreateEntry("Card 7", KeyCode.Alpha7, "Hotkey for Card 7");
            key7 = category.CreateEntry("Card 8", KeyCode.Alpha8, "Hotkey for Card 8");
            key8 = category.CreateEntry("Card 9", KeyCode.Alpha9, "Hotkey for Card 9");
            key9 = category.CreateEntry("Card 10", KeyCode.Alpha0, "Hotkey for Card 10");
            key10 = category.CreateEntry("Card 11", KeyCode.Minus, "Hotkey for Card 11");
            key11 = category.CreateEntry("Card 12", KeyCode.Equals, "Hotkey for Card 12");
            key12 = category.CreateEntry("Card 13", KeyCode.LeftBracket, "Hotkey for Card 13");
            key13 = category.CreateEntry("Card 14", KeyCode.RightBracket, "Hotkey for Card 14");
            keyShovel = category.CreateEntry("Shovel", KeyCode.Q, "Hotkey for Shovel");
            keyGlove = category.CreateEntry("Glove", KeyCode.W, "Hotkey for Glove");
            keyHammer = category.CreateEntry("Hammer", KeyCode.E, "Hotkey for Hammer");
            keyGoldenBean = category.CreateEntry("Golden Bean", KeyCode.R, "Hotkey for Golden Bean");
            keySlowTrigger = category.CreateEntry("Slow Trigger", KeyCode.Tab, "Hotkey for Slow Trigger");

            MelonPreferences.Save();
		}
		public override void OnUpdate()
		{
			HotKeysManager.CheckHotKeys();
		}
		private void RegisterComponents()
		{
			ClassInjector.RegisterTypeInIl2Cpp<BeansAmountDrawer>();
		}
	}
}
