using UnityEngine;
using UnityEngine.UI;

public class HealthIconUI : MonoBehaviour
{
    [SerializeField] private Image Full;
    [SerializeField] private Image Empty;

    private void Awake()
    {
        Empty.gameObject.SetActive(false);
    }

    public bool IsFull => Full.gameObject.activeSelf;

    public void SetDamage()
    {
        Empty.gameObject.SetActive(true);
        Full.gameObject.SetActive(false);
    }

    public void AddHealth()
    {
        Empty.gameObject.SetActive(false);
        Full.gameObject.SetActive(true);
    }
}
