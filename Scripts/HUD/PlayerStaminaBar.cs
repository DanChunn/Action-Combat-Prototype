using UnityEngine;
using System.Collections;

public class PlayerStaminaBar : ResourceBar {

    public PlayerStaminaBar()
    {
        barSizeMultiplier = 3f;
    }

    // Use this for initialization
    void Awake()
    {
        currentBar = transform.FindChild("CurrentBar").gameObject;
        BarBG = transform.FindChild("BarBG").gameObject;
    }
}
