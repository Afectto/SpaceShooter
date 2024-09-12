using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private HealthIconUI iconPrefab;
    [SerializeField] private PlayerHealth playerHealth;

    private List<HealthIconUI> _healthIcons = new List<HealthIconUI>();
    
    private const int Offset = -110;
    private float _maxHealth;
    
    private void Start()
    {
        _maxHealth = playerHealth.GetHealth();

        for (int i = 0; i < _maxHealth; i++)
        {
            var icon = Instantiate(iconPrefab, transform);
            icon.transform.localPosition = new Vector2(i* Offset, 0);
            _healthIcons.Add(icon);
        }
    }

    public void SetDamage()
    {
        for (var index = _healthIcons.Count - 1; index >= 0; index--)
        {
            var icon = _healthIcons[index];
            if (icon.IsFull)
            {
                icon.SetDamage();
                return;
            }
        }
    }

    public void AddHealth()
    {
        foreach (var icon in _healthIcons)
        {
            if (!icon.IsFull)
            {
                icon.AddHealth();
                return;
            }
        }
    }
}
