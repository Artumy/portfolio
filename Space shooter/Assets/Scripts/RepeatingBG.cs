using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{

    public float vertical_size;

    private Vector2 _offset_Up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -vertical_size)
        {
            RepeatBackground();
        }
    }

    void RepeatBackground()
    {
        _offset_Up = new Vector2(0, vertical_size * 2f);
        transform.position = (Vector2)transform.position + _offset_Up;
    }
}
