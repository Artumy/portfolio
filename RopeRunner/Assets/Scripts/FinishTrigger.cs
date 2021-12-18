using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{

    [SerializeField] private List<ParticleSystem> _starEffects;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover playerMover))
        {
            for(int i = 0; i < _starEffects.Count; i++)
            {
                _starEffects[i].Play();
            }
        }
    }
}
