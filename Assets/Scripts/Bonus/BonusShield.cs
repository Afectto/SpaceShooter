using UnityEngine;

public class BonusShield : BonusBase
{
    [SerializeField] private EnergyShield energyShieldPrefab;
    [SerializeField] private float lifeTime;

    private  EnergyShield _currentShield;

    private void CheckShield()
    {
        if (_currentShield == null)
        {
            _currentShield = Instantiate(energyShieldPrefab);
        }
    }
    
    protected override void Activate(GameObject playerGameObject)
    {
        CheckShield();
        
        _currentShield.Activate(lifeTime, playerGameObject.transform);
    }
}
