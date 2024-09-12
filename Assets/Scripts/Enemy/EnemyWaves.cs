using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] private BonusGenerator bonusGenerator;
    [SerializeField] private BonusQueue bonusQueue;
    [SerializeField] private UnityEvent EndGame;
    
    private LevelData _level;
    private int _indexWave;
    private int _indexEnemy;
    private List<GameObject> _enemies = new List<GameObject>();
    private SafeAreaData _safeArea;

    private void Awake()
    {
        _safeArea = FindObjectOfType<SafeAreaData>();
        int index = 1;//TODO: CurrentLevel
        _level = Resources.Load<LevelData>($"Levels/Level{index}");
    }

    private void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }

        EndGame?.Invoke();
        Time.timeScale = 0;
    }

    public void Generate()
    {
        var offset = 2.5f;
        Vector2 startPosition = new Vector2(0, _safeArea.GetMax().y + offset);

        foreach (var wave in _level.Waves)
        {
            for (int i = 0; i < wave.CountInWave; i++)
            {
                var enemy = Instantiate(wave.EnemyPrefab, transform);
                if (enemy.TryGetComponent(out EnemyBonusDrop enemyBonusDrop))
                {
                    enemyBonusDrop.SetBonusQueue(bonusQueue);
                    enemyBonusDrop.SetHaveBonus(bonusGenerator.TryGetBonus());
                }
                
                enemy.transform.position = startPosition;
                enemy.SetActive(false);
                _enemies.Add(enemy);
            }
        }
    }
    
    public void Activate()
    {
        StartCoroutine(EnemyActivate());
    }

    private IEnumerator EnemyActivate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        var count = _level.Waves[_indexWave].CountInWave;

        while (count > 0)
        {
            count--;
            _enemies[_indexEnemy].gameObject.SetActive(true);
            _indexEnemy++;
            yield return wait;
        }

        if (_indexWave < _level.Waves.Count - 1)
        {
            Invoke(nameof(Activate), _level.Waves[_indexWave].WaitAfterWave);
            _indexWave++;
        }
        
        
    }

}
