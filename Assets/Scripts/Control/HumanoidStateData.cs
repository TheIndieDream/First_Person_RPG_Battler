using UnityEngine;

[CreateAssetMenu(fileName = "new HumanoidStateData", 
    menuName = "State Data.../Humanoid State Data")]
public class HumanoidStateData : ScriptableObject
{
    public bool CanAttack { get; set; } 
    public bool IsCrouching { get; set; }
    public bool IsGrounded { get; set; }
    public bool IsRunning { get; set; }
    public bool IsSprinting { get; set; }
    public bool IsTransferingWeapon { get; set; }
    public bool IsWeaponDrawn { get; set; }

    private void OnEnable()
    {
        IsCrouching = false;
        IsRunning = false;
        IsSprinting = false;
    }
}
