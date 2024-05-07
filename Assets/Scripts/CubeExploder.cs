using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _raduis;
    [SerializeField] private float _force;

    private List<Rigidbody> _explosionObjects = new List<Rigidbody>();

    public void AddExplosionObject(Rigidbody rigidbody) => _explosionObjects.Add(rigidbody);

    public void Explode()
    {
        foreach (Rigidbody explosionObject in _explosionObjects)
        {
            explosionObject.AddExplosionForce(_force, transform.position, _raduis);
        }
    }
}
