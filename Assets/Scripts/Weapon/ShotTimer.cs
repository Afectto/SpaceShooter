using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShotTimer : MonoBehaviour
{
    [SerializeField, Min(0.001f)] private float shotInterval = 0.5f;
    [SerializeField] private UnityEvent OnShot;

    private WaitForSeconds _wait;
    
    private IEnumerator Timer()
    {
        while (true)
        {
            OnShot.Invoke();
            yield return _wait;
        }
    }

    public void StartTimer()
    {
        _wait = new WaitForSeconds(shotInterval);
        StartCoroutine(Timer());
    }
}
