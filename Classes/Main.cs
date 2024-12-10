using HotKeysMod.Components;
using Il2CppInterop.Runtime.Injection;
using MelonLoader;

namespace HotKeysMod.Classes
{
    public class Main : MelonMod
    {
        public static Main Instance { get; private set; }

        public override void OnInitializeMelon()
        {
            RegisterComponents();
            base.OnInitializeMelon();
            Instance = this;
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
