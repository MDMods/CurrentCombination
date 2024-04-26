using UnityEngine;
using UnityEngine.UI;
using Logger = CurrentCombination.Utils.Logger;
using Object = UnityEngine.Object;

namespace CurrentCombination.Models;

internal abstract class BaseText(string objectName, Vector3 newPosition)
{
    protected Text _textComponent;

    private static Text InstantiateBase(Transform parent)
    {
        var baseText = GameObject.Find("ImgArtistMask").transform.Find("TxtArtist")
            ?.gameObject
            .GetComponent<Text>();

        if (baseText is not null) return Object.Instantiate(baseText, parent);

        Logger.Debug("BaseText is null");
        return null;
    }

    protected abstract string GetText();

    internal void Create(Transform parent)
    {
        if (parent is null)
        {
            Logger.Debug("Parent is null");
            return;
        }

        _textComponent = InstantiateBase(parent);

        if (_textComponent is null)
        {
            Logger.Debug("Text creation failed");
            return;
        }

        _textComponent.name = objectName;
        _textComponent.text = GetText();
        _textComponent.resizeTextForBestFit = true;
        _textComponent.transform.position = newPosition;
        _textComponent.gameObject.SetActive(true);
    }

    internal void UpdateText()
    {
        if (_textComponent is null) return;
        _textComponent.text = GetText();
    }
}