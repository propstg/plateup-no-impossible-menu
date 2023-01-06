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
            Debug.Log($"[{NoImpossibleMenu.MOD_ID}] Bypass system initialized.");
        }

        protected override void OnUpdate() {
            if (NoImpossibleMenuPreferences.isBypassRequiredAppliance()) {
                this.Clear<CheckSellingRequiredAppliance.SWarning>();
            }
        }
    }
}
