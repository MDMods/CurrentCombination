using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using static CurrentCombination.ModHandler;

namespace CurrentCombination.Patches
{
    [HarmonyPatch(typeof(DataHelper))]
    internal static class UpdatingDataPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(DataHelper.selectedRoleIndex), MethodType.Setter)]
        public static void UpdateGirl()
        {
            GetCurrentGirl();
            UpdateDisplay();
            UpdateGirlObject();
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(DataHelper.selectedElfinIndex), MethodType.Setter)]
        public static void UpdateElfin()
        {
            GetCurrentElfin();
            UpdateDisplay();
            UpdateElfinObject();
        }
    }
}
