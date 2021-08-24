using UnityEngine;
using UnityEngine.Events;

public class FighterComponent : BaseMonoBehaviour
{
    public UnityIntEvent WeaponAttackResponse;
    public UnityEvent WeaponDrawResponse;
    public UnityEvent WeaponSheathResponse;

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

    public Weapon CurrentWeapon
    {
        get
        {
            return currentWeapon;
        }
        set
        {
            currentWeapon = value;
            InitalizeWeapon();
        }
    }

    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private HumanoidStateData stateData;
    [SerializeField] private WeaponSlot weaponSlot;

    private void Start()
    {
        InitalizeWeapon();
        StateData.IsWeaponDrawn = false;
        StateData.CanAttack = true;
    }

    private void InitalizeWeapon()
    {
        if (currentWeapon != null)
        {
            currentWeapon.Fighter = this;
            currentWeapon.Initialize(weaponSlot.WeaponSheathedParent);
            weaponSlot.GetCurrentWeapon();
        }
    }

    public void Attack()
    {
        if (StateData.IsWeaponDrawn && StateData.CanAttack)
        {
            currentWeapon.Attack(this);
        }
    }

    public void DisableWeaponCollider()
    {
        if (currentWeapon != null)
        {
            currentWeapon.DisableCollider();
        }
    }

    public void EnableWeaponCollider()
    {
        if(currentWeapon != null)
        {
            currentWeapon.EnableCollider();
        }
    }

    public void ToggleWeaponDraw()
    {
        if (!StateData.IsTransferingWeapon)
        {
            if (!StateData.IsWeaponDrawn)
            {
                WeaponDrawResponse.Invoke();
            }
            else
            {
                WeaponSheathResponse.Invoke();
            }
            StateData.IsWeaponDrawn = !StateData.IsWeaponDrawn;
        }
    }
}
