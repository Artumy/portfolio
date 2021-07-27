using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{

    private BoxCollider2D _boundare_Collider;

    private Vector2 _viewport_Size;

    private void Awake()
    {
        _boundare_Collider = GetComponent<BoxCollider2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        ResizeCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResizeCollider()
    {
        _viewport_Size = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
        _viewport_Size.x *= 1.5f;
        _viewport_Size.y *= 1.5f;
        _boundare_Collider.size = _viewport_Size;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Planet":
                Destroy(collision.gameObject);
                break;
            case "Bullet":
                Destroy(collision.gameObject);
                break;
        }
    }
}
