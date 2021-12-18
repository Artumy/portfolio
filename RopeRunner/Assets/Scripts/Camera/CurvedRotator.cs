using AmazingAssets.CurvedWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CurvedRotator : MonoBehaviour
{
    [SerializeField] private CurvedWorldController _curvedController;

    private void Start()
    {
        ChangeX();
        ChangeY();
    }

    private void ChangeX()
    {
        DOVirtual.Float(-2f, 2f, 60f, value =>
        {
            _curvedController.SetBendHorizontalSize(value);
        });

        //DOVirtual.Float(0, 360, duration, angle => {
        //    Debug.Log(Mathf.sin(angle * Mathf.Rad2Deg));
        //});
    }

    private void ChangeY()
    {
        DOVirtual.Float(-2f, 2f, 60f, value =>
        {
            _curvedController.SetBendVerticalSize(value);
        });
    }
}
