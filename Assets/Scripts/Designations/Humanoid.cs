using UnityEngine;

public class Humanoid : BaseMonoBehaviour, IHumanoid
{
    [SerializeField] private HumanoidCommandStream commandStream;
    [SerializeField] private HumanoidStateData stateData;

    [SerializeField] private CrouchComponent crouchComponent;
    [SerializeField] private FighterComponent fighterComponent;
    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private JumpComponent jumpComponent;
    [SerializeField] private CharacterControllerMover characterControllerMover;

    private void Awake()
    {
        if(stateData == null)
        {
            HumanoidStateData stateDataInstance = 
                ScriptableObject.CreateInstance<HumanoidStateData>();
            crouchComponent.StateData = stateDataInstance;
            fighterComponent.StateData = stateDataInstance;
            jumpComponent.StateData = stateDataInstance;
            moveComponent.StateData = stateDataInstance;
            characterControllerMover.StateData = stateDataInstance;
        }
    }

    private void Update()
    {
        if(commandStream != null && commandStream.Count() > 0)
        {
            commandStream.Dequeue().Execute(this);
        }
    }

    public void Attack()
    {
        fighterComponent.Attack();
    }

    public void Crouch()
    {
        crouchComponent.Crouch();
    }

    public void ToggleWeaponDraw()
    {
        fighterComponent.ToggleWeaponDraw();
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
