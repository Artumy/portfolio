using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _vibroButton;
    [SerializeField] private Sprite _enabledSoundSprite;
    [SerializeField] private Sprite _disabledSoundSprite;
    [SerializeField] private Sprite _enabledVibroSprite;
    [SerializeField] private Sprite _disabledVibroSprite;

    private bool _volumeEnable = true;
    private bool _vibroEnable = true;

    public void OpenWindow()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ChangeVolume()
    {
        _volumeEnable = !_volumeEnable;

        if (_volumeEnable == false)
        {
            AudioListener.volume = 0f;
            //_soundButton.image.sprite = _disabledSoundSprite;
        }
        else
        {
            AudioListener.volume = 1f;
            //_soundButton.image.sprite = _enabledSoundSprite;
        }
    }

    public void ChangeVibro()
    {
        _vibroEnable = !_vibroEnable;

        if (_vibroEnable == false)
        {
            //_vibroButton.image.sprite = _disabledVibroSprite;
            PhoneVIbrateCustom.DisableVibro();
        }
        else
        {
            //_vibroButton.image.sprite = _enabledVibroSprite;
            PhoneVIbrateCustom.EnableVibro();
        }
    }
}
