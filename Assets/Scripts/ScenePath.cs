using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePath : MonoBehaviour
{
    [SerializeField] private List<Transform> pathPosition = new List<Transform>();

    private void Awake()
    {
        Destroy(gameObject);
    }

    public void AddPoint(Transform point)
    {
        pathPosition.Add(point);
    }

    public List<Vector2> GetPathPoints()
    {
        List<Vector2> point = new List<Vector2>();
        foreach (var pointTransform in pathPosition)
        {
            point.Add(pointTransform.position);
        }

        return point;
    }
}
