using Il2Cpp;
using UnityEngine;
using UnityEngine.UI;

namespace CurrentCombination.Managers
{
    using static ModManager;
    using static SettingsManager;

    internal static class UIManager
    {
        //--------------------------------------------------------------------+
        // Main Text
        //--------------------------------------------------------------------+
        internal static Text MainText = null;
        public static void CreateMainText(Text baseText, Transform baseTransform)
        {
            if (!ShowInSongsMenu) return;
            if (MainText != null) return;

            MainText = UnityEngine.Object.Instantiate(baseText, baseTransform);
            MainText.name = "DisplayDataText";
            MainText.text = "";
            MainText.resizeTextForBestFit = true;
            MainText.GetComponent<RectTransform>().position = new Vector3(6f, -5f, 100f);
        }

        internal static void UpdateMainText()
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
        internal static void CreateObject(ref GameObject original, string ObjectName, GameObject baseObject, Transform baseTransform, Vector3 offset)
        {
            if (!ShowInSongView) return;
            if (original != null) return;
            GameObject gameObject = UnityEngine.Object.Instantiate(baseObject, baseTransform);
            UnityEngine.Object.Destroy(gameObject.GetComponent<LongSongNameController>());

            gameObject.name = ObjectName;
            gameObject.transform.GetChild(0).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            Vector3 position = baseTransform.position;
            gameObject.GetComponent<RectTransform>().position = position + offset;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = "";

            original = gameObject;
        }

        internal static void UpdateObject(ref GameObject displayObject, string text)
        {
            if (displayObject == null) return;
            displayObject.transform.GetChild(0).GetComponent<Text>().text = text;
        }

        //--------------------------------------------------------------------+
        // Girl
        //--------------------------------------------------------------------+
        internal static GameObject GirlObject = null;

        public static void CreateGirlObject(GameObject baseObject, Transform baseTransform)
        {
            CreateObject(ref GirlObject, "GirlDisplayObject", baseObject, baseTransform, new Vector3(6f, 0.8f, 0f));
        }
        internal static void UpdateGirlObject()
        {
            UpdateObject(ref GirlObject, Girl);
        }

        //--------------------------------------------------------------------+
        // Elfin
        //--------------------------------------------------------------------+
        internal static GameObject ElfinObject = null;

        public static void CreateElfinObject(GameObject baseObject, Transform baseTransform)
        {
            CreateObject(ref ElfinObject, "ElfinDisplayObject", baseObject, baseTransform, new Vector3(6f, 0.4f, 0f));
        }
        internal static void UpdateElfinObject()
        {
            UpdateObject(ref ElfinObject, Elfin);
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