using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
public class Npc : MonoBehaviour
{
    public NpcPhysicsComponent physicsComponent { get; protected set; }
    public NpcResourceComponent resourceComponent { get; protected set; }
    //public NpcInputComponent inputComponent { get; protected set; }
    public NpcAnimationComponent animationComponent { get; protected set; }

    public NpcHudComponent hud;

    public bool alive { get; protected set; }

    string enemyName;

    public Npc()
    {
        alive = true;
        enemyName = "test";
    }

    void Awake()
    {
        //hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        //physicsComponent = new NpcPhysicsComponent(this, GetComponent<Rigidbody>(), hud.crosshair);
        resourceComponent = new NpcResourceComponent(this, hud);
        //inputComponent = new PlayerInputComponent(this);
        //animationComponent = new PlayerAnimationComponent(this, GetComponent<Animator>());
    }

    void Update()
    {
        //inputComponent.HandleCommand();
        //physicsComponent.UpdateLookAtMouse();
    }

    void FixedUpdate()
    {
        resourceComponent.BaseStaminaRegen(); //regenerate stamina naturally
        //physicsComponent.FixedUpdateMove(); //if physicsController's velocity is zero, it won't move.
    }

    void LateUpdate()
    {
        //animationComponent.UpdateAnimations();
    }


    bool hittable = true;
    Collider weaponHitBy = null;

    void OnTriggerEnter(Collider other)
    {
        if (hittable)
        {
            hittable = false;
            weaponHitBy = other;
            resourceComponent.DamageHealth(50);
            Debug.Log(name + " hit enter by !" + other.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other = weaponHitBy)
        {
            hittable = true;
            weaponHitBy = null;
            Debug.Log(name + " hit exit by " + other.name);
        }
    }
}
