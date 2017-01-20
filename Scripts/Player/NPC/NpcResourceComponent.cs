using UnityEngine;
using System.Collections;

public class NpcResourceComponent : ResourceComponent
{
    HudComponent hud;

    bool alive = true;
    public float health { get; protected set; }
    public float maxHealth { get; protected set; }
    public float maxStamina { get; protected set; }
    public float stamina { get; protected set; }

    float staminaRegenDelay = 7.5f;
    float staminaRegenDelayCount = 0;
    float staminaRegenDelayIncr = .1f;
    float staminaRegenRate = .6f;

    public NpcResourceComponent(Npc _npc, HudComponent _hud)
    {
        maxStamina = 200f;
        maxHealth = 700f;
        health = maxHealth;
        stamina = maxStamina;
        hud = _hud;
    }


    public void BaseStaminaRegen()
    {
        RegenStamina(staminaRegenRate);
    }

    public void RegenStamina(float regenRate)
    {
        if (staminaRegenDelayCount < staminaRegenDelay)
        {
            staminaRegenDelayCount += staminaRegenDelayIncr;
            return;
        }

        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
            return;
        }
        stamina += regenRate;
        //hud.UpdateStaminaBar(stamina, maxStamina);
    }

    public void DamageStamina(float damage)
    {
        stamina -= damage;
        if (stamina < 0)
        {
            stamina = 0;
        }
        ResetStaminaRegenDelay();
        //hud.UpdateStaminaBar(stamina, maxStamina);
    }

    public void ResetStaminaRegenDelay()
    {
        staminaRegenDelayCount = 0;
    }

    public void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        // Do some stuff here with hit var
        DamageHealth(damage);
    }

    public void HealHealth(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        //hud.UpdateHealthBar(health, maxHealth);
    }

    public void DamageHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        hud.UpdateHealthBar(health, maxHealth);
    }

    public void Die()
    {
        alive = false;
        //player.Die(alive);
    }
}
