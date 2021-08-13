using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComponent : MonoBehaviour
{
    [SerializeField] private Vector3Variable moveDirection;
    [SerializeField] private CharacterControllerMover characterControllerMover;
    [SerializeField] private float gravity;
    [SerializeField] private float maxFallVelocity;

    private void Start()
    {
        if(moveDirection == null)
        {
            moveDirection = characterControllerMover.MoveDirection;
        }
    }

    private void Update()
    {   
        if (!characterControllerMover.Controller.isGrounded)
        {
            moveDirection.Value.y -= gravity * Time.deltaTime;
        }

        if (moveDirection.Value.y < -maxFallVelocity)
        {
            moveDirection.Value.y = -maxFallVelocity;
        }
    }
}
