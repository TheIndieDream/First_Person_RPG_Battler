using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public FighterComponent Fighter { get; set; }

    public GameObject WeaponPrefab;
    public AttackStrategy Strategy;

    private Collider weaponCollider;
    private WeaponObject weaponObject;

    public void Initialize(Transform weaponSheathedSlot)
    {
        GameObject weaponGameObject = 
            Instantiate(WeaponPrefab, weaponSheathedSlot);

        weaponObject = weaponGameObject.GetComponent<WeaponObject>();
        weaponObject.Weapon = this;

        weaponCollider = weaponGameObject.GetComponent<Collider>();
        weaponCollider.enabled = false;
    }

    public void Attack(FighterComponent fighter)
    {
        Strategy.Execute(fighter);
    }

    public void EnableCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableCollider()
    {
        weaponCollider.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        CombatTarget target = other.GetComponent<CombatTarget>();
        if(target != null && other.transform.root != Fighter.transform.root)
        {
            target.OnAttackRecieved();
        }
    }
}
