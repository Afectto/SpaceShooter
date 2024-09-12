using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Bonus")]
public class GameBonusData : ScriptableObject
{
    public List<BonusBase> Bonuses = new List<BonusBase>();
}
