using System.Collections;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float _currentTime;
    private bool _isEnabled;
    private Transform _target;

    public bool IsEnabled => _isEnabled;

    public void Activate(float lifeTime, Transform target)
    {
        _currentTime += lifeTime;
        if (!_isEnabled)
        {
            _target = target;
            transform.position = target.position;
            ShowShield(true);
            StartCoroutine(Timer());
        }
    }

    private void Update()
    {
        if (IsEnabled)
        {
            transform.position = _target.position;
        }
    }

    private void ShowShield(bool value)
    {
        circleCollider2D.enabled = value;
        spriteRenderer.enabled = value;
        _isEnabled = value;
    }

    private IEnumerator Timer()
    {
        float waitAndStep = 0.5f;
        WaitForSeconds wait = new WaitForSeconds(waitAndStep);
        while (_currentTime > 0)
        {
            _currentTime -= waitAndStep;
            yield return wait;
        }

        _currentTime = 0;
        ShowShield(false);
        transform.SetParent(null);
    }
}
