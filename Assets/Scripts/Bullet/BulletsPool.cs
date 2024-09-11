using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    private readonly Dictionary<string, List<GameObject>> _bullets = new Dictionary<string, List<GameObject>>();

    public void AddBullets(GameObject prefab, int count)
    {
        if (!_bullets.ContainsKey(prefab.name))
        {
            _bullets.Add(prefab.name, new List<GameObject>());
        }
        
        for (int i = 0; i < count; i++)
        {
            Create(prefab);
        }
    }

    private GameObject Create(GameObject prefab)
    {
        var bullet = Instantiate(prefab, transform);
        bullet.SetActive(false);
        _bullets[prefab.name].Add(bullet);
        
        return bullet;
    }

    public GameObject GetBullet(GameObject prefab)
    {
        if (_bullets.ContainsKey(prefab.name))
        {
            for (int i = 0; i < _bullets[prefab.name].Count; i++)
            {
                if (!_bullets[prefab.name][i].activeInHierarchy)
                {
                    return _bullets[prefab.name][i];
                }
            }
        }
        else
        {
            _bullets.Add(prefab.name, new List<GameObject>());
        }

        return Create(prefab);
    }
}
