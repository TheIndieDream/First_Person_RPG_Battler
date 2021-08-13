using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour, IHumanoid
{
    [SerializeField] private HumanoidCommandStream commandStream;
    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private CrouchComponent crouchComponent;
    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private JumpComponent jumpComponent;

    private void Update()
    {
        if(commandStream.Count() > 0)
        {
            commandStream.Dequeue().Execute(this);
        }
    }

    public void Crouch()
    {
        crouchComponent.Crouch();
    }

    public void Jump()
    {
        jumpComponent.Jump();
    }

    public void Move(Vector2 moveInput, bool isGamepadInput)
    {
        moveComponent.Move(moveInput, isGamepadInput);
    }

    public void ToggleRun()
    {
        stateData.IsRunning = !stateData.IsRunning;
    }

    public void ToggleSprint()
    {
        stateData.IsSprinting = !stateData.IsSprinting;
    }
}
