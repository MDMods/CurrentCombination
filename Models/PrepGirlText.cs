using CurrentCombination.Managers;
using UnityEngine;

namespace CurrentCombination.Models;

internal class PrepGirlText() : BaseText(nameof(PrepGirlText), new Vector3(7.5f, -4.6f, 100f))
{
    protected override string GetText() => ModManager.GetGirl();
}