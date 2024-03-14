using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using static CurrentCombination.Managers.ModManager;

namespace CurrentCombination.Patches;

[HarmonyPatch(typeof(DataHelper))]
internal static class UpdatingDataPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(DataHelper.selectedRoleIndex), MethodType.Setter)]
    public static void GirlSetter()
    {
        UpdateGirl();
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(DataHelper.selectedElfinIndex), MethodType.Setter)]
    public static void ElfinSetter()
    {
        UpdateElfin();
    }
}