using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using static CurrentCombination.Managers.ModManager;

namespace CurrentCombination.Patches;

[HarmonyPatch(typeof(DataHelper))]
internal static class UpdatingDataPatch
{
    [HarmonyPatch(nameof(DataHelper.selectedRoleIndex), MethodType.Setter)]
    [HarmonyPostfix]
    internal static void GirlSetter()
    {
        UpdateGirl();
    }

    [HarmonyPatch(nameof(DataHelper.selectedElfinIndex), MethodType.Setter)]
    [HarmonyPostfix]
    internal static void ElfinSetter()
    {
        UpdateElfin();
    }
}