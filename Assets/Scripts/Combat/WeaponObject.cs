using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public Weapon Weapon { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        Weapon.OnTriggerEnter(other);
    }
}
