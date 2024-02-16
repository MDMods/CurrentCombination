using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppNewtonsoft.Json.Linq;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace CurrentCombination
{
    internal static class ModHandler
    {
        public static string elfin = string.Empty;
        public static string girl = string.Empty;
        public static Text DisplayData = null;
        public static GameObject GirlObject = null;
        public static GameObject ElfinObject = null;

        private static MelonPreferences_Entry<bool> showInSongsMenu;
        private static MelonPreferences_Entry<bool> showInSongView;

        public static void Load()
        {
            MelonPreferences_Category settings = MelonPreferences.CreateCategory("CurrentCombination");
            showInSongsMenu = settings.CreateEntry<bool>(nameof(showInSongsMenu), true);
            showInSongView = settings.CreateEntry<bool>(nameof(showInSongView), true);
        }


        public static string DisplayString()
        {
            string combinationText = string.Empty;
            combinationText += girl;
            if (girl.Length > 0 && elfin.Length > 0) combinationText += " / ";
            combinationText += elfin;
            return combinationText;
        }

        public static string GetCurrentElfin()
        {
            int elfinIndex = DataHelper.selectedElfinIndex;
            if (elfinIndex < 0)
            {
                elfin = "";
            }
            else
            {
                elfin = Singleton<ConfigManager>.instance?.GetJson("elfin", true)?[elfinIndex]?["name"].ToString() ?? "";
            }

            return elfin;
        }

        public static string GetCurrentGirl()
        {
            int characterIndex = DataHelper.selectedRoleIndex;
            if (characterIndex < 0)
            {
                girl = "";
                return girl;
            }

            JToken character = Singleton<ConfigManager>.instance?.GetJson("character", true)?[characterIndex];
            string charName = character?["characterName"]?.ToString() ?? "";
            string cosName = character?["cosName"]?.ToString() ?? "";

            girl = charName + " " + cosName;

            if (DisplayString().Length <= 35) return girl;

            string[] baseCharacters = { "Buro", "Marija", "Rin" };
            if (baseCharacters.Any(charName.Equals))
            {
                girl = cosName;
            }
            else
            {
                girl = charName;
            }

            return girl;
        }

        public static void CreateDisplay(Text baseText, Transform baseTransform)
        {
            if (!showInSongsMenu.Value) return;
            if (DisplayData != null) return;

            DisplayData = UnityEngine.Object.Instantiate(baseText, baseTransform) as Text;
            DisplayData.name = "DisplayDataText";
            DisplayData.text = DisplayString();
            DisplayData.resizeTextForBestFit = true;
            DisplayData.GetComponent<RectTransform>().position = new Vector3(6f, -5f, 100f);

        }
        public static void CreateGirlObject(GameObject baseObject, Transform baseTransform)
        {
            if (!showInSongView.Value) return;
            if (GirlObject != null) return;

            GirlObject = UnityEngine.Object.Instantiate(baseObject, baseTransform);
            GirlObject.name = "GirlDisplayObject";
            GirlObject.transform.GetChild(0).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            Vector3 position = baseTransform.position;
            GirlObject.GetComponent<RectTransform>().position = new Vector3(position.x + 6f, position.y + 0.8f, position.z);
            GirlObject.transform.GetChild(0).GetComponent<Text>().text = girl;
        }
        public static void CreateElfinObject(GameObject baseObject, Transform baseTransform)
        {
            if (!showInSongView.Value) return;
            if (ElfinObject != null) return;

            ElfinObject = UnityEngine.Object.Instantiate(baseObject.gameObject, baseTransform);
            ElfinObject.name = "ElfinDisplayObject";
            ElfinObject.transform.GetChild(0).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            Vector3 position = baseTransform.position;
            ElfinObject.GetComponent<RectTransform>().position = new Vector3(position.x + 6f, position.y + 0.4f, position.z);
            ElfinObject.transform.GetChild(0).GetComponent<Text>().text = elfin;
        }

        public static void UpdateDisplay()
        {
            if (DisplayData == null) return;
            DisplayData.text = DisplayString();
        }

        public static void UpdateGirlObject()
        {
            if (GirlObject == null) return;
            GirlObject.transform.GetChild(0).GetComponent<Text>().text = girl;
        }

        public static void UpdateElfinObject()
        {
            if (ElfinObject == null) return;
            ElfinObject.transform.GetChild(0).GetComponent<Text>().text = elfin;

        }

    }
}
