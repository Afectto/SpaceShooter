using UnityEngine;

public sealed class BonusHealth : BonusBase
{
    [SerializeField, Min(1)] private int healthValue;

    protected override void Activate(GameObject playerGameObject)
    {
        if (playerGameObject.TryGetComponent(out PlayerHealth health))
        {
            health.AddHealth(healthValue);
        }
    }
}
