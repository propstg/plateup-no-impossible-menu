using Kitchen;
using KitchenLib;
using KitchenLib.Event;
using System;
using System.Reflection;
using UnityEngine;

namespace NoImpossibleMenu {

    public class NoImpossibleMenu : BaseMod {

        public const string MOD_ID = "blargle.NoImpossibleMenu";
        public const string MOD_NAME = "No Impossible Menu";
        public const string MOD_VERSION = "0.0.3";

        public static bool isRegistered = false;

        public NoImpossibleMenu() : base(MOD_ID, MOD_NAME, "blargle", MOD_VERSION, "1.1.2", Assembly.GetExecutingAssembly()) { }

        protected override void Initialise() {
            base.Initialise();
            Debug.Log($"[{MOD_ID}] v{MOD_VERSION} initialized");
            if (!isRegistered) {
                NoImpossibleMenuPreferences.registerPreferences();
                initMainMenu();
                initPauseMenu();
                isRegistered = true;
                Debug.Log($"[{MOD_ID}] started with bypassRequiredAppliance = {NoImpossibleMenuPreferences.isOn(NoImpossibleMenuPreferences.BypassRequiredAppliancePref)}");
                Debug.Log($"[{MOD_ID}] started with bypassRequiredIngredient = {NoImpossibleMenuPreferences.isOn(NoImpossibleMenuPreferences.BypassRequiredIngredientPref)}");
            }
        }

        protected override void OnUpdate() { }

        private void initMainMenu() {
            Events.PreferenceMenu_MainMenu_SetupEvent += (s, args) => {
                Type type = args.instance.GetType().GetGenericArguments()[0];
                args.mInfo.Invoke(args.instance, new object[] { MOD_NAME, typeof(NoImpossibleMenuMenu<>).MakeGenericType(type), false });
            };
            Events.PreferenceMenu_MainMenu_CreateSubmenusEvent += (s, args) => {
                args.Menus.Add(typeof(NoImpossibleMenuMenu<MainMenuAction>), new NoImpossibleMenuMenu<MainMenuAction>(args.Container, args.Module_list));
            };
        }

        private void initPauseMenu() {
            Events.PreferenceMenu_PauseMenu_SetupEvent += (s, args) => {
                Type type = args.instance.GetType().GetGenericArguments()[0];
                args.mInfo.Invoke(args.instance, new object[] { MOD_NAME, typeof(NoImpossibleMenuMenu<>).MakeGenericType(type), false });
            };
            Events.PreferenceMenu_PauseMenu_CreateSubmenusEvent += (s, args) => {
                args.Menus.Add(typeof(NoImpossibleMenuMenu<PauseMenuAction>), new NoImpossibleMenuMenu<PauseMenuAction>(args.Container, args.Module_list));
            };
        }
    }
}
