using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float delay;
    
    protected BulletsPool BulletsPool;

    private void OnEnable()
    {
        if (!BulletsPool)
        {
            BulletsPool = FindObjectOfType<BulletsPool>();
            BulletsPool.AddBullets(bulletPrefab, 5);
        }
    }

    protected void BulletActivate(Transform startPosition)
    {
        var bullet = BulletsPool.GetBullet(bulletPrefab);
        bullet.transform.position = startPosition.position;
        bullet.transform.Rotate(startPosition.rotation.eulerAngles);
        bullet.SetActive(true);
    }

    public abstract void Shot();
}
