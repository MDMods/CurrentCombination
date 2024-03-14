using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroPeroGames.GlobalDefines;

namespace CurrentCombination.Managers;

internal static class ModManager
{
    internal static string _girl = string.Empty;
    internal static string _elfin = string.Empty;

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

    public static string Girl
    {
        get => _girl;
        set
        {
            _girl = value;
            UpdateGirlActionInvoke();
        }
    }

    public static string Elfin
    {
        get => _elfin;
        set
        {
            _elfin = value;
            UpdateElfinActionInvoke();
        }
    }

    public static event Action UpdateGirlAction;

    internal static void UpdateGirlActionInvoke()
    {
        UpdateGirlAction?.Invoke();
    }

    public static event Action UpdateElfinAction;

    internal static void UpdateElfinActionInvoke()
    {
        UpdateElfinAction?.Invoke();
    }

    public static void UpdateGirl()
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

    public static void UpdateElfin()
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