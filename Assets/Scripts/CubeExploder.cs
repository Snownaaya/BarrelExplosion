using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _raduis;
    [SerializeField] private float _force;

    [SerializeField] private Rigidbody _rigidbody;

    public void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _raduis);

        foreach (Collider hit in hits)
        {
            _rigidbody = hit.attachedRigidbody;

            if (_rigidbody)
                _rigidbody.AddExplosionForce(_force, transform.position, _raduis);
        }
    }
}
