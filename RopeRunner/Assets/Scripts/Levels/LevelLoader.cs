using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private int _levelForLoad;

    private int _currentLevel;

    private void Start()
    {
#if UNITY_EDITOR

        SetLevel();
#endif

        if (PlayerPrefs.HasKey("CurrentLevel") == false)
        {
            _currentLevel = 0;
            PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
            PlayerPrefs.SetInt("TotalLevel", _currentLevel + 1);
        }
        else
        {
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        LoadLevel();
    }

    private void LoadLevel()
    {
        _levels[_currentLevel].gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    private void SetLevel()
    {
        if (_levelForLoad != 0)
            PlayerPrefs.SetInt("CurrentLevel", _levelForLoad - 1);
    }

    public void LoadNextLevel()
    {
        _currentLevel++;

        if (_levels.Count <= _currentLevel)
            _currentLevel = 0;

        //PlayerPrefs.SetInt("TotalLevel", PlayerPrefs.GetInt("TotalLevel") + 1);
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);

        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
