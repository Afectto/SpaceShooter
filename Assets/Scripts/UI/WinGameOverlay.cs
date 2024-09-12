using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinGameOverlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreInGame;
    [SerializeField] private TextMeshProUGUI resultScore;
    [SerializeField] private Button restart;
    [SerializeField] private Button toMenu;

    private void Awake()
    {
        restart.onClick.AddListener(OnRestartClick);
        toMenu.onClick.AddListener(OnMenuClicked);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        restart.onClick.RemoveListener(OnRestartClick);
        toMenu.onClick.RemoveListener(OnMenuClicked);
    }

    private void OnMenuClicked()
    {
        Time.timeScale = 1;
        FindObjectOfType<SceneChanger>().ChangeScene("Menu");
    }

    private void OnRestartClick()
    {
        Time.timeScale = 1;
        FindObjectOfType<SceneChanger>().ChangeScene("Game");
    }
    
    private void OnEnable()
    {
        scoreInGame.gameObject.SetActive(false);
        resultScore.gameObject.SetActive(true);

    }

    public void ShowValue(int value)
    {
        resultScore.text = "Score:\n" + value;
        var topScore = PlayerPrefs.GetInt("TopScore");
        if (topScore < value)
        {
            PlayerPrefs.SetInt("TopScore", value);
        }
    }

    private void OnDisable()
    {
        scoreInGame.gameObject.SetActive(true);
        resultScore.gameObject.SetActive(false);
    }
}
