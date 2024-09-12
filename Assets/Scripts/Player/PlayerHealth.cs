using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : ObjectHealth
{
    [SerializeField] private UnityEvent<int> OnTakeDamage;
    [SerializeField] private UnityEvent<int> OnAddHealth;


    protected override void Awake()
    {
        base.Awake();
        OnTakeDamage.Invoke(GetHealth());
    }

    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        OnTakeDamage.Invoke(GetHealth());
    }

    public override void AddHealth(int value)
    {
        base.AddHealth(value);
        OnAddHealth?.Invoke(value);
    }
}
