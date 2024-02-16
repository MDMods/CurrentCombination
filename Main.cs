using MelonLoader;
using static CurrentCombination.ModHandler;

namespace CurrentCombination
{
    public class Main : MelonMod
    {

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
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
