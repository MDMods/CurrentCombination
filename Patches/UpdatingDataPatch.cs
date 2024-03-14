using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using static CurrentCombination.Managers.ModManager;

namespace CurrentCombination.Patches;

[HarmonyPatch(typeof(DataHelper))]
internal static class UpdatingDataPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(DataHelper.selectedRoleIndex), MethodType.Setter)]
    internal static void GirlSetter()
    {
        UpdateGirl();
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(DataHelper.selectedElfinIndex), MethodType.Setter)]
    internal static void ElfinSetter()
    {
        UpdateElfin();
    }
}