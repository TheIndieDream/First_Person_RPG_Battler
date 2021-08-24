using UnityEngine.Events;

public class HumanoidAnimationEventListener : BaseMonoBehaviour
{
    public UnityEvent AE_WeaponDrawTransfer_Response;
    public UnityEvent AE_WeaponSheathTransfer_Response;
    public UnityEvent AE_WeaponColliderActivate_Response;
    public UnityEvent AE_WeaponColliderDeactivate_Response;

    public void AE_WeaponDrawTransfer()
    {
        AE_WeaponDrawTransfer_Response.Invoke();
    }

    public void AE_WeaponSheathTransfer()
    {
        AE_WeaponSheathTransfer_Response.Invoke();
    }

    public void AE_WeaponColliderActivate()
    {
        AE_WeaponColliderActivate_Response.Invoke();
    }

    public void AE_WeaponColliderDeactivate()
    {
        AE_WeaponColliderDeactivate_Response.Invoke();
    }
}
