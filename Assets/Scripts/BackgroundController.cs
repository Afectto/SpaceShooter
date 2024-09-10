using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float speed;

    private float _positionMinY;
    private Vector2 _restartPosition;

    private void Awake()
    {
        _restartPosition = transform.position;
        _positionMinY = sprite.bounds.size.y * 2 - _restartPosition.y;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -_positionMinY)
        {
            transform.position = _restartPosition;
        }
    }
}
