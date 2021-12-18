using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    [SerializeField] private GameObject _crashedModel;
    [SerializeField] private ParticleSystem _crashEffect;

    public void Crash()
    {
        _crashedModel.transform.SetParent(null);
        _crashedModel.SetActive(true);

        _crashEffect.transform.SetParent(null);
        _crashEffect.Play();

        VibroControl.Vibrate(50f);

        Destroy(_crashEffect.gameObject, 1f);
        Destroy(gameObject);
    }
}
