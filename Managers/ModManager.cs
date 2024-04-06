using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;

namespace CurrentCombination.Managers;

internal static class ModManager
{
    private static string _girl = string.Empty;

    private static string _elfin = string.Empty;

    internal static string Girl
    {
        get => _girl;
        private set
        {
            if (string.Equals(_girl, value)) return;
            _girl = value;
            UpdateGirlActionInvoke();
        }
    }

    internal static string Elfin
    {
        get => _elfin;
        private set
        {
            if (string.Equals(_elfin, value)) return;
            _elfin = value;
            UpdateElfinActionInvoke();
        }
    }

    internal static event Action UpdateGirlAction;

    private static void UpdateGirlActionInvoke()
    {
        UpdateGirlAction?.Invoke();
    }

    internal static event Action UpdateElfinAction;

    private static void UpdateElfinActionInvoke()
    {
        UpdateElfinAction?.Invoke();
    }

    internal static void UpdateGirl()
    {
        var characterIndex = DataHelper.selectedRoleIndex;

        if (characterIndex < 0)
        {
            Girl = "";
            return;
        }

        var configManager = Singleton<ConfigManager>.instance;
        var character = configManager.GetJson("character", true)[characterIndex];

        var characterType = configManager.GetConfigObject<DBConfigCharacter>()
            .GetCharacterInfoByIndex(characterIndex)
            .characterType;

        if (string.Equals(characterType, "Special"))
        {
            Girl = character["characterName"].ToString();
            return;
        }

        Girl = character["cosName"].ToString();
    }

    internal static void UpdateElfin()
    {
        var elfinIndex = DataHelper.selectedElfinIndex;

        if (elfinIndex < 0)
        {
            Elfin = "";
            return;
        }

        Elfin = Singleton<ConfigManager>.instance
            .GetJson("elfin", true)[elfinIndex]
            ["name"].ToString();
    }
}