using CurrentCombination.Models;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;

namespace CurrentCombination.Managers;

internal static class ModManager
{
    internal static StageText StageText { get; } = new();

    internal static PrepGirlText PrepGirlText { get; } = new();

    internal static PrepElfinText PrepElfinText { get; } = new();

    internal static string GetElfin()
    {
        var elfinIndex = DataHelper.selectedElfinIndex;

        if (elfinIndex < 0) return string.Empty;

        return Singleton<ConfigManager>.instance
            .GetJson("elfin", true)[elfinIndex]
            ["name"].ToString();
    }

    internal static string GetGirl()
    {
        var characterIndex = DataHelper.selectedRoleIndex;

        if (characterIndex < 0) return string.Empty;

        var configManager = Singleton<ConfigManager>.instance;
        var character = configManager.GetJson("character", true)[characterIndex];

        var characterType = configManager.GetConfigObject<DBConfigCharacter>()
            .GetCharacterInfoByIndex(characterIndex)
            .characterType;

        return string.Equals(characterType, "Special")
            ? character["characterName"].ToString()
            : character["cosName"].ToString();
    }

    internal static void UpdateAll()
    {
        StageText.UpdateText();
        PrepGirlText.UpdateText();
        PrepElfinText.UpdateText();
    }
}