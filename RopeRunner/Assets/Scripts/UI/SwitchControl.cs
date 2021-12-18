using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    [SerializeField] private GameObject _textSwipe;
    [SerializeField] private GameObject _textFinger;
    [SerializeField] private PlayerMover _playerMover;

    public void ChangeControl()
    {
        _playerMover.isSwipe = !_playerMover.isSwipe;
        if(_playerMover.isSwipe)
        {
            _textSwipe.SetActive(true);
            _textFinger.SetActive(false);
        }
        else
        {
            _textSwipe.SetActive(false);
            _textFinger.SetActive(true);
        }
    }
}
