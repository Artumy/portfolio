using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePlayer : MonoBehaviour
{
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;

    private bool _isDraging = false;

    private Vector2 _startTouch, _swipeDelta;

    private void Update()
    {
        Swiper();
    }

    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDraging = false;
    }

    private void Swiper()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            _isDraging = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isDraging = false;
            Reset();
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                _isDraging = true;
                _startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _isDraging = false;
                Reset();
            }
        }

        _swipeDelta = Vector2.zero;
        if (_isDraging)
        {
            if (Input.touches.Length < 0)
                _swipeDelta = Input.touches[0].position - _startTouch;
            else if (Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
        }

        if (_swipeDelta.magnitude > 100)
        {
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {

                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {

                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
    }
}