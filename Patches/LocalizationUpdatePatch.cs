using CurrentCombination.Managers;
using HarmonyLib;
using Il2CppAssets.Scripts.UI.Specials;

namespace CurrentCombination.Patches;

[HarmonyPatch(typeof(SwitchLanguages), nameof(SwitchLanguages.OnClick))]
internal static class LocalizationUpdatePatch
{
    internal static void Postfix()
    {
        ModManager.UpdateAll();
    }
}