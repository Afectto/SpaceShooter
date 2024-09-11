using UnityEngine;
using UnityEngine.Events;

public class ScoreCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> ChangeScore;
    private int _scoreCollected;

    private void Awake()
    {
        ChangeScore?.Invoke(_scoreCollected);
    }

    private void OnEnable()
    {
        ObjectScore.OnChange += OnChangeScore;
    }

    private void OnDisable()
    {
        ObjectScore.OnChange -= OnChangeScore;
    }

    private void OnChangeScore(int obj)
    {
        _scoreCollected += obj;
        ChangeScore?.Invoke(_scoreCollected);
    }
}
