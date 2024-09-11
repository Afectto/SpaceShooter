using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    public void Activate()
    {
        Destroy(gameObject);
        //TODO: Effect, score ...
    }
}
