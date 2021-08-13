public class JumpCommand : Command<IHumanoid>
{
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.Jump();
    }
}
