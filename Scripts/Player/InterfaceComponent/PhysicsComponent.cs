using UnityEngine;

public interface PhysicsComponent {
    void FixedUpdateMove();
    void Move();
    void SetVelocity(Vector3 _velocity);
    void Stop();
}
