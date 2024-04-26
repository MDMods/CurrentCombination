using CurrentCombination.Managers;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.UI.Panels;
using UnityEngine;

namespace CurrentCombination.Patches;

using static ModManager;

[Harmony]
internal static class CreateComponentsPatch
{
    [HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.Awake))]
    [HarmonyPostfix]
    internal static void PnlPreparationPostfix(PnlPreparation __instance)
    {
        if (!SettingsManager.ShowInSongView) return;

        var transform = __instance.startButton.transform;

        PrepGirlText.Create(transform);
        PrepElfinText.Create(transform);
    }

    [HarmonyPatch(typeof(PnlStage), nameof(PnlStage.Awake))]
    [HarmonyPostfix]
    internal static void PnlStagePostfix()
    {
        if (!SettingsManager.ShowInSongsMenu) return;

        StageText.Create(GameObject.Find("Info")?.transform.Find("Bottom"));
    }
}