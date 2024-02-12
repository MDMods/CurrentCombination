using MelonLoader;
using HarmonyLib;

using UnityEngine;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppAssets.Scripts.UI.Panels;
using Text = UnityEngine.UI.Text;
using Il2Cpp;
using Il2CppNewtonsoft.Json.Linq;


namespace CurrentCombination
{
    [Harmony]
    public class Main : MelonMod
    {
        private static string elfin = string.Empty;
        private static string girl = string.Empty;
        private static Text displayData = null;
        private static GameObject girlObject = null;
        private static GameObject elfinObject = null;

        private static string DisplayString()
        {
            string combinationText = string.Empty;
            combinationText += girl;
            if (girl.Length > 0 && elfin.Length > 0) combinationText += " / ";
            combinationText += elfin;
            return combinationText;
        }

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName )
        {
            if (sceneName == "UISystem_PC")
            {
                // Get current elfin first to stablish the base length of the string
                GetCurrentElfin();
                GetCurrentGirl();
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DataHelper), nameof(DataHelper.selectedRoleIndex), MethodType.Setter )]
        public static void UpdateGirl()
        {
            GetCurrentGirl();
            if ( displayData )
            {
                displayData.text = DisplayString();
            }

            if ( girlObject)
            {
                girlObject.transform.GetChild(0).GetComponent<Text>().text = girl;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DataHelper), nameof(DataHelper.selectedElfinIndex), MethodType.Setter)]
        public static void UpdateElfin()
        {
            GetCurrentElfin();
            if (displayData)
            {
                displayData.text = DisplayString();
            }

            if (elfinObject)
            {
                elfinObject.transform.GetChild(0).GetComponent<Text>().text = elfin;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PnlStage), nameof(PnlStage.Awake))]
        public static void InitDisplay (PnlStage __instance)
        {
            if (!displayData)
            {
                displayData = UnityEngine.Object.Instantiate(__instance.artistNameTitle, __instance.stageAchievementPercent.transform) as Text;
                displayData.name = "DisplayData";
                displayData.text = DisplayString();
                displayData.resizeTextForBestFit = true;
                displayData.GetComponent<RectTransform>().position = new Vector3(6f, -5f, 100f);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.Awake))]
        public static void InitDiplays (PnlPreparation __instance) {
            if (girlObject && elfinObject) return;

            Transform levelDesignerTransform = GameObject.Find("TxtStageDesigner").transform.GetChild(0);
            Vector3 position = __instance.startButton.transform.position;
            if (!girlObject)
            {
                
                girlObject = UnityEngine.Object.Instantiate(levelDesignerTransform.gameObject, __instance.startButton.transform);
                girlObject.name = "GirlDisplay";
                girlObject.transform.GetChild(0).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                girlObject.GetComponent<RectTransform>().position = new Vector3(position.x + 6f, position.y + 0.8f, position.z);
                girlObject.transform.GetChild(0).GetComponent<Text>().text = girl;
            }
    
            if (!elfinObject)
            {
                elfinObject = UnityEngine.Object.Instantiate(levelDesignerTransform.gameObject, __instance.startButton.transform);
                elfinObject.name = "ElfinDisplay";
                elfinObject.transform.GetChild(0).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                elfinObject.GetComponent<RectTransform>().position = new Vector3(position.x + 6f, position.y + 0.4f, position.z);
                elfinObject.transform.GetChild(0).GetComponent<Text>().text = elfin;
            }
        }

        public static string GetCurrentElfin()
        {
            int elfinIndex = DataHelper.selectedElfinIndex;
            if (elfinIndex < 0)
            {
                elfin = "";
            } else
            {
                elfin = Singleton<ConfigManager>.instance.GetJson("elfin", true)[elfinIndex]["name"].ToString();
            }
  
            return elfin;
        }

        public static string GetCurrentGirl() {
            int characterIndex = DataHelper.selectedRoleIndex;
            if (characterIndex < 0)
            {
                girl = "";
                return girl;
            }
           
            JToken character = Singleton<ConfigManager>.instance.GetJson("character", true)[characterIndex];
            string charName = character["characterName"].ToString();
            string cosName = character["cosName"].ToString();

            girl = charName + " " + cosName;

            if (DisplayString().Length <= 35) return girl;
        
            string[] baseCharacters = {"Buro", "Marija", "Rin"};
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
    }
}
