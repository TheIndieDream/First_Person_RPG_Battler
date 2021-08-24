using UnityEngine;
using UnityEngine.Events;

public class JumpComponent : BaseMonoBehaviour
{
    public UnityEvent JumpResponse;

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

    [SerializeField] private Vector3Variable moveDirection;
    [SerializeField] private CharacterControllerMover characterControllerMover;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private HumanoidStateData stateData;

    //private bool returnToCrouch = false;

    private void Start()
    {
        if(moveDirection == null)
        {
            moveDirection = characterControllerMover.MoveDirection;
        }
    }

    public void Update()
    {
        if (characterControllerMover.Controller.isGrounded)
        {
            moveDirection.Value.y = -0.5f;
        }
    }

    public void Jump()
    {
        if (characterControllerMover.Controller.isGrounded)
        {
            JumpResponse.Invoke();
            moveDirection.Value.y = jumpForce;
        }
    }
}
