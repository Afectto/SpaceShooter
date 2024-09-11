using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    public void Activate()
    {
        Destroy(gameObject);
        //TODO: Effect, score ...
    }
}
