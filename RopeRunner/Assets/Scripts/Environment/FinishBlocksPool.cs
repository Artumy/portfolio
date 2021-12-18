using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBlocksPool : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _finishBlocks;

    public void Activate()
    {
        foreach (Rigidbody child in _finishBlocks)
        {
            child.isKinematic = false;
        }
    }
}
