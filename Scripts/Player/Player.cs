using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    public PlayerPhysicsComponent physicsComponent { get; protected set; }
    public PlayerResourceComponent resourceComponent { get; protected set; }
    public PlayerInputComponent inputComponent { get; protected set; }
    public PlayerAnimationComponent animationComponent { get; protected set; }
    public PlayerHudComponent hud { get; protected set; }

    public bool alive { get; protected set; }

    string playerName;

    public Player()
    {
        alive = true;
        playerName = "Player";
    }

    void Awake()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<PlayerHudComponent>();
    }

    void Start()
    {
        physicsComponent = new PlayerPhysicsComponent(this, GetComponent<Rigidbody>(), hud.crosshair);
        resourceComponent = new PlayerResourceComponent(this, hud);
        inputComponent = new PlayerInputComponent(this);
        animationComponent = new PlayerAnimationComponent(this, GetComponent<Animator>());
    }

    void Update()
    {
        inputComponent.HandleCommand();
        physicsComponent.UpdateLookAtMouse();
    }

    void FixedUpdate()
    {
        resourceComponent.BaseStaminaRegen(); //regenerate stamina naturally
        physicsComponent.FixedUpdateMove(); //if physicsController's velocity is zero, it won't move.
    }

    void LateUpdate()
    {
        animationComponent.UpdateAnimations();
    }

    public void Stop()
    {
        physicsComponent.Stop();
    }

    public void HandleMove()
    {
        physicsComponent.HandleMove();
    }

    public void Roll()
    {
        if (resourceComponent.stamina > 0)
        {
            animationComponent.Roll();
            resourceComponent.DamageStamina(50);
        }
    }

    public void Attack0()
    {
        animationComponent.Attack0();
    }

    public void Die(bool tf)
    {
        alive = tf;
        //play animations...
        GameObject.Destroy(gameObject);
    }

    public void Rename(string s)
    {
        playerName = s;
    }
}