using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BorderHeight : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private const float FullSize = 2;

    private void Start()
    {
        SetSize();
    }

    private void SetSize()
    {
        var yScale = camera.ScreenToWorldPoint(Screen.safeArea.max).y * FullSize;
        var boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(boxCollider.size.x, yScale);
    }
}
