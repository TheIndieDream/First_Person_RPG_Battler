using UnityEngine;

public class CharacterControllerMover : BaseMonoBehaviour
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

    public CharacterController Controller;
    public Vector3Variable MoveDirection;
    public Vector2Variable MoveInput;
    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private Vector3Variable moveVelocity;

    private void Awake()
    {
        if(MoveDirection == null)
        {
            MoveDirection = ScriptableObject.CreateInstance<Vector3Variable>();
        }
    }

    private void LateUpdate()
    {
        Controller.Move(MoveDirection.Value * Time.deltaTime);
        StateData.IsGrounded = Controller.isGrounded;
        if(moveVelocity != null && MoveDirection != null)
        {
            moveVelocity.Value = transform.InverseTransformVector(MoveDirection.Value);
        }
    }
}
