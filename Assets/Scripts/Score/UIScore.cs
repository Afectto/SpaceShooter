using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ShowValue(int value)
    {
        _text.text = "Score: " + value;
    }
}
