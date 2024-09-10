using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private float _endPosition;

    private void Start()
    {
        _endPosition = FindObjectOfType<SafeAreaData>().GetMin().y - 0.5f;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= _endPosition)
        {
            Destroy(gameObject);
        }
    }
}
