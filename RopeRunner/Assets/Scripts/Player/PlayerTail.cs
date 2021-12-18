using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTail : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private RopeScaler _ropeScaler;
    [SerializeField] private FinishAction _finishAction;

    private bool _canScale = false;
    Vector3 newPosition;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out FinishTrigger FinishTrigger))
        {
            if (TryGetComponent(out Rigidbody rigidbody))
                rigidbody.isKinematic = true;

            _finishAction.Win();

            Invoke(nameof(StopMove), 1f);
        }
    }

    private void StopMove()
    {
        _playerMover.StopMove();

        _ropeScaler.Scale(100f);
    }

    private IEnumerator ScaleTimer()
    {
        _canScale = true;

        yield return new WaitForSeconds(1f);

        _canScale = false;
    }
}
