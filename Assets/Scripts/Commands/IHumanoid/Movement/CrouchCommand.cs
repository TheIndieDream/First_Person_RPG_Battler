using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCommand : Command<IHumanoid>
{
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.Crouch();
    }
}
