using Kitchen;
using KitchenMods;
using Unity.Entities;
using UnityEngine;

namespace NoImpossibleMenu {

    [UpdateInGroup(typeof(EndOfDayProgressionGroup))]
    [UpdateAfter(typeof(CheckSellingRequiredAppliance))]
    class BypassImpossibleMenuSystem : GameSystemBase, IModSystem {

        protected override void Initialise() {
            base.Initialise();
            NoImpossibleMenu.Log($"Bypass appliance system initialized.");
        }

        protected override void OnUpdate() {
            if (NoImpossibleMenuPreferences.isOn(NoImpossibleMenuPreferences.BypassRequiredAppliancePref)) {
                this.Clear<CheckSellingRequiredAppliance.SWarning>();
            }
        }
    }

    [UpdateInGroup(typeof(EndOfDayProgressionGroup))]
    [UpdateAfter(typeof(CheckSellingRequiredIngredient))]
    class BypassImpossibleIngredientSystem : GameSystemBase, IModSystem {

        protected override void Initialise() {
            base.Initialise();
            NoImpossibleMenu.Log($"Bypass ingredient system initialized.");
        }

        protected override void OnUpdate() {
            if (NoImpossibleMenuPreferences.isOn(NoImpossibleMenuPreferences.BypassRequiredIngredientPref)) {
                this.Clear<CheckSellingRequiredIngredient.SWarning>();
            }
        }
    }
}
