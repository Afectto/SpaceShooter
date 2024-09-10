using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level")]
public class LevelData : ScriptableObject
{
    public List<Wave> Waves = new List<Wave>();
}
[Serializable]
public class Wave
{
    public GameObject EnemyPrefab;
    [Range(1, 100)] public int CountInWave;
    [Range(1, 360)] public int WaitAfterWave;
}