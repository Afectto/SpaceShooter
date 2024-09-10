using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    private SafeAreaData _data;
    private const float Offset = 3f;

    private void Start()
    {
        _data = FindObjectOfType<SafeAreaData>();
        SetPosition();
    }

    private void SetPosition()
    {
        var posY = _data.GetMin().y + Offset;
        transform.position = new Vector2(transform.position.x, posY);
    }
}
