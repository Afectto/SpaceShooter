using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            _direction.x = joystick.Horizontal;
            _direction.y = joystick.Vertical;
            _rigidbody2D.MovePosition(_rigidbody2D.position + speed * _direction * Time.deltaTime);
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
