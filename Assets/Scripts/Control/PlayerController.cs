using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseMonoBehaviour
{
    [Header("Gamepad Parameters")]
    [SerializeField] private float gamepadLookSensitivity;

    [Header("Command Streams")]
    [SerializeField] private PlayerCameraCommandStream playerCameraCommandStream;
    [SerializeField] private HumanoidCommandStream playerCommandStream;

    private AttackCommand attackCommand = new AttackCommand();
    private CrouchCommand crouchCommand = new CrouchCommand();

    private ToggleWeaponDrawCommand toggleWeaponDrawCommand = 
        new ToggleWeaponDrawCommand();

    private JumpCommand jumpCommand = new JumpCommand();
    private LookCommand lookCommand = new LookCommand();
    private MoveCommand moveCommand = new MoveCommand();
    private ToggleRunCommand toggleRunCommand = new ToggleRunCommand();

    private ToggleSprintCommand toggleSprintCommand = 
        new ToggleSprintCommand();

    private void Start()
    {
        Cursor.visible = false;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerCommandStream.Enqueue(attackCommand);
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerCommandStream.Enqueue(crouchCommand);
        }
    }

    public void OnWeaponDrawToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerCommandStream.Enqueue(toggleWeaponDrawCommand);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerCommandStream.Enqueue(jumpCommand);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lookCommand.DeltaInput = context.ReadValue<Vector2>();
            playerCameraCommandStream.Enqueue(lookCommand);
        }
    }

    public void OnGamePadLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lookCommand.DeltaInput = 
                context.ReadValue<Vector2>() * gamepadLookSensitivity;
            playerCameraCommandStream.Enqueue(lookCommand);
        }
    }

    public void OnGamepadMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveCommand.MoveInput = context.ReadValue<Vector2>();
            moveCommand.IsGamepadInput = true;
            playerCommandStream.Enqueue(moveCommand);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveCommand.MoveInput = context.ReadValue<Vector2>();
            moveCommand.IsGamepadInput = false;
            playerCommandStream.Enqueue(moveCommand);
        }
    }

    public void OnRunToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerCommandStream.Enqueue(toggleRunCommand);
        }
    }

    public void OnSprintToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerCommandStream.Enqueue(toggleSprintCommand);
        }
        if (context.canceled)
        {
            playerCommandStream.Enqueue(toggleSprintCommand);
        }
    }
}
