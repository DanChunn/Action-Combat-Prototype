using UnityEngine;
using System.Collections;

public class PlayerInputComponent : InputComponent {

    Player player;

    public PlayerInputComponent(Player _player)
    {
        player = _player;
    }

    public void HandleCommand()
    {
        Command command = HandleInput();
        if (command != null)
        {
            command.Execute(player);
        }
    }

    public Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return new EscapeMoveCommand();
        }
        if (Input.GetMouseButtonDown(0))
        {
            return new Attack0Command();
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            return new MoveCommand();
        }


        return new DoNothingCommand();
    }
}
