using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterFinishTrigger : MonoBehaviour
{
    [SerializeField] private List<FinishBlocksPool> _finishBlocksPools;
    public void DownCube()
    {
        foreach (var item in _finishBlocksPools)
        {
            item.Activate();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover player))
        {
            DownCube();
        }
    }
}
