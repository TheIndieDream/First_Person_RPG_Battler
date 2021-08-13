using UnityEngine;
using Cinemachine;

public class CinemachineFirstPersonCamera : CinemachineExtension
{
    [SerializeField] 
    private PlayerCameraCommandStream playerFirstPersonCameraCommandStream;
    [SerializeField] private CinemachineVirtualCamera firstPersonCamera;
    [SerializeField] private Transform humanoidTransform;

    [Header("Look Parameters")]
    [SerializeField] private bool InvertYAxis = false;
    [SerializeField, Range(1, 25)] private float lookSpeedX = 10.0f;
    [SerializeField, Range(1, 25)] private float lookSpeedY = 10.0f;
    [SerializeField, Range(1, 180)] private float clampAngle = 80.0f;

    private Vector3 startingRotation = Vector3.zero;
    private Vector2 deltaInput = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        startingRotation = transform.localRotation.eulerAngles;
    }

    protected void Update()
    {
        if(playerFirstPersonCameraCommandStream.Count() > 0)
        {
            playerFirstPersonCameraCommandStream.Dequeue().Execute(this);
        }
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, 
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                startingRotation.x += deltaInput.x * lookSpeedY * Time.deltaTime;
                startingRotation.y += deltaInput.y * lookSpeedX * Time.deltaTime;
                startingRotation.y = Mathf. Clamp(startingRotation.y,
                    -clampAngle, clampAngle);

                int cameraYInversion;
                if (InvertYAxis)
                {
                    cameraYInversion = 1;
                }
                else
                {
                    cameraYInversion = -1;
                }

                state.RawOrientation =
                    Quaternion.Euler(cameraYInversion * startingRotation.y,
                    startingRotation.x, 0.0f);

                humanoidTransform.rotation = Quaternion.Euler(0.0f,
                    startingRotation.x, 0.0f);

            }
        }
    }

    public void SetDeltaInput(Vector2 deltaInput)
    {
        this.deltaInput = deltaInput;
    }
}
