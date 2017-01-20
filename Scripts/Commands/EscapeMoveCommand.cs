using UnityEngine;
using System.Collections;
using System;

public class EscapeMoveCommand : Command
{

    public override void Execute(Player player)
    {
        player.Roll();
    }
}
