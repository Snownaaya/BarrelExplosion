using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _raduis;
    [SerializeField] private float _force;

    private List<Rigidbody> _explosionObject = new List<Rigidbody>();

    public void Explode()
    {
        foreach (Rigidbody explosionObject in _explosionObject)
        {
            explosionObject.AddExplosionForce(_force, transform.position, _raduis);
        }
    }
}
