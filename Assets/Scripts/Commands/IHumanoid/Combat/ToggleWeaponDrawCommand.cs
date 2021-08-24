public class ToggleWeaponDrawCommand : Command<IHumanoid>
{
    public override void Execute(IHumanoid humanoid)
    {
        humanoid.ToggleWeaponDraw();
    }
}
