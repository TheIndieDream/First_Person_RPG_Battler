public class ToggleRunCommand : Command<IHumanoid>
{
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.ToggleRun();
    }
}

