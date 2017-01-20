using UnityEngine;
using System.Collections;

public class PlayerAnimationComponent : AnimationComponent {

    Player player;
    PlayerPhysicsComponent ppc;
    public Animator animator { get; protected set; }

    public PlayerAnimationComponent(Player _player, Animator _anim)
    {
        player = _player;
        animator = _anim;
        ppc = player.physicsComponent;
    }

    public void UpdateAnimations()
    {
        if (ppc.moving)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("Strafing", true);
            float angle = ppc.AngleOfMovementTowardsCursor();
            Debug.Log(angle);
            if (angle > -45f &&  angle < 45f)
            {
                animator.SetFloat("Forward Velocity", .3f);
                animator.SetFloat("Side Velocity", 0f);
            } else if (angle < -135f || angle > 135f)
            {
                animator.SetFloat("Forward Velocity", -.3f);
                animator.SetFloat("Side Velocity", 0f);
            } else if (angle >= 45f && angle <= 135f)
            {
                animator.SetFloat("Side Velocity", .3f);
                animator.SetFloat("Forward Velocity", 0f);
            } else if (angle <= -45f && angle >= -135f)
            {
                animator.SetFloat("Side Velocity", -.3f);
                animator.SetFloat("Forward Velocity", 0f);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
            animator.SetBool("Strafing", false);
            animator.SetFloat("Forward Velocity", 0f);
            animator.SetFloat("Side Velocity", 0f);
        }
    }
    public int attack0Combo = 0;

    public void Roll()
    {
        animator.SetTrigger("RollTrigger");
    }

    public void Attack0()
    {
        Debug.Log("Attack0");
        animator.SetTrigger("Attack0Trigger");
        animator.SetInteger("ComboNumber", attack0Combo);
        attack0Combo++;
        if (attack0Combo > 1)
        {
            attack0Combo = 0;
        }
    }
}
