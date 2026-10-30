using UnityEngine;

public class ColliiderToCamScaler : MonoBehaviour
{
    private Camera Cam;
    private BoxCollider2D BoxCol;
    
    void Awake()
    {
        Cam = GetComponent<Camera>();
        BoxCol = GetComponent<BoxCollider2D>();

        float AspectRat = Screen.width / Screen.height;
        float OrthographicSize = Cam.orthographicSize;

        float width = 4f * OrthographicSize * AspectRat;
        float height = 2f * OrthographicSize;

        BoxCol.size = new Vector2(width,height);
    }

}
