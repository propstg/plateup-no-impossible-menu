using Kitchen;

namespace NoImpossibleMenu {

    public class NoImpossibleMenuPreferences {

        public static readonly Pref BypassRequiredAppliancePref = new Pref(NoImpossibleMenu.MOD_ID, nameof(BypassRequiredAppliancePref));
        public static readonly Pref BypassRequiredIngredientPref = new Pref(NoImpossibleMenu.MOD_ID, nameof(BypassRequiredIngredientPref));

        public static void registerPreferences() {
            addBoolPreference(BypassRequiredAppliancePref);
            addBoolPreference(BypassRequiredIngredientPref);
            Preferences.Load();
        }

        public static bool isOn(Pref pref) {
            return Preferences.Get<bool>(pref);
        }

        public static void setBool(Pref pref, bool value) {
            Preferences.Set<bool>(pref, value);
        }

        private static void addBoolPreference(Pref pref) {
            Preferences.AddPreference<bool>(new BoolPreference(pref, false));
        }
    }
}
