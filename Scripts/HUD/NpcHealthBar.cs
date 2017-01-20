using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NpcHealthBar : ResourceBar {

    Text text;

    public NpcHealthBar()
    {
        barSizeMultiplier = 1f;
    }

    // Use this for initialization
    void Awake()
    {
        currentBar = transform.FindChild("CurrentBar").gameObject;
        BarBG = transform.FindChild("BarBG").gameObject;
        text = transform.FindChild("Text").gameObject.GetComponent<Text>();
    }

    public void UpdateDamageTakenText(float damage)
    {
        text.text = damage.ToString();
    }
}
