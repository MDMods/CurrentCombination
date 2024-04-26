using CurrentCombination.Managers;
using MelonLoader;

namespace CurrentCombination.Utils;

public static class Logger
{
    private static readonly MelonLogger.Instance _logger = Melon<Main>.Logger;

    internal static void Debug(object message)
    {
        if (!SettingsManager.DebugLog) return;
        _logger.Msg(message);
    }

    internal static void Error(object message)
    {
        _logger.Error(message);
    }

    internal static void Msg(object message)
    {
        _logger.Msg(message);
    }

    internal static void Warning(object message)
    {
        _logger.Warning(message);
    }
}