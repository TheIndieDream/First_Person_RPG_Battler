public class ToggleSprintCommand : Command<IHumanoid>
{
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.ToggleSprint();
    }
}
