using MelonLoader;

namespace CurrentCombination.Managers;

internal static class SettingsManager
{
    private static MelonPreferences_Entry<bool> _showInSongsMenu;

    private static MelonPreferences_Entry<bool> _showInSongView;

    internal static bool ShowInSongsMenu => _showInSongsMenu.Value;

    internal static bool ShowInSongView => _showInSongView.Value;

    public static void Load()
    {
        var settings = MelonPreferences.CreateCategory("CurrentCombination");
        _showInSongsMenu = settings.CreateEntry(nameof(ShowInSongsMenu), true);
        _showInSongView = settings.CreateEntry(nameof(ShowInSongView), true);
    }
}