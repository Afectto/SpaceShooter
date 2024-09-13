using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Color startColor = Color.white;
    [SerializeField] private Color endColor = Color.red;
    [SerializeField] private float animationDuration = 1f;

    private Vector3 _baseScale;
    private Sequence _mySequence;

    private void Start()
    {
        _baseScale = score.transform.localScale;
        AnimateText();
    }
    
    private void AnimateText()
    {
        _mySequence = DOTween.Sequence();

        _mySequence.Append(score.transform.DOScale(1.25f * _baseScale, animationDuration))
            .Join(score.DOColor(endColor, animationDuration))
            .Append(score.transform.DOScale(1f * _baseScale, animationDuration))
            .Join(score.DOColor(startColor, animationDuration))
            .SetLoops(-1, LoopType.Restart);
    }
    
    private void OnDestroy()
    {
        _mySequence.Kill();
    }
}
