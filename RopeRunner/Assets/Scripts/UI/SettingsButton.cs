using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private SettingsWindow _settingsWindow;
    [SerializeField] private GameObject _forDisable;

    public void OpenWindow()
    {
        Time.timeScale = 0;
        //_forDisable.SetActive(false);
        _settingsWindow.gameObject.SetActive(true);
    }
}
