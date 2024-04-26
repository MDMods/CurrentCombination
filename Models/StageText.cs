using CurrentCombination.Managers;
using UnityEngine;

namespace CurrentCombination.Models;

internal class StageText() : BaseText(nameof(StageText), new Vector3(6f, -5f, 100f))
{
    protected override string GetText()
    {
        var text = ModManager.GetGirl();
        var elfin = ModManager.GetElfin();

        if (text.Length > 0 && elfin.Length > 0) text += " / ";

        text += elfin;

        return text;
    }
}