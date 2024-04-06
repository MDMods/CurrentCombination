using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.UI.Panels;
using UnityEngine;
using UnityEngine.UI;
using static CurrentCombination.Managers.UIManager;

namespace CurrentCombination.Patches;

[Harmony]
internal static class CreateComponentsPatch
{
    [HarmonyPatch(typeof(PnlStage), nameof(PnlStage.Awake))]
    [HarmonyPostfix]
    internal static void PnlStagePostfix(PnlStage __instance)
    {
        CreateMainText(__instance.artistNameTitle, GameObject.Find("Info").transform.Find("Bottom"));
        UpdateMainText();
    }

    [HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.Awake))]
    [HarmonyPostfix]
    internal static void PnlPreparationPostfix(PnlPreparation __instance)
    {
        if (GirlObject != null && ElfinObject != null) return;

        var artistText = GameObject.Find("ImgArtistMask").transform.Find("TxtArtist").gameObject;
        var baseText = artistText.GetComponent<Text>();
        var buttonTransform = __instance.startButton.transform;

        CreateGirlObject(baseText, buttonTransform);
        UpdateGirlObject();
        CreateElfinObject(baseText, buttonTransform);
        UpdateElfinObject();
    }
}