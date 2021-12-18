using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishAction : MonoBehaviour
{
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private ParticleSystem _winEffect;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private List<FinishBlocksPool> _finishBlocksPools;


    public void Lose()
    {
        _panelLose.SetActive(true);
    }

    public void Win()
    {
        _cameraMover.FinishMove();

        foreach (var item in _finishBlocksPools)
        {
            item.Activate();
        }

        Invoke(nameof(DelayActivation), 3f);
    }

    private void DelayActivation()
    {
        _winEffect.Play();
        _panelWin.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
