using UnityEngine;

public interface ResourceComponent  {
    void BaseStaminaRegen();
    void RegenStamina(float regenRate);
    void DamageStamina(float damage);
    void ResetStaminaRegenDelay();
    void DamageHealth(float damage);
    void HealHealth(float heal);
    void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection);
    void Die();
}
