using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShotTimer : MonoBehaviour
{
    [SerializeField, Min(0.001f)] private float shotInterval = 0.5f;
    [SerializeField] private UnityEvent OnShot;

    private WaitForSeconds _wait;
    private Coroutine _timerCoroutine;
    private bool _isFirstStart;

    private void OnEnable()
    {
        if (!_isFirstStart)
        {
            _isFirstStart = true;
            return;
        }
        StartTimer();
    }

    private void OnDisable()
    {
        StopTimer();
    }
    
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
        if (_timerCoroutine == null)
        {
            _wait = new WaitForSeconds(shotInterval);
            _timerCoroutine = StartCoroutine(Timer());
        }
    }
    
    public void StopTimer()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }
}
