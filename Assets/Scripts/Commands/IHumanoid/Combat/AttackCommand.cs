using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command<IHumanoid>
{
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.Attack();
    }
}
