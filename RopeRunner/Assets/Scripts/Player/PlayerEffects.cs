using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _greenFastEffect;
    [SerializeField] private ParticleSystem _pinkFastEffect;
    [SerializeField] private ParticleSystem _blueFastEffect;
    [SerializeField] private ParticleSystem _yellowFastEffect;

    public void PlayFastEffect(ColorFastEffect color)
    {
        switch (color)
        {
            case ColorFastEffect.green:
                _greenFastEffect.Play();
                break;
            case ColorFastEffect.pink:
                _pinkFastEffect.Play(); 
                break;
            case ColorFastEffect.blue:
                _blueFastEffect.Play();
                break;
            case ColorFastEffect.yellow:
                _yellowFastEffect.Play();
                break;
            default:
                break;
        }
    }

    public void StopFastEffect()
    {
        _greenFastEffect.Stop();
        _pinkFastEffect.Stop();
        _blueFastEffect.Stop();
        _yellowFastEffect.Stop();
    }
}

public enum ColorFastEffect
{
    green,
    pink,
    blue,
    yellow
}
