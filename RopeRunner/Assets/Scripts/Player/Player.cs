using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private RopeScaler _ropeScaler;
    [SerializeField] private RopeColorChanger _ropeColorChanger;

    private bool _canScale;


    private void Update()
    {
        if (_canScale == true)
        {
            _ropeScaler.Scale(1f);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Coin bonus))
        {
            bonus.Crash();
 
            _ropeScaler.Scale(bonus.Cost);

        }

        if (collider.TryGetComponent(out Coil coil))
        {
            _ropeColorChanger.ChangeColorTo(coil.Color);
        }
    }
}
