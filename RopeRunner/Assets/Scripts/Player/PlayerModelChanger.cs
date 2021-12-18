using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModelChanger : MonoBehaviour
{
    [SerializeField] private GameObject _unbrokenNeedle;
    [SerializeField] private GameObject _damagedNeedle;
    [SerializeField] private GameObject _crashedNeedle;
    [SerializeField] private FinishAction _finishAction;

    private int _health = 2;

    public event UnityAction Destroed;

    public void ActivateDamagedModel()
    {
        _unbrokenNeedle.SetActive(false);
        _damagedNeedle.SetActive(true);
    }

    public void ActivateCrashedModel()
    {
        _unbrokenNeedle.SetActive(false);
        _damagedNeedle.SetActive(false);
        _crashedNeedle.SetActive(true);
        _crashedNeedle.transform.SetParent(null);

        Destroed?.Invoke();
    }

    public void TakeDamage()
    {
        _health--;

        if (_health == 1)
            ActivateDamagedModel();
        else if (_health == 0)
        {
            ActivateCrashedModel();
            _finishAction.Lose();
        }
    }
}
