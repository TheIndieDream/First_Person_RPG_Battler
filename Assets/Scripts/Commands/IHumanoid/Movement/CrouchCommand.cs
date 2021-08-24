public class CrouchCommand : Command<IHumanoid>
{
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.Crouch();
    }
}
