using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _cost;
    [SerializeField] private GameObject _crashedModel;
    [SerializeField] private ParticleSystem _crashEffect;

    public float Cost => _cost;

    public void Crash()
    {
        Instantiate(_crashedModel, transform.position, Quaternion.identity);

        _crashEffect.transform.parent = null;
        _crashEffect.Play();

        VibroControl.Vibrate(30f);
        //add autodestroy!

        _renderer.enabled = false;
        //Destroy(gameObject);
    }

}
