using UnityEngine;

public class MoveCommand : Command<IHumanoid>
{
    public Vector2 MoveInput;
    public bool IsGamepadInput;
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.Move(MoveInput,IsGamepadInput);
    }
}
