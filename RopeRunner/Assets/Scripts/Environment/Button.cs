using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _crashedModel;
    [SerializeField] private ParticleSystem _crashEffect;

    public void Crash()
    {
        Instantiate(_crashedModel, transform.position, Quaternion.identity);

        _crashEffect.transform.SetParent(null);
        _crashEffect.Play();

        VibroControl.Vibrate(50f);

        Destroy(_crashEffect.gameObject, 1f);
        Destroy(gameObject);


    }
}
