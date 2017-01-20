using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthBar : ResourceBar
{
    public PlayerHealthBar()
    {
        barSizeMultiplier = 1f;
    }
    
    // Use this for initialization
    void Awake()
    {
        currentBar = transform.FindChild("CurrentBar").gameObject;
        BarBG = transform.FindChild("BarBG").gameObject;
    }
}