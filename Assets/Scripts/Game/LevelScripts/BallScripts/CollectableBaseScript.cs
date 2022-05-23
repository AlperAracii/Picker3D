using DG.Tweening;
using UnityEngine;

public class CollectableBaseScript : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Push()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.DOMoveZ(transform.position.z + 8f, 1f);
    }
}
