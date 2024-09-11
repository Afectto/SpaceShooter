using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class BulletCollision : MonoBehaviour
{
    [SerializeField, Range(0, 5000)] private int damage;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble damageble))
        {
            damageble.TakeDamage(damage);
        }
        ResetObject();
    }

    private void ResetObject()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
