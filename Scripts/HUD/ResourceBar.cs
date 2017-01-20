using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class ResourceBar : MonoBehaviour {

    protected GameObject currentBar;
    protected GameObject BarBG;
    protected float currentValue { get; set; }
    protected float maxValue { get; set; }
    protected float barSizeMultiplier { get; set; }
    public void UpdateBar(float _currentValue, float _maxValue)
    {
        currentValue = _currentValue;
        maxValue = _maxValue;
        float ratio = currentValue / maxValue;
        currentBar.GetComponent<Image>().rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void SetBarSize(float _maxValue)
    {
        float height = GetComponent<RectTransform>().rect.height;
        GetComponent<RectTransform>().sizeDelta = new Vector2(_maxValue * barSizeMultiplier, height);
        foreach (Transform child in transform)
        {
            child.GetComponent<RectTransform>().sizeDelta = new Vector2(_maxValue * barSizeMultiplier, height);
        }
    }
}
