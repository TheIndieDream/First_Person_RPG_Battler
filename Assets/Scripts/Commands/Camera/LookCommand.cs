using UnityEngine;

public class LookCommand : Command<CinemachineFirstPersonCamera>
{
    public Vector2 DeltaInput = Vector2.zero;
    public override void Execute(CinemachineFirstPersonCamera playerCamera)
    {
        playerCamera.SetDeltaInput(DeltaInput);
    }
}
