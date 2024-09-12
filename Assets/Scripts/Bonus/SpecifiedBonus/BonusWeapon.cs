using UnityEngine;

public class BonusWeapon : BonusBase
{
    protected override void Activate(GameObject playerGameObject)
    {
        if(playerGameObject.TryGetComponent(out PlayerWeaponController weaponController))
        {
            weaponController.UpWeapon();
        }
    }
}
