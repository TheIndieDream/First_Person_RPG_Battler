using System.Collections;
using UnityEngine;

public class HumanoidGraphics : BaseMonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private Vector3Variable moveVelocity;
    [SerializeField] private FloatVariable humanoidDrawTime;
    private void FixedUpdate()
    {
        if(stateData != null)
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
    }

    private void Update()
    {
        if(moveVelocity != null)
        {
            animator.SetFloat("VelocityX_f", moveVelocity.Value.x);
            animator.SetFloat("VelocityZ_f", moveVelocity.Value.z);
        }
    }

    public void OnAttack(int triggerNumber)
    {
        animator.SetTrigger("Attack" + triggerNumber + "_t");
    }

    public void OnCrouchToggle()
    {
        animator.SetBool("IsCrouching_b", stateData.IsCrouching);
    }

    public void OnJumpStart()
    {
        animator.SetTrigger("Jump_t");
    }

    public void OnStagger()
    {
        animator.SetTrigger("Stagger_t");
    }

    public void OnWeaponDraw()
    {
        StartCoroutine(WeaponDrawRoutine());
    }

    public void OnWeaponSheath()
    {
        StartCoroutine(WeaponSheathRoutine());
    }

    private IEnumerator WeaponSheathRoutine()
    {
        stateData.IsTransferingWeapon = true;
        animator.SetBool("IsWeaponDrawn_b", false);
        animator.SetBool("IsSheathingWeapon_b", true);
        yield return new WaitForSeconds(humanoidDrawTime.Value);
        animator.SetBool("IsSheathingWeapon_b", false);
        stateData.IsTransferingWeapon = false;
    }

    private IEnumerator WeaponDrawRoutine()
    {
        stateData.IsTransferingWeapon = true;
        animator.SetBool("IsDrawingWeapon_b", true);
        yield return new WaitForSeconds(humanoidDrawTime.Value);
        animator.SetBool("IsDrawingWeapon_b", false);
        animator.SetBool("IsWeaponDrawn_b", true);
        stateData.IsTransferingWeapon = false;
    }
}
