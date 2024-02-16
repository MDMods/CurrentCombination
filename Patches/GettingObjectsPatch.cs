using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.UI.Panels;
using UnityEngine;
using static CurrentCombination.ModHandler;

namespace CurrentCombination.Patches
{
    [Harmony]
    internal static class GettingObjectsPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(PnlStage), nameof(PnlStage.Awake))]
        private static void PnlStagePostfix(PnlStage __instance)
        {
            CreateDisplay(__instance.artistNameTitle, __instance.stageAchievementPercent.transform);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.Awake))]
        private static void PnlPreparationPostfix(PnlPreparation __instance)
        {
            if (GirlObject != null && ElfinObject != null) return;

            GameObject stageDesigner = GameObject.Find("TxtStageDesigner").transform.GetChild(0).gameObject;
            Transform buttonTransform = __instance.startButton.transform;

            CreateGirlObject(stageDesigner, buttonTransform);
            CreateElfinObject(stageDesigner, buttonTransform);

            //CreateElfinObject(__instance, levelDesignerTransform, position);
        }
    }
}
