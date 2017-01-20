using UnityEngine;
using System.Collections;
using System;

public class DoNothingCommand : Command {

    public override void Execute(Player player)
    {
        player.Stop();
    }
}
