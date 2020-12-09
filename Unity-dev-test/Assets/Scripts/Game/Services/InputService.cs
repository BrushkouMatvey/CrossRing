using UnityEngine;

public class InputService
{
    private Camera _camera;
    public Camera Camera => _camera;
    public static Vector2 clickPosition;
    
    public InputService() => _camera = Camera.main;
    public bool IsScreenHoldingClick()
    {
        clickPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        return Input.GetMouseButton(0);
    }
}