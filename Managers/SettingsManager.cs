using MelonLoader;

namespace CurrentCombination.Managers
{
    internal static class SettingsManager
    {
        private static MelonPreferences_Entry<bool> _showInSongsMenu;
        private static MelonPreferences_Entry<bool> _showInSongView;

        public static bool ShowInSongsMenu => _showInSongsMenu.Value;
        public static bool ShowInSongView => _showInSongView.Value;

        public static void Load()
        {
            MelonPreferences_Category settings = MelonPreferences.CreateCategory("CurrentCombination");
            _showInSongsMenu = settings.CreateEntry<bool>(nameof(ShowInSongsMenu), true);
            _showInSongView = settings.CreateEntry<bool>(nameof(ShowInSongView), true);
        }
    }
}