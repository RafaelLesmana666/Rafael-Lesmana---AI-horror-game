using UnityEngine;
using UnityEngine.UI;

public class CrosshairUI : MonoBehaviour
{
    [SerializeField]
    private Color _normalColor = Color.white;

    [SerializeField]
    private Color _highlightColor = Color.white;

    [SerializeField]
    private Image _crosshairImage;

    private void Awake()
    {
        _crosshairImage.color = _normalColor;
    }

    public void SetHighlightColor(bool value)
    {
        if (value)
        {
            _crosshairImage.color = _highlightColor;
        }
        else
        {
            _crosshairImage.color = _normalColor;
        }
    }
}
