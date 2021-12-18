using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Awake()
    {
        transform.SetParent(_player);
    }
}
