using CurrentCombination.Managers;
using CurrentCombination.Properties;
using MelonLoader;

namespace CurrentCombination;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        SettingsManager.Load();
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}