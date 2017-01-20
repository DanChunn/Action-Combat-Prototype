using UnityEngine;

public interface InputComponent {
    void HandleCommand();
    Command HandleInput();
}
