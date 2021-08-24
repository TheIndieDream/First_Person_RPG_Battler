using UnityEngine;

public abstract class AttackStrategy : ScriptableObject
{
    public abstract void Execute(FighterComponent fighter);
}
