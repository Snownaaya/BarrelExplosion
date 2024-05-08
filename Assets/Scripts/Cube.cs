using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _minCubeCount;
    [SerializeField] private int _maxCubeCount;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _currentChance = 100f;

    [SerializeField] private CubeExploder _cubeExploder;

    private float _minPrecent = 0f;
    private float _maxPrecent = 100f;

    private void OnMouseDown()
    {
        if (GetRandomPrecent() <= _currentChance)
        {
            SpawnCubes();
            _cubeExploder.Explode();
        }

        Destroy(gameObject);
    }

    private void SpawnCubes()
    {
        int countCube = Random.Range(_minCubeCount, _maxCubeCount);

        CreateCubes(countCube);
    }

    private void CreateCubes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(this);
            cube.transform.localScale = transform.localScale * _scaleFactor;

            Rigidbody cubeRigibody = cube.GetComponent<Rigidbody>();
            _cubeExploder.AddExplosionObject(cubeRigibody);
        }
    }

    private float GetRandomPrecent() => Random.Range(_minPrecent, _maxPrecent);
}