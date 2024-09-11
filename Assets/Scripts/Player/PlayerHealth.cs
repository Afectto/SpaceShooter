using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : ObjectHealth
{
    [SerializeField] private UnityEvent<int> OnChangeHealth;

    protected override void Awake()
    {
        base.Awake();
        OnChangeHealth.Invoke(GetHealth());
    }

    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        OnChangeHealth.Invoke(GetHealth());
    }
}
