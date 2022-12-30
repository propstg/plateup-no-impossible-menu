using Kitchen;
using KitchenMods;
using Unity.Entities;

namespace NoImpossibleMenu {

    [UpdateInGroup(typeof(EndOfDayProgressionGroup))]
    [UpdateAfter(typeof(CheckSellingRequiredAppliance))]
    class BypassImpossibleMenuSystem : GameSystemBase, IModSystem {

        protected override void OnUpdate() {
            if (NoImpossibleMenuPreferences.isBypassRequiredAppliance()) {
                this.Clear<CheckSellingRequiredAppliance.SWarning>();
            }
        }
    }
}
