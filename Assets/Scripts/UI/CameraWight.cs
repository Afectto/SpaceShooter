using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraWight : MonoBehaviour
{
    [SerializeField] private float wight = 1080f;
    private const float HalfSizeInPixels = 200f;

    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = wight * Screen.height / Screen.width / HalfSizeInPixels;
    }
}
