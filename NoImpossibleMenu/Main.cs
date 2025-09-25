using Kitchen;
using KitchenLib;
using KitchenLib.Event;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NoImpossibleMenu {

    public class NoImpossibleMenu : BaseMod {

        public const string MOD_ID = "blargle.NoImpossibleMenu";
        public const string MOD_NAME = "No Impossible Menu";
        public static readonly string MOD_VERSION = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.ToString();

        private bool isRegistered;

        public NoImpossibleMenu() : base(MOD_ID, MOD_NAME, "blargle", MOD_VERSION, ">=1.2.0", Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise() {
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
            ModsPreferencesMenu<MenuAction>.RegisterMenu(MOD_NAME, typeof(NoImpossibleMenuMenu<MenuAction>), typeof(MenuAction));
            Events.PlayerPauseView_SetupMenusEvent += (s, args) => {
                args.addMenu.Invoke(args.instance, new object[] { typeof(NoImpossibleMenuMenu<MenuAction>), new NoImpossibleMenuMenu<MenuAction>(args.instance.ButtonContainer, args.module_list) });
            };
        }

        public static void Log(object message, [CallerFilePath] string callingFilePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null) {
            UnityEngine.Debug.Log($"[{MOD_ID}] [{caller}({callingFilePath}:{lineNumber})] {message}");
        }
    }
}
