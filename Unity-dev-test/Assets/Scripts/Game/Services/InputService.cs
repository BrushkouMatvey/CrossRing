using UnityEngine;

public class InputService
{
    private static Camera _camera;
    public static Camera Camera => _camera;
    public static Vector2 clickPosition;
    
    static InputService() => _camera = Camera.main;
    public static bool isScreenHoldingClick()
    {
        clickPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        return Input.GetMouseButton(0);
    }
}