using HarmonyLib;
using Il2CppAssets.Scripts.UI.Specials;
using static CurrentCombination.Managers.ModManager;

namespace CurrentCombination.Patches;

[HarmonyPatch(typeof(SwitchLanguages), nameof(SwitchLanguages.OnClick))]
internal class LocalizationUpdatePatch
{
    internal static void Postfix()
    {
        UpdateGirl();
        UpdateElfin();
    }
}