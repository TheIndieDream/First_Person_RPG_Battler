using UnityEngine;

public class WeaponSlot : BaseMonoBehaviour
{
    public Transform WeaponDrawnParent;
    public Transform WeaponSheathedParent;

    private Transform currentWeaponTransform;

    public void GetCurrentWeapon()
    {
        currentWeaponTransform = WeaponSheathedParent.GetChild(0);
    }

    public void OnWeaponDrawTransfer()
    {
        currentWeaponTransform.parent = WeaponDrawnParent;
        currentWeaponTransform.localPosition = Vector3.zero;
        currentWeaponTransform.localRotation = Quaternion.identity;
    }

    public void OnWeaponSheathTransfer()
    {
        currentWeaponTransform.parent = WeaponSheathedParent;
        currentWeaponTransform.localPosition = Vector3.zero;
        currentWeaponTransform.localRotation = Quaternion.identity;
    }
}
