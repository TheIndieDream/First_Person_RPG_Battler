using UnityEngine;

public class MoveComponent : BaseMonoBehaviour
{
    public HumanoidStateData StateData
    {
        get
        {
            return stateData;
        }
        set
        {
            stateData = value;
        }
    }

    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private Vector3Variable moveDirection;
    [SerializeField] private CharacterControllerMover characterControllerMover;
    [SerializeField] private float crouchWalkSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float sprintSpeed;

    private Vector3 movementSmoothing;
    private Vector2 moveInput;
    private bool isGamepadInput;
    private float moveSpeed;

    private void Start()
    {
        if(moveDirection == null)
        {
            moveDirection = characterControllerMover.MoveDirection;
        }
    }

    private void Update()
    {
        moveSpeed = walkSpeed;
        if (stateData.IsRunning)
        {
            moveSpeed = runSpeed;
        }
        if (stateData.IsSprinting)
        {
            moveSpeed = sprintSpeed;
        }
        if (stateData.IsCrouching)
        {
            moveSpeed = crouchWalkSpeed;
        }

        float moveDirectionY = moveDirection.Value.y;

        Vector3 proposedMoveDirection;
        if (!isGamepadInput || stateData.IsSprinting)
        {
            proposedMoveDirection = ((transform.forward * moveInput.y) +
            (transform.right * moveInput.x)).normalized * moveSpeed;
        }
        else
        {
            proposedMoveDirection = ((transform.forward * moveInput.y) +
            (transform.right * moveInput.x)) * 
            (stateData.IsCrouching ? crouchWalkSpeed:runSpeed) ;
        }

        moveDirection.Value = Vector3.SmoothDamp(moveDirection.Value,
            proposedMoveDirection, ref movementSmoothing, 0.1f);
            
        moveDirection.Value.y = moveDirectionY;
    }

    public void Move(Vector2 moveInput, bool isGamepadInput)
    {
        this.moveInput = moveInput;
        this.isGamepadInput = isGamepadInput;
    }
}
