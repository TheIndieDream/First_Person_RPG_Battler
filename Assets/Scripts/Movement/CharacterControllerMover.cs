using UnityEngine;

public class CharacterControllerMover : MonoBehaviour
{
    public CharacterController Controller;
    public HumanoidStateData stateData;
    public Vector3Variable MoveDirection;
    [SerializeField] public Vector2Variable moveInput;
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
        stateData.IsGrounded = Controller.isGrounded;
        moveVelocity.Value = transform.InverseTransformVector(MoveDirection.Value);
    }
}
