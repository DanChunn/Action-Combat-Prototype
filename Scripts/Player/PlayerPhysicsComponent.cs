
using UnityEngine;
using System.Collections;

/* Class used to handle physics, movement, and look direction */
public class PlayerPhysicsComponent : PhysicsComponent
{
    public bool moving { get; protected set; }
    public bool strafing { get; protected set; }
    /* Changeable */
    float moveSpeed = 5;

    Player player;
    Vector3 velocity;
    Rigidbody rb;
    Crosshair crosshair;

    public PlayerPhysicsComponent(Player _player, Rigidbody _rb, Crosshair _crosshair)
    {
        player = _player;
        rb = _rb;
        crosshair = _crosshair;
    }

    public void FixedUpdateMove()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void Move()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void Stop()
    {
        SetVelocity(Vector3.zero);
    }

    public void HandleMove()
    {
        // Movement input
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(inputH, 0, inputV);
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        SetVelocity(moveVelocity); 
    }

    public void SetVelocity(Vector3 _velocity)
    {
        velocity = _velocity;
        if(velocity != Vector3.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }

    public float AngleOfMovementTowardsCursor()
    {
        float angle = Vector3.Angle(LookDirectionMagnitude(), MoveDirectionMagnitude());
        Vector3 cross = Vector3.Cross(LookDirectionMagnitude(), MoveDirectionMagnitude());
        if (cross.y < 0) angle = -angle;
        Debug.Log(angle);
        return angle;
    }

    /* Direction from where the character is looking to the target */
    Vector3 LookDirectionMagnitude()
    {
        return (crosshair.transform.position - player.transform.position).normalized;
    }
    Vector3 LookDirectionMagnitude(GameObject go)
    {
        return (go.transform.position - player.transform.position).normalized;
    }

    /* Move direction of the character */
    Vector3 MoveDirectionMagnitude()
    {
        return velocity.normalized;
    }

    /* Returns a scalar indicating direction of movement; 0 for towards cursor and 180 for away from cursor */
    float DotVector()
    {
        return Vector3.Dot(LookDirectionMagnitude(), MoveDirectionMagnitude());
    }

    /* Have the transform look at a direction */
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, player.transform.position.y, lookPoint.z);
        player.transform.LookAt(heightCorrectedPoint);
    }

    /* Have the transform to look at the cursor */
    public void UpdateLookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up * 1); //multiply 2nd param by weapon height?
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            crosshair.transform.position = point;
            LookAt(point);
        }
    }
}