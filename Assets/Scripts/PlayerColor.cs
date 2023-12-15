using System;
using System.Linq;
using UnityEngine;

/// <summary>
/// Класс игрока, содержащий информацию о цвете игрока.
/// </summary>
public class PlayerColor : MonoBehaviour
{
    public Color Color { get; private set; }
    [SerializeField]
    private Renderer _renderer;
    private Material _material;

    private void Awake()
    {
        // Сохраняем colored материал
        var materials = _renderer.materials;
        _material = materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));
    }

    public void SetColor(Color color)
    {
        _material.color = color;
        Color = color;
    }
}