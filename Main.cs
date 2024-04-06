using CurrentCombination.Managers;
using CurrentCombination.Properties;
using MelonLoader;

namespace CurrentCombination;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        SettingsManager.Load();
        UIManager.Load();
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        if (!"UISystem_PC".Equals(sceneName)) return;

        ModManager.UpdateGirl();
        ModManager.UpdateElfin();
    }
}