using CurrentCombination.Managers;
using HarmonyLib;
using Il2CppAssets.Scripts.Database;

namespace CurrentCombination.Patches;

[HarmonyPatch(typeof(DataHelper))]
internal static class UpdatingDataPatch
{
    [HarmonyPatch(nameof(DataHelper.selectedElfinIndex), MethodType.Setter)]
    [HarmonyPostfix]
    internal static void ElfinSetter()
    {
        ModManager.UpdateAll();
    }

    [HarmonyPatch(nameof(DataHelper.selectedRoleIndex), MethodType.Setter)]
    [HarmonyPostfix]
    internal static void GirlSetter()
    {
        ModManager.UpdateAll();
    }
}