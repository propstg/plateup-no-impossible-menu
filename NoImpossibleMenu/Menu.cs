using Kitchen;
using Kitchen.Modules;
using KitchenLib;
using System.Collections.Generic;
using UnityEngine;

namespace NoImpossibleMenu {

    public class NoImpossibleMenuMenu<T> : KLMenu<T> {

        private static readonly List<bool> boolValues = new List<bool> { false, true };
        private static readonly List<string> boolLabels = new List<string> { "Off", "On" };

        public NoImpossibleMenuMenu(Transform container, ModuleList module_list) : base(container, module_list) { }

        public override void Setup(int player_id) {

            addBool("Bypass Required Appliances", "Setting to 'On' will allow you to sell appliances that the game thinks you need.", NoImpossibleMenuPreferences.BypassRequiredAppliancePref);
            addBool("Bypass Required Ingredients", "Setting to 'On' will allow you to sell ingredients that the game thinks you need.", NoImpossibleMenuPreferences.BypassRequiredIngredientPref);

            New<SpacerElement>();
            AddInfo("There is no undo. Don't sell something you actually need. :)");
            New<SpacerElement>();
            AddButton(Localisation["MENU_BACK_SETTINGS"], delegate { RequestPreviousMenu(); });
        }

        private void addBool(string label, string info, Pref pref) {
            Option<bool> option = new Option<bool>(boolValues, NoImpossibleMenuPreferences.isOn(pref), boolLabels);
            AddLabel(label);
            AddInfo(info);
            AddSelect(option);
            option.OnChanged += delegate (object _, bool value) {
                NoImpossibleMenuPreferences.setBool(pref, value);
                Debug.Log($"[{NoImpossibleMenu.MOD_ID}] Updated {nameof(pref)} value to {value}");
            };
        }
    }
}
