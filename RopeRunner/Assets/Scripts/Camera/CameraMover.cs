using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _finishPosition;
    [SerializeField] private Vector3 _finishRotation;
    [SerializeField] private int _cameraSpeed = 2;

    private Vector3 _offset;
    public bool _canMove = true;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }

    private void Update()
    {
        if(_canMove == true)
        {
        Vector3 newPosition = new Vector3(_offset.x, _player.position.y + _offset.y, _player.position.z + _offset.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, _cameraSpeed * Time.deltaTime);

        }
    }

    public void StopMove()
    {
        _canMove = false;
    }

    public void FinishMove()
    {
        _canMove = false;

        transform.DOMove(_finishPosition, 2f);
        transform.DORotate(_finishRotation, 1f);

        Camera.main.DOFieldOfView(90, 2f);
    }

    public void UpCamera()
    {
        _offset.y += 0.5f;
        _offset.z -= 0.5f;
    }
}
