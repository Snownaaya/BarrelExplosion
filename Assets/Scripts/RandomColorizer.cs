using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColorizer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private void Start() => RandomColor();

    private void RandomColor() => _renderer.material.color = Random.ColorHSV();
}
