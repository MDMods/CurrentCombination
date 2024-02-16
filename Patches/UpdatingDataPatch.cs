using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using UnityEngine.UI;
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
            if (DisplayData != null)
            {
                DisplayData.text = DisplayString();
            }

            if (GirlObject != null)
            {
                GirlObject.transform.GetChild(0).GetComponent<Text>().text = girl;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(DataHelper.selectedElfinIndex), MethodType.Setter)]
        public static void UpdateElfin()
        {
            GetCurrentElfin();
            if (DisplayData != null)
            {
                DisplayData.text = DisplayString();
            }

            if (ElfinObject != null)
            {
                ElfinObject.transform.GetChild(0).GetComponent<Text>().text = elfin;
            }
        }
    }
}
