using Kitchen;
using Kitchen.Modules;
using KitchenLib;
using System.Collections.Generic;
using UnityEngine;

namespace NoImpossibleMenu {

    public class NoImpossibleMenuMenu<T> : KLMenu<T> {

        private static readonly List<bool> bypassRequiredApplianceValues = new List<bool> { false, true };
        private static readonly List<string> bypassRequiredApplianceLabels = new List<string> { "Off", "On" };

        public NoImpossibleMenuMenu(Transform container, ModuleList module_list) : base(container, module_list) { }

        public override void Setup(int player_id) {
            Option<bool> option = new Option<bool>(bypassRequiredApplianceValues, NoImpossibleMenuPreferences.isBypassRequiredAppliance(), bypassRequiredApplianceLabels);

            AddLabel("Bypass Required Appliances");
            AddInfo("Setting to 'On' will allow you to sell appliances that the game thinks you need.");
            AddSelect(option);
            AddInfo("There is no undo. Don't sell something you actually need. :)");

            New<SpacerElement>();
            New<SpacerElement>();
            AddButton(Localisation["MENU_BACK_SETTINGS"], delegate { RequestPreviousMenu(); });

            option.OnChanged += delegate (object _, bool value) {
                NoImpossibleMenuPreferences.setBypassRequiredAppliance(value);
            };
        }
    }
}
