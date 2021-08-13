using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private Vector3Variable moveVelocity;

    private void FixedUpdate()
    {
        if (!stateData.IsGrounded)
        {
            Physics.Raycast(transform.position, -transform.up, out RaycastHit hitInfo);
            animator.SetFloat("JumpHeight_f", (transform.position - hitInfo.point).sqrMagnitude);
        }
        else
        {
            animator.SetFloat("JumpHeight_f", 0.0f);
        }
    }

    private void Update()
    {
        animator.SetBool("IsJumping_b", stateData.ShouldJump);
        animator.SetBool("IsCrouching_b", stateData.IsCrouching);
        animator.SetFloat("VelocityX_f", moveVelocity.Value.x);
        animator.SetFloat("VelocityZ_f", moveVelocity.Value.z);
    }
}
