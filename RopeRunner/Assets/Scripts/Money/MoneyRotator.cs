using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyRotator : MonoBehaviour
{
    private float _speed = 1f;

    private void Start()
    {
        StartMove();
    }

    private void StartMove()
    {
        transform.DOLocalRotate(transform.localEulerAngles + Vector3.up * 90f, 1f).SetLoops(-1, LoopType.Yoyo);
        transform.DOMoveY(transform.position.y + 0.2f, 0.6f).SetLoops(-1, LoopType.Yoyo);

    }
}
