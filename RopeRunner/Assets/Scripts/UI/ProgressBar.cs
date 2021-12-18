using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _maximum;
    private Image _mask;

    private void Start()
    {
        _mask = GetComponent<Image>();
    }
    private void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = _player.position.z / _maximum;
        _mask.fillAmount = fillAmount;
    }
}
