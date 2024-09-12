using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class BonusBase : MonoBehaviour
{
    [SerializeField] private UnityEvent Activated;
    [SerializeField, Range(1,100)] private int weightBonus = 10;
    public int Weight => weightBonus;

    private const float Speed = 5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Activate(other.gameObject);
            Activated?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y < -15)
        {
            gameObject.SetActive(false);
        }
    }

    protected abstract void Activate(GameObject playerGameObject);
}
