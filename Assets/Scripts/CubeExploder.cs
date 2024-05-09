using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _raduis;
    [SerializeField] private float _force;

    private List<Rigidbody> _explosionObjects = new List<Rigidbody>();

    public List<Rigidbody> AddExplosionObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _raduis);


        foreach (Collider hit in hits)
        {
            Rigidbody rigidbody = hit.attachedRigidbody;

            if (rigidbody)
                _explosionObjects.Add(rigidbody);
        }

        return _explosionObjects;
    }

    public void Explode()
    {
        foreach (Rigidbody explosionObject in AddExplosionObject())
        {
            float distance = Vector3.Distance(transform.position, explosionObject.position);

            if (distance > 0 && transform.localScale.x > 0)
            {
                float explosionForce = _force / (distance * transform.localScale.x);

                explosionObject.AddExplosionForce(explosionForce, transform.position, _raduis);
            }
        }
    }
}
