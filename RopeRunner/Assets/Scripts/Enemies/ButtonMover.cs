using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonMover : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private bool _leftDirection;

    private Vector3 _startPoint;

    private void Awake()
    {
        _startPoint = transform.position;
    }

    private void Start()
    {
        StartMove();
    }

    private void StartMove()
    {
        if (_leftDirection == true)
            _step = -_step;

        transform.DOMoveX(_startPoint.x + _step, 1f).From(_startPoint.x).SetLoops(-1, LoopType.Yoyo);
    }
}
