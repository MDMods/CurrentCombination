using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;

namespace CurrentCombination.Managers;

internal static class ModManager
{
    internal static string _girl = string.Empty;
    internal static string _elfin = string.Empty;

    private static readonly HashSet<int> NotBaseCharacters = new()
    {
        15, // Yume
        16, // Neko
        18, // Reimu
        19, // Clear
        21, // Maris
        22, // Amiya
        25, // Miku
        26, // Kagamines
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