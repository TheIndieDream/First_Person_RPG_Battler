using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CrouchComponent : BaseMonoBehaviour
{
    public UnityEvent CrouchToggleResponse;

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

    [SerializeField] private float timeToCrouch = 0.1f;
    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private Transform characterHead;
    [SerializeField] private CharacterControllerMover characterControllerMover;

    [Header("Crouch Parameters")]
    [SerializeField] private Vector3 crouchCenter = new Vector3(0.0f, 0.73f, 0.2f);
    [SerializeField] private float crouchHeight = 1.4f;
    [SerializeField] private float crouchRaidus = 0.5f;
    [SerializeField] private Vector3 crouchHeadPos = new Vector3(0.09f, 1.15f, 0.43f);

    [Header("Stand Parameters")]
    [SerializeField] private Vector3 standCenter = new Vector3(0.0f, 0.96f, 0.0f);
    [SerializeField] private float standHeight = 1.86f;
    [SerializeField] private float standRadius = 0.3f;
    [SerializeField] private Vector3 standHeadPos = new Vector3(0.0f, 1.75f, 0.0f);

    private bool duringCrouchAnimation = false;

    private void Start()
    {
        stateData.IsCrouching = false;
    }

    public void Crouch()
    {
        if(characterControllerMover.Controller.isGrounded &&
            !duringCrouchAnimation)
        {
            StartCoroutine(CrouchStandRoutine());
        }
    }

    private IEnumerator CrouchStandRoutine()
    {
        duringCrouchAnimation = true;

        float timeElapsed = 0.0f;

        Vector3 targetCenter = stateData.IsCrouching ? standCenter : crouchCenter;
        Vector3 currentCenter = characterControllerMover.Controller.center;

        float targetHeight = stateData.IsCrouching ? standHeight : crouchHeight;
        float currentHeight = characterControllerMover.Controller.height;

        float targetRadius = stateData.IsCrouching ? standRadius : crouchRaidus;
        float currentRadius = characterControllerMover.Controller.radius;

        Vector3 targetHeadPos = stateData.IsCrouching ? standHeadPos : crouchHeadPos;
        Vector3 currentHeadPos = stateData.IsCrouching ? crouchHeadPos : standHeadPos;

        stateData.IsCrouching = !stateData.IsCrouching;

        CrouchToggleResponse.Invoke();

        while (timeElapsed < timeToCrouch)
        {
            characterControllerMover.Controller.center =
                Vector3.Lerp(currentCenter, targetCenter, 
                timeElapsed / timeToCrouch);
            characterControllerMover.Controller.height =
                Mathf.Lerp(currentHeight, targetHeight, 
                timeElapsed / timeToCrouch);
            characterControllerMover.Controller.radius =
                Mathf.Lerp(currentRadius, targetRadius, 
                timeElapsed / timeToCrouch);

            if(characterHead != null)
            {
                characterHead.localPosition =
                Vector3.Lerp(currentHeadPos, targetHeadPos,
                timeElapsed / timeToCrouch);
            }
            
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        characterControllerMover.Controller.center = targetCenter;
        characterControllerMover.Controller.height = targetHeight;
        characterControllerMover.Controller.radius = targetRadius;
        characterHead.localPosition = targetHeadPos;

        duringCrouchAnimation = false;
    }
}
