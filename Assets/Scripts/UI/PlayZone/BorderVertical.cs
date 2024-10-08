using UnityEngine;

public class BorderVertical : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private bool isUp;

    private void Start()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Vector2 safeAreaPosition = isUp ? Screen.safeArea.max : Screen.safeArea.min;
        var posY = cameraMain.ScreenToWorldPoint(safeAreaPosition).y;
        transform.position = new Vector2(transform.position.x, posY);
    }
}
