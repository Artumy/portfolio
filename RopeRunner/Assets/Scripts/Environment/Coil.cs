using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private ColorFastEffect _colorEffect;
    public Color Color => _color;

    private void OnTriggerEnter(Collider colldier)
    {
        if(colldier.TryGetComponent(out PlayerMover playerMover))
        {
            playerMover.ChangeSpeedOnTime(7f, 3f);
            playerMover.ChangeVisibilityEffect(3f);
        }

        if (colldier.TryGetComponent(out PlayerEffects playerEffects))
        {
            playerEffects.PlayFastEffect(_colorEffect);
        }
    }
}
