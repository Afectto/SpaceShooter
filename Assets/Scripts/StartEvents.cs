using UnityEngine;

public class StartEvents : MonoBehaviour
{
    [SerializeField] private GameEvent startScene;
    [SerializeField] private GameEvent startGame;
    void Start()
    {
        startScene.Init();
        startGame.Init();
    }
}
