using Kitchen;
using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NoImpossibleMenu {

    public class NoImpossibleMenu : BaseMod {

        public const string MOD_ID = "blargle.NoImpossibleMenu";
        public const string MOD_NAME = "No Impossible Menu";
        public static readonly string MOD_VERSION = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.ToString();

        private bool isRegistered;

        public NoImpossibleMenu() : base(MOD_ID, MOD_NAME, "blargle", MOD_VERSION, ">=1.1.8", Assembly.GetExecutingAssembly()) { }

        protected override void OnPostActivate(Mod mod) {
            Debug.Log($"[{MOD_ID}] v{MOD_VERSION} initialized");
            if (!isRegistered) {
                NoImpossibleMenuPreferences.registerPreferences();
                initPauseMenu();
                isRegistered = true;
                Log($"[{MOD_ID}] started with bypassRequiredAppliance = {NoImpossibleMenuPreferences.isOn(NoImpossibleMenuPreferences.BypassRequiredAppliancePref)}");
                Log($"[{MOD_ID}] started with bypassRequiredIngredient = {NoImpossibleMenuPreferences.isOn(NoImpossibleMenuPreferences.BypassRequiredIngredientPref)}");
            }
        }

        private void initPauseMenu() {
            ModsPreferencesMenu<PauseMenuAction>.RegisterMenu(MOD_NAME, typeof(NoImpossibleMenuMenu<PauseMenuAction>), typeof(PauseMenuAction));
            Events.PreferenceMenu_PauseMenu_CreateSubmenusEvent += (s, args) => {
                args.Menus.Add(typeof(NoImpossibleMenuMenu<PauseMenuAction>), new NoImpossibleMenuMenu<PauseMenuAction>(args.Container, args.Module_list));
            };
        }

        public static void Log(object message, [CallerFilePath] string callingFilePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null) {
            UnityEngine.Debug.Log($"[{MOD_ID}] [{caller}({callingFilePath}:{lineNumber})] {message}");
        }
    }
}
