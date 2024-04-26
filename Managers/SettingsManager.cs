using CurrentCombination.Properties;
using MelonLoader;

namespace CurrentCombination.Managers;

internal static class SettingsManager
{
    private static MelonPreferences_Entry<bool> _showInSongsMenu;

    private static MelonPreferences_Entry<bool> _showInSongView;

    private static MelonPreferences_Entry<bool> _debugLog;

    internal static bool ShowInSongsMenu => _showInSongsMenu.Value;

    internal static bool ShowInSongView => _showInSongView.Value;

    internal static bool DebugLog => _debugLog.Value;

    public static void Load()
    {
        var settings = MelonPreferences.CreateCategory(MelonBuildInfo.ModName);
        _showInSongsMenu = settings.CreateEntry(nameof(ShowInSongsMenu), true);
        _showInSongView = settings.CreateEntry(nameof(ShowInSongView), true);
        _debugLog = settings.CreateEntry(nameof(DebugLog), false);
    }
}