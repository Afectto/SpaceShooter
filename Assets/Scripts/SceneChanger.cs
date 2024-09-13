using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }
    
    [SerializeField] private CanvasGroup loadingScreen;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        loadingScreen.alpha = 0;
        loadingScreen.gameObject.SetActive(false);
    }
    
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
    
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingScreen.gameObject.SetActive(true);
        loadingScreen.DOKill();
        loadingScreen.DOFade(1f, fadeDuration);
        
        yield return loadingScreen.DOFade(1f, fadeDuration).WaitForCompletion();


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        loadingScreen.DOFade(0f, fadeDuration).OnComplete(() => loadingScreen.gameObject.SetActive(false));
    }
}
