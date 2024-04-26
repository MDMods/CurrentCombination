using CurrentCombination.Managers;
using UnityEngine;

namespace CurrentCombination.Models;

internal class PrepElfinText() : BaseText(nameof(PrepElfinText), new Vector3(7.5f, -5.05f, 100f))
{
    protected override string GetText() => ModManager.GetElfin();
}