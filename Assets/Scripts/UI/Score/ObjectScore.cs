using System;
using UnityEngine;

public class ObjectScore : MonoBehaviour
{
    [SerializeField, Min(1)] private int score;
    public static event Action<int> OnChange;

    public void Activate()
    {
        OnChange?.Invoke(score);
    }
}
