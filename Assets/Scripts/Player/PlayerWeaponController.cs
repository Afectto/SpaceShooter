using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private List<WeaponBase> weaponsByLevel = new List<WeaponBase>();

    private List<WeaponBase> _allWeapons = new List<WeaponBase>();
    private WeaponBase _currentWeapon;
    private int _levelWeapon;

    private void Awake()
    {
        foreach (var weapon in weaponsByLevel)
        {
            var weaponItem = Instantiate(weapon, transform);
            weaponItem.gameObject.SetActive(false);
            _allWeapons.Add(weaponItem);
        }
        
        ChangeWeapon();
    }

    public void UpWeapon()
    {
        _levelWeapon++;
        if (_levelWeapon >= _allWeapons.Count)
        {
            _levelWeapon = _allWeapons.Count - 1;
        }
        ChangeWeapon();
    }

    public void DownWeapon()
    {
        _levelWeapon = Math.Max(0, --_levelWeapon);
        if (_levelWeapon > 0)
        {
            ChangeWeapon();
        }
    }

    private void ChangeWeapon()
    {
        _currentWeapon?.gameObject.SetActive(false);
        _currentWeapon = _allWeapons[_levelWeapon];
        _currentWeapon.gameObject.SetActive(true);
    }
}
