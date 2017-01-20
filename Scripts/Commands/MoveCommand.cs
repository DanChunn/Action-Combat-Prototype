using UnityEngine;
using System.Collections;
using System;

public class MoveCommand : Command {

    public override void Execute(Player player)
    {
        player.HandleMove();
    }
}
