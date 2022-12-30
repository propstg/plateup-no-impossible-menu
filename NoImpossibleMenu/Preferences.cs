using Kitchen;

namespace NoImpossibleMenu {

    public class NoImpossibleMenuPreferences {

        private static Pref BypassRequiredAppliancePref = new Pref(NoImpossibleMenu.MOD_ID, nameof(BypassRequiredAppliancePref));

        public static void registerPreferences() {
            Preferences.AddPreference<bool>(new BoolPreference(BypassRequiredAppliancePref, false));
            Preferences.Load();
        }

        public static bool isBypassRequiredAppliance() {
            return Preferences.Get<bool>(BypassRequiredAppliancePref);
        }

        public static void setBypassRequiredAppliance(bool value) {
            Preferences.Set<bool>(BypassRequiredAppliancePref, value);
        }
    }
}
