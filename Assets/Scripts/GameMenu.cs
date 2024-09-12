using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button startGame;

    private const string ScoreText = "Top Score:\n";

    private void Awake()
    {
        if (PlayerPrefs.HasKey("TopScore"))
        {
            score.text = ScoreText + PlayerPrefs.GetInt("TopScore");
        }
        else
        {
            PlayerPrefs.SetInt("TopScore", 0);
            score.text = ScoreText + "0";
        }
        startGame.onClick.AddListener(OnGameClicked);
    }

    private void OnDestroy()
    {
        startGame.onClick.RemoveListener(OnGameClicked);
    }

    private void OnGameClicked()
    {
        FindObjectOfType<SceneChanger>().ChangeScene("Game");
    }
}
