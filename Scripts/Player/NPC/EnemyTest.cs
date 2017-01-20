using UnityEngine;
using System.Collections;

public class EnemyTest : MonoBehaviour {

    int iFrame = 3;
    float iFrameCount = 0;
    float iFrameRegen = .2f;

    bool hittable = true;
    Collider weaponHitBy = null;

    public GameObject enemyHUDelement;

    bool alive = true;
    float maxHealth = 1000;
    float health;
    NpcHealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        enemyHUDelement.transform.rotation = Camera.main.transform.rotation;
        if (healthBar == null)
        {
            healthBar = enemyHUDelement.transform.GetComponentInChildren<NpcHealthBar>();
            Debug.Log(healthBar);
        }
    }
    void Update()
    {
        UpdateHealthBar(health,maxHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hittable)
        {
            hittable = false;
            weaponHitBy = other;
            health -= 50;
            //UpdateDamageTaken(50);
            Debug.Log(name + " hit enter by " + other.name);
        }
    }
    /*
    void OnTriggerStay(Collider other)
    {
        if (other = weaponHitBy)
        {
            hittable = false;
        }
    }*/

    void OnTriggerExit(Collider other)
    {
        if (other = weaponHitBy)
        {
            hittable = true;
            weaponHitBy = null;
            Debug.Log(name + " hit exit by " + other.name);
        }
    }
    /*
    void FixedUpdate()
    {
        //Debug.Log(hittable);
        if(iFrameCount < iFrame)
        {
            iFrameCount += iFrameRegen;
            if(iFrameCount >= iFrame)
            {
                iFrameCount = iFrame;
                hittable = false;
            }
        }
        else
        {
            hittable = true;
        }
        
    }*/

    public void DamageHealth(float damage)
    {
        health -= damage;
        UpdateHealthBar(health, maxHealth);

        if (health <= 0 && alive)
        {
            health = 0;
            //Die();
        }
    }

    public void UpdateHealthBar(float curr, float max)
    {
        healthBar.UpdateBar(curr, max);
    }

    public void UpdateDamageTaken(float damage)
    {
        healthBar.UpdateDamageTakenText(damage);
    }
}
