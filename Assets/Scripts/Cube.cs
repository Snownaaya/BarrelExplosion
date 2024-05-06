using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private const float SplitChanceDivisor = 2.0f;

    [SerializeField] private int _minCubeCount;
    [SerializeField] private int _maxCubeCount;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _currentChance = 100f;

    [SerializeField] private RandomColorizer _randomColorizer;
    [SerializeField] private CubeExploder _cubeExploder;

    private float _minPrecent = 0f;
    private float _maxPrecent = 100f;

    private void OnMouseDown()
    {
        if (RandomPrecent() <= _currentChance)
        {
            SpawnCubes();
            _currentChance /= SplitChanceDivisor;
            _cubeExploder.Explode();
        }

        Destroy(gameObject);
    }

    private void SpawnCubes()
    {
        int countCube = Random.Range(_minCubeCount, _maxCubeCount);

        _randomColorizer.RandomColor();
        CreateCubes(countCube);
    }

    private void CreateCubes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(this);
            cube.transform.localScale = transform.localScale * _scaleFactor;
        }
    }

    private float RandomPrecent() => Random.Range(_minPrecent, _maxPrecent);
}