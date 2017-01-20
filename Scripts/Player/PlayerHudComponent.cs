using UnityEngine;
using System.Collections;

public class PlayerHudComponent : MonoBehaviour, HudComponent {

    Player player;
	PlayerHealthBar healthBar;
    PlayerStaminaBar staminaBar;
    public Crosshair crosshair { get; protected set; }


    void Start()
    {
        Initialize(player.resourceComponent.maxHealth, player.resourceComponent.maxStamina);
    }

    void Awake()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        if(healthBar == null)
        {
            healthBar = transform.GetComponentInChildren<PlayerHealthBar>();
        }
        if(staminaBar == null)
        {
            staminaBar = transform.GetComponentInChildren<PlayerStaminaBar>();  
        }
        if(crosshair == null)
        {
            GameObject go = Instantiate(Resources.Load("Crosshair", typeof(GameObject))) as GameObject;
            crosshair = go.GetComponent<Crosshair>();
        }
        Cursor.visible = false;
    }

    void Initialize(float maxHealth, float maxStamina)
    {
        healthBar.SetBarSize(maxHealth);
        staminaBar.SetBarSize(maxStamina);
    }


    public void UpdateHealthBar(float curr, float max)
    {
        healthBar.UpdateBar(curr, max);
    }

    public void UpdateStaminaBar(float curr, float max)
    {
        staminaBar.UpdateBar(curr, max);
    }

    public void SetPlayer(Player _player)
    {
        player = _player;
    }
}
