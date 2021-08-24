using UnityEngine.Events;

public class CombatTarget : BaseMonoBehaviour
{
    public UnityEvent Response;

    public void OnAttackRecieved()
    {
        Response.Invoke();
    }
}
