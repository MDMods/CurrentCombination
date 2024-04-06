using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace CurrentCombination.Managers;

using static ModManager;
using static SettingsManager;

internal static class UIManager
{
    //--------------------------------------------------------------------+
    // Main Text
    //--------------------------------------------------------------------+
    private static Text MainText { get; set; }

    //--------------------------------------------------------------------+
    // Girl and elfin
    //--------------------------------------------------------------------+
    internal static Text GirlObject { get; private set; }

    internal static Text ElfinObject { get; private set; }

    private static void CreateText(out Text textObject, string textName, Text baseText, Transform baseTransform,
        Vector3 newPosition)
    {
        textObject = Object.Instantiate(baseText, baseTransform);
        textObject.name = textName;
        textObject.text = "";
        textObject.resizeTextForBestFit = true;
        textObject.GetComponent<RectTransform>().position = newPosition;
        textObject.gameObject.SetActive(true);
    }

    internal static void CreateMainText(Text baseText, Transform baseTransform)
    {
        if (!ShowInSongsMenu) return;
        if (MainText != null) return;

        CreateText(out var mainText,
            "DisplayDataText",
            baseText,
            baseTransform,
            new Vector3(6f, -5f, 100f));

        MainText = mainText;
    }

    internal static void UpdateMainText()
    {
        if (MainText == null) return;
        var text = string.Empty;
        text += Girl;
        if (Girl.Length > 0 && Elfin.Length > 0) text += " / ";
        text += Elfin;
        MainText.text = text;
    }

    internal static void CreateGirlObject(Text baseObject, Transform baseTransform)
    {
        if (!ShowInSongView) return;
        if (GirlObject != null) return;

        CreateText(out var girlObject,
            "GirlDisplayObject",
            baseObject,
            baseTransform,
            new Vector3(7.5f, -4.6f, 100f));

        GirlObject = girlObject;
    }

    internal static void CreateElfinObject(Text baseObject, Transform baseTransform)
    {
        if (!ShowInSongView) return;
        if (ElfinObject != null) return;

        CreateText(out var elfinObject,
            "ElfinDisplayObject",
            baseObject,
            baseTransform,
            new Vector3(7.5f, -5f, 100f));

        ElfinObject = elfinObject;
    }

    internal static void UpdateGirlObject()
    {
        if (GirlObject == null) return;
        GirlObject.text = Girl;
    }

    internal static void UpdateElfinObject()
    {
        if (ElfinObject == null) return;
        ElfinObject.text = Elfin;
    }

    //--------------------------------------------------------------------+
    // Update Components Events
    //--------------------------------------------------------------------+
    internal static void Load()
    {
        UpdateGirlAction += UpdateMainText;
        UpdateGirlAction += UpdateGirlObject;
        UpdateElfinAction += UpdateMainText;
        UpdateElfinAction += UpdateElfinObject;
    }
}