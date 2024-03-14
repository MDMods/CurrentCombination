using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroPeroGames.GlobalDefines;

namespace CurrentCombination.Managers;

internal static class ModManager
{
    private static string _girl = string.Empty;
    private static string _elfin = string.Empty;

    private static readonly HashSet<int> NotBaseCharacters = new()
    {
        CharacterDefine.yume,
        CharacterDefine.neko,
        CharacterDefine.reimu,
        CharacterDefine.clear,
        CharacterDefine.marisa,
        CharacterDefine.ark_nights_amiya,
        CharacterDefine.hastune_miku,
        CharacterDefine.kagamine_rin_len,
    };

    internal static string Girl
    {
        get => _girl;
        private set
        {
            _girl = value;
            UpdateGirlActionInvoke();
        }
    }

    internal static string Elfin
    {
        get => _elfin;
        private set
        {
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

        var character = Singleton<ConfigManager>.instance?.GetJson("character", true)?[characterIndex];

        if (NotBaseCharacters.Contains(characterIndex))
        {
            Girl = character?["characterName"]?.ToString() ?? "";
            return;
        }

        Girl = character?["cosName"]?.ToString() ?? "";
    }

    internal static void UpdateElfin()
    {
        var elfinIndex = DataHelper.selectedElfinIndex;
        if (elfinIndex < 0)
        {
            Elfin = "";
            return;
        }

        Elfin = Singleton<ConfigManager>.instance?.GetJson("elfin", true)?[elfinIndex]?["name"]?.ToString() ?? "";
    }
}