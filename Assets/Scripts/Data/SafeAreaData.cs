using UnityEngine;

public class SafeAreaData : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    private Vector2 _max;
    private Vector2 _min;
    private const string KeyMaxX = "MaxX";
    private const string KeyMaxY = "MaxY";
    private const string KeyMinX = "MinX";
    private const string KeyMinY = "MinY";

    private void Start()
    {
        cameraMain = GetComponent<Camera>();
        _max = cameraMain.ScreenToWorldPoint(Screen.safeArea.max);
        _min = cameraMain.ScreenToWorldPoint(Screen.safeArea.min);
        SetMax();
        SetMin();
    }

    private void SetMax()
    {
        PlayerPrefs.SetFloat(KeyMaxX, _max.x);
        PlayerPrefs.SetFloat(KeyMaxY, _max.y);
    }

    private void SetMin()
    {
        PlayerPrefs.SetFloat(KeyMinX, _min.x);
        PlayerPrefs.SetFloat(KeyMinY, _min.y);
    }

    public Vector2 GetMax()
    {
        Vector2 vec = Vector2.zero;

        if (PlayerPrefs.HasKey(KeyMaxX))
        {
            vec.x = PlayerPrefs.GetFloat(KeyMaxX);
        }
        if (PlayerPrefs.HasKey(KeyMaxY))
        {
            vec.y = PlayerPrefs.GetFloat(KeyMaxY);
        }
        
        return vec;
    }
    
    public Vector2 GetMin()
    {
        Vector2 vec = Vector2.zero;

        if (PlayerPrefs.HasKey(KeyMinX))
        {
            vec.x = PlayerPrefs.GetFloat(KeyMinX);
        }
        if (PlayerPrefs.HasKey(KeyMinY))
        {
            vec.y = PlayerPrefs.GetFloat(KeyMinY);
        }
        
        return vec;
    }
}
