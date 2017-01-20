using UnityEngine;
using System.Collections;
using System;

public class Attack0Command : Command
{

    public override void Execute(Player player)
    {
        player.Attack0();
    }
}