using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour
{
    [SerializeField, Range(5, 40)] private float speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.up * speed;
    }
}
