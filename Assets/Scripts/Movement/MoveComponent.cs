using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private HumanoidStateData humanoidStateData;
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
        if (humanoidStateData.IsRunning)
        {
            moveSpeed = runSpeed;
        }
        if (humanoidStateData.IsSprinting)
        {
            moveSpeed = sprintSpeed;
        }
        if (humanoidStateData.IsCrouching)
        {
            moveSpeed = crouchWalkSpeed;
        }

        float moveDirectionY = moveDirection.Value.y;

        Vector3 proposedMoveDirection;
        if (!isGamepadInput || humanoidStateData.IsSprinting)
        {
            proposedMoveDirection = ((transform.forward * moveInput.y) +
            (transform.right * moveInput.x)).normalized * moveSpeed;
        }
        else
        {
            proposedMoveDirection = ((transform.forward * moveInput.y) +
            (transform.right * moveInput.x)) * 
            (humanoidStateData.IsCrouching ? crouchWalkSpeed:runSpeed) ;
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
