using UnityEngine;

[CreateAssetMenu(fileName = "new HumanoidStateData", 
    menuName = "State Data.../Humanoid State Data")]
public class HumanoidStateData : ScriptableObject
{
    public bool IsCrouching;
    public bool IsRunning;
    public bool IsSprinting;
    public bool IsGrounded;

    public bool ShouldCrouch;
    public bool ShouldJump;

    private void OnEnable()
    {
        IsCrouching = false;
        IsRunning = false;
        IsSprinting = false;

        ShouldCrouch = false;
        ShouldJump = false;
    }
}
