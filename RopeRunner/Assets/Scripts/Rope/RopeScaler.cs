using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeScaler : MonoBehaviour
{
    private ObiRopeCursor _cursor;
    private ObiRope _rope;

    private void Awake()
    {
        _cursor = GetComponentInChildren<ObiRopeCursor>();
        _rope = _cursor.GetComponent<ObiRope>();
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        _cursor.ChangeLength(_rope.restLength + 1f * Time.deltaTime);
    //    }
    //}

    public void Scale(float value)
    {
        _cursor.ChangeLength(_rope.restLength + value * Time.deltaTime);
    }
}
