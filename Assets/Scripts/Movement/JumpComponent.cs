using UnityEngine;

public class JumpComponent : MonoBehaviour
{
    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private Vector3Variable moveDirection;
    [SerializeField] private CharacterControllerMover characterControllerMover;
    [SerializeField] private float jumpForce = 8.0f;

    private bool returnToCrouch = false;

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
            if (stateData.ShouldJump)
            {
                moveDirection.Value.y = jumpForce;
                if (returnToCrouch)
                {
                    stateData.ShouldCrouch = true;
                    returnToCrouch = false;
                }
                
            }
        }
        stateData.ShouldJump = false;
    }

    public void Jump()
    {
        if (stateData.IsCrouching)
        {
            stateData.ShouldCrouch = true;
            returnToCrouch = true;
        }
        stateData.ShouldJump = true;
    }
}
