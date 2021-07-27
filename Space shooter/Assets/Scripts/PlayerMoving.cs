using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Borders
{
    public float minX_Offset = 1.1f;
    public float maxX_Offset = 1.1f;
    public float minY_Offset = 1.1f;
    public float maxY_Offset = 1.1f;

    [HideInInspector]
    public float minX, maxX, minY, maxY;

}
public class PlayerMoving : MonoBehaviour
{

    public static PlayerMoving instance;
    public Borders borders;
    public int speed_Player = 5;
    private Camera _camera;
    private Vector2 _mouse_Position;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResizeBorders();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _mouse_Position = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mouse_Position.y += 1.5f;
            transform.position = Vector2.MoveTowards(transform.position, _mouse_Position, speed_Player * Time.deltaTime);
        }
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
            Mathf.Clamp(transform.position.y, borders.minY, borders.maxY));
    }

    private void ResizeBorders()
    {
        borders.minX = _camera.ViewportToWorldPoint(Vector2.zero).x + borders.minX_Offset;
        borders.minY = _camera.ViewportToWorldPoint(Vector2.zero).y + borders.minY_Offset;
        borders.maxX = _camera.ViewportToWorldPoint(Vector2.zero).x + borders.maxX_Offset;
        borders.maxY = _camera.ViewportToWorldPoint(Vector2.zero).y + borders.maxY_Offset;
    }
}


