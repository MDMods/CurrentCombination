using MelonLoader;
using static CurrentCombination.ModHandler;

namespace CurrentCombination
{
    public class Main : MelonMod
    {

        public override void OnInitializeMelon()
        {
            Load();
            LoggerInstance.Msg("CurrentCombination has loaded correctly!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "UISystem_PC")
            {
                // Get current elfin first to stablish the base length of the string
                GetCurrentElfin();
                GetCurrentGirl();
            }
        }
    }
}
