using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    [SerializeField] private SwipePlayer _swipePlayer;

    private void Update()
    {
        if (_swipePlayer.tap == true)
            Destroy(gameObject);
    }
}
