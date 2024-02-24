using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.UI.Panels;
using UnityEngine;
using static CurrentCombination.Managers.UIManager;

namespace CurrentCombination.Patches
{
    [Harmony]
    internal static class CreateComponentsPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(PnlStage), nameof(PnlStage.Awake))]
        private static void PnlStagePostfix(PnlStage __instance)
        {
            CreateMainText(__instance.artistNameTitle, __instance.stageAchievementPercent.transform);
            UpdateMainText();
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.Awake))]
        private static void PnlPreparationPostfix(PnlPreparation __instance)
        {
            if (GirlObject != null && ElfinObject != null) return;

            GameObject stageDesigner = GameObject.Find("TxtStageDesigner").transform.GetChild(0).gameObject;
            Transform buttonTransform = __instance.startButton.transform;

            CreateGirlObject(stageDesigner, buttonTransform);
            UpdateGirlObject();
            CreateElfinObject(stageDesigner, buttonTransform);
            UpdateElfinObject();
        }
    }
}