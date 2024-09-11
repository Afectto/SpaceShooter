using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private UnityEvent OnCheckPoint;

    [SerializeField] private Path _path;
    private int _index;
    private Rigidbody2D _rigidbody2D;
    
    private float _endPosition;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition( Vector2.MoveTowards(transform.position, _path.Points[_index], speed * Time.deltaTime));

        if (Vector2.Distance(transform.position, _path.Points[_index]) < 0.01f)
        {
            if (_index < _path.Points.Count - 1)
            {
                _index++;
                OnCheckPoint.Invoke();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

