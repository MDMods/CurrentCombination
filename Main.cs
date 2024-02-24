using CurrentCombination.Managers;
using MelonLoader;

namespace CurrentCombination
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            SettingsManager.Load();
            UIManager.Load();
            LoggerInstance.Msg("CurrentCombination has loaded correctly!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "UISystem_PC")
            {
                ModManager.UpdateGirl();
                ModManager.UpdateElfin();
            }
        }
    }
}