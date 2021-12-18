using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class FinalScores : MonoBehaviour
{
    [SerializeField] private List<FinishItem> _finishItems;
    [SerializeField] private TMP_Text _text;

    private int _currentMultiply = 0;

    private void OnEnable()
    {
        foreach (var item in _finishItems)
        {
            item.Activated += AddMultiply;
        }
    }

    private void OnDisable()
    {
        foreach (var item in _finishItems)
        {
            item.Activated -= AddMultiply;
        }
    }

    private void AddMultiply()
    {
        _currentMultiply++;

        ShowScores();
    }

    private void ShowScores()
    {
        _text.text = $"X{_currentMultiply}";
        _text.transform.DOShakeScale(0.3f, 0.5f, 5);
        _text.transform.DOScale(Vector3.one, 0.3f).SetDelay(0.3f);
    }

}
