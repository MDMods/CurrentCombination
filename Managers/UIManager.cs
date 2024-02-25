using UnityEngine;
using UnityEngine.UI;

namespace CurrentCombination.Managers
{
    using static ModManager;
    using static SettingsManager;

    internal static class UIManager
    {
        internal static void CreateText(ref Text textObject, string textName, Text baseText, Transform baseTransform, Vector3 newPosition)
        {
            textObject = UnityEngine.Object.Instantiate(baseText, baseTransform);
            textObject.name = textName;
            textObject.text = "";
            textObject.resizeTextForBestFit = true;
            textObject.GetComponent<RectTransform>().position = newPosition;
        }

        //--------------------------------------------------------------------+
        // Main Text
        //--------------------------------------------------------------------+
        internal static Text MainText = null;

        public static void CreateMainText(Text baseText, Transform baseTransform)
        {
            if (!ShowInSongsMenu) return;
            if (MainText != null) return;

            CreateText(ref MainText, "DisplayDataText", baseText, baseTransform, new Vector3(6f, -5f, 100f));
        }

        public static void UpdateMainText()
        {
            if (MainText == null) return;
            string text = string.Empty;
            text += Girl;
            if (Girl.Length > 0 && Elfin.Length > 0) text += " / ";
            text += Elfin;
            MainText.text = text;
        }

        //--------------------------------------------------------------------+
        // Girl and elfin
        //--------------------------------------------------------------------+
        internal static Text GirlObject = null;
        internal static Text ElfinObject = null;

        public static void CreateGirlObject(Text baseObject, Transform baseTransform)
        {
            if (!ShowInSongView) return;
            if (GirlObject != null) return;
            CreateText(ref GirlObject, "GirlDisplayObject", baseObject, baseTransform, new Vector3(7.5f, -4.6f, 100f));
        }

        public static void CreateElfinObject(Text baseObject, Transform baseTransform)
        {
            if (!ShowInSongView) return;
            if (ElfinObject != null) return;
            CreateText(ref ElfinObject, "ElfinDisplayObject", baseObject, baseTransform, new Vector3(7.5f, -5f, 100f));
        }

        public static void UpdateGirlObject()
        {
            if (GirlObject == null) return;
            GirlObject.text = Girl;
        }

        public static void UpdateElfinObject()
        {
            if (ElfinObject == null) return;
            ElfinObject.text = Elfin;
        }

        //--------------------------------------------------------------------+
        // Update Components Events
        //--------------------------------------------------------------------+
        public static void Load()
        {
            UpdateGirlAction += new Action(UpdateMainText);
            UpdateGirlAction += new Action(UpdateGirlObject);
            UpdateElfinAction += new Action(UpdateMainText);
            UpdateElfinAction += new Action(UpdateElfinObject);
        }
    }
}