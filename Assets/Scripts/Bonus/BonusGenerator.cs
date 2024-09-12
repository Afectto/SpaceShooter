using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private BonusQueue bonusQueue;
    [SerializeField] private GameBonusData gameBonusData;
    
    private List<int> _bonusChance = new List<int>();
    private int _maxChance;

    private void Awake()
    {
        Calculate();
    }

    private void Calculate()
    {
        for (int i = 0; i < gameBonusData.Bonuses.Count; i++)
        {
            _maxChance += gameBonusData.Bonuses[i].Weight;
            _bonusChance.Add(_maxChance);
        }
        
        _bonusChance.Add(_maxChance * 3);
    }
    
    public bool TryGetBonus()
    {
        int chance = Random.Range(0, _bonusChance[^1]);
        bool yesChance = false;
        if (chance < _maxChance)
        {
            int min = 0;
            for (int i = 0; i < _bonusChance.Count - 1; i++)
            {
                if (chance >= min && chance < _bonusChance[i])
                {
                    Generate(gameBonusData.Bonuses[i].gameObject);
                    yesChance = true;
                    break;
                }

                min = _bonusChance[i];
            }
        }
        
        return yesChance;
    }

    private void Generate(GameObject prefab)
    {
        GameObject bonus = Instantiate(prefab, bonusQueue.transform);
        bonus.SetActive(false);
        bonusQueue.AddObject(bonus);
    }

}
