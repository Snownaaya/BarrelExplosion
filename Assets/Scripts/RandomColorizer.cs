using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColorizer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private void Start() => GetRandomColor();

    private void GetRandomColor() => _renderer.material.color = Random.ColorHSV();
}
