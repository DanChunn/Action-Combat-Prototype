using UnityEngine;
using System.Collections;

public class NpcHudComponent: MonoBehaviour, HudComponent
{

    Npc npc;
    NpcHealthBar healthBar;

    // Use this for initialization
    void Awake()
    {
        if (npc == null)
        {
            npc = transform.parent.GetComponent<Npc>();
        }
        if (healthBar == null)
        {
            healthBar = transform.GetComponentInChildren<NpcHealthBar>();
        }
        transform.rotation = Camera.main.transform.rotation;

    }

    void Initialize(float maxHealth)
    {

    }

    public void UpdateHealthBar(float curr, float max)
    {
        healthBar.UpdateBar(curr, max);
    }

    public void UpdateStaminaBar(float curr, float max)
    {

    }
}
