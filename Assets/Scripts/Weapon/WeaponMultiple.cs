using System.Collections.Generic;
using UnityEngine;

public class WeaponMultiple : WeaponBase
{
    [SerializeField] private List<Transform> firePoints;

    public override void Shot()
    {
        foreach (var point in firePoints)
        {
            BulletActivate(point);
        }
    }
}
