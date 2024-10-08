using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour, IDamageble
{
    [SerializeField] private int maxHealth;
    [SerializeField] private UnityEvent OnEndenHealth;
    private int _currentHealth;

    protected virtual void Awake()
    {
        _currentHealth = maxHealth;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public virtual void TakeDamage(int value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
        {
            OnEndenHealth?.Invoke();
            Destroy(gameObject);
        }
    }

    public virtual void AddHealth(int value)
    {
        if (value > 0)
            _currentHealth += value;
        if (_currentHealth > maxHealth)
            _currentHealth = maxHealth;
    }
}
