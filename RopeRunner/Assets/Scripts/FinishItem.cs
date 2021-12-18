using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishItem : MonoBehaviour
{
    [SerializeField] private Color _activeColor;
    [SerializeField] private Rigidbody _rigidbody;

    private Renderer _renderer;

    public event UnityAction Activated;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void EnableKinematic()
    {
        _rigidbody.isKinematic = false;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            _renderer.material.color = _activeColor;
            Activated?.Invoke();
            //Invoke(nameof(EnableGravity), 1f);
        }
    }
}
