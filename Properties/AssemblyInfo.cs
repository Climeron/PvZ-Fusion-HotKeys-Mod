using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: MelonInfo(typeof(HotKeysMod.Main), HotKeysMod.AssemblyInfo.MODE_NAME, HotKeysMod.AssemblyInfo.VERSION, HotKeysMod.AssemblyInfo.AUTHOR)]
[assembly: MelonGame("LanPiaoPiao", "PlantsVsZombiesRH")]
[assembly: MelonAdditionalDependencies("ClimeronToolsForPvZ")]

// Общие сведения об этой сборке предоставляются следующим набором
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанные со сборкой.
[assembly: AssemblyTitle("HotKeysMod")]
[assembly: AssemblyDescription("Adds hotkeys to plant selection and changes default item hotkeys.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("HotKeysMod")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("0c7795e4-5fa0-4699-8010-33cee6ec412f")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(HotKeysMod.AssemblyInfo.VERSION)]
[assembly: AssemblyFileVersion(HotKeysMod.AssemblyInfo.VERSION)]

namespace HotKeysMod
{
    public static class AssemblyInfo
    {
        public const string MODE_NAME = nameof(HotKeysMod);
        public const string VERSION = "214.0.0";
        public const string AUTHOR = "Climeron";
    }
}