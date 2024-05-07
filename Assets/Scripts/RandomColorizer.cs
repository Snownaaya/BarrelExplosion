using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColorizer : MonoBehaviour
{
    private Renderer _renderer;

    private void Start() => _renderer = GetComponent<Renderer>();

    public void RandomColor() => _renderer.material.color = Random.ColorHSV();
}
