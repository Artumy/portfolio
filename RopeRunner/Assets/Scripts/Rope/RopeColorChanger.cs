using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeColorChanger : MonoBehaviour
{
    [SerializeField] private List<Material> _ropeMaterials;

    public void ChangeColorTo(Color color)
    {
        foreach (var material in _ropeMaterials)
        {
            material.color = color;
        }
    }
}
